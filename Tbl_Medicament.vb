'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Tbl_Medicament
    Public Property ID_Medicament As Long
    Public Property CodeInternational As String
    Public Property Description As String
    Public Property cout As Nullable(Of Decimal)

    Public Overridable Property Tbl_MedicamentPrescrit As ICollection(Of Tbl_MedicamentPrescrit) = New HashSet(Of Tbl_MedicamentPrescrit)

End Class
