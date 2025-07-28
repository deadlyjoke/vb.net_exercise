Public Class Form2
    '自訂事件，回傳資料給 Form1
    Public Event DataSubmitted(Value As String)

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        '當按鈕被點擊時，觸發事件並傳遞TextBox1的值
        RaiseEvent DataSubmitted(txtInput.Text)
        Me.DialogResult = DialogResult.OK '設定DialogResult為OK
        Me.Close() '關閉Form2
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel '設定DialogResult為Cancel
        Me.Close() '關閉Form2
    End Sub

End Class