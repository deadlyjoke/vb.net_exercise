Public Class Form1
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        Dim font As New Font("微軟正黑體", 16, FontStyle.Bold)
        Dim startX As Integer = 20 '初始X座標
        Dim startY As Integer = 20 '初始Y座標
        Dim cellWidth As Integer = 100 '單元格寬度
        Dim lineHeight As Integer = 30 '行高

        For i As Integer = 1 To 9
            For j As Integer = 1 To 9
                Dim text As String = $"{i}*{j} = {i * j}" '計算乘法表的值" 
                Dim x As Integer = startX + (j - 1) * cellWidth
                Dim y As Integer = startY + (i - 1) * lineHeight
                ' 繪製文字
                g.DrawString(Text, font, Brushes.Black, x, y)
                ' 繪製單元格邊框
                g.DrawRectangle(Pens.Black, x, y, cellWidth, lineHeight)
            Next
        Next
    End Sub
End Class
