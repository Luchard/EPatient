Public Class Institution

    Private _nom As String
    Private _email As String
    Private _emailResponsable As String
    Private _adresse As String
    Private _nomResponsable As String

    Private _telephone As String
    Private _telephoneResponsable As String
    Private _idTypeInstitution As Long
    Private _idlocalisation As Long

    Public Property Nom As String
        Get
            Return _nom
        End Get
        Set(value As String)
            _nom = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property

    Public Property EmailResponsable As String
        Get
            Return _emailResponsable
        End Get
        Set(value As String)
            _emailResponsable = value
        End Set
    End Property

    Public Property Adresse As String
        Get
            Return _adresse
        End Get
        Set(value As String)
            _adresse = value
        End Set
    End Property

    Public Property NomResponsable As String
        Get
            Return _nomResponsable
        End Get
        Set(value As String)
            _nomResponsable = value
        End Set
    End Property

    Public Property Telephone As String
        Get
            Return _telephone
        End Get
        Set(value As String)
            _telephone = value
        End Set
    End Property

    Public Property TelephoneResponsable As String
        Get
            Return _telephoneResponsable
        End Get
        Set(value As String)
            _telephoneResponsable = value
        End Set
    End Property

    Public Property IdTypeInstitution As Long
        Get
            Return _idTypeInstitution
        End Get
        Set(value As Long)
            _idTypeInstitution = value
        End Set
    End Property

    Public Property Idlocalisation As Long
        Get
            Return _idlocalisation
        End Get
        Set(value As Long)
            _idlocalisation = value
        End Set
    End Property

    Public Shared Function ListerInstitution()
        Dim allInstitution As New List(Of Tbl_Institution)
        Using db As New EPatient_dbEntities
            allInstitution = db.Tbl_Institution.ToList

        End Using

        Return allInstitution
    End Function
End Class
