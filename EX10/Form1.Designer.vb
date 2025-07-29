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
        Me.lblInput = New System.Windows.Forms.Label()
        Me.txtA = New System.Windows.Forms.TextBox()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.BtnCheck = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblInput
        '
        Me.lblInput.AutoSize = True
        Me.lblInput.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.lblInput.Location = New System.Drawing.Point(51, 74)
        Me.lblInput.Name = "lblInput"
        Me.lblInput.Size = New System.Drawing.Size(114, 16)
        Me.lblInput.TabIndex = 0
        Me.lblInput.Text = "請輸入變數A："
        '
        'txtA
        '
        Me.txtA.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtA.Location = New System.Drawing.Point(171, 71)
        Me.txtA.Name = "txtA"
        Me.txtA.Size = New System.Drawing.Size(110, 27)
        Me.txtA.TabIndex = 1
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.lblResult.Location = New System.Drawing.Point(51, 168)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(87, 16)
        Me.lblResult.TabIndex = 2
        Me.lblResult.Text = "輸出結果："
        '
        'txtResult
        '
        Me.txtResult.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.txtResult.Location = New System.Drawing.Point(144, 168)
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(227, 27)
        Me.txtResult.TabIndex = 3
        '
        'BtnCheck
        '
        Me.BtnCheck.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.BtnCheck.Location = New System.Drawing.Point(158, 231)
        Me.BtnCheck.Name = "BtnCheck"
        Me.BtnCheck.Size = New System.Drawing.Size(85, 38)
        Me.BtnCheck.TabIndex = 4
        Me.BtnCheck.Text = "判斷"
        Me.BtnCheck.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 311)
        Me.Controls.Add(Me.BtnCheck)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.txtA)
        Me.Controls.Add(Me.lblInput)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblInput As Label
    Friend WithEvents txtA As TextBox
    Friend WithEvents lblResult As Label
    Friend WithEvents txtResult As TextBox
    Friend WithEvents BtnCheck As Button
End Class
