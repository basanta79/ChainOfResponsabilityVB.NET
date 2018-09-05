Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ChainOfResponsability.Director
Imports ChainOfResponsability

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestMethod1()
        Dim p As Purchase
        p = New Purchase(1234, 350.0, "Test1")
        Dim d As Director
        d = New Director()

        Dim result = d.ProcessRequest(p)

        Assert.AreEqual("Director aproved request #1234", result)

    End Sub

End Class