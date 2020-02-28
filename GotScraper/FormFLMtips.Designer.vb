<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFLMtips
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFLMtips))
        Me.ButtonChiudi = New System.Windows.Forms.Button()
        Me.ButtonTip = New System.Windows.Forms.Button()
        Me.CheckBoxTip = New System.Windows.Forms.CheckBox()
        Me.LabelTip = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ButtonChiudi
        '
        Me.ButtonChiudi.Location = New System.Drawing.Point(134, 159)
        Me.ButtonChiudi.Name = "ButtonChiudi"
        Me.ButtonChiudi.Size = New System.Drawing.Size(75, 23)
        Me.ButtonChiudi.TabIndex = 8
        Me.ButtonChiudi.Text = "Chiudi"
        Me.ButtonChiudi.UseVisualStyleBackColor = True
        '
        'ButtonTip
        '
        Me.ButtonTip.Location = New System.Drawing.Point(215, 159)
        Me.ButtonTip.Name = "ButtonTip"
        Me.ButtonTip.Size = New System.Drawing.Size(75, 23)
        Me.ButtonTip.TabIndex = 7
        Me.ButtonTip.Text = "Prossima tip"
        Me.ButtonTip.UseVisualStyleBackColor = True
        Me.ButtonTip.Visible = False
        '
        'CheckBoxTip
        '
        Me.CheckBoxTip.AutoSize = True
        Me.CheckBoxTip.Checked = True
        Me.CheckBoxTip.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxTip.Location = New System.Drawing.Point(15, 159)
        Me.CheckBoxTip.Name = "CheckBoxTip"
        Me.CheckBoxTip.Size = New System.Drawing.Size(113, 17)
        Me.CheckBoxTip.TabIndex = 6
        Me.CheckBoxTip.Text = "Visualizza all'avvio"
        Me.CheckBoxTip.UseVisualStyleBackColor = True
        '
        'LabelTip
        '
        Me.LabelTip.Location = New System.Drawing.Point(12, 9)
        Me.LabelTip.Name = "LabelTip"
        Me.LabelTip.Size = New System.Drawing.Size(278, 147)
        Me.LabelTip.TabIndex = 5
        Me.LabelTip.Text = "Label1"
        '
        'FormFLMtips
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(300, 215)
        Me.ControlBox = False
        Me.Controls.Add(Me.ButtonChiudi)
        Me.Controls.Add(Me.ButtonTip)
        Me.Controls.Add(Me.CheckBoxTip)
        Me.Controls.Add(Me.LabelTip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormFLMtips"
        Me.Text = "Tips"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonChiudi As Button
    Friend WithEvents ButtonTip As Button
    Friend WithEvents CheckBoxTip As CheckBox
    Friend WithEvents LabelTip As Label
End Class
