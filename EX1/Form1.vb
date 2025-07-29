Public Class Form1

    '計算階乘
    Function Factorial(n As Integer) As Long
        Dim result As Long = 1
        For i As Integer = 2 To n
            result *= i
        Next
        Return result
    End Function

    '當按下 "計算階乘按鈕"
    Private Sub btnCalculateFactorial_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Dim num As Integer
        '嘗試將輸入轉換為整數
        If Integer.TryParse(txtInput.Text.Trim(), num) AndAlso num >= 0 Then
            If num <= 20 Then '安全範圍，避免Long溢出
                Dim result As Long = Factorial(num)
                txtResult.Text = result.ToString("N0") ' 顯示千分位格式
            Else
                MessageBox.Show("數字太大可能導致結果溢位，請輸入0到20之間的整數。", "數值過大，錯誤!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ClearInput()
            End If
        Else
            MessageBox.Show("請輸入有效的非負整數(0~20)。", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ClearInput()
        End If
    End Sub



    ' 鍵盤按 Enter 自動觸發計算
    Private Sub txtInput_KeyDown(sender As Object, e As KeyEventArgs) Handles txtInput.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnCalculate.PerformClick()
        End If
    End Sub

    ' 清除輸入與結果
    Private Sub ClearInput()
        txtInput.Clear()
        txtInput.Focus()
        txtResult.Clear()
    End Sub

End Class
