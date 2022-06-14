
Imports System.IO
Imports System.Xml.Serialization

Public Class Lpt
    Dim myName As String
    Dim myType As Integer
    Dim myStream As String
    Dim myIgnore As Boolean
    Dim myStart As Boolean
    Dim myWindowsPrinter As String
    Dim myLandscape As Boolean
    Dim myFontName As String
    Dim myFontSize As String
    Dim myAutoSize As Boolean
    Dim myWindowsPage As System.Drawing.Printing.PageSettings
    Dim myWindowsPrinterSettings As System.Drawing.Printing.PrinterSettings
    Dim myStreamOffset As Long = 0
    Public Property Name As String
        Get
            Return myName
        End Get
        Set(value As String)
            myName = value
        End Set
    End Property

    Public Property LptType As Integer
        Get
            Return myType
        End Get
        Set(value As Integer)
            myType = value
        End Set
    End Property

    Public Property Stream As String
        Get
            Return myStream
        End Get
        Set(value As String)
            myStream = value
        End Set
    End Property

    Public Property Ignore As Boolean
        Get
            Return myIgnore
        End Get
        Set(value As Boolean)
            myIgnore = value
        End Set
    End Property

    Public Property Start As Boolean
        Get
            Return myStart
        End Get
        Set(value As Boolean)
            myStart = value
        End Set
    End Property

    Public Property Destination As String
        Get
            Return myWindowsPrinter
        End Get
        Set(value As String)
            myWindowsPrinter = value
        End Set
    End Property

    Public Property Landscape As Boolean
        Get
            Return myLandscape
        End Get
        Set(value As Boolean)
            myLandscape = value
        End Set
    End Property

    Public Property FontName As String
        Get
            Return myFontName
        End Get
        Set(value As String)
            myFontName = value
        End Set
    End Property

    Public Property FontSize As String
        Get
            Return myFontSize
        End Get
        Set(value As String)
            myFontSize = value
        End Set
    End Property

    Public Property AutoSize As Boolean
        Get
            Return myAutoSize
        End Get
        Set(value As Boolean)
            myAutoSize = value
        End Set
    End Property

    Public Property LPTPageSettings As System.Drawing.Printing.PageSettings
        Get
            Return myWindowsPage
        End Get
        Set(value As System.Drawing.Printing.PageSettings)
            myWindowsPage = value
        End Set
    End Property

    Public Property LastMaxOffset As Long
        Get
            Return myStreamOffset
        End Get
        Set(value As Long)
            myStreamOffset = value
        End Set

    End Property


End Class

Public Class Printers
    Dim myPrinters As New List(Of Lpt)

    Property All As List(Of Lpt)
        Get
            Return myPrinters
        End Get
        Set(value As List(Of Lpt))
            myPrinters = value
        End Set
    End Property

    Public Sub Save(Optional toFile As String = "Printers.xml")
        For Each p In myPrinters
            If p.LPTPageSettings.PrinterSettings.PrintFileName = "" Then
                p.LPTPageSettings.PrinterSettings.PrintFileName = "null_device"
            End If
        Next
        Dim f As New StreamWriter(toFile)
        Dim s As New XmlSerializer(GetType(List(Of Lpt)))
        s.Serialize(f, myPrinters)
        f.Close()
    End Sub

    Public Sub Load(Optional fromFile As String = "Printers.xml")
        Dim serializer As New XmlSerializer(GetType(List(Of Lpt)))
        Try
            Dim fs As New FileStream(fromFile, FileMode.Open)
            myPrinters = CType(serializer.Deserialize(fs), List(Of Lpt))
            fs.Close()
        Catch ex As Exception
            Debug.Print(ex.ToString)
        End Try
    End Sub
End Class
