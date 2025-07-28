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
        Me.btnMax = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.txtResult = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnMax
        '
        Me.btnMax.Location = New System.Drawing.Point(202, 249)
        Me.btnMax.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnMax.Name = "btnMax"
        Me.btnMax.Size = New System.Drawing.Size(92, 39)
        Me.btnMax.TabIndex = 0
        Me.btnMax.Text = "計算"
        Me.btnMax.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(159, 36)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(199, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "請輸入以，分開之一串數字"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(61, 180)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "最大值為："
        '
        'txtInput
        '
        Me.txtInput.Location = New System.Drawing.Point(45, 84)
        Me.txtInput.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(415, 23)
        Me.txtInput.TabIndex = 3
        '
        'txtResult
        '
        Me.txtResult.Location = New System.Drawing.Point(146, 177)
        Me.txtResult.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtResult.Name = "txtResult"
        Me.txtResult.Size = New System.Drawing.Size(94, 23)
        Me.txtResult.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(517, 352)
        Me.Controls.Add(Me.txtResult)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnMax)
        Me.Font = New System.Drawing.Font("新細明體", 10.0!)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "Form1"
        Me.Text = "尋找array最大值"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnMax As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtInput As TextBox
    Friend WithEvents txtResult As TextBox
End Class
