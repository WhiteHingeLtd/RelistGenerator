Imports WHLClasses
Imports System.IO
Imports System.Windows.Threading
Imports System.Xaml

Public Class Relist

    ''' <summary>
    ''' Global query data storage
    ''' </summary>
    Dim querydata As New List(Of Dictionary(Of String, Object))
    Dim ReadOnly FolderSelection As New FolderBrowserDialog()

    ''' <summary>
    ''' On Loading, we want to ensure we can gather info from the server, and check the V drive exists
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RelistMain_Load(sender As Object, e As EventArgs) Handles MyBase.Loaded
        'Check Server is receiving requests.
        If My.Computer.Network.Ping("sql") Then
            'Good, we're working. Load the default folder from settings.
            FolderLocTxt.Text = My.Settings.DefaultFolderLoc
            'Now set the CSV Automatic Name
            CSVNameTXT.Text = "relist-" + Today.ToString("yyMMdd")
            'Check folder
            If Not My.Computer.FileSystem.DirectoryExists(FolderLocTxt.Text) Then
                'Well, we need a folder to save in.
                StatusLabel.Text = "The folder being referenced doesn't exist or can't be reached. Please choose another folder."
            End If
        Else
            'We can't get info. That basically means that something is up with the server as a whole.
            MsgBox("Failed to connect to the MySQL server. Please contact technical support.")
            'May as well just not open at all. They can reopen it when they can connect to the server.
            Me.Close()
        End If
    End Sub

    ''' <summary>
    ''' SQL stuff - This is where we get our info for the table.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CollectBTN_Click(sender As Object, e As EventArgs) 
        'Before we give them any messages, ensure we're using a neutral font style.
        StatusLabel.Foreground = System.Windows.Media.Brushes.Black
        'Check filename is valid
        If CSVNameTXT.Text.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0 Then
            'We have invalid characters
            StatusLabel.Text = "There are invalid characters in the file name. Please remove them before continuing."
        ElseIf Not My.Computer.FileSystem.DirectoryExists(FolderLocTXT.Text) Then
            'Folder doesn't exist
            StatusLabel.Text = "The folder being referenced doesn't exist or can't be reached. Please choose another folder."
        ElseIf CSVNameTXT.Text.Trim = "" Then
            'No name is here
            StatusLabel.Text = "Please enter a file name."
        ElseIf My.Computer.FileSystem.FileExists(FolderLocTXT.Text + CSVNameTXT.Text + ".csv") Then
            'File exists already.
            StatusLabel.Text = "That file exists already. Please choose another name or rename / remove the old file."
        Else
            'Ok, go!
            'Visual Effect; This will take a while, a signal is nice.
            StatusLabel.Text = "Please wait."
            StatusLabel.Foreground = System.Windows.Media.Brushes.Maroon

            'Query
            Dim QueryText As String = "SELECT
    a.shortsku,
    d.ShelfName as 'Location',
    a.labelshort,
    CONCAT('\'',b.SupplierCode) as 'SupplierCode',
    CAST(c.stock AS SIGNED) as 'Level',
    CAST(c.stockminimum AS SIGNED) as 'Min',
    (c.stock + c.stockminimum) as 'Total',
    '' as 'Check'
FROM whldata.whlnew as a
LEFT JOIN whldata.sku_supplierdata as b on a.shortsku=b.SKU
LEFT JOIN whldata.inventory as c on a.sku=c.sku
LEFT JOIN
		(SELECT
			qa.shortsku,
			qa.Shelfname,
            qa.LocationID,
            qb.LocType,
            qb.LocID
		FROM whldata.shortsku_locations as qa
        LEFT JOIN whldata.locationreference as qb on qa.LocationID=qb.LocID
        WHERE
        qb.LocType=1 Group by qa.shortsku)
	as d on a.shortsku=d.shortsku
WHERE
(CAST(c.stock AS SIGNED) < CAST(c.stockminimum AS SIGNED)) AND (CAST(c.stockminimum AS SIGNED) >= 3) AND (b.isPrimary = 'True') AND NOT (a.packsize > c.stockminimum);"

            'Get Info
            querydata.Clear()
            Try
                'If this works, and gets info, we're golden. Otherwise... well, we need to tell them.
                querydata = MySQL.SelectDataDictionary(QueryText)
            Catch ex As Exception
                'I wanna know about it.
                Reporting.ErrorReporting.ReportException(ex, False, False)
                StatusLabel.Text = "Data retrieval failed. The error has been reported to the developer."
                'We cant do anything without data. Exit sub.
                Exit Sub
            End Try

            If Not querydata.Count > 0 Then
                'They need to know they got nothing rather than just... sitting around waiting for the table to fill when it isnt going to.
                StatusLabel.Text = "No relist data was received. See technical support."
                'Note however that it is possible to reach this if we have nothing with a stock count below its minimum. That's a good thing.
                'We cant do anything without data. Exit sub.
                Exit Sub
            Else
                'Begin saving
                CSVSavingSetup()
            End If

            'Visual effect; rather than continuing to say Please Wait...
            StatusLabel.Text = "Saved."
            'Disable the red font.
            StatusLabel.Foreground = System.Windows.Media.Brushes.Black
        End If
    End Sub

    ''' <summary>
    ''' Once data is present, we can export it to a CSV file.
    ''' </summary>
    Private Sub CSVSavingSetup()
        'The file name is usually in the format of 'relist-yyMMdd'.
        Dim FileName As String = FolderLocTXT.Text + CSVNameTXT.Text + ".csv"

        'Now we do the saving thing! This requires a worker to do the stuff for us, but we exit the loop now.
        OperationDialog("Generating CSV", AddressOf CSVExport, FileName, True)
    End Sub

    ''' <summary>
    ''' This code is Lee's CSV export code in Inventory Control, only modified slightly. It works.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CSVExport(sender As System.ComponentModel.BackgroundWorker, e As System.ComponentModel.DoWorkEventArgs)
        'Setup
        Dim rawcsv As String = ""

        'Report to user
        sender.ReportProgress(0, "Preparing CSV")
        'Get our column names, seperate by comma
        rawcsv += String.Join(",", querydata(0).Keys)
        'Primary save - We continue adding to this later
        My.Computer.FileSystem.WriteAllText(e.Argument, rawcsv, False)
        'Report to user
        sender.ReportProgress(0, "Generating CSV")

        'More setup
        Dim DispPercentage As Integer = 0
        rawcsv = ""

        'Get every row of data
        For Each row As Dictionary(Of String, Object) In querydata
            'Display completion percentage
            DispPercentage += 1
            sender.ReportProgress((DispPercentage / querydata.Count) * 100)
            'CSV moves down a line.
            rawcsv += vbNewLine

            'Whenever we reach this threshold, we save and clear the cache.
            'One would think reaching this limit wouldn't happen often.
            'On 20/09/17, it triggered 3 times on a single run. Some of those item titles are huge.
            If rawcsv.Length > 10240 Then
                'Escaping the symbols
                rawcsv = rawcsv.Replace("\", "\\").Replace("""", """""").Replace("," + vbNewLine, vbNewLine).Replace("§", """")
                'Mid-progress saving; Append
                My.Computer.FileSystem.WriteAllText(e.Argument, rawcsv, True)
                'Clear text
                rawcsv = ""
            End If

            'For everything in the dictionary
            For Each value In row.Values
                'Formatting exists, but it has a problem - human error. If the text we're saving contains certain symbols, we need to prevent formatting issues.
                If value.ToString.Contains(",") Or value.ToString.Contains("""") Or value.ToString.Contains(vbNewLine) Or value.ToString.StartsWith(" ") Or value.ToString.EndsWith(" ") Then
                    rawcsv += "§" + value.ToString.Replace(vbNewLine, "") + "§,"
                Else
                    rawcsv += value.ToString.Replace(vbNewLine, "") + ","
                End If
            Next
        Next

        'Escaping the symbols
        rawcsv = rawcsv.Replace("\", "\\").Replace("""", """""").Replace("," + vbNewLine, vbNewLine).Replace("§", """")
        'Report completion
        sender.ReportProgress(100, "Saving file")
        'Final save; Append
        My.Computer.FileSystem.WriteAllText(e.Argument, rawcsv, True)

        'Load the file
        Process.Start(e.Argument)
    End Sub

    ''' <summary>
    ''' We want easy default folder selection
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FolderLocTXT_Click(sender As Object, e As EventArgs) Handles FolderLocTxt.MouseDown
        'Show the dialog, only act if they click the OK button
        If FolderSelection.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            'Change text to reflect changes
            FolderLocTXT.Text = FolderSelection.SelectedPath
            'Errorproofing - it needs that slash at the end, or it'll save as Documentsrelist-yyMMdd in the folder above or something.
            If Not FolderLocTXT.Text.EndsWith("\") Then
                FolderLocTXT.Text = FolderLocTXT.Text + "\"
            End If
            'Then save that to the settings.
            My.Settings.DefaultFolderLoc = FolderLocTXT.Text
            My.Settings.Save()
        End If
    End Sub

    Private Sub FolderLocTxt_MouseLeftButtonDown(sender As Object, e As System.Windows.Input.MouseButtonEventArgs) Handles FolderLocTxt.MouseLeftButtonDown
        FolderLocTXT_Click(sender,e)
    End Sub

    Private Sub FolderLocTxt_GotFocus(sender As Object, e As System.Windows.RoutedEventArgs) Handles FolderLocTxt.GotFocus
        FolderLocTXT_Click(sender,e)
    End Sub

    Private Sub CollectBtn_Click_1(sender As Object, e As System.Windows.RoutedEventArgs) Handles CollectBtn.Click
        CollectBTN_Click(sender,e)
    End Sub

    Private Sub Window_Closed(sender As Object, e As EventArgs)
        System.Windows.Forms.Application.Exit()
    End Sub

    Dim disp As Dispatcher

    Private Sub FindNegativeStockButton_Click(sender As Object, e As System.Windows.RoutedEventArgs) Handles FindNegativeStockButton.Click
        'Disable some controls
        CollectBtn.IsEnabled = False
        FindNegativeStockButton.IsEnabled = False
        'Grab the dispatcher
        disp = Me.dispatcher
        'Make the hread to execure the bois
        Dim thred = New Threading.Thread(addressof FindNegBackThred)
        'gogogo
        thred.Start()
    End Sub

    Dim Saver As New SaveFileDialog()
    Dim Applicables as List(Of WhlSKU)

    Private sub FindNegBackThred()
        'Load skus
        disp.Invoke(Sub()
            StockFinderProgresssBar.Value=0
                        StockFinderProgresssBar.IsIndeterminate = True
                        StockFinderProgressText.Text = "Loading Item Data..."
                        StockFinderPercentage.Text = "0%"

                    End Sub)
        Dim skus = (New GenericDataController).SmartSkuCollLoad()
        disp.Invoke(Sub()
                        StockFinderProgresssBar.IsIndeterminate = True
                        StockFinderProgressText.Text = "Mixing Skus..."
                    End Sub)
        dim mixer = skus.MakeMixdown
        'Start findind items
        disp.Invoke(Sub()
            StockFinderProgresssBar.IsIndeterminate = False
            StockFinderProgresssBar.Maximum = mixer.Count
            StockFinderProgressText.Text = "Checking Items... {}"
        End Sub)
        Applicables = New List(Of WhlSKU)
        Dim counter = 0
        for each item in mixer
            counter += 1
            Threading.Thread.Sleep(1)
            If (counter Mod 10) = 0 then
                disp.BeginInvoke(Sub(Item2 As Whlsku, Counter2 As integer)
                    StockFinderProgresssBar.Value = Counter2
                    StockFinderPercentage.Text = $"{Math.Round((counter2/mixer.Count)*100)}%"
                    StockFinderProgressText.Text = $"Checking {Item2.ShortSku} {Item2.Title.Label}"
                End Sub,{item,counter})
            End If
            Try
                Dim pick = item.GetLocation(SKULocation.SKULocationType.Pickable)
                If Convert.ToInt32(pick.Additional) < 0 Then
                    Applicables.Add(item)
                End If
            Catch ex As Exception

            End Try
        Next
        disp.Invoke(Sub()
            StockFinderProgresssBar.IsIndeterminate = true
            StockFinderProgressText.Text = $"Preparing to save CSV ({Applicables.Count} items)..."
            Saver.DefaultExt = ".csv"
            Saver.Filter = "Comma seperated values document (*.csv)|*.csv"
            Saver.FileName=$"NegativeStock-{Now.ToString("yyyy MMM d")}"
            Saver.InitialDirectory = My.Settings.DefaultFolderLoc
            if Saver.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                            'Start another new thread because the main one is kill.
                StockFinderProgressText.Text = $"Preparing to save CSV ({Applicables.Count} items) at ""{Saver.FileName}""..."
                Dim Thred = New Threading.Thread(addressof FindNegBackThredPart2)
                'gogogo
                Thred.Start(Saver.FileName)
            End If
        End Sub)
    End Sub
    Private sub FindNegBackThredPart2(Filename As string)
        Dim CsvData as string="""Shortsku"", Location,""Label"",""Supplier Code"",""Stock"""
        Dim counter = 0
        for each item in Applicables
            counter += 1
            Threading.Thread.Sleep(1)
            If (counter Mod 10) = 0 then
                disp.BeginInvoke(Sub(Item2 As Whlsku, Counter2 As integer)
                    StockFinderProgresssBar.Value = Counter2
                    StockFinderPercentage.Text = $"{Math.Round((counter2/Applicables.Count)*100)}%"
                    StockFinderProgressText.Text = $"Preparing to save CSV ({Item2.ShortSku} {Item2.Title.Label})"
                End Sub,{item,counter})
            End If
            Try
                Dim pick = item.GetLocation(SKULocation.SKULocationType.Pickable)
                
                Dim line = $"""{item.ShortSku}"", {pick.LocationText},""{item.Title.Label.Replace("""","``")}"",""{item.GetPrimarySupplier.ReOrderCode}"",""{pick.Additional}"""
                CSVData += vbNewLine + line
            Catch ex As Exception

            End Try
        Next
        'Finished preparing the data to save, now save it
        disp.BeginInvoke(Sub()
            StockFinderProgresssBar.Value = StockFinderProgresssBar.Maximum
            StockFinderProgresssBar.IsIndeterminate=True
            StockFinderPercentage.Text = $"{100}%"
            StockFinderProgressText.Text = $"Writing CSV..."
        End Sub)
        'Save the data.
        My.Computer.FileSystem.WriteAllText(filename, CsvData, false)
        disp.BeginInvoke(Sub()
            StockFinderProgresssBar.Value = 0
            StockFinderProgresssBar.IsIndeterminate = false
            StockFinderPercentage.Text = $"{100}%"
            StockFinderProgressText.Text = $"Task Complete."
            'Open the CSV
            Process.Start(filename)
        End Sub)
    End sub

End Class
