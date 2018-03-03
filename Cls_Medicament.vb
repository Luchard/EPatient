Imports System.Data.SqlClient

Public Class Cls_Medicament
    Private _code As String
    Private _description As String



    Sub New()
        InitialisePropriete()
    End Sub

    Sub InitialisePropriete()
        _code = ""
        _description = ""

    End Sub

    Sub New(code As String, description As String)
        _code = code
        _description = description


    End Sub


    Public Property Code() As String
        Get
            Return _code
        End Get
        Set(value As String)
            _code = value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return _description

        End Get
        Set(value As String)
            _description = value
        End Set
    End Property

    Public Shared Function AllMedicament() As List(Of Tbl_Medicament)
        Dim allMed As New List(Of Tbl_Medicament)
        Using db As New EPatient_dbEntities
            allMed = db.Tbl_Medicament.ToList

        End Using

        Return allMed
    End Function

    Public Function ListeMedicamentPrescrit(ByVal id_prescription As Long) As List(Of Tbl_Medicament)
        Dim liste As New List(Of Tbl_Medicament)
        Using db As New EPatient_dbEntities

            liste = From s In db.Tbl_MedicamentPrescrit Join
                    c In db.Tbl_Medicament On s.CodeMedicament Equals c.ID_Medicament
                    Where s.CodePrescription = id_prescription
                    Select c


        End Using
        Return liste
    End Function




    Shared Sub AjouterMedicament(ByVal code As String, ByVal decription As String)
        Using db As New EPatient_dbEntities

            Dim Medicament As New Tbl_Medicament
            Medicament.CodeInternational = code
            Medicament.Description = decription
            db.Tbl_Medicament.Add(Medicament)
            db.SaveChanges()


        End Using
    End Sub

    Shared Sub ModifierMedicament(ByVal id_medicament As Long, ByVal code As String, ByVal decription As String)
        Using db As New EPatient_dbEntities

            Dim Medicament As New Tbl_Medicament
            Medicament = db.Tbl_Medicament.Find(id_medicament)
            Medicament.CodeInternational = code
            Medicament.Description = decription

            db.SaveChanges()


        End Using
    End Sub

    Shared Sub SupprimerMedicament(ByVal code As Integer)
        Using db As New EPatient_dbEntities

            Dim Medicament As New Tbl_Medicament
            Medicament = db.Tbl_Medicament.Find(code)
            db.Tbl_Medicament.Remove(Medicament)
            db.SaveChanges()


        End Using
    End Sub



End Class
