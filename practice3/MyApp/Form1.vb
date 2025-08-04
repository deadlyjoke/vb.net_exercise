' 專案：MyApp（EXE 專案）
' 檔案：Form1.vb
Imports MyLibrary
Public Class Form1
    Private db As New DBHelper()
    Private Sub BtnInsert_Click(sender As Object, e As EventArgs) Handles BtnInsert.Click
        db.InsertDoctor()
        MessageBox.Show("新增成功！")
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        db.UpdateDoctor()
        MessageBox.Show("修改成功！")
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        db.DeleteDoctor()
        MessageBox.Show("刪除成功！")
    End Sub

    Private Sub BtnTxn_Click(sender As Object, e As EventArgs) Handles BtnTxn.Click
        If db.InsertTwoTablesTransaction() Then
            MessageBox.Show("跨表新增成功！")
        Else
            MessageBox.Show("跨表新增失敗！")
        End If
    End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        Dim name As String = db.GetDoctorName("D001")
        MessageBox.Show("醫師姓名：" & name)
    End Sub
End Class



