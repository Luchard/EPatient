Public Class Cls_Privilege




    Shared Function ListePateintAutorise(ByVal code As Long) As List(Of Tbl_Individu)
        Dim ListePatient As New List(Of Tbl_Individu)
        Using db As New EPatient_dbEntities
            ListePatient = db.Tbl_Individu.Where(Function(s) s.ID_Individu = code).ToList
        End Using
        Return ListePatient
    End Function


End Class
