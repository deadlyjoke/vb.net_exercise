Imports System.Numerics

Public Class Form1
    Private Sub btnCheck_Click(Sender As Object, e As EventArgs) Handles btnCheck.Click
        Dim input As String = txtInput.Text.Trim()
        Dim number As BigInteger

        '清空顯示
        txtResult.Clear()

        '判斷是否為合規整數
        If Not BigInteger.TryParse(input, number) Then
            txtResult.Text = "請輸入有效的整數"
            Return
        End If

        '排除負數小於2的情況
        If number < 2 Then
            txtResult.Text = "請輸入大於等於2的整數"
            Return
        End If

        If IsPrime(number) Then
            txtResult.Text = "是質數"
        Else
            txtResult.Text = "不是質數"
        End If

    End Sub

    '判斷是否為質數
    Private Function IsPrime(n As BigInteger) As Boolean
        If n <= 1 Then Return False
        If n = 2 Then Return True
        If n Mod 2 = 0 Then Return False

        Dim i As BigInteger = 3
        Dim limit As BigInteger = Sqrt(n)

        While i <= limit
            If n Mod i = 0 Then Return False
            i += 2 '只檢查奇數
        End While

        Return True
    End Function

    '牛頓法計算平方根
    Private Function Sqrt(n As BigInteger) As BigInteger
        If n = 0 Then Return 0
        Dim x0 As BigInteger = n >> 1
        Dim x1 As BigInteger = (x0 + n / x0) >> 1

        While x1 < x0
            X0 = x1
            x1 = (x0 + n / x0) >> 1
        End While

        Return x0
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class