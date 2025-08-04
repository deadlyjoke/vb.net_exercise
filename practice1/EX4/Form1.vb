Public Class Form1
    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        txtOutput.Clear()

        For n As Integer = 1 To 1000
            If isPrime(n) Then
                txtOutput.AppendText(n.ToString() & Environment.NewLine)
            End If
        Next

        txtOutput.AppendText("完成")
    End Sub

    '判斷是否為質數的函式
    Private Function isPrime(n As Integer) As Boolean
        If n < 2 Then Return False
        For i As Integer = 2 To Math.Sqrt(n)
            If n Mod i = 0 Then Return False
        Next
        Return True
    End Function
End Class
