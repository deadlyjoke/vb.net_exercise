Public Class Form1
    Private Sub btnOpenForm2_Click(sender As Object, e As EventArgs) Handles btnOpenForm2.Click
        Dim f2 As New Form2()

        '使用事件接收Form2的回傳資料
        AddHandler f2.DataSubmitted, Sub(Value As String)
                                         '在Form1中處理Form2的TextBox1的TextChanged事件
                                         lblDisplay.Text = Value
                                     End Sub

        f2.ShowDialog()
        '使用ShowDialog來顯示Form2為模態視窗
    End Sub
End Class