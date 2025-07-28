<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnOpenForm2 = New System.Windows.Forms.Button()
        Me.lblDisplay = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnOpenForm2
        '
        Me.btnOpenForm2.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.btnOpenForm2.Location = New System.Drawing.Point(151, 179)
        Me.btnOpenForm2.Name = "btnOpenForm2"
        Me.btnOpenForm2.Size = New System.Drawing.Size(143, 38)
        Me.btnOpenForm2.TabIndex = 1
        Me.btnOpenForm2.Text = "Please click me"
        Me.btnOpenForm2.UseVisualStyleBackColor = True
        '
        'lblDisplay
        '
        Me.lblDisplay.Location = New System.Drawing.Point(117, 93)
        Me.lblDisplay.Name = "lblDisplay"
        Me.lblDisplay.Size = New System.Drawing.Size(216, 22)
        Me.lblDisplay.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 322)
        Me.Controls.Add(Me.lblDisplay)
        Me.Controls.Add(Me.btnOpenForm2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOpenForm2 As Button
    Friend WithEvents lblDisplay As TextBox
End Class
