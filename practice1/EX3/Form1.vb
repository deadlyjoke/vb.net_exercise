Public Class Form1
    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        txtOutput.Clear()

        For a As Integer = 1 To 58
            For b As Integer = 1 To 58
                For c As Integer = 1 To 58
                    Dim sum As Integer = a + b + c
                    If sum >= 20 AndAlso sum < 60 Then
                        txtOutput.AppendText($"({a}, {b}, {c}) → {sum}" & Environment.NewLine)
                    End If
                Next
            Next
        Next

        txtOutput.AppendText("完成！")
    End Sub
End Class

