Public Class Form1
    Dim currentExpression As String = ""

    Private Sub AppendToExpression(value As String)
        currentExpression &= value
        txtDisplay.Text = currentExpression
    End Sub

    ' 數字與小數點按鈕共用
    Private Sub Digit_Click(sender As Object, e As EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click,
        btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btnDot.Click

        Dim btn As Button = CType(sender, Button)
        AppendToExpression(btn.Text)
    End Sub

    ' 運算子按鈕共用
    Private Sub Operator_Click(sender As Object, e As EventArgs) Handles btnAdd.Click, btnSub.Click, btnMul.Click, btnDiv.Click
        Dim btn As Button = CType(sender, Button)
        AppendToExpression(" " & btn.Text & " ")
    End Sub

    ' 清除全部
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        currentExpression = ""
        txtDisplay.Text = ""
    End Sub

    ' 刪除一個字
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If currentExpression.Length > 0 Then
            currentExpression = currentExpression.Substring(0, currentExpression.Length - 1)
            txtDisplay.Text = currentExpression
        End If
    End Sub

    ' 計算等號
    Private Sub btnEqual_Click(sender As Object, e As EventArgs) Handles btnEqual.Click
        Try
            ' 把符號轉為可運算
            Dim expr As String = currentExpression.Replace("×", "*").Replace("÷", "/").Replace("＋", "+").Replace("−", "-")
            Dim result = New DataTable().Compute(expr, Nothing)
            txtDisplay.Text = result.ToString()
            currentExpression = result.ToString() ' 可接著計算
        Catch ex As Exception
            txtDisplay.Text = "錯誤"
            currentExpression = ""
        End Try
    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnClear.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnBack.Click

    End Sub
End Class
