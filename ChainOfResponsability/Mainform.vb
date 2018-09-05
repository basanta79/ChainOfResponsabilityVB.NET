Option Explicit On

Public Class Mainform


    Dim Larry As Approver
    Dim Sam As Approver
    Dim Tammy As Approver

    Private Sub Mainform_Load(sender As Object, e As EventArgs) Handles Me.Load
        Larry = New Director
        Sam = New VicePresident
        Tammy = New President

        Larry.SetSuccessor(Sam)
        Sam.SetSuccessor(Tammy)

        Dim p As New Purchase(2034, 350.0, "Assets")
        Larry.ProcessRequest(p)

        p = Nothing
        p = New Purchase(2035, 32590.1, "Project X")
        Larry.ProcessRequest(p)

        p = Nothing
        p = New Purchase(2036, 122100.0, "Project Y")
        Larry.ProcessRequest(p)

    End Sub
End Class
