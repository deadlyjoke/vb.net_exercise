Option Explicit On
Imports System
Imports System.Net
Imports System.Text
Imports System.Xml
Imports ICSharpCode.SharpZipLib.Zip

Module DownloadJob

    ' ===== WebService 參數 =====
    Private Const SERVICE_URL As String = "http://172.20.0.103/MER/PE/DownService2/Service.asmx"
    Private Const SOAP_ACTION As String = "http://tempuri.org/GetFileList"

    Private Const STORE_NO As String = "6141"
    Private Const ECR_NO As String = "201"
    Private Const ECR_ID As String = "6141201"
    Private Const CUST_ID As String = "SME"
    Private Const ECR_TYPE As String = "POS"
    Private Const INDEXVal As String = ""

    ' ===== FTP 參數（配合你的 Ftp.vb）=====
    Private Const FTP_SERVER As String = "172.20.0.103"   ' 不含 ftp://
    Private Const FTP_BASE As String = "6141/CSV/"        ' 相對路徑
    Private Const FTP_USER As String = "SME"
    Private Const FTP_PASS As String = "SME"

    ' ===== 路徑 =====
    Private Const OUT_DIR As String = "D:\opt\pos\6141\CSV"
    Private Const TMP_DIR As String = "D:\opt\pos\6141\CSV\_tmp"

#Region "Console 入口（WinForms 用按鈕呼叫 RunJob 即可）"
    Sub Main()
        Try
            RunJob()
        Catch ex As Exception
            SafeWriteFile(System.IO.Path.Combine(TMP_DIR, "fatal.txt"), ex.ToString())
            Try : Console.WriteLine("未預期錯誤：" & ex.Message) : Console.ReadKey() : Catch : End Try
        End Try
    End Sub
#End Region

    ' ===== 主流程 =====
    Public Sub RunJob()
        Try
            System.IO.Directory.CreateDirectory(OUT_DIR)
            System.IO.Directory.CreateDirectory(TMP_DIR)
            Logp("debug.log", "[STEP] start")

            ' 1) 呼叫 WebService 取得 RTab
            Dim ok As Boolean = False
            Dim rtab As String = Nothing
            Dim err As String = Nothing

            If Not SendGetFileList(ok, rtab, err) Then
                Logp("debug.log", "[ERR] SendGetFileList HTTP/SOAP fail: " & If(err, ""))
                ShowMsg("SendGetFileList 失敗：" & If(err, ""))
                Exit Sub
            End If

            Logp("debug.log", "[INFO] GetFileListResult=" & ok.ToString() & " | ErrorMsg=" & If(err, ""))
            If Not ok OrElse String.IsNullOrEmpty(rtab) Then
                SafeWriteFile(System.IO.Path.Combine(TMP_DIR, "soap_response.xml"), If(rtab, ""))
                ShowMsg("GetFileList 回傳 False 或 RTab 空。ErrorMsg=" & If(err, ""))
                Exit Sub
            End If

            SafeWriteFile(System.IO.Path.Combine(TMP_DIR, "GetFileList.xml"), rtab)

            ' 2) 解析 RTab → 檔名清單（支援純文字）
            Dim files As System.Collections.Generic.List(Of String) = ParseFileNamesFromRTab(rtab)
            If files Is Nothing Then files = New System.Collections.Generic.List(Of String)
            Logp("debug.log", "[INFO] files.count=" & files.Count)
            If files.Count = 0 Then
                ShowMsg("RTab 解析不到檔名，請把 _tmp\GetFileList.xml 貼我。")
                Exit Sub
            End If

            ' 3) FTP 下載（用你的 Ftp 類別）
            Dim ftp As New Ftp(FTP_SERVER, FTP_USER, FTP_PASS)
            Dim fn As String
            For Each fn In files
                If String.IsNullOrEmpty(fn) Then Continue For
                Dim name As String = System.IO.Path.GetFileName(fn.Trim())
                If String.IsNullOrEmpty(name) Then Continue For

                Dim remoteRel As String = FTP_BASE & name         ' 例如 6141/CSV/xxx.zip
                Dim local As String = System.IO.Path.Combine(TMP_DIR, name)

                Try
                    Logp("debug.log", "[DL] " & remoteRel)
                    ' 覆寫下載（無 UI、Timeout=60秒、覆蓋=True）
                    ftp.OrverwriteDownLoadFile(remoteRel, local, False, 60000, True)
                Catch ex As Exception
                    Logp("debug.log", "[ERR] download " & name & " -> " & ex.Message)
                End Try
            Next

            ' 4) 解壓縮（zip / gz）
            Dim p As String
            For Each p In System.IO.Directory.GetFiles(TMP_DIR)
                Dim ext As String = System.IO.Path.GetExtension(p).ToLowerInvariant()
                Try
                    If ext = ".zip" Then
                        Logp("debug.log", "[UNZIP] " & System.IO.Path.GetFileName(p))
                        UnzipWithSharpZipLib(p, OUT_DIR)
                    ElseIf ext = ".gz" Then
                        Logp("debug.log", "[UNGZ] " & System.IO.Path.GetFileName(p))
                        ' 你的 Ftp.vb 有 GZip 解壓成 .txt（同目錄）
                        Ftp.UncompressFile(p)
                        ' 如需移動到 OUT_DIR，請自行搬移：
                        ' System.IO.File.Move(p & ".txt", System.IO.Path.Combine(OUT_DIR, System.IO.Path.GetFileName(p) & ".txt"))
                    Else
                        Logp("debug.log", "[SKIP] " & System.IO.Path.GetFileName(p))
                    End If
                Catch ex As Exception
                    Logp("debug.log", "[ERR] unzip " & p & " -> " & ex.Message)
                End Try
            Next

            ' 5) 清理暫存
            Dim f As String
            For Each f In System.IO.Directory.GetFiles(TMP_DIR)
                Try : System.IO.File.Delete(f) : Catch : End Try
            Next

            Logp("debug.log", "[STEP] done")
            ShowMsg("完成")
        Catch ex As Exception
            SafeWriteFile(System.IO.Path.Combine(TMP_DIR, "fatal.txt"), ex.ToString())
            ShowMsg("未預期錯誤：" & ex.ToString())
        End Try
    End Sub

    ' ===== SOAP 1.1 呼叫 GetFileList =====
    Private Function SendGetFileList(ByRef resultOk As Boolean, ByRef rtab As String, ByRef errorMsg As String) As Boolean
        resultOk = False : rtab = Nothing : errorMsg = Nothing

        Dim sb As New StringBuilder()
        sb.Append("<?xml version=""1.0"" encoding=""utf-8""?>")
        sb.Append("<soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" ")
        sb.Append("xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" ")
        sb.Append("xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">")
        sb.Append("<soap:Body><GetFileList xmlns=""http://tempuri.org/"">")
        sb.Append("<Input><UserInfo>")
        sb.Append("<StoreNo>").Append(XmlEscape(STORE_NO)).Append("</StoreNo>")
        sb.Append("<EcrNo>").Append(XmlEscape(ECR_NO)).Append("</EcrNo>")
        sb.Append("<EcrID>").Append(XmlEscape(ECR_ID)).Append("</EcrID>")
        sb.Append("<CustID>").Append(XmlEscape(CUST_ID)).Append("</CustID>")
        sb.Append("<EcrType>").Append(XmlEscape(ECR_TYPE)).Append("</EcrType>")
        sb.Append("</UserInfo><Index>").Append(XmlEscape(INDEXVal)).Append("</Index></Input>")
        sb.Append("</GetFileList></soap:Body></soap:Envelope>")

        Dim respXml As String = Nothing
        Try
            Dim req As HttpWebRequest = CType(WebRequest.Create(SERVICE_URL), HttpWebRequest)
            req.Method = "POST"
            req.ContentType = "text/xml; charset=utf-8"
            req.Headers.Add("SOAPAction", """" & SOAP_ACTION & """")
            req.Timeout = 1000 * 60 * 3

            Dim body() As Byte = Encoding.UTF8.GetBytes(sb.ToString())
            req.ContentLength = body.Length
            Using rs As System.IO.Stream = req.GetRequestStream()
                rs.Write(body, 0, body.Length)
            End Using

            Using resp As HttpWebResponse = CType(req.GetResponse(), HttpWebResponse)
                Using s As System.IO.Stream = resp.GetResponseStream()
                    Using sr As New System.IO.StreamReader(s, Encoding.UTF8)
                        respXml = sr.ReadToEnd()
                    End Using
                End Using
            End Using

            ' 存原始回應（RTab 其實是純文字）
            SafeWriteFile(System.IO.Path.Combine(TMP_DIR, "soap_response.xml"), respXml)

            ' 解析 SOAP（只抓三個節點）
            Dim doc As New XmlDocument()
            doc.LoadXml(respXml)

            Dim nsmgr As New XmlNamespaceManager(doc.NameTable)
            nsmgr.AddNamespace("t", "http://tempuri.org/")

            Dim nodeResult As XmlNode = doc.SelectSingleNode("//t:GetFileListResponse/t:GetFileListResult", nsmgr)
            Dim nodeRtab As XmlNode = doc.SelectSingleNode("//t:GetFileListResponse/t:RTab", nsmgr)
            Dim nodeErr As XmlNode = doc.SelectSingleNode("//t:GetFileListResponse/t:ErrorMsg", nsmgr)

            Dim resultText As String = ""
            Dim rtabText As String = ""
            Dim errText As String = ""

            If (Not nodeResult Is Nothing) AndAlso (Not nodeResult.InnerText Is Nothing) Then resultText = nodeResult.InnerText.Trim()
            If (Not nodeRtab Is Nothing) AndAlso (Not nodeRtab.InnerText Is Nothing) Then rtabText = nodeRtab.InnerText.Trim()
            If (Not nodeErr Is Nothing) AndAlso (Not nodeErr.InnerText Is Nothing) Then errText = nodeErr.InnerText.Trim()

            ' 解析布林（容錯：true/True/1）
            resultOk = (String.Compare(resultText, "true", True) = 0 OrElse resultText = "1")
            rtab = rtabText
            errorMsg = errText

            Return True

        Catch ex As WebException
            Dim more As String = ""
            Try
                If Not ex.Response Is Nothing Then
                    Using es As System.IO.Stream = ex.Response.GetResponseStream()
                        Using sr As New System.IO.StreamReader(es, Encoding.UTF8)
                            more = sr.ReadToEnd()
                        End Using
                    End Using
                End If
            Catch
            End Try
            errorMsg = "SendGetFileList WebException: " & ex.Message & If(more <> "", " | " & more, "")
            SafeWriteFile(System.IO.Path.Combine(TMP_DIR, "soap_error.txt"), errorMsg & vbCrLf & "RAW:" & If(respXml, ""))
            Return False
        Catch ex As Exception
            errorMsg = "SendGetFileList EX: " & ex.Message
            SafeWriteFile(System.IO.Path.Combine(TMP_DIR, "soap_error.txt"), errorMsg & vbCrLf & "RAW:" & If(respXml, ""))
            Return False
        End Try
    End Function

    Private Function XmlEscape(s As String) As String
        If s Is Nothing Then Return ""
        Return Security.SecurityElement.Escape(s)
    End Function

    ' ===== 解析 RTab（純文字或 XML）→ 檔名清單 =====
    Private Function ParseFileNamesFromRTab(rtabXml As String) As System.Collections.Generic.List(Of String)
        Dim results As New System.Collections.Generic.List(Of String)
        If String.IsNullOrEmpty(rtabXml) Then Return results

        ' 1) 判斷是否像 XML（第一個非空白字元是否是 '<'）
        Dim i As Integer = 0
        While i < rtabXml.Length AndAlso Char.IsWhiteSpace(rtabXml(i)) : i += 1 : End While
        Dim looksXml As Boolean = (i < rtabXml.Length AndAlso rtabXml(i) = "<"c)

        If looksXml Then
            ' 若真是 XML，嘗試用節點名稱抓
            Try
                Dim doc As New XmlDocument()
                doc.LoadXml(rtabXml)

                Dim tags() As String = {"FileName", "FILE_NAME", "FILENAME", "NAME", "FILE"}
                Dim t As String
                For Each t In tags
                    Dim nodes As XmlNodeList = doc.GetElementsByTagName(t)
                    If Not nodes Is Nothing Then
                        Dim n As XmlNode
                        For Each n In nodes
                            Dim v As String = ""
                            If Not n.InnerText Is Nothing Then v = n.InnerText.Trim()
                            If v <> "" AndAlso LooksLikeFileName(v) Then
                                results.Add(v)
                            End If
                        Next
                    End If
                Next
            Catch
                ' 不是標準 XML，就落到 Regex
            End Try
        End If

        ' 2) 非 XML 或沒抓到 → 用 Regex 從純文字撈檔名（允許路徑）
        If results.Count = 0 Then
            Dim rx As New System.Text.RegularExpressions.Regex(
                "([A-Za-z0-9_\-\.\\/]+?\.(zip|gz|csv))",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase)

            Dim m As System.Text.RegularExpressions.Match = rx.Match(rtabXml)
            While m.Success
                Dim full As String = m.Groups(1).Value
                If Not String.IsNullOrEmpty(full) Then
                    Dim name As String = System.IO.Path.GetFileName(full.Trim())
                    If Not String.IsNullOrEmpty(name) Then results.Add(name)
                End If
                m = m.NextMatch()
            End While
        End If

        ' 3) 去重（忽略大小寫）
        Dim dict As New System.Collections.Generic.Dictionary(Of String, Boolean)(StringComparer.OrdinalIgnoreCase)
        Dim uniq As New System.Collections.Generic.List(Of String)
        Dim f As String
        For Each f In results
            If f Is Nothing Then Continue For
            If Not dict.ContainsKey(f) Then
                dict.Add(f, True)
                uniq.Add(f)
            End If
        Next

        ' 4) 除錯：列出抓到的檔名
        Try
            Dim sb As New System.Text.StringBuilder()
            sb.AppendLine("Detected files:")
            Dim x As String
            For Each x In uniq
                sb.AppendLine(x)
            Next
            SafeWriteFile(System.IO.Path.Combine(TMP_DIR, "parsed_files.txt"), sb.ToString())
        Catch
        End Try

        Return uniq
    End Function

    Private Function LooksLikeFileName(s As String) As Boolean
        If String.IsNullOrEmpty(s) Then Return False
        Dim lower As String = s.Trim().ToLowerInvariant()
        Return (lower.EndsWith(".zip") OrElse lower.EndsWith(".gz") OrElse lower.EndsWith(".csv"))
    End Function

    ' ===== 解壓（zip）=====
    Private Sub UnzipWithSharpZipLib(zipFilePath As String, targetDir As String)
        Dim fz As New FastZip()
        fz.CreateEmptyDirectories = True
        fz.ExtractZip(zipFilePath, targetDir, Nothing)
    End Sub

    ' ===== 寫檔 / 記錄 =====
    Private Function Logp(name As String, msg As String) As String
        Dim p As String = System.IO.Path.Combine(TMP_DIR, name)
        Try
            System.IO.Directory.CreateDirectory(TMP_DIR)
            System.IO.File.AppendAllText(p, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & " " & msg & Environment.NewLine, Encoding.UTF8)
        Catch
        End Try
        Return p
    End Function

    Private Sub SafeWriteFile(path As String, content As String)
        Try
            Dim dir As String = System.IO.Path.GetDirectoryName(path)
            If Not String.IsNullOrEmpty(dir) Then
                System.IO.Directory.CreateDirectory(dir)
            End If
            System.IO.File.WriteAllText(path, content, Encoding.UTF8)
        Catch
        End Try
    End Sub

    Private Sub ShowMsg(text As String)
        Try : Console.WriteLine(text) : Catch : End Try
        Try : System.Windows.Forms.MessageBox.Show(text) : Catch : End Try
    End Sub

End Module
