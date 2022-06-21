Imports System.Drawing.Printing
Imports System.Drawing.Printing.PrinterSettings
Imports System.IO
Imports System.Windows.Media
Imports nsoftware.IPWorks

Public Class Form1

    Structure st
        Dim PrinterIndex As Integer
        Dim Status As ls
        Dim Message As String
    End Structure

    Enum ls
        ONLINE = 1
        OFFLINE = 2
        PAUSED = 3
        ERRORSTATE = 4
    End Enum

    Public AppRunning As Boolean = False
    Public currentPrinter As Lpt
    Public PrinterList As New Printers
    Public myPrinters As List(Of Lpt)
    Public myWindowsPrinters As StringCollection
    Public status As New List(Of st)
    Friend WithEvents devs As New List(Of Device)
    Dim monFmt As String = "{0} {1}"
    Dim pd As New PrintDocument
    Dim printFont As Font
    Dim StreamToPrint As StreamReader
    Dim Idlers As New List(Of Integer)
    Dim listeners As New List(Of nsoftware.IPWorks.Ipdaemon)
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Application.DoEvents()
        TabControl1.SelectedTab = TabPage3
        MonitorLog("Suspending polling")
        Timer1.Enabled = False
        MonitorLog("Application starting.")
        PrinterList.Load()
        myPrinters = PrinterList.All
        RefreshList()
        For Each p As Lpt In myPrinters
            MonitorLog("Loading " & p.Name & " LPT device.")
            If p.LptType = 0 Then
                p.LastMaxOffset = GetCurrentOffset(p.Stream)
                MonitorLog(String.Format("SETUP {0}: Setting offset to {1}", p.Stream, p.LastMaxOffset))
                If p.Ignore = False Then
                    MonitorLog("Ignoring offset, setting to 0 on printer " & p.Name)
                    p.LastMaxOffset = 0
                Else
                    MonitorLog("Checking file for existing data.")
                    p.LastMaxOffset = GetCurrentOffset(p.Stream)
                    If p.LastMaxOffset <> 0 Then
                        MonitorLog("Setting offset to " & p.LastMaxOffset)
                    End If
                End If
            Else
                'It must be a telnet
                CreateNewListener(p)
            End If
            Dim myStatus As New st
            myStatus.PrinterIndex = myPrinters.IndexOf(p)
            myStatus.Status = ls.ONLINE
            myStatus.Message = "Idle"
            status.Add(myStatus)
        Next
        MonitorLog("Collecting a list of available Windows printers.")
        destination.Items.Clear()
        myWindowsPrinters = System.Drawing.Printing.PrinterSettings.InstalledPrinters
        For Each p As String In myWindowsPrinters
            MonitorLog("Located printer: " & p)
            destination.Items.Add(p)
            Idlers.Add(0)
        Next
        fontname.Items.Clear()
        For Each f As System.Windows.Media.FontFamily In Fonts.SystemFontFamilies
            MonitorLog("Found font: " & f.Source)
            fontname.Items.Add(f.Source)
        Next


        MonitorLog("Starting allocated printers.")
        MonitorLog("Resume polling.")
        Timer1.Enabled = True
        AppRunning = True
        RefreshStatus()
    End Sub

    Public Sub StatusUpdate(Idx As Integer, sts As ls, Message As String)
        Dim thisStatus As New st
        thisStatus = status(Idx)
        thisStatus.Status = sts
        thisStatus.Message = Message
        status(Idx) = thisStatus
    End Sub

    Public Function LookupStatus(i As Integer)
        Select Case i
            Case 0
                Return "Unknown"
            Case 1
                Return "ONLINE"
            Case 2
                Return "OFFLINE"
            Case 3
                Return "PAUSED"
            Case 4
                Return "ERROR"
            Case Else
                Return "INVALID"
        End Select

    End Function

    Public Sub RefreshStatus()
        ListBox1.Items.Clear()
        For Each s As st In status
            Dim myS As String
            myS = String.Format("[{0:15}]-{1:10}- {2}", myPrinters(s.PrinterIndex).Name, LookupStatus(s.Status), s.Message)
            ListBox1.Items.Add(myS)
        Next

    End Sub

    Public Sub MonitorLog(txt As String)
        Dim thisLog As String
        thisLog = String.Format(monFmt, Now.ToShortDateString & " " & Now.ToShortTimeString, txt)
        monitor.AppendText(thisLog & vbCrLf)
        If AppRunning Then
            monitor.Select(monitor.TextLength, 1)
            monitor.ScrollToCaret()
            monitor.Refresh()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' Create a new entry here.  it's a blank entry they can click on it in the list
        Dim newPrinter As New Lpt
        newPrinter.Name = "New Printer"
        myPrinters = PrinterList.All
        myPrinters.Add(newPrinter)
        RefreshList()
        MonitorLog("Added new undefined printer to printer list.")
    End Sub

    Private Sub RefreshList()
        Dim p As IEnumerable(Of Lpt)
        ListBox2.Items.Clear()
        p = From pr In myPrinters Select pr
        For Each pr In p
            ListBox2.Items.Add(pr.Name)
        Next

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If currentPrinter Is Nothing Then
            Exit Sub
        Else
            currentPrinter.Name = printername.Text
            currentPrinter.LptType = printertype.SelectedIndex
            currentPrinter.Stream = inputstream.Text
            currentPrinter.Ignore = checkignore.Checked
            currentPrinter.Start = checkstart.Checked
            currentPrinter.Destination = destination.Text
            currentPrinter.Landscape = checklandscape.Checked
            currentPrinter.FontName = fontname.Text
            currentPrinter.FontSize = fontsize.Text
            currentPrinter.AutoSize = checkautofont.Checked
            currentPrinter.LPTPageSettings = pd.DefaultPageSettings

        End If
        PrinterList.Save()
        MonitorLog("Saved printer definition to file.")
        currentPrinter = Nothing
        RefreshList()
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        PopulateForm(ListBox2.SelectedIndex)
        printername.Focus()

    End Sub

    Private Sub PopulateForm(idx As Integer)
        If idx = -1 Then
            MonitorLog("Populating with -1/new printer?")
            Dim ThisPrinter As New Lpt
            pd.DefaultPageSettings.PrinterSettings.PrintFileName = "nothing"
            pd.DefaultPageSettings.PrinterSettings.PrintToFile = False
            ThisPrinter.LPTPageSettings = pd.DefaultPageSettings
            currentPrinter = ThisPrinter
        Else
            Dim thisPrinter As Lpt = myPrinters.Item(idx)
            printername.Text = thisPrinter.Name
            printertype.SelectedIndex = thisPrinter.LptType
            inputstream.Text = thisPrinter.Stream
            checkignore.Checked = thisPrinter.Ignore
            checkstart.Checked = thisPrinter.Start
            destination.SelectedIndex = destination.Items.IndexOf(thisPrinter.Destination & "") ' More bullcrap about null not being the same as ""
            checklandscape.Checked = thisPrinter.Landscape
            fontname.SelectedIndex = fontname.Items.IndexOf(thisPrinter.FontName & "")
            fontsize.Text = thisPrinter.FontSize
            checkautofont.Checked = thisPrinter.AutoSize
            pd.DefaultPageSettings.PrinterSettings.PrinterName = destination.Text
            pd.DefaultPageSettings.PrinterSettings.PrintToFile = False
            pd.DefaultPageSettings.PrinterSettings.PrintFileName = "nothing"

            pd.DefaultPageSettings = thisPrinter.LPTPageSettings
            currentPrinter = thisPrinter
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If printertype.SelectedIndex <> 0 Then
            MsgBox("The selected printer type does not support file names." & vbCrLf &
                   "Enter the required telnet port number or select a stream" & vbCrLf &
                   "type printer.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Selection error")
            Exit Sub
        End If
        Dim result As New DialogResult
        result = fileChooser.ShowDialog()
        If result = DialogResult.OK Then
            inputstream.Text = fileChooser.FileName
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        pd.PrinterSettings.PrinterName = destination.Text
        page_Setup.Document = pd
        pd.DefaultPageSettings = currentPrinter.LPTPageSettings
        page_Setup.ShowDialog()
        currentPrinter.LPTPageSettings = page_Setup.PageSettings
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        For Each t As MyIPDaemon In listeners
            t.Shutdown()
            Application.DoEvents()
        Next
        For Each d As Device In devs
            d.Destroy()
        Next
    End Sub

    Private Function GetCurrentOffset(filename As String) As Long
        Dim ff As Integer = FreeFile()
        Dim Instream As StreamReader
        Instream = New StreamReader(New FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        Dim Length As Long = Instream.BaseStream.Length
        Instream.Close()
        Return Length
    End Function

    Private Function CheckStream(filename As String, LastOffset As Long) As Boolean
        Dim ff As Integer = FreeFile()
        Dim Instream As StreamReader
        Instream = New StreamReader(New FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        If Instream.BaseStream.Length > LastOffset Then
            Return True
        Else
            Return False
        End If
        Instream.Close()
    End Function

    Private Function GetNewData(filename As String, ByRef Offset As Long) As String
        Dim Reading As Boolean = True
        Dim printjob As String = ""
        Dim settleOffset As Long = 0
        Dim ff As Integer = FreeFile()
        Dim Instream As StreamReader
        Instream = New StreamReader(New FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        Instream.BaseStream.Seek(Offset, SeekOrigin.Begin)
        Dim thisLine As String
        While Instream.BaseStream.Position < Instream.BaseStream.Length
            thisLine = Instream.ReadLine() & vbCrLf
            If thisLine.Contains(Chr(12)) Then
                Dim newlines As String = ""
                For Each c As Char In thisLine
                    If c = Chr(12) Then
                        newlines = newlines & c & vbCrLf
                    Else
                        newlines = newlines & c
                    End If
                    thisLine = newlines
                Next
            End If

            If thisLine <> "" Then
                printjob = printjob + thisLine

            Else
                printjob = printjob + vbCrLf
            End If
            Offset = Instream.BaseStream.Position
        End While
        Instream.Close()
        Return printjob
    End Function

    Private Sub PollData()
        Timer1.Enabled = False
        'MonitorLog("Polling file stream printers.")
        For Each p As Lpt In myPrinters
            If p.LptType = 0 Then
                If p.Stream & "" = "" Then Exit For ' still being configured
                Dim newOffset = GetCurrentOffset(p.Stream)
                'MonitorLog(String.Format("New Offset {0}, old offset {1}", newOffset, p.LastMaxOffset))
                If newOffset > p.LastMaxOffset Then
                    MonitorLog(String.Format("Data waiting on {0}, {1} bytes pending.", p.Name, newOffset - p.LastMaxOffset))
                    StatusUpdate(myPrinters.IndexOf(p), ls.ONLINE, "Settling stream")
                    Dim myIndex As Integer = myPrinters.IndexOf(p)
                    Idlers(myIndex) += 1
                    MonitorLog(String.Format("Waiting for stream to settle on printer {0} ({1} of 3)", myIndex, Idlers(myIndex)))
                    If Idlers(myIndex) >= 3 Then
                        StatusUpdate(myPrinters.IndexOf(p), ls.ONLINE, "Spooling job")
                        Dim thisData As String = GetNewData(p.Stream, p.LastMaxOffset)
                        MonitorLog(String.Format("Printing {0} bytes on device {1}", thisData.Length, p.Name))
                        StatusUpdate(myPrinters.IndexOf(p), ls.ONLINE, "Sending job to printer")
                        PrintJob(thisData, p)
                        StatusUpdate(myPrinters.IndexOf(p), ls.ONLINE, "Idle")
                        MonitorLog("Setting new offset for " & p.Stream)
                        p.LastMaxOffset = GetCurrentOffset(p.Stream)
                        Idlers(myIndex) = 0
                    End If
                End If
            End If
        Next

        Timer1.Enabled = True

    End Sub

    Private Sub PrintJob(inputText As String, prt As Lpt)
        Dim ff As Integer = FreeFile()
        Dim myFile As String = Guid.NewGuid.ToString & ".txt"
        Dim outf As New StreamWriter(myFile)
        outf.AutoFlush = True
        MonitorLog("Dumping print job to " & myFile)
        outf.Write(inputText)
        outf.Flush()
        outf.Close()
        SendToPrinter(myFile, prt)
    End Sub

    Private Sub SendToPrinter(inputFile As String, prt As Lpt)
        Dim pd As New PrintDocument
        Dim pc As New Printing.StandardPrintController
        pd.PrintController = pc
        StreamToPrint = New StreamReader(inputFile)

        pd.PrinterSettings.PrinterName = prt.Destination
        pd.DefaultPageSettings.Landscape = True
        pd.PrinterSettings.PrintFileName = "Output\" & prt.Name & "-" & inputFile & ".pdf"
        If prt.Destination.Contains("PDF") Then
            pd.DefaultPageSettings.PrinterSettings.PrintToFile = True
            MonitorLog("Output stored as " & pd.PrinterSettings.PrintFileName)
        Else
            pd.DefaultPageSettings.PrinterSettings.PrintToFile = False
        End If
        Dim PageHeight = pd.DefaultPageSettings.Bounds.Height
        Dim PageWidth = pd.DefaultPageSettings.Bounds.Width
        printFont = New Font(prt.FontName, prt.FontSize)
        Dim linesPerPage As Single = PageHeight / printFont.GetHeight
        Dim lines66 As Single = (printFont.GetHeight) * 66
        Dim whitespace As Single = (PageHeight - lines66) / 2
        pd.DefaultPageSettings.Margins.Top = whitespace
        pd.DefaultPageSettings.Margins.Left = whitespace
        pd.DefaultPageSettings.Margins.Bottom = 25
        pd.DefaultPageSettings.Margins.Right = 25
        AddHandler pd.PrintPage, AddressOf Me.pd_PrintPage

        pd.Print()
        StreamToPrint.Close()
        File.Move(inputFile, inputFile & ".printed")
    End Sub

    Private Sub pd_PrintPage(ByVal Sender As Object, ByVal ev As PrintPageEventArgs)

        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim count As Integer = 0
        Dim leftmargin As Single = ev.MarginBounds.Left
        Dim topmargin As Single = ev.MarginBounds.Top
        Dim line As String = Nothing


        linesPerPage = ev.MarginBounds.Height / printFont.GetHeight

        If linesPerPage > 66 Then

            linesPerPage = 66
        End If

        While count < linesPerPage
            line = StreamToPrint.ReadLine()
            If (line Is Nothing) Then
                Exit While
            End If
            If line.StartsWith(Chr(12)) Then
                'MonitorLog("FORM FEED!")
                Exit While
            End If
            yPos = topmargin + count * printFont.GetHeight(ev.Graphics)
            ev.Graphics.DrawString(line, printFont, System.Drawing.Brushes.Black, leftmargin, yPos, New StringFormat())
            count += 1
        End While

        If (line IsNot Nothing) Then
            ev.HasMorePages = True
        Else
            ev.HasMorePages = False
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        PollData()
        RefreshStatus()
        Timer1.Enabled = True
    End Sub

    Private Sub CreateNewListener(p As Lpt)
        Dim l As New MyIPDaemon
        l.SSLStartMode = IpdaemonSSLStartModes.sslNone
        l.LocalPort = p.Stream
        l.KeepAlive = True
        l.DefaultSingleLineMode = False
        AddHandler l.OnConnected, AddressOf ipDaemon_Connected
        AddHandler l.OnDataIn, AddressOf ipDaemon_DataIn
        l.Listening = True
        l.Index = p
        listeners.Add(l)
        MonitorLog("printer " & p.Name & " listening on port " & p.Stream)

    End Sub

    Private Sub ipDaemon_Connected(source As MyIPDaemon, e As IpdaemonConnectedEventArgs)
        Debug.WriteLine(String.Format("Connection on {0} from {1}", source.Index.Name, e.StatusCode))

    End Sub

    Private Sub ipDaemon_DataIn(source As MyIPDaemon, e As IpdaemonDataInEventArgs)
        Debug.Write(e.Text)
    End Sub

End Class
