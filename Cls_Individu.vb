Public Class Cls_Individu
    Private _id As Long
    Private _nom As String
    Private _prenom As String
    Private _nomPere As String
    Private _nomMere As String

    Private _dateNaissance As Date
    Private _lieuNaissance As String
    Private _identification As Long
    Private _groupeSanguin As String
    Private _isMedecin As Boolean
    Private _villeNaissance As String
    Private _idSexe As Long


    Sub New(ByVal id_individu As Long)

    End Sub

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

    Public Property Id As Long
        Get
            Return _id
        End Get
        Set(value As Long)
            _id = value
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

    Shared Function AjouterIndividu(ByVal identification As String, ByVal isMedecin As Boolean, ByVal nom As String, ByVal prenom As String, ByVal groupeSanguin As String, ByVal dateNaissance As String, ByVal idSexe As Long, ByVal addresse As String) As Long
        Dim id_individu As Long = 0
        Using db As New EPatient_dbEntities

            Dim Individu As New Tbl_Individu
            Individu.isMedecin = isMedecin
            Individu.Nom = nom
            Individu.Prenom = prenom
            Individu.GroupeSanguin = groupeSanguin
            Individu.DateNaissance = dateNaissance
            Individu.ID_Sexe = idSexe
            Individu.Identification = identification
            Individu.addresse = addresse
            db.Tbl_Individu.Add(Individu)
            db.SaveChanges()
            id_individu = Individu.ID_Individu

        End Using
        Return id_individu
    End Function



    Shared Sub ModifierIndividu(ByVal CodeINdividu As Long, ByVal identification As String, ByVal isMedecin As Boolean, ByVal nom As String, ByVal prenom As String, ByVal groupeSanguin As String, ByVal dateNaissance As String, ByVal idSexe As Long, ByVal addresse As String)

        Using db As New EPatient_dbEntities
            Dim Individu As Tbl_Individu = db.Tbl_Individu.Find(CodeINdividu)

            Individu = db.Tbl_Individu.Find(CodeINdividu)
            Individu.isMedecin = isMedecin
            Individu.Nom = nom
            Individu.Prenom = prenom
            Individu.GroupeSanguin = groupeSanguin
            Individu.DateNaissance = dateNaissance
            Individu.ID_Sexe = idSexe
            Individu.Identification = identification
            Individu.addresse = addresse

            db.SaveChanges()


        End Using

    End Sub


    Shared Function Read(ByVal code As Long) As Cls_Individu

        Dim individu As Cls_Individu = Nothing

        Using entities As New EPatient_dbEntities
            Dim user = (From func In entities.Tbl_Individu.Where(Function(s) s.ID_Individu = code)
                        Select func).FirstOrDefault


            individu._id = user.ID_Individu

            individu._nom = user.Nom
            individu._prenom = user.Prenom
            individu._idSexe = user.ID_Sexe
            individu._identification = user.Identification

        End Using


        Return individu
    End Function
End Class
