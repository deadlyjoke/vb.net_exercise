Imports Oracle.ManagedDataAccess.Client
Imports System.IO
Imports System.Globalization

Public Class Form1
    Private Sub btnInsertData_Click(sender As Object, e As EventArgs) Handles btnInsertData.Click
        Dim filePath As String = "chart.txt" ' 檔案請放在執行檔旁邊

        If Not File.Exists(filePath) Then
            MessageBox.Show("找不到檔案")
            Exit Sub
        End If

        Dim lines() As String = File.ReadAllLines(filePath, System.Text.Encoding.UTF8)
        Dim connStr As String = "Data Source=ORACLE_DB_HCC;User ID=MAST;Password=MAST"

        Using conn As New OracleConnection(connStr)
            conn.Open()

            Dim sql As String = "INSERT INTO CHART_yourname (CHART_NO, PT_NAME, SEX, BIRTH_DATE, OCCUPATION, ADDRESS) " &
                                "VALUES (:CHART_NO, :PT_NAME, :SEX, :BIRTH_DATE, :OCCUPATION, :ADDRESS)"

            Using cmd As OracleCommand = conn.CreateCommand()
                For Each line As String In lines
                    If String.IsNullOrWhiteSpace(line) Then Continue For

                    Dim parts() As String = line.Split(","c)
                    If parts.Length < 6 Then Continue For

                    Dim chartNo As String = parts(0).Trim()
                    Dim ptName As String = parts(1).Trim()
                    Dim sex As String = parts(2).Trim()
                    Dim birthDateRaw As String = parts(3).Trim()
                    Dim occupation As String = parts(4).Trim()
                    Dim address As String = parts(5).Trim()

                    ' 將 19230523 → DateTime 格式
                    Dim birthDate As DateTime = DateTime.ParseExact(birthDateRaw, "yyyyMMdd", CultureInfo.InvariantCulture)

                    cmd.CommandText = sql
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New OracleParameter("CHART_NO", chartNo))
                    cmd.Parameters.Add(New OracleParameter("PT_NAME", ptName))
                    cmd.Parameters.Add(New OracleParameter("SEX", sex))
                    cmd.Parameters.Add(New OracleParameter("BIRTH_DATE", birthDate))
                    cmd.Parameters.Add(New OracleParameter("OCCUPATION", occupation))
                    cmd.Parameters.Add(New OracleParameter("ADDRESS", address))

                    cmd.ExecuteNonQuery()
                Next
            End Using
        End Using

        MessageBox.Show("匯入成功！")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
