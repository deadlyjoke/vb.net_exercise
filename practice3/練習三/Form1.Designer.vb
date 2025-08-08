<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnDrop = New System.Windows.Forms.Button()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.btnGenEach = New System.Windows.Forms.Button()
        Me.btnGenOnce = New System.Windows.Forms.Button()
        Me.btnUpdateOnce = New System.Windows.Forms.Button()
        Me.btnUpdateEach = New System.Windows.Forms.Button()
        Me.btnUpdateTwoSession = New System.Windows.Forms.Button()
        Me.btnQuery1 = New System.Windows.Forms.Button()
        Me.btnQuery2 = New System.Windows.Forms.Button()
        Me.btnQuery3 = New System.Windows.Forms.Button()
        Me.btnQuery4 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtStartTime = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEndTime = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnDrop
        '
        Me.btnDrop.Location = New System.Drawing.Point(26, 23)
        Me.btnDrop.Name = "btnDrop"
        Me.btnDrop.Size = New System.Drawing.Size(202, 51)
        Me.btnDrop.TabIndex = 0
        Me.btnDrop.Text = "DROP TABLE CHART_Massi"
        Me.btnDrop.UseVisualStyleBackColor = True
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(26, 80)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(202, 51)
        Me.btnCreate.TabIndex = 1
        Me.btnCreate.Text = "CREATE TABLE CHART_ANDY ADD PRIMARY KEY"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'btnGenEach
        '
        Me.btnGenEach.Location = New System.Drawing.Point(26, 137)
        Me.btnGenEach.Name = "btnGenEach"
        Me.btnGenEach.Size = New System.Drawing.Size(202, 51)
        Me.btnGenEach.TabIndex = 2
        Me.btnGenEach.Text = "Generate data 200000 筆, commit each"
        Me.btnGenEach.UseVisualStyleBackColor = True
        '
        'btnGenOnce
        '
        Me.btnGenOnce.Location = New System.Drawing.Point(26, 194)
        Me.btnGenOnce.Name = "btnGenOnce"
        Me.btnGenOnce.Size = New System.Drawing.Size(202, 51)
        Me.btnGenOnce.TabIndex = 3
        Me.btnGenOnce.Text = "Generate data 200000 筆, commit once"
        Me.btnGenOnce.UseVisualStyleBackColor = True
        '
        'btnUpdateOnce
        '
        Me.btnUpdateOnce.Location = New System.Drawing.Point(26, 326)
        Me.btnUpdateOnce.Name = "btnUpdateOnce"
        Me.btnUpdateOnce.Size = New System.Drawing.Size(202, 51)
        Me.btnUpdateOnce.TabIndex = 4
        Me.btnUpdateOnce.Text = "Modify PT_NAME… do update, commit once"
        Me.btnUpdateOnce.UseVisualStyleBackColor = True
        '
        'btnUpdateEach
        '
        Me.btnUpdateEach.Location = New System.Drawing.Point(26, 399)
        Me.btnUpdateEach.Name = "btnUpdateEach"
        Me.btnUpdateEach.Size = New System.Drawing.Size(202, 51)
        Me.btnUpdateEach.TabIndex = 5
        Me.btnUpdateEach.Text = "Modify PT_NAME… do update, commit each"
        Me.btnUpdateEach.UseVisualStyleBackColor = True
        '
        'btnUpdateTwoSession
        '
        Me.btnUpdateTwoSession.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.btnUpdateTwoSession.Location = New System.Drawing.Point(41, 483)
        Me.btnUpdateTwoSession.Name = "btnUpdateTwoSession"
        Me.btnUpdateTwoSession.Size = New System.Drawing.Size(175, 106)
        Me.btnUpdateTwoSession.TabIndex = 7
        Me.btnUpdateTwoSession.Text = "Modify PT_NAME… one session write, one session read"
        Me.btnUpdateTwoSession.UseVisualStyleBackColor = True
        '
        'btnQuery1
        '
        Me.btnQuery1.Location = New System.Drawing.Point(370, 109)
        Me.btnQuery1.Name = "btnQuery1"
        Me.btnQuery1.Size = New System.Drawing.Size(149, 61)
        Me.btnQuery1.TabIndex = 8
        Me.btnQuery1.Text = "READ WITH CHART_NO"
        Me.btnQuery1.UseVisualStyleBackColor = True
        '
        'btnQuery2
        '
        Me.btnQuery2.Location = New System.Drawing.Point(370, 207)
        Me.btnQuery2.Name = "btnQuery2"
        Me.btnQuery2.Size = New System.Drawing.Size(149, 61)
        Me.btnQuery2.TabIndex = 9
        Me.btnQuery2.Text = "READ WITH PT_NAME"
        Me.btnQuery2.UseVisualStyleBackColor = True
        '
        'btnQuery3
        '
        Me.btnQuery3.Location = New System.Drawing.Point(370, 303)
        Me.btnQuery3.Name = "btnQuery3"
        Me.btnQuery3.Size = New System.Drawing.Size(149, 61)
        Me.btnQuery3.TabIndex = 10
        Me.btnQuery3.Text = "READ EACH RECORD ORDER BY CHART_NO"
        Me.btnQuery3.UseVisualStyleBackColor = True
        '
        'btnQuery4
        '
        Me.btnQuery4.Location = New System.Drawing.Point(370, 399)
        Me.btnQuery4.Name = "btnQuery4"
        Me.btnQuery4.Size = New System.Drawing.Size(149, 61)
        Me.btnQuery4.TabIndex = 11
        Me.btnQuery4.Text = "READ EACH RECORD ORDER BY PT_NAME"
        Me.btnQuery4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 618)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Start Time："
        '
        'txtStartTime
        '
        Me.txtStartTime.Location = New System.Drawing.Point(83, 615)
        Me.txtStartTime.Name = "txtStartTime"
        Me.txtStartTime.Size = New System.Drawing.Size(100, 22)
        Me.txtStartTime.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(200, 618)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 12)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "End Time："
        '
        'txtEndTime
        '
        Me.txtEndTime.Location = New System.Drawing.Point(269, 615)
        Me.txtEndTime.Name = "txtEndTime"
        Me.txtEndTime.Size = New System.Drawing.Size(100, 22)
        Me.txtEndTime.TabIndex = 15
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("新細明體", 10.0!)
        Me.lblStatus.Location = New System.Drawing.Point(392, 618)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(96, 14)
        Me.lblStatus.TabIndex = 16
        Me.lblStatus.Text = "Show Progess："
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(368, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 12)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "CHART_NO OR PT_NAME："
        '
        'txtInput
        '
        Me.txtInput.Location = New System.Drawing.Point(395, 62)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(100, 22)
        Me.txtInput.TabIndex = 18
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 672)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.txtEndTime)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtStartTime)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnQuery4)
        Me.Controls.Add(Me.btnQuery3)
        Me.Controls.Add(Me.btnQuery2)
        Me.Controls.Add(Me.btnQuery1)
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
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnDrop As Button
    Friend WithEvents btnCreate As Button
    Friend WithEvents btnGenEach As Button
    Friend WithEvents btnGenOnce As Button
    Friend WithEvents btnUpdateOnce As Button
    Friend WithEvents btnUpdateEach As Button
    Friend WithEvents btnUpdateTwoSession As Button
    Friend WithEvents btnQuery1 As Button
    Friend WithEvents btnQuery2 As Button
    Friend WithEvents btnQuery3 As Button
    Friend WithEvents btnQuery4 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtStartTime As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtEndTime As TextBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtInput As TextBox
End Class
