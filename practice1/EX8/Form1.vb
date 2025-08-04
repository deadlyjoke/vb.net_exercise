Public Class Form1
    Private f2 As Form2 = Nothing

    Private Sub btnOpenForm2_Click(sender As Object, e As EventArgs) Handles btnOpenForm2.Click
        ' 避免重複開啟
        If f2 IsNot Nothing AndAlso Not f2.IsDisposed Then
            f2.Activate()
            Return
        End If

        f2 = New Form2()
        AddHandler f2.Submitted, AddressOf OnForm2Submitted
        AddHandler f2.Canceled, AddressOf OnForm2Canceled

        f2.StartPosition = FormStartPosition.CenterParent
        f2.Show(Me)               ' 非模態，由 Form1 掌控生命週期
    End Sub

    Private Sub OnForm2Submitted()
        If f2 Is Nothing OrElse f2.IsDisposed Then Return
        lblDisplay.Text = f2.UserInput   ' 只讀屬性，不碰控制項
        CloseForm2()
    End Sub

    Private Sub OnForm2Canceled()
        CloseForm2()
    End Sub

    Private Sub CloseForm2()
        If f2 Is Nothing Then Return
        RemoveHandler f2.Submitted, AddressOf OnForm2Submitted
        RemoveHandler f2.Canceled, AddressOf OnForm2Canceled
        f2.Close()              '  由主表單關閉
        f2 = Nothing
    End Sub
End Class
