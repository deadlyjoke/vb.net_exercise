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
        Me.BtnInsert = New System.Windows.Forms.Button()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnTxn = New System.Windows.Forms.Button()
        Me.BtnSelect = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnInsert
        '
        Me.BtnInsert.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.BtnInsert.Location = New System.Drawing.Point(54, 74)
        Me.BtnInsert.Name = "BtnInsert"
        Me.BtnInsert.Size = New System.Drawing.Size(89, 45)
        Me.BtnInsert.TabIndex = 0
        Me.BtnInsert.Text = "新增"
        Me.BtnInsert.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.BtnUpdate.Location = New System.Drawing.Point(199, 73)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(75, 45)
        Me.BtnUpdate.TabIndex = 1
        Me.BtnUpdate.Text = "修改"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.BtnDelete.Location = New System.Drawing.Point(335, 74)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(76, 45)
        Me.BtnDelete.TabIndex = 2
        Me.BtnDelete.Text = "刪除"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BtnTxn
        '
        Me.BtnTxn.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.BtnTxn.Location = New System.Drawing.Point(69, 161)
        Me.BtnTxn.Name = "BtnTxn"
        Me.BtnTxn.Size = New System.Drawing.Size(149, 43)
        Me.BtnTxn.TabIndex = 3
        Me.BtnTxn.Text = "跨表新增"
        Me.BtnTxn.UseVisualStyleBackColor = True
        '
        'BtnSelect
        '
        Me.BtnSelect.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.BtnSelect.Location = New System.Drawing.Point(255, 161)
        Me.BtnSelect.Name = "BtnSelect"
        Me.BtnSelect.Size = New System.Drawing.Size(127, 43)
        Me.BtnSelect.TabIndex = 4
        Me.BtnSelect.Text = "查詢姓名"
        Me.BtnSelect.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 275)
        Me.Controls.Add(Me.BtnSelect)
        Me.Controls.Add(Me.BtnTxn)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Controls.Add(Me.BtnInsert)
        Me.Font = New System.Drawing.Font("新細明體", 9.0!)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnInsert As Button
    Friend WithEvents BtnUpdate As Button
    Friend WithEvents BtnDelete As Button
    Friend WithEvents BtnTxn As Button
    Friend WithEvents BtnSelect As Button
End Class
