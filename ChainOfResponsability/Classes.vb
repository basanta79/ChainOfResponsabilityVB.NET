Option Explicit On

Public MustInherit Class Approver
    Protected successor As Approver

    Public Sub SetSuccessor(successor As Approver)
        Me.successor = successor
    End Sub

    Public Overridable Function ProcessRequest(Purchase As Purchase) As String
        Return ""
    End Function

End Class

Public Class Purchase
    Private _number As Integer
    Private _amount As Double
    Private _purpose As String

    Public Sub New(number As Integer, amount As Double, purpose As String)
        Me.Amount = amount
        Me.Number = number
        Me.Purpose = purpose
    End Sub

    Public Property Purpose As String
        Get
            Return _purpose
        End Get
        Set(value As String)
            _purpose = value
        End Set
    End Property

    Public Property Amount As Double
        Get
            Return _amount
        End Get
        Set(value As Double)
            _amount = value
        End Set
    End Property

    Public Property Number As Integer
        Get
            Return _number
        End Get
        Set(value As Integer)
            _number = value
        End Set
    End Property
End Class

Public Class Director
    Inherits Approver

    Public Overrides Function ProcessRequest(purchase As Purchase) As String
        Dim sResult = ""
        If (purchase.Amount < 1000) Then
            Console.WriteLine("{0} aproved request #{1}", Me.GetType.Name, purchase.Number)
            sResult = String.Format("{0} aproved request #{1}", Me.GetType.Name, purchase.Number)
        ElseIf successor IsNot Nothing Then
            sResult = successor.ProcessRequest(purchase)
        End If
        Return sResult
    End Function

End Class

Public Class VicePresident
    Inherits Approver

    Public Overrides Function ProcessRequest(purchase As Purchase) As String
        Dim sResult = ""
        If (purchase.Amount < 25000) Then
            Console.WriteLine("{0} aproved request #{1}", Me.GetType().Name, purchase.Number)
            sResult = String.Format("{0} aproved request #{1}", Me.GetType().Name, purchase.Number)
        ElseIf successor IsNot Nothing Then
            sResult = successor.ProcessRequest(purchase)
        End If
        Return sResult
    End Function
End Class

Public Class President
    Inherits Approver

    Public Overrides Function ProcessRequest(purchase As Purchase) As String
        Dim sResult = ""
        If (purchase.Amount < 100000) Then
            Console.WriteLine("{0} aproved request #{1}", Me.GetType().Name, purchase.Number)
            sResult = String.Format("{0} aproved request #{1}", Me.GetType().Name, purchase.Number)
        Else
            Console.WriteLine("Request #{0}, needs a executive meeting!!", purchase.Number)
            sResult = String.Format("{0} aproved request #{1}", Me.GetType().Name, purchase.Number)
        End If
        Return sResult
    End Function
End Class


