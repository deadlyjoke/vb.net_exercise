Imports System.Data.OracleClient
Imports System.Diagnostics
Imports System.IO

Public Class Form1
    Private ConnStr As String = "Data Source=ORACLE_DB_HCC;User ID=MAST;Password=MAST"

    ' 按鈕1：Drop CHART_Massi
    Private Sub btnDrop_Click(sender As Object, e As EventArgs) Handles btnDrop.Click
        Try
            Using Conn As New OracleConnection(ConnStr)
                Conn.Open()
                Using Cmd As OracleCommand = Conn.CreateCommand()
                    Cmd.CommandText = "DROP TABLE CHART_Massi PURGE"
                    Cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("成功：CHART_Massi 已刪除")
        Catch ex As Exception
            MessageBox.Show("失敗: " & ex.Message)
        End Try
    End Sub

    ' 按鈕2：CREATE TABLE CHART_Massi ADD PRIMARY KEY
    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Try
            Using Conn As New OracleConnection(ConnStr)
                Conn.Open()
                Using Cmd As OracleCommand = Conn.CreateCommand()
                    Cmd.CommandText = "CREATE TABLE CHART_Massi (CHART_NO NUMBER PRIMARY KEY, PT_NAME VARCHAR2(100))"
                    Cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("成功：CHART_Massi 已建立")
        Catch ex As Exception
            MessageBox.Show("失敗: " & ex.Message)
        End Try
    End Sub

    ' 按鈕3：Generate data 200000 筆, commit each
    Private Sub btnGenEach_Click(sender As Object, e As EventArgs) Handles btnGenEach.Click
        Dim Rand As New Random()
        Try
            Using Conn As New OracleConnection(ConnStr)
                Conn.Open()
                For i = 1 To 200000
                    Using Trans = Conn.BeginTransaction()
                        Using Cmd As OracleCommand = Conn.CreateCommand()
                            Cmd.Transaction = Trans
                            Cmd.CommandText = $"INSERT INTO CHART_Massi (CHART_NO, PT_NAME) VALUES ({i}, 'CHART_{i}_{Rand.Next(1000, 9999)}')"
                            Cmd.ExecuteNonQuery()
                        End Using
                        Trans.Commit()
                    End Using
                    If i Mod 1000 = 0 OrElse i = 1 OrElse i = 200000 Then
                        lblStatus.Text = $"寫入進度：{i} / 200000"
                        lblStatus.Refresh()
                    End If
                Next
            End Using
            MessageBox.Show("成功：已逐筆插入 200000 筆")
        Catch ex As Exception
            MessageBox.Show("失敗: " & ex.Message)
        End Try
    End Sub

    ' 按鈕4：Insert Commit Once
    Private Sub btnGenOnce_Click(sender As Object, e As EventArgs) Handles btnGenOnce.Click
        Dim Rand As New Random()
        Try
            Using Conn As New OracleConnection(ConnStr)
                Conn.Open()
                Using Trans = Conn.BeginTransaction()
                    For i = 1 To 200000
                        Using Cmd As OracleCommand = Conn.CreateCommand()
                            Cmd.Transaction = Trans
                            Cmd.CommandText = $"INSERT INTO CHART_ANDY (CHART_NO, PT_NAME) VALUES ({i}, 'CHART_{i}_{Rand.Next(1000, 9999)}')"
                            Cmd.ExecuteNonQuery()
                        End Using
                    Next
                    Trans.Commit()
                End Using
            End Using
            MessageBox.Show("成功：已一次交易插入 200000 筆")
        Catch ex As Exception
            MessageBox.Show("失敗: " & ex.Message)
        End Try
    End Sub

    ' 按鈕5：查詢 CHART_NO
    Private Sub btnQuery1_Click(sender As Object, e As EventArgs) Handles btnQuery1.Click
        If txtInput.Text.Trim() = "" Then
            MessageBox.Show("請輸入 CHART_NO")
            Exit Sub
        End If
        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()
                Using cmd As OracleCommand = conn.CreateCommand()
                    cmd.CommandText = $"SELECT * FROM CHART_Massi WHERE CHART_NO = {txtInput.Text.Trim()}"
                    Using reader = cmd.ExecuteReader()
                        Dim result As String = ""
                        While reader.Read()
                            result &= $"{reader("CHART_NO")}, {reader("PT_NAME")}{Environment.NewLine}"
                        End While
                        MessageBox.Show(result)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("查詢失敗: " & ex.Message)
        End Try
    End Sub

    ' 按鈕6：查詢 PT_NAME LIKE
    Private Sub btnQuery2_Click(sender As Object, e As EventArgs) Handles btnQuery2.Click
        If txtInput.Text.Trim() = "" Then
            MessageBox.Show("請輸入 PT_NAME 關鍵字")
            Exit Sub
        End If
        Dim keyword = txtInput.Text.Trim().Replace("'", "''")
        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()
                Using cmd As OracleCommand = conn.CreateCommand()
                    cmd.CommandText = $"SELECT * FROM CHART_Massi WHERE PT_NAME LIKE 'CHART_{keyword}_%'"
                    Using reader = cmd.ExecuteReader()
                        Dim result As String = ""
                        While reader.Read()
                            result &= $"{reader("CHART_NO")}, {reader("PT_NAME")}{Environment.NewLine}"
                        End While
                        MessageBox.Show(result)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("查詢失敗: " & ex.Message)
        End Try
    End Sub


    ' 按鈕7：查詢排序 CHART_NO
    Private Sub btnQuery3_Click(sender As Object, e As EventArgs) Handles btnQuery3.Click
        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()
                Using cmd As OracleCommand = conn.CreateCommand()
                    cmd.CommandText = "SELECT * FROM CHART_Massi ORDER BY CHART_NO"
                    Using reader = cmd.ExecuteReader()
                        Dim result As String = ""
                        While reader.Read()
                            result &= $"{reader("CHART_NO")}, {reader("PT_NAME")}{Environment.NewLine}"
                        End While
                        MessageBox.Show(result)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("查詢失敗: " & ex.Message)
        End Try
    End Sub

    ' 按鈕8：查詢排序 PT_NAME
    Private Sub btnQuery4_Click(sender As Object, e As EventArgs) Handles btnQuery4.Click
        Try
            Using conn As New OracleConnection(connStr)
                conn.Open()
                Using cmd As OracleCommand = conn.CreateCommand()
                    cmd.CommandText = "SELECT * FROM CHART_Massi ORDER BY PT_NAME"
                    Using reader = cmd.ExecuteReader()
                        Dim result As String = ""
                        While reader.Read()
                            result &= $"{reader("CHART_NO")}, {reader("PT_NAME")}{Environment.NewLine}"
                        End While
                        MessageBox.Show(result)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("查詢失敗: " & ex.Message)
        End Try
    End Sub

    ' 按鈕9：Update Once Commit
    Private Sub btnUpdateOnce_Click(sender As Object, e As EventArgs) Handles btnUpdateOnce.Click
        Dim Rand As New Random()
        Try
            Using Conn As New OracleConnection(ConnStr)
                Conn.Open()
                Using Trans = Conn.BeginTransaction()
                    Using CmdSelect As New OracleCommand("SELECT CHART_NO FROM CHART_Massi", Conn)
                        CmdSelect.Transaction = Trans
                        Using Reader = CmdSelect.ExecuteReader()
                            While Reader.Read()
                                Dim ChartNo As Integer = Reader.GetInt32(0)
                                Dim NewName As String = $"CHART_{chartNo}_{Rand.Next(1000, 9999)}"
                                Dim Sql As String = $"UPDATE CHART_Massi SET PT_NAME = '{NewName}' WHERE CHART_NO = {chartNo}"
                                Using CmdUpdate As OracleCommand = Conn.CreateCommand()
                                    CmdUpdate.Transaction = Trans
                                    CmdUpdate.CommandText = Sql
                                    CmdUpdate.ExecuteNonQuery()
                                End Using
                            End While
                        End Using
                    End Using
                    Trans.Commit()
                End Using
            End Using
            MessageBox.Show("成功：邊讀邊更新完成交易")
        Catch ex As Exception
            MessageBox.Show("失敗: " & ex.Message)
        End Try
    End Sub


    ' 按鈕10：Update Each Commit
    Private Sub btnUpdateEach_Click(sender As Object, e As EventArgs) Handles btnUpdateEach.Click
        Dim Rand As New Random()
        Try
            Using Conn As New OracleConnection(ConnStr)
                Conn.Open()
                Dim Count As Integer = 0
                Dim Total As Integer = 0

                ' 先計算總筆數（顯示進度用）
                Using CmdCount As New OracleCommand("SELECT COUNT(*) FROM CHART_Massi", Conn)
                    Total = Convert.ToInt32(CmdCount.ExecuteScalar())
                End Using

                ' 邊讀邊更新，每筆開啟一個 transaction
                Using CmdSelect As New OracleCommand("SELECT CHART_NO FROM CHART_Massi", Conn)
                    Using Reader = CmdSelect.ExecuteReader()
                        While Reader.Read()
                            Dim ChartNo As Integer = Reader.GetInt32(0)
                            Dim NewName As String = $"CHART_{ChartNo}_{Rand.Next(1000, 9999)}"
                            Dim UpdateSql As String = $"UPDATE CHART_Massi SET PT_NAME = '{NewName}' WHERE CHART_NO = {ChartNo}"

                            Using Trans = Conn.BeginTransaction()
                                Using CmdUpdate As OracleCommand = Conn.CreateCommand()
                                    CmdUpdate.Transaction = Trans
                                    CmdUpdate.CommandText = UpdateSql
                                    CmdUpdate.ExecuteNonQuery()
                                End Using
                                Trans.Commit()
                            End Using
                        End While
                    End Using
                End Using
            End Using
            MessageBox.Show("成功：每筆交易各自 Commit 完成更新")
        Catch ex As Exception
            If ex.Message.Contains("OracleTransaction 已經完成") Then
                MessageBox.Show("錯誤：交易已完成，無法重複使用，請檢查是否有重複使用相同的 Transaction 或 Command。")
            Else
                MessageBox.Show("失敗: " & ex.Message)
            End If
        End Try
    End Sub


    '按鈕7跟8做共用的函式
    ' 讀取所有 CHART_NO 的 DataReader（caller 要自己處理 Reader 與 Conn 的關閉）
    Private Function GetChartReader(ByVal DbConn As OracleConnection, ByVal SqlStr As String) As OracleDataReader
        Dim DbCom As OracleClient.OracleCommand
        DbCom = DbConn.CreateCommand
        DbCom.CommandText = SqlStr
        Return DbCom.ExecuteReader()
    End Function

    ' 針對單一 ID 執行更新
    Private Sub UpdateChartName(ByVal DbConn As OracleConnection, ByVal Trans As OracleTransaction, ByVal ChartNo As Integer, ByVal Rand As Random)
        Dim DbCom As OracleClient.OracleCommand
        DbCom = DbConn.CreateCommand
        DbCom.Transaction = Trans
        DbCom.CommandText = "UPDATE CHART_ANDY SET PT_NAME = 'CHART_" & ChartNo & "_" & Rand.Next(1000, 9999) & "' WHERE CHART_NO = " & ChartNo
        DbCom.ExecuteNonQuery()
    End Sub

    '按鈕7
    Private Sub btnUpdateTwoSession_Click(sender As Object, e As EventArgs) Handles btnUpdateTwoSession.Click
        Dim Rand As New Random()
        Try
            Using ConnRead As New OracleConnection(ConnStr), ConnWrite As New OracleConnection(ConnStr)
                ConnRead.Open()
                ConnWrite.Open()

                Dim DbReader As OracleDataReader = GetChartReader(ConnRead, "SELECT CHART_NO FROM CHART_Massi")

                Dim DbTrans As OracleTransaction = ConnWrite.BeginTransaction()
                Do While DbReader.Read()
                    Dim ChartNo As Integer = DbReader.GetInt32(0)
                    UpdateChartName(ConnWrite, DbTrans, ChartNo, Rand)
                Loop
                DbTrans.Commit()
                DbReader.Close()
            End Using
            MessageBox.Show("成功：Button7 兩個 Session 寫入完成")
        Catch Ex As Exception
            If Ex.Message.Contains("OracleTransaction 已經完成") Then
                MessageBox.Show("錯誤：交易已完成，無法重複使用，請檢查是否重複使用相同 Transaction。")
            Else
                MessageBox.Show("失敗: " & Ex.Message)
            End If
        End Try
    End Sub


    '按鈕8
    Private Sub btnUpdateOneSessionEachCommit_Click(sender As Object, e As EventArgs) Handles btnUpdateOneSessionEachCommit.Click
        Dim Rand As New Random()
        Try
            Using ConnRead As New OracleConnection(ConnStr), ConnWrite As New OracleConnection(ConnStr)
                ConnRead.Open()
                ConnWrite.Open()

                Dim DbReader As OracleDataReader = GetChartReader(ConnRead, "SELECT CHART_NO FROM CHART_ANDY")
                Dim Count As Integer = 0

                Do While DbReader.Read()
                    Dim ChartNo As Integer = DbReader.GetInt32(0)

                    Dim DbTrans As OracleTransaction = ConnWrite.BeginTransaction()
                    UpdateChartName(ConnWrite, DbTrans, ChartNo, Rand)
                    DbTrans.Commit()

                Loop
                DbReader.Close()

            End Using
            MessageBox.Show("成功：Button8 單 Session 每筆 Commit 完成")
        Catch Ex As Exception
            If Ex.Message.Contains("OracleTransaction 已經完成") Then
                MessageBox.Show("錯誤：交易已完成，無法重複使用，請檢查是否重複使用相同 Transaction。")
            Else
                MessageBox.Show("失敗: " & Ex.Message)
            End If
        End Try
    End Sub




    '抽出的更新函式
    Private Sub UpdateOneChart(ByVal ChartNo As Integer, ByVal PtName As String)
        Using DbConn As New OracleConnection(ConnStr)
            DbConn.Open()
            Dim DbTrans As OracleTransaction
            DbTrans = DbConn.BeginTransaction()

            Dim DbCom As OracleClient.OracleCommand
            DbCom = DbConn.CreateCommand
            DbCom.Transaction = DbTrans
            DbCom.CommandText = "UPDATE CHART_Massi SET PT_NAME = '" & PtName & "' WHERE CHART_NO = " & ChartNo
            DbCom.ExecuteNonQuery()

            DbTrans.Commit()
        End Using
    End Sub

    '按鈕7 主程式碼
    Private Sub btnUpdateTwoSession_Click(sender As Object, e As EventArgs) Handles btnUpdateTwoSession.Click
        Dim Rand As New Random()
        Try
            Using ConnRead As New OracleConnection(ConnStr)
                ConnRead.Open()

                Dim DbComRead As OracleClient.OracleCommand
                DbComRead = ConnRead.CreateCommand
                DbComRead.CommandText = "SELECT CHART_NO FROM CHART_Massi"

                Dim Reader As OracleDataReader
                Reader = DbComRead.ExecuteReader()

                Do While Reader.Read()
                    Dim ChartNo As Integer = Reader.GetInt32(0)
                    Dim PtName As String = "CHART_" & ChartNo & "_" & Rand.Next(1000, 9999)
                    UpdateOneChart(ChartNo, PtName)  ' 呼叫不帶 Conn/Trans 的版本
                Loop

                Reader.Close()
            End Using

            MessageBox.Show("成功：Button7 每筆開啟 Transaction 並更新完成")
        Catch Ex As Exception
            MessageBox.Show("失敗: " & Ex.Message)
        End Try
    End Sub


    'Function：取得 DataTable
    Private Function GetChartDataTable() As DataTable
        Dim Dt As New DataTable()
        Using DbConn As New OracleConnection(ConnStr)
            DbConn.Open()

            Dim DbCom As OracleClient.OracleCommand
            DbCom = DbConn.CreateCommand
            DbCom.CommandText = "SELECT CHART_NO FROM CHART_Massi"

            Dim Reader As OracleDataReader
            Reader = DbCom.ExecuteReader()
            Dt.Load(Reader)
            Reader.Close()
        End Using
        Return Dt
    End Function
    '按鈕8：一個 Session，每筆 Commit
    Private Sub btnUpdateOneSessionEachCommit_Click(sender As Object, e As EventArgs) Handles btnUpdateOneSessionEachCommit.Click
        Dim Rand As New Random()
        Try
            ' 第一步：取得 DataTable
            Dim Dt As DataTable = GetChartDataTable()

            ' 第二步：逐筆更新
            Dim Count As Integer = 0
            For Each Row As DataRow In Dt.Rows
                Dim ChartNo As Integer = Convert.ToInt32(Row("CHART_NO"))
                Dim PtName As String = "CHART_" & ChartNo & "_" & Rand.Next(1000, 9999)

                UpdateOneChart(ChartNo, PtName)

            Next

            MessageBox.Show("成功：每筆更新皆以單獨 Transaction 執行完成")
        Catch Ex As Exception
            MessageBox.Show("失敗: " & Ex.Message)
        End Try
    End Sub


