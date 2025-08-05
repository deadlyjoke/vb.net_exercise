Imports Oracle.ManagedDataAccess.Client
Imports System.IO

Public Class Form1
    Private connStr As String = "Data Source = ORACLE_DB_HCC; User ID = MAST; Password = MAST"

    'button1: to drop a table 
    Private Sub btnDrop_Click(sender As Object, e As EventArgs) Handles btnDrop.Click
        Using conn As New OracleConnection(connStr)
            conn.Open()
            Using cmd As New OracleCommand("Drop Table CHART_ANDY PURGE", conn)
                Try
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Table tropped.")
                Catch ex As Exception
                    MessageBox.Show($"Error dropping table: {ex.Message}")
                Finally
                    conn.Close()
                End Try
            End Using
        End Using
    End Sub

    'button2: to Create a table 
    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Dim sql As String = "CREATE TABLE CHART_Massi (CHART_NO NUMBER PRIMARY KEY, PT_NAME VARCHAR2(100))"
        Using conn As New OracleConnection(connStr)
            conn.Open()
            Using cmd As New OracleCommand(sql, conn)
                Try
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Table created.")
                Catch ex As Exception
                    MessageBox.Show("Create table failed: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub
End Class

'button3: to Insert 200000 rows, commit each
Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
    Using conn As New OracleConnection(connStr)
        conn.Open()
        Dim sql As String = "INSERT INTO CHART_Massi (CHART_NO, PT_NAME) VALUES (:chart_no, :pt_name)"
        Using cmd As New OracleCommand(sql, conn)
            cmd.Parameters.Add("chart_no", OracleDbType.Int32)
            cmd.Parameters.Add("pt_name", OracleDbType.Varchar2)
            For i As Integer = 1 To 200000
                cmd.Parameters("chart_no").Value = i
                cmd.Parameters("pt_name").Value = "Patient " & i
                Try
                    cmd.ExecuteNonQuery()
                    conn.Commit() ' Commit each insert
                Catch ex As Exception
                    MessageBox.Show($"Error inserting row {i}: {ex.Message}")
                End Try
            Next
            MessageBox.Show("200000 rows inserted.")
        End Using
    End Using
End Sub
End Class

