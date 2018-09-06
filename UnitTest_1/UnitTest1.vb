Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ChainOfResponsability.Director
Imports ChainOfResponsability

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestMethod1()
        Dim p As Purchase
        p = New Purchase(1234, 12590.1, "Test1")
        Dim d As Approver
        Dim vc As Approver
        Dim pr As Approver
        d = New Director()
        vc = New VicePresident()
        pr = New President()

        d.SetSuccessor(vc)
        vc.SetSuccessor(pr)

        Dim result = d.ProcessRequest(p)

        Assert.AreEqual("VicePresident aproved request #1234", result)

    End Sub

End Class