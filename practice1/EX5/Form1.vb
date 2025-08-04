Public Class Form1
    Private Sub BtnCalculate_Click(sender As Object, e As EventArgs) Handles BtnCalculate.Click
        Dim num1 As Integer
        Dim num2 As Integer

        ' 驗證輸入是否為整數
        If Not Integer.TryParse(txtFirst.Text, num1) Then
            MessageBox.Show("請輸入有效的整數。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSecond.Text = String.Empty
            Exit Sub
        End If

        If Not Integer.TryParse(txtSecond.Text, num2) Then
            MessageBox.Show("請輸入有效的整數。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSecond.Text = String.Empty
            Exit Sub
        End If

        '計算最大公約數
        Dim result As Integer = GetGCD(num1, num2)
        txtResult.Text = result.ToString()

    End Sub

    ' 計算最大公約數的函式(輾轉相除法)
    Private Function GetGCD(a As Integer, b As Integer) As Integer
        Do While b <> 0
            Dim temp As Integer = b
            b = a Mod b
            a = temp
        Loop
        Return Math.Abs(a) '回傳正整數
    End Function
End Class
