Imports EPatient

Public Class Cls_Specialisation
    Private _code As String
    Private _descriptionSpecialisation As String
    Private _medecin As Cls_Individu
    Private _codeMedecin As Long

    Public Property Code As String
        Get
            Return _code
        End Get
        Set(value As String)
            _code = value
        End Set
    End Property

    Public Property DescriptionSpecialisation As String
        Get
            Return _descriptionSpecialisation
        End Get
        Set(value As String)
            _descriptionSpecialisation = value
        End Set
    End Property

    Public Property Medecin As Cls_Individu
        Get
            Return _medecin
        End Get
        Set(value As Cls_Individu)
            _medecin = value
        End Set
    End Property

    Public Property CodeMedecin As Long
        Get
            Return _codeMedecin
        End Get
        Set(value As Long)
            _codeMedecin = value
        End Set
    End Property

    Sub New()
        InitialisePropriete()
    End Sub

    Sub InitialisePropriete()
        Code = ""
        CodeMedecin = 0
        DescriptionSpecialisation = ""
    End Sub

    Sub New(_desciption As String)
        _descriptionSpecialisation = _desciption

    End Sub


    Public Shared Function ListeSpecialisation() As List(Of Tbl_Specialisation)
        Dim allSpecialisation As New List(Of Tbl_Specialisation)
        Using db As New EPatient_dbEntities
            allSpecialisation = db.Tbl_Specialisation.ToList
        End Using

        Return allSpecialisation
    End Function

    Public Shared Function ListeSpecialisationParMedecin(ByVal id_medecin As Long) As IList

        Dim liste As New List(Of Tbl_Specialisation)


        Dim allIndividu As IList
        Using db As New EPatient_dbEntities
            allIndividu = db.sp_specialisation.Where(Function(s) s.CodeIndividu = id_medecin).ToList
        End Using

        Return allIndividu




    End Function


    Public Shared Sub AjouterSpecialisationMedecin(_codeMedecin As Long, _codeSpecialisation As Long)
        Using db As New EPatient_dbEntities
            Dim specialisationMedecin As New Tbl_SpecialisationMedecin
            specialisationMedecin.CodeIndividu = _codeMedecin
            specialisationMedecin.CodeSpecialisation = _codeSpecialisation
            db.Tbl_SpecialisationMedecin.Add(specialisationMedecin)
            db.SaveChanges()

        End Using
    End Sub

    Public Shared Sub AjouterSpecialisation(_codeSpecialisation As String, _description As String)
        Using db As New EPatient_dbEntities
            Dim specialisation As New Tbl_Specialisation
            specialisation.codeSpecialisation = _codeSpecialisation
            specialisation.Description = _description
            db.Tbl_Specialisation.Add(specialisation)
            db.SaveChanges()

        End Using
    End Sub

    Public Shared Sub ModifierSpecialisation(_code As Long, _codeSpecialisation As String, _description As String)
        Using db As New EPatient_dbEntities
            Dim specialisation As New Tbl_Specialisation
            specialisation = db.Tbl_Specialisation.Find(_code)
            specialisation.codeSpecialisation = _codeSpecialisation
            specialisation.Description = _description
            db.SaveChanges()

        End Using
    End Sub


    Public Shared Sub SupprimerSpecialisationMedecin(ByVal code As Long)
        Dim allSpecialisation As New List(Of Tbl_SpecialisationMedecin)
        Using db As New EPatient_dbEntities
            allSpecialisation = db.Tbl_SpecialisationMedecin.Where(Function(s) s.CodeIndividu = code).ToList


            For Each specialisation As Tbl_SpecialisationMedecin In allSpecialisation
                db.Tbl_SpecialisationMedecin.Remove(specialisation)
                db.SaveChanges()
            Next
        End Using
    End Sub


    Public Shared Function ListeSpecialisationMedecin(ByVal code As Long) As List(Of Tbl_SpecialisationMedecin)
        Dim allSpecialisation As New List(Of Tbl_SpecialisationMedecin)
        Using db As New EPatient_dbEntities
            allSpecialisation = db.Tbl_SpecialisationMedecin.Where(Function(s) s.CodeIndividu = code).ToList
        End Using
        Return allSpecialisation
    End Function

End Class
