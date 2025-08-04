Imports System.Numerics

Public Class Form1
    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles BtnCheck.Click
        txtResult.Clear()

        Dim inputStr As String = txtA.Text.Trim()
        Dim B As Object
        Dim result As Boolean

        ' 嘗試轉為整數、浮點數、BigInteger
        If Integer.TryParse(inputStr, Nothing) Then
            Dim A As Integer = Convert.ToInt32(inputStr)
            result = CheckThreshold(A, B)
        ElseIf Double.TryParse(inputStr, Nothing) Then
            Dim A As Double = Convert.ToDouble(inputStr)
            result = CheckThreshold(A, B)
        ElseIf BigInteger.TryParse(inputStr, Nothing) Then
            Dim A As BigInteger = BigInteger.Parse(inputStr)
            result = CheckThreshold(A, B)
        Else
            txtResult.Text = " 請輸入有效的數字格式。"
            Return
        End If

        ' 顯示結果,回傳值(boolean)T/F和變數 B 的值
        txtResult.Text = $"{result};" & vbCrLf & $"變數 B 的值: {B}"
    End Sub

    ' 泛型函式：判斷是否大於 10，並回傳 B 的值
    Private Function CheckThreshold(A As Double, ByRef B As Object) As Boolean
        If A > 10 Then
            B = 111
            Return True
        Else
            B = 222
            Return False
        End If
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtResult_TextChanged(sender As Object, e As EventArgs) Handles txtResult.TextChanged

    End Sub
End Class
