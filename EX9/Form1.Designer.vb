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
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.lblPrompt = New System.Windows.Forms.Label()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtInput
        '
        Me.txtInput.Location = New System.Drawing.Point(132, 104)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(182, 22)
        Me.txtInput.TabIndex = 0
        '
        'btnCheck
        '
        Me.btnCheck.Font = New System.Drawing.Font("新細明體", 10.0!)
        Me.btnCheck.Location = New System.Drawing.Point(179, 166)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(90, 47)
        Me.btnCheck.TabIndex = 1
        Me.btnCheck.Text = "開始判斷"
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'lblPrompt
        '
        Me.lblPrompt.AutoSize = True
        Me.lblPrompt.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.lblPrompt.Location = New System.Drawing.Point(159, 60)
        Me.lblPrompt.Name = "lblPrompt"
        Me.lblPrompt.Size = New System.Drawing.Size(135, 16)
        Me.lblPrompt.TabIndex = 2
        Me.lblPrompt.Text = "請輸入一個正整數"
        '
        'txtResult
        '
        Me.txtResult.Location = New System.Drawing.Point(25, 245)
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(399, 22)
        Me.txtResult.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 327)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.lblPrompt)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.txtInput)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtInput As TextBox
    Friend WithEvents btnCheck As Button
    Friend WithEvents lblPrompt As Label
    Friend WithEvents txtResult As TextBox
End Class
