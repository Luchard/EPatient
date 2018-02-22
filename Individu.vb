Public Class Individu
    Private _nom As String
    Private _prenom As String
    Private _nomPere As String
    Private _nomMere As String

    Private _dateNaissance As DateTime
    Private _lieuNaissance As String
    Private _identification As Long
    Private _groupeSanguin As String
    Private _isMedecin As Boolean
    Private _villeNaissance As String
    Private _idSexe As Long

    Public Property Nom As String
        Get
            Return _nom
        End Get
        Set(value As String)
            _nom = value
        End Set
    End Property

    Public Property Prenom As String
        Get
            Return _prenom
        End Get
        Set(value As String)
            _prenom = value
        End Set
    End Property

    Public Property NomPere As String
        Get
            Return _nomPere
        End Get
        Set(value As String)
            _nomPere = value
        End Set
    End Property

    Public Property NomMere As String
        Get
            Return _nomMere
        End Get
        Set(value As String)
            _nomMere = value
        End Set
    End Property

    Public Property DateNaissance As Date
        Get
            Return _dateNaissance
        End Get
        Set(value As Date)
            _dateNaissance = value
        End Set
    End Property

    Public Property LieuNaissance As String
        Get
            Return _lieuNaissance
        End Get
        Set(value As String)
            _lieuNaissance = value
        End Set
    End Property

    Public Property Identification As Long
        Get
            Return _identification
        End Get
        Set(value As Long)
            _identification = value
        End Set
    End Property

    Public Property GroupeSanguin As String
        Get
            Return _groupeSanguin
        End Get
        Set(value As String)
            _groupeSanguin = value
        End Set
    End Property

    Public Property IsMedecin As Boolean
        Get
            Return _isMedecin
        End Get
        Set(value As Boolean)
            _isMedecin = value
        End Set
    End Property

    Public Property VilleNaissance As String
        Get
            Return _villeNaissance
        End Get
        Set(value As String)
            _villeNaissance = value
        End Set
    End Property

    Public Property IdSexe As Long
        Get
            Return _idSexe
        End Get
        Set(value As Long)
            _idSexe = value
        End Set
    End Property

    Public Shared Function ListerIndividu() As IList
        Dim allIndividu As IList
        Using db As New EPatient_dbEntities
            allIndividu = db.sp_ListeIndividu.ToList
        End Using

        Return allIndividu
    End Function

    Public Shared Function ListerMedecin() As IList
        Dim allIndividu As IList
        Using db As New EPatient_dbEntities
            allIndividu = db.sp_ListeIndividu.Where(Function(s) s.isMedecin = True).ToList

        End Using

        Return allIndividu
    End Function

    Public Shared Function ListerPatient() As IList
        Dim allIndividu As IList
        Using db As New EPatient_dbEntities
            allIndividu = db.sp_ListeIndividu.Where(Function(s) s.isMedecin = 0).ToList

        End Using

        Return allIndividu
    End Function
End Class
