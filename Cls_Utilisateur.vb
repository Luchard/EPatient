Imports System.Data.SqlClient
Imports EPatient

Public Class Cls_Utilisateur

    Private _idUtilisateur As Long
    Private _individu As Cls_Individu
    Private _idIndividu As Long
    Private _idPrivilege As Long
    Private _idStatutCompte As Long
    Private _username As String
    Private _privilege As Cls_Privilege


    Sub New()

    End Sub

    Public Sub New(ByVal _idUtilisateur As Long)
        Read(_idUtilisateur)
    End Sub



    Public Property Individu() As Cls_Individu
        Get
            If Not (_individu Is Nothing) Then
                If (_individu.Id = 0) Or (_individu.Id <> _idIndividu) Then
                    _individu = New Cls_Individu(_idIndividu)
                End If
            Else
                _individu = New Cls_Individu(_idIndividu)
            End If
            Return _individu

        End Get
        Set(ByVal Value As Cls_Individu)
            If Value Is Nothing Then

                _idIndividu = 0
            Else
                If Me.Individu.Id <> Value.Id Then

                    _idIndividu = Value.Id
                End If
            End If
        End Set
    End Property

    Public Property Privilege As Cls_Privilege
        Get
            Return _privilege
        End Get
        Set(value As Cls_Privilege)
            _privilege = value
        End Set
    End Property

    Public Property Username As String
        Get
            Return _username
        End Get
        Set(value As String)
            _username = value
        End Set
    End Property

    Public Property Idutilisateur As Long
        Get
            Return _idutilisateur
        End Get
        Set(value As Long)
            _idutilisateur = value
        End Set
    End Property

    Public Property IdPrivilege As Long
        Get
            Return _idPrivilege
        End Get
        Set(value As Long)
            _idPrivilege = value
        End Set
    End Property

    Public Property IdStatutCompte As Long
        Get
            Return _idStatutCompte
        End Get
        Set(value As Long)
            _idStatutCompte = value
        End Set
    End Property

    Shared Function IndiviByUsername(ByVal username_1 As String) As Tbl_Utilisateur
        Dim user As New Tbl_Utilisateur
        Using entities As New EPatient_dbEntities
            user = (From func In entities.Tbl_Utilisateur.Where(Function(s) s.username = username_1)
                    Select func).FirstOrDefault
        End Using

        Return user
    End Function

    Shared Function IndiviById(ByVal code As Long) As Tbl_Individu
        Dim user As New Tbl_Individu
        Using entities As New EPatient_dbEntities
            user = (From func In entities.Tbl_Individu.Where(Function(s) s.ID_Individu = code)
                    Select func).FirstOrDefault
        End Using

        Return user
    End Function

    Shared Function Read(ByVal code As Long) As Cls_Utilisateur

        Dim utilisateur As Cls_Utilisateur = Nothing

        Using entities As New EPatient_dbEntities
            Dim user = (From func In entities.Tbl_Utilisateur.Where(Function(s) s.ID_Utilisateur = code)
                        Select func).FirstOrDefault


            utilisateur._idIndividu = user.ID_Individu
            utilisateur._idutilisateur = user.ID_Utilisateur
            utilisateur._username = user.username
            utilisateur._idPrivilege = user.ID_Privilege
            utilisateur._idStatutCompte = user.ID_StatutCompte
        End Using


        Return utilisateur
    End Function


    Shared Function AllUtilisateur() As IList

        Dim user As IList
        Using entities As New EPatient_dbEntities
            user = entities.sp_liste_utilisateurs.ToList

        End Using

        Return user
    End Function

End Class
