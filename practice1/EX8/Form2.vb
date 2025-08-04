Public Class Form2
    ' 由 Form2 內部設定、對外唯讀
    Private _userInput As String = String.Empty
    Public ReadOnly Property UserInput As String
        Get
            Return _userInput
        End Get
    End Property

    ' 通知主表單「已提交」或「取消」
    Public Event Submitted()
    Public Event Canceled()

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ' 簡單驗證（可依需求加強）
        If String.IsNullOrWhiteSpace(txtInput.Text) Then
            MessageBox.Show("請輸入文字")
            txtInput.Focus()
            Exit Sub
        End If

        _userInput = txtInput.Text
        RaiseEvent Submitted()   '  僅通知，不關閉、不設 DialogResult
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        RaiseEvent Canceled()    '  僅通知，不關閉
    End Sub
End Class
