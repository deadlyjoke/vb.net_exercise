Public Class Form1

    ' 點擊按鈕後找出最大值
    Private Sub btnMax_Click(sender As Object, e As EventArgs) Handles btnMax.Click
        ' 取得輸入字串
        Dim inputText As String = txtInput.Text.Trim()

        ' 用逗號分割成字串陣列，再轉成整數陣列
        Dim numbers() As Integer = Array.ConvertAll(inputText.Split(","c), Function(s) CInt(s.Trim()))

        ' 找最大值
        Dim maxValue As Integer = numbers.Max()

        ' 顯示結果
        txtResult.Text = maxValue.ToString()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
