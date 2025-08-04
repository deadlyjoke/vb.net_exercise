' 專案：MyLibrary（DLL 專案）
' 檔案：Class1.vb

Imports Oracle.ManagedDataAccess.Client

Public Class DBHelper
    Private connStr As String = "Data Source = ORACLE_DB_ZTH; User ID = MAST; Password = MAST"

    ' 1. 新增一筆資料
    Public Sub InsertDoctor()
        Dim sql As String = "INSERT INTO DOCTOR (DOCTOR_NO, DOCTOR_NAME) VALUES ('D001', '王小明')"
        ExecuteNonQuery(sql)
    End Sub

    ' 2. 刪除一筆資料
    Public Sub DeleteDoctor()
        Dim sql As String = "DELETE FROM DOCTOR WHERE DOCTOR_NO = 'D001'"
        ExecuteNonQuery(sql)
    End Sub

    ' 3. 修改一筆資料
    Public Sub UpdateDoctor()
        Dim sql As String = "UPDATE DOCTOR SET DOCTOR_NAME = '林大偉' WHERE DOCTOR_NO = 'D001'"
        ExecuteNonQuery(sql)
    End Sub

    ' 4. 同時新增兩表資料 + COMMIT
    Public Function InsertTwoTablesTransaction() As Boolean
        Using conn As New OracleConnection(connStr)
            conn.Open()
            Dim tx = conn.BeginTransaction()
            Try
                Dim cmd As OracleCommand = conn.CreateCommand()
                cmd.Transaction = tx

                cmd.CommandText = "INSERT INTO DOCTOR (DOCTOR_NO, DOCTOR_NAME) VALUES ('D002', '李小華')"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "INSERT INTO DIV (DIV_NO, DIV_NAME) VALUES ('D99', '測試科')"
                cmd.ExecuteNonQuery()

                tx.Commit()
                Return True
            Catch ex As Exception
                tx.Rollback()
                Return False
            End Try
        End Using
    End Function

    ' 5. 用 DbReader 抓指定欄位值
    Public Function GetDoctorName(doctorNo As String) As String
        Dim sql As String = "SELECT DOCTOR_NAME FROM DOCTOR WHERE DOCTOR_NO = '" & doctorNo & "'"
        Using conn As New OracleConnection(connStr)
            conn.Open()
            Using cmd As New OracleCommand(sql, conn)
                Using reader As OracleDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Return reader("DOCTOR_NAME").ToString()
                    Else
                        Return "查無資料"
                    End If
                End Using
            End Using
        End Using
    End Function

    ' 共用執行指令
    Private Sub ExecuteNonQuery(sql As String)
        Using conn As New OracleConnection(connStr)
            conn.Open()
            Using cmd As New OracleCommand(sql, conn)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
End Class


