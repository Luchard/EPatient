Public Class Cls_Prescription


    Private _code As String
    Private _dateAusculte As Date
    Private _descriptionDiagnostique As String
    Private _descriptionSymptome As String
    Private _lieuConsultation As String
    Private _poidsPatient As Double
    Private _taillePatient As Double
    Private _patient As Cls_Individu
    Private _medecin As Cls_Individu
    Private _codePatient As Long
    Private _codeMedecin As Long

    Sub New()
        InitialisePropriete()
    End Sub

    Sub InitialisePropriete()
        _code = ""
        _dateAusculte = Date.Now
        _descriptionDiagnostique = ""
        _descriptionSymptome = ""
        _lieuConsultation = ""
        _poidsPatient = 0.0
        _taillePatient = 0.0

    End Sub

    Sub New(_codePatient As Long, _codeMedecin As Long, descriptionDiagnostique As String, descriptionSymptome As String, lieu As String, taille As Double, poids As Double, datePrescription As DateTime)
        _codePatient = _codePatient
        _codeMedecin = _codeMedecin
        _descriptionDiagnostique = descriptionDiagnostique
        _descriptionSymptome = descriptionSymptome
        _lieuConsultation = lieu
        _poidsPatient = poids
        _taillePatient = taille
        _dateAusculte = datePrescription
    End Sub



    Public Property DescriptionSymptome As String
        Get
            Return _descriptionSymptome
        End Get
        Set(value As String)
            _descriptionSymptome = value
        End Set
    End Property

    Public Property LieuConsultation As String
        Get
            Return _lieuConsultation
        End Get
        Set(value As String)
            _lieuConsultation = value
        End Set
    End Property

    Public Property PoidsPatient As Double
        Get
            Return _poidsPatient
        End Get
        Set(value As Double)
            _poidsPatient = value
        End Set
    End Property

    Public Property TaillePatient As Double
        Get
            Return _taillePatient
        End Get
        Set(value As Double)
            _taillePatient = value
        End Set
    End Property

    Public Property Patient As Cls_Individu
        Get
            Return _patient
        End Get
        Set(value As Cls_Individu)
            _patient = value
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

    Public Property Code As String
        Get
            Return _code
        End Get
        Set(value As String)
            _code = value
        End Set
    End Property

    Public Property DateAusculte As Date
        Get
            Return _dateAusculte
        End Get
        Set(value As Date)
            _dateAusculte = value
        End Set
    End Property

    Public Property CodePatient As Long
        Get
            Return _codePatient
        End Get
        Set(value As Long)
            _codePatient = value
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

    Public Sub SupprimerMedicamentDansPrescription(ByVal codeMedicament As Long, ByVal codePrescription As Long)
        Using db As New EPatient_dbEntities



            Dim MedicamentPrescrit As New Tbl_MedicamentPrescrit
            MedicamentPrescrit = db.Tbl_MedicamentPrescrit.Where(Function(s) s.CodeMedicament = codePrescription And codePrescription = codePrescription)
            db.Tbl_MedicamentPrescrit.Remove(MedicamentPrescrit)
            db.SaveChanges()


        End Using
    End Sub

    Public Shared Function ListePrescription() As List(Of Tbl_Prescription)
        Dim allPrescription As New List(Of Tbl_Prescription)
        Using db As New EPatient_dbEntities
            allPrescription = db.Tbl_Prescription.ToList
        End Using

        Return allPrescription
    End Function

    Public Shared Function ListePrescriptionPatientMedecin(ByVal codeMedecin As Long) As IList
        Dim allPrescription As IList
        Using db As New EPatient_dbEntities
            allPrescription = db.sp_presciption_patient_medecin.Where(Function(s) s.CodeMedecin = codeMedecin).ToList

        End Using

        Return allPrescription
    End Function

    Public Shared Function ListePrescriptionPatientMedecin() As IList
        Dim allPrescription As IList
        Using db As New EPatient_dbEntities
            allPrescription = db.sp_presciption_patient_medecin

        End Using

        Return allPrescription
    End Function

    Public Shared Sub updatePrescription(code As Long, _codePatient As Long, _codeMedecin As Long, descriptionDiagnostique As String, descriptionSymptome As String, lieu As String, taille As Double, poids As Double, datePrescription As DateTime)
        Using db As New EPatient_dbEntities
            Dim prescription As Tbl_Prescription = db.Tbl_Prescription.Find(code)
            prescription.CodeMedecin = _codeMedecin
            prescription.CodePatient = _codePatient
            prescription.DateAusculte = datePrescription
            prescription.DescriptionDiagnostique = descriptionDiagnostique
            prescription.DescriptionSymptome = descriptionSymptome
            prescription.LieuConsultation = lieu
            prescription.TaillePatient = taille
            prescription.PoidsPatient = poids

            db.SaveChanges()

        End Using
    End Sub




    Public Shared Sub AjouterPrescription(_codePatient As Long, _codeMedecin As Long, descriptionDiagnostique As String, descriptionSymptome As String, lieu As String, taille As Double, poids As Double, datePrescription As DateTime)
        Using db As New EPatient_dbEntities
            Dim prescription As New Tbl_Prescription
            prescription.CodeMedecin = _codeMedecin
            prescription.CodePatient = _codePatient
            prescription.DateAusculte = datePrescription
            prescription.DescriptionDiagnostique = descriptionDiagnostique
            prescription.DescriptionSymptome = descriptionSymptome
            prescription.LieuConsultation = lieu
            prescription.TaillePatient = taille
            prescription.PoidsPatient = poids
            db.Tbl_Prescription.Add(prescription)
            db.SaveChanges()

        End Using
    End Sub

    Public Sub AjouterMedicamentAPrescription(ByVal codePrescription As Long, ByVal codeMedicament As Long)
        Using db As New EPatient_dbEntities
            Dim medicamentPrescrit As New Tbl_MedicamentPrescrit
            medicamentPrescrit.CodePrescription = codePrescription
            medicamentPrescrit.CodeMedicament = codePrescription
            db.Tbl_MedicamentPrescrit.Add(medicamentPrescrit)
            db.SaveChanges()

        End Using


    End Sub




    Public Shared Sub SupprimerPrescription(code As Long)
        Using db As New EPatient_dbEntities


            Dim allPrescription As List(Of Tbl_MedicamentPrescrit) = db.Tbl_MedicamentPrescrit.Where(Function(s) s.CodePrescription = code)

            For Each medicament As Tbl_MedicamentPrescrit In allPrescription
                db.Tbl_MedicamentPrescrit.Remove(medicament)
                db.SaveChanges()
            Next
            Dim prescription As Tbl_Prescription = db.Tbl_Prescription.Find(code)
            db.Tbl_Prescription.Remove(prescription)
            db.SaveChanges()

        End Using
    End Sub
End Class
