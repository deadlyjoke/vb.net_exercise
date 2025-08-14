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
        Me.btnDrop = New System.Windows.Forms.Button()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.btnGenEach = New System.Windows.Forms.Button()
        Me.btnGenOnce = New System.Windows.Forms.Button()
        Me.btnUpdateOnce = New System.Windows.Forms.Button()
        Me.btnUpdateEach = New System.Windows.Forms.Button()
        Me.btnUpdateTwoSession = New System.Windows.Forms.Button()
        Me.btnUpdateOneSessionEachCommit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnDrop
        '
        Me.btnDrop.Location = New System.Drawing.Point(45, 12)
        Me.btnDrop.Name = "btnDrop"
        Me.btnDrop.Size = New System.Drawing.Size(133, 51)
        Me.btnDrop.TabIndex = 0
        Me.btnDrop.Text = "DROP TABLE CHART_Massi"
        Me.btnDrop.UseVisualStyleBackColor = True
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(45, 69)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(133, 51)
        Me.btnCreate.TabIndex = 1
        Me.btnCreate.Text = "CREATE TABLE CHART_Massi ADD PRIMARY KEY"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'btnGenEach
        '
        Me.btnGenEach.Location = New System.Drawing.Point(45, 126)
        Me.btnGenEach.Name = "btnGenEach"
        Me.btnGenEach.Size = New System.Drawing.Size(133, 38)
        Me.btnGenEach.TabIndex = 2
        Me.btnGenEach.Text = "Generate data 200000 筆, commit each"
        Me.btnGenEach.UseVisualStyleBackColor = True
        '
        'btnGenOnce
        '
        Me.btnGenOnce.Location = New System.Drawing.Point(45, 170)
        Me.btnGenOnce.Name = "btnGenOnce"
        Me.btnGenOnce.Size = New System.Drawing.Size(133, 36)
        Me.btnGenOnce.TabIndex = 3
        Me.btnGenOnce.Text = "Generate data 200000 筆, commit once"
        Me.btnGenOnce.UseVisualStyleBackColor = True
        '
        'btnUpdateOnce
        '
        Me.btnUpdateOnce.Location = New System.Drawing.Point(45, 240)
        Me.btnUpdateOnce.Name = "btnUpdateOnce"
        Me.btnUpdateOnce.Size = New System.Drawing.Size(133, 65)
        Me.btnUpdateOnce.TabIndex = 4
        Me.btnUpdateOnce.Text = "Modify PT_NAME… do update, commit once"
        Me.btnUpdateOnce.UseVisualStyleBackColor = True
        '
        'btnUpdateEach
        '
        Me.btnUpdateEach.Location = New System.Drawing.Point(45, 311)
        Me.btnUpdateEach.Name = "btnUpdateEach"
        Me.btnUpdateEach.Size = New System.Drawing.Size(133, 58)
        Me.btnUpdateEach.TabIndex = 5
        Me.btnUpdateEach.Text = "Modify PT_NAME… do update, commit each"
        Me.btnUpdateEach.UseVisualStyleBackColor = True
        '
        'btnUpdateTwoSession
        '
        Me.btnUpdateTwoSession.Location = New System.Drawing.Point(45, 387)
        Me.btnUpdateTwoSession.Name = "btnUpdateTwoSession"
        Me.btnUpdateTwoSession.Size = New System.Drawing.Size(133, 42)
        Me.btnUpdateTwoSession.TabIndex = 6
        Me.btnUpdateTwoSession.Text = "Solve No.6 problem using 2 sessions"
        Me.btnUpdateTwoSession.UseVisualStyleBackColor = True
        '
        'btnUpdateOneSessionEachCommit
        '
        Me.btnUpdateOneSessionEachCommit.Location = New System.Drawing.Point(45, 447)
        Me.btnUpdateOneSessionEachCommit.Name = "btnUpdateOneSessionEachCommit"
        Me.btnUpdateOneSessionEachCommit.Size = New System.Drawing.Size(133, 82)
        Me.btnUpdateOneSessionEachCommit.TabIndex = 7
        Me.btnUpdateOneSessionEachCommit.Text = "Modify PT_NAME… one session write, one session read"
        Me.btnUpdateOneSessionEachCommit.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 552)
        Me.Controls.Add(Me.btnUpdateOneSessionEachCommit)
        Me.Controls.Add(Me.btnUpdateTwoSession)
        Me.Controls.Add(Me.btnUpdateEach)
        Me.Controls.Add(Me.btnUpdateOnce)
        Me.Controls.Add(Me.btnGenOnce)
        Me.Controls.Add(Me.btnGenEach)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.btnDrop)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnDrop As Button
    Friend WithEvents btnCreate As Button
    Friend WithEvents btnGenEach As Button
    Friend WithEvents btnGenOnce As Button
    Friend WithEvents btnUpdateOnce As Button
    Friend WithEvents btnUpdateEach As Button
    Friend WithEvents btnUpdateTwoSession As Button
    Friend WithEvents btnUpdateOneSessionEachCommit As Button
End Class
