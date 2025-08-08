Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar
Imports Microsoft.VisualBasic.Logging
Imports Oracle.ManagedDataAccess.Client

Public Class Form1
    Private connStr As String = "Data Source = ORACLE_DB_HCC; User ID = MAST; Password = MAST"

    ' 顯示並記錄開始與結束時間（含毫秒），可選擇性顯示進度狀態
    Private Sub LogOperation(opName As String, action As Action)
        Dim startTime = DateTime.Now
        Dim sw As Stopwatch = Stopwatch.StartNew()

        txtStartTime.Text = startTime.ToString("yyyy/MM/dd HH:mm:ss.fff")
        txtEndTime.Text = "執行中..."
        lblStatus.Text = $"[{opName}] 執行中..."
        lblStatus.Refresh()

        Try
            action.Invoke()
        Catch ex As Exception
            MessageBox.Show($"錯誤：{ex.Message}")
        End Try

        sw.Stop()
        Dim endTime = DateTime.Now
        txtEndTime.Text = endTime.ToString("yyyy/MM/dd HH:mm:ss.fff")
        lblStatus.Text = $"[{opName}] 已完成 (耗時 {sw.Elapsed.TotalSeconds:F2} 秒)"

        File.AppendAllText("log.txt", $"[{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff}] {opName} 執行完畢，耗時 {sw.Elapsed.TotalSeconds:F3} 秒{Environment.NewLine}")
    End Sub

    'button1: to drop a table 
    Private Sub btnDrop_Click(sender As Object, e As EventArgs) Handles btnDrop.Click
        Using conn As New OracleConnection(connStr)
            conn.Open()
            Using cmd As New OracleCommand("Drop Table CHART_Massi PURGE", conn)
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

    'button3: to Insert 200000 rows, commit each
    Private Sub btnGenEach_Click(sender As Object, e As EventArgs) Handles btnGenEach.Click
        Using conn As New OracleConnection(connStr)
            conn.Open()
            Dim rand As New Random()
            For i = 1 To 200000
                Dim trans = conn.BeginTransaction()
                Using cmd As New OracleCommand("INSERT INTO CHART_Massi (CHART_NO, PT_NAME) VALUES (:no, :name)", conn)
                    cmd.Transaction = trans
                    cmd.Parameters.Add(":no", OracleDbType.Int32).Value = i
                    cmd.Parameters.Add(":name", OracleDbType.Varchar2).Value = $"CHART_{i}_{rand.Next(1000, 9999)}"
                    cmd.ExecuteNonQuery()
                    trans.Commit()
                End Using

                If i Mod 1000 = 0 Or i = 1 Or i = 200000 Then
                    lblStatus.Text = $"{i} / 200000"
                    lblStatus.Refresh()
                End If
            Next
            MessageBox.Show("Inserted 200000 rows, commit each")
        End Using
    End Sub

    'button4: to Insert 200000 rows, commit once
    Private Sub btnGenOnce_Click(sender As Object, e As EventArgs) Handles btnGenOnce.Click
        LogOperation("Insert Once", Sub()
                                        Using conn As New OracleConnection(connStr)
                                            conn.Open()
                                            Dim trans = conn.BeginTransaction()
                                            Dim rand As New Random()

                                            Using cmd As New OracleCommand("INSERT INTO CHART_ANDY (CHART_NO, PT_NAME) VALUES (:no, :name)", conn)
                                                cmd.Transaction = trans
                                                cmd.Parameters.Add(":no", OracleDbType.Int32)
                                                cmd.Parameters.Add(":name", OracleDbType.Varchar2)

                                                For i = 1 To 200000
                                                    cmd.Parameters(":no").Value = i
                                                    cmd.Parameters(":name").Value = $"CHART_{i}_{rand.Next(1000, 9999)}"
                                                    cmd.ExecuteNonQuery()

                                                    If i Mod 1000 = 0 Or i = 1 Or i = 200000 Then
                                                        lblStatus.Text = $"寫入進度：{i} / 200000"
                                                        lblStatus.Refresh()
                                                    End If
                                                Next
                                            End Using

                                            trans.Commit()
                                        End Using
                                    End Sub)
    End Sub

    ' 查詢功能共用
    Private Sub QueryAndDisplay(opName As String, sql As String)
        LogOperation(opName, Sub()
                                 Using conn As New OracleConnection(connStr)
                                     conn.Open()
                                     Using cmd As New OracleCommand(sql, conn)
                                         Using reader = cmd.ExecuteReader()
                                             Dim result As String = ""
                                             While reader.Read()
                                                 result &= $"{reader("CHART_NO")}, {reader("PT_NAME")}" & Environment.NewLine
                                             End While
                                             MessageBox.Show(result.Substring(0, Math.Min(result.Length, 500)), "查詢前幾筆結果")
                                         End Using
                                     End Using
                                 End Using
                             End Sub)
    End Sub

    Private Sub btnQuery1_Click(sender As Object, e As EventArgs) Handles btnQuery1.Click
        If txtInput.Text.Trim() = "" Then
            MessageBox.Show("請輸入 CHART_NO")
            Exit Sub
        End If
        Dim no As String = txtInput.Text.Trim()
        QueryAndDisplay("查詢 CHART_NO", $"SELECT * FROM CHART_Massi WHERE CHART_NO = {no}")
    End Sub

    Private Sub btnQuery2_Click(sender As Object, e As EventArgs) Handles btnQuery2.Click
        If txtInput.Text.Trim() = "" Then
            MessageBox.Show("請輸入 PT_NAME")
            Exit Sub
        End If
        Dim namePart As String = txtInput.Text.Trim().Replace("'", "''")
        QueryAndDisplay("查詢 PT_NAME LIKE", $"SELECT * FROM CHART_Massi WHERE PT_NAME LIKE 'CHART_{namePart}_%'")
    End Sub
    Private Sub btnQuery3_Click(sender As Object, e As EventArgs) Handles btnQuery3.Click
        QueryAndDisplay("查詢排序CHART_NO", "SELECT * FROM CHART_Massi WHERE ORDER BY CHART_NO")
    End Sub
    Private Sub btnQuery4_Click(sender As Object, e As EventArgs) Handles btnQuery4.Click
        QueryAndDisplay("查詢排序PT_NAME", "SELECT * FROM CHART_Massi WHERE ORDER BY PT_NAME")
    End Sub

    'Button 6 & 7
    Private Sub UpdateNames(conn As OracleConnection, commitEach As Boolean)
        Dim trans As OracleTransaction = conn.BeginTransaction
        Dim rand As New Random()
        Dim chartNos As New List(Of Integer)()
        Using cmdRead As New OracleCommand("SELECT CHART_NO FROM CHART_Massi", conn)
            Using reader = cmdRead.ExecuteReader()
                While reader.Read()
                    chartNos.Add(reader.GetInt32(0))
                End While
            End Using
        End Using

        Using cmdUpdate As New OracleCommand("UPDATE CHART_Massi SET PT_NAME = :name WHERE CHART_NO= :no", conn)
            cmdUpdate.Parameters.Add(":name", OracleDbType.Varchar2)
            cmdUpdate.Parameters.Add(":no", OracleDbType.Int32)
            For Each id In chartNos
                cmdUpdate.Parameters(":name").Value = $"CHART_{id}_{rand.Next(1000, 9999)}"
                cmdUpdate.Parameters(":no").Value = id
                cmdUpdate.ExecuteNonQuery()
                If commitEach Then
                    trans.Commit()
                    trans = conn.BeginTransaction()
                    cmdUpdate.Transaction = trans
                End If
            Next
        End Using
        If Not commitEach Then trans.Commit()
    End Sub

    Private Sub btnUpdateOnce_Click(sender As Object, e As EventArgs) Handles btnUpdateOnce.Click
        LogOperation("Update Once Commit", Sub()
                                               Using conn As New OracleConnection(connStr)
                                                   conn.Open()
                                                   UpdateNames(conn, False)
                                               End Using
                                           End Sub)
    End Sub

    Private Sub btnUpdateEach_Click(sender As Object, e As EventArgs) Handles btnUpdateEach.Click
        LogOperation("Update Each Commit", Sub()
                                               Using conn As New OracleConnection(connStr)
                                                   conn.Open()
                                                   UpdateNames(conn, True)
                                               End Using
                                           End Sub)
    End Sub



    'button8
    Private Sub btnUpdateTwoSession_Click(sender As Object, e As EventArgs) Handles btnUpdateTwoSession.Click
        LogOperation("Update two sessions", Sub()
                                                Using connRead As New OracleConnection(connStr), connWrite As New OracleConnection(connStr)
                                                    connRead.Open()
                                                    connWrite.Open()
                                                    Dim tran = connWrite.BeginTransaction()
                                                    Dim rand As New Random()
                                                    Dim chartNos As New List(Of Integer)()

                                                    Using cmdRead As New OracleCommand("SELECT CHART_NO FROM CHART_Massi", connRead)
                                                        Using reader = cmdRead.ExecuteReader()
                                                            While reader.Read()
                                                                chartNos.Add(reader.GetInt32(0))
                                                            End While
                                                        End Using
                                                    End Using

                                                    Using cmdUpdate As New OracleCommand("UPDATE CHART_Massi SET PT_NAME = :name WHERE CHART_NO= :no", connWrite)
                                                        cmdUpdate.Transaction = tran
                                                        cmdUpdate.Parameters.Add(":name", OracleDbType.Varchar2)
                                                        cmdUpdate.Parameters.Add(":no", OracleDbType.Int32)
                                                        For Each id In chartNos
                                                            cmdUpdate.Parameters(":name").Value = $"CHART_{id}_{rand.Next(1000, 9999)}"
                                                            cmdUpdate.Parameters(":no").Value = id
                                                            cmdUpdate.ExecuteNonQuery()
                                                        Next
                                                    End Using
                                                    tran.Commit()
                                                End Using
                                            End Sub)
    End Sub

    Private Sub txtEndTime_TextChanged(sender As Object, e As EventArgs) Handles txtEndTime.TextChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class