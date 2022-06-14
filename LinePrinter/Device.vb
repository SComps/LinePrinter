Imports System.Drawing.Printing
Imports System.IO
Imports System.Threading

Public Class Device
    ' This class handles individual printers

    Dim myPrinter As Lpt
    Public myThread As New System.Threading.Thread(AddressOf Printer_Thread)
    Dim lastMaxOffset As Long = 0
    Dim IdleTime As Long = 0
    Dim printerObj As PrintDocument
    Dim printjob As String = ""


    Property LinePrinter As Lpt
        Get
            Return myPrinter
        End Get
        Set(value As Lpt)
            myPrinter = value
        End Set
    End Property

    Public Sub New(printer As Lpt)
        myPrinter = printer
        Form1.MonitorLog(String.Format("PRINTER: {0} allocated.", myPrinter.Name))
    End Sub


    Public Sub Start()
        SendLog("Starting printer " & myPrinter.Name)
        myThread.Start()
    End Sub

    Public Sub Destroy()
        Try
            myThread.Abort()
        Catch ex As Exception
        End Try

        SendLog("Shutting down thread for " & myPrinter.Name)

    End Sub


    Private Sub SendLog(txt As String)
        Form1.MonitorLog(txt)
    End Sub

    Private Sub Printer_Thread()
        SendLog("Opening stream file: " & myPrinter.Stream)
        Dim ff As Integer = FreeFile()
        Dim Instream As StreamReader
        Instream = New StreamReader(New FileStream(myPrinter.Stream, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        SendLog("Thread starting...")
        Debug.Print("Thread starting")
        While (True)
            Dim Reading As Boolean = True
            System.Threading.Thread.Sleep(100)
            Application.DoEvents()
            If myPrinter.Ignore = True Then
                lastMaxOffset = Instream.BaseStream.Length
            End If
            If Instream.BaseStream.Length > lastMaxOffset Then
                Instream.BaseStream.Seek(lastMaxOffset, SeekOrigin.Begin)
                Dim thisLine As String
                While Reading = True
                    thisLine = Instream.ReadLine()
                    If thisLine = Nothing Then
                        Reading = False
                        Exit While
                    End If
                    IdleTime = 0
                    printjob = printjob + thisLine
                    SendLog(String.Format("[{0}] {1}", myPrinter.Name, thisLine))
                    Debug.Print(thisLine)
                    lastMaxOffset = Instream.BaseStream.Position
                End While
            Else
                If printjob <> "" Then
                    IdleTime = IdleTime + 1
                    Debug.Print("Idle " & IdleTime.ToString)
                    If IdleTime > 100 Then
                        IdleTime = 0
                        SendLog("Spooling job on printer " & myPrinter.Name)
                        Debug.Print("Spooling")
                        'Print the job
                        printjob = ""
                    End If
                Else
                    'Debug.Print("Nothing to print.")
                End If
            End If
        End While
    End Sub

End Class
