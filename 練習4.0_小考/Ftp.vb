Option Explicit On
Imports System.IO
Imports System.Net
Imports System.IO.Compression

Public Class Ftp
    Private mServerIP As String
    Private mUserName As String
    Private mPassWord As String
    Public Sub New(ByVal ServerIP As String, ByVal UserName As String, ByVal PassWord As String)

        mServerIP = "ftp://" & ServerIP & "/"
        mUserName = UserName
        mPassWorD = PassWord
    End Sub
    Public Sub DownLoadFile(ByVal URL As String, ByVal LocalPathName As String)

        Try
            Call My.Computer.Network.DownloadFile(mServerIP & URL, LocalPathName, mUserName, mPassWord)
        Catch ex As Exception
            Throw New Exception("[Ftp.DownLoadFile]" & ex.Message & mServerIP & URL)
        End Try
    End Sub
    Public Sub OrverwriteDownLoadFile(ByVal URL As String, ByVal LocalPathName As String, ByVal ShowUI As Boolean, ByVal Timeover As Integer, ByVal Orverwrite As Boolean)

        Try
            Call My.Computer.Network.DownloadFile(mServerIP & URL, LocalPathName, mUserName, mPassWord, ShowUI, Timeover, Orverwrite)
        Catch ex As Exception
            Throw New Exception("[Ftp.DownLoadFile]" & ex.Message)
        End Try
    End Sub


    Public Sub UpLoadFile(ByVal LocalPathName As String, ByVal URL As String)
        'Try
        'Call My.Computer.Network.UploadFile(LocalPathName, mServerIP & URL, mUserName, mPassWord)
        'Catch ex As Exception
        '    Throw New Exception("[Ftp.UpLoadFile]" & ex.Message)
        'End Try
        Dim myStream As FileStream
        Dim rqstStream As Stream
        Try
            Dim uPldRqst As FtpWebRequest = CType(WebRequest.Create(mServerIP & URL), FtpWebRequest)
            uPldRqst.Method = WebRequestMethods.Ftp.UploadFile
            uPldRqst.Credentials = New NetworkCredential(mUserName, mPassWord)
            uPldRqst.KeepAlive = False
            myStream = New FileStream(LocalPathName, FileMode.Open)
            Dim dataByte As Byte() = New Byte(myStream.Length - 1) {}
            myStream.Read(dataByte, 0, dataByte.Length)
            myStream.Close()
            rqstStream = uPldRqst.GetRequestStream()
            rqstStream.Write(dataByte, 0, dataByte.Length)
            rqstStream.Close()
        Catch ex As Exception
            Throw New Exception("[Ftp.UpLoadFile]" & ex.Message)
        Finally
            Try
                rqstStream.Close()
            Catch ex As Exception

            End Try
            Try
                myStream.Close()
            Catch ex As Exception

            End Try
        End Try
    End Sub
    Public Sub DeleteFile(ByVal URL As String)
        Dim Request As FtpWebRequest
        Dim Response As FtpWebResponse
        Dim Stream As Stream

        Try
            Request = FtpWebRequest.Create(New Uri(mServerIP & URL))
            Request.Credentials = New NetworkCredential(mUserName, mPassWord)
            Request.KeepAlive = False
            Request.Method = WebRequestMethods.Ftp.DeleteFile
            Response = Request.GetResponse()
            Stream = Response.GetResponseStream()
            Stream.Close()
            Response.Close()
        Catch ex As Exception
            Throw New Exception("[Ftp.DeleteFile]" & ex.Message)
        Finally
            Try
                Response.Close()
            Catch ex As Exception

            End Try
            Try
                Stream.Close()
            Catch ex As Exception

            End Try
        End Try
    End Sub
    Public Sub RenameFile(ByVal URL As String, ByVal NewFileName As String)
        Dim Request As FtpWebRequest
        Dim Response As FtpWebResponse
        Dim Stream As Stream

        Try
            Request = FtpWebRequest.Create(New Uri(mServerIP & URL))
            Request.Credentials = New NetworkCredential(mUserName, mPassWord)
            Request.Method = WebRequestMethods.Ftp.Rename
            Request.UseBinary = True
            Request.KeepAlive = False
            Request.RenameTo = NewFileName
            Response = Request.GetResponse()
            Stream = Response.GetResponseStream()
            Stream.Close()
            Response.Close()
        Catch ex As Exception
            Throw New Exception("[Ftp.RenameFile]" & ex.Message)
        Finally
            Try
                Response.Close()
            Catch ex As Exception

            End Try
            Try
                Stream.Close()
            Catch ex As Exception

            End Try
        End Try
    End Sub
    Public Sub MakeDirectory(ByVal URL As String)
        Dim Request As FtpWebRequest
        Dim Response As FtpWebResponse
        Dim Stream As Stream

        Try
            Request = FtpWebRequest.Create(New Uri(mServerIP & URL))
            Request.Credentials = New NetworkCredential(mUserName, mPassWord)
            Request.Method = WebRequestMethods.Ftp.MakeDirectory
            Request.UseBinary = True
            Request.KeepAlive = False
            Response = Request.GetResponse()
            Stream = Response.GetResponseStream()

            Stream.Close()
            Response.Close()

        Catch ex As Exception
            Throw New Exception("[Ftp.MakeDirectory]" & ex.Message)
        Finally
            Try
                Response.Close()
            Catch ex As Exception

            End Try
            Try
                Stream.Close()
            Catch ex As Exception

            End Try
        End Try
    End Sub
    Public Function GetDateTimeStamp(ByVal URL As String) As DateTime
        Dim Request As FtpWebRequest
        Dim Response As FtpWebResponse
        Dim Stream As Stream
        Dim D As DateTime

        Try
            Request = FtpWebRequest.Create(New Uri(mServerIP & URL))
            Request.Credentials = New NetworkCredential(mUserName, mPassWord)
            Request.Method = WebRequestMethods.Ftp.GetDateTimestamp
            Request.UseBinary = True
            Request.KeepAlive = False
            Response = Request.GetResponse()
            Stream = Response.GetResponseStream()
            D = Response.LastModified
            Stream.Close()
            Response.Close()
            Return D
        Catch ex As Exception
            Throw New Exception("[Ftp.GetDateTimeStamp]" & ex.Message)
        Finally
            Try
                Response.Close()
            Catch ex As Exception

            End Try
            Try
                Stream.Close()
            Catch ex As Exception

            End Try
        End Try
    End Function
    Public Function GetFileSize(ByVal URL As String) As Long
        Dim Request As FtpWebRequest
        Dim Response As FtpWebResponse
        Dim Stream As Stream
        Dim FileSize As Long

        Try
            Request = FtpWebRequest.Create(New Uri(mServerIP & URL))
            Request.Credentials = New NetworkCredential(mUserName, mPassWord)
            Request.Method = WebRequestMethods.Ftp.GetFileSize
            Request.UseBinary = True
            Request.KeepAlive = False
            Response = Request.GetResponse()
            Stream = Response.GetResponseStream()
            FileSize = Response.ContentLength
            Stream.Close()
            Response.Close()
            Return FileSize
        Catch ex As Exception
            Throw New Exception("[Ftp.GetFileSize]" & ex.Message)
        Finally
            Try
                Response.Close()
            Catch ex As Exception

            End Try
            Try
                Stream.Close()
            Catch ex As Exception

            End Try
        End Try

    End Function
    Public Function ListDirectoryDetails(ByVal URL As String) As String()
        Dim Request As FtpWebRequest
        Dim Response As FtpWebResponse
        Dim Stream As Stream
        Dim StreamReader As StreamReader
        Dim Line, A(2000) As String
        Dim Count As Integer
        Try
            Request = FtpWebRequest.Create(New Uri(mServerIP & URL))
            Request.Credentials = New NetworkCredential(mUserName, mPassWord)
            Request.Method = WebRequestMethods.Ftp.ListDirectoryDetails
            Request.KeepAlive = False
            Request.UseBinary = True
            Response = Request.GetResponse()
            Stream = Response.GetResponseStream()
            StreamReader = New StreamReader(Stream)
            Count = 0
            Line = StreamReader.ReadLine()
            If Line IsNot Nothing Then
                Line = Line.Trim.Substring(InStrRev(Line.Trim, " ", , CompareMethod.Text))
            End If
           
            While (Not Line Is Nothing)
                A(Count) = Line
                Count = Count + 1
                Line = StreamReader.ReadLine()
                If Line IsNot Nothing Then
                    Line = Line.Trim.Substring(InStrRev(Line.Trim, " ", , CompareMethod.Text))
                    'Line = StreamReader.ReadLine().Trim.Substring(InStrRev(StreamReader.ReadLine().Trim, " ", , CompareMethod.Text))
                End If
              
            End While
            StreamReader.Close()
            Stream.Close()
            Response.Close()
            ReDim Preserve A(Count - 1)
            Return A
        Catch ex As Exception
            Throw New Exception("[Ftp.ListDirectoryDetails]" & ex.Message)
        Finally
            Try
                Response.Close()
            Catch ex As Exception

            End Try
            Try
                Stream.Close()
            Catch ex As Exception

            End Try
            Try
                StreamReader.Close()
            Catch ex As Exception

            End Try
        End Try
    End Function
    'Public Sub DownLoadFile(ByVal URL As String, ByVal LocalPathName As String)
    '    Try
    '        Dim dnldRqst As FtpWebRequest = CType(WebRequest.Create(mServerIP & URL), FtpWebRequest)
    '        dnldRqst.Method = WebRequestMethods.Ftp.DownloadFile
    '        dnldRqst.Credentials = New NetworkCredential(mUserName, mPassWord)
    '        Dim responseStream As Stream
    '        Dim dnldResponse As FtpWebResponse = CType(dnldRqst.GetResponse(), FtpWebResponse)
    '        responseStream = dnldResponse.GetResponseStream()
    '        Dim dataByte(1024) As Byte
    '        Dim bytesRead As Integer
    '        Dim myStream As FileStream = File.Create(LocalPathName)
    '        While True
    '            bytesRead = responseStream.Read(dataByte, 0, dataByte.Length)
    '            If bytesRead = 0 Then
    '                Exit While
    '            End If
    '            myStream.Write(dataByte, 0, bytesRead)
    '        End While
    '    Catch ex As Exception
    '        Throw New Exception("[Ftp.DownLoadFile]" & ex.Message)
    '    End Try
    'End Sub
    Public Shared Sub UncompressFile(ByVal path As String)
        Dim sourceFile As FileStream = File.OpenRead(path)
        Dim destinationFile As FileStream = File.Create(path + ".txt")

        ' Because the uncompressed size of the file is unknown, 
        ' we are imports an arbitrary buffer size.
        Dim buffer(4096) As Byte
        Dim n As Integer

        Using input As New GZipStream(sourceFile, _
            CompressionMode.Decompress, False)

            Console.WriteLine("Decompressing {0} to {1}.", sourceFile.Name, _
                destinationFile.Name)

            n = input.Read(buffer, 0, buffer.Length)
            destinationFile.Write(buffer, 0, n)
        End Using

        ' Close the files.
        sourceFile.Close()
        destinationFile.Close()
    End Sub

End Class



