Public Class MyIPDaemon
    Inherits nsoftware.IPWorks.Ipdaemon

    Dim myIndex As Lpt

    Property Index As Lpt
        Get
            Return myIndex
        End Get
        Set(value As Lpt)
            myIndex = value
        End Set
    End Property
End Class
