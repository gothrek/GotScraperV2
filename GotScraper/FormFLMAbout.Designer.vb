<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFLMAbout
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
        Me.LabelFEEL = New System.Windows.Forms.Label()
        Me.LabelFLM = New System.Windows.Forms.Label()
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.LabelAuthor = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LabelFEEL
        '
        Me.LabelFEEL.AutoSize = True
        Me.LabelFEEL.Font = New System.Drawing.Font("Rampage", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFEEL.Location = New System.Drawing.Point(54, 479)
        Me.LabelFEEL.Name = "LabelFEEL"
        Me.LabelFEEL.Size = New System.Drawing.Size(310, 11)
        Me.LabelFEEL.TabIndex = 0
        Me.LabelFEEL.Text = "F.E.(E.L.) By Dr. Prodigy"
        '
        'LabelFLM
        '
        Me.LabelFLM.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelFLM.Font = New System.Drawing.Font("Rampage", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFLM.Location = New System.Drawing.Point(0, 490)
        Me.LabelFLM.Name = "LabelFLM"
        Me.LabelFLM.Size = New System.Drawing.Size(447, 78)
        Me.LabelFLM.TabIndex = 1
        Me.LabelFLM.Text = "F.L.M. F.E.(E.L.) Layout Manager"
        Me.LabelFLM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelVersion
        '
        Me.LabelVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelVersion.AutoSize = True
        Me.LabelVersion.Font = New System.Drawing.Font("Rampage", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelVersion.Location = New System.Drawing.Point(291, 589)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(143, 8)
        Me.LabelVersion.TabIndex = 2
        Me.LabelVersion.Text = "Versione {0}.{1}.{2}"
        '
        'LabelAuthor
        '
        Me.LabelAuthor.AutoSize = True
        Me.LabelAuthor.Font = New System.Drawing.Font("Rampage", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAuthor.Location = New System.Drawing.Point(0, 561)
        Me.LabelAuthor.Name = "LabelAuthor"
        Me.LabelAuthor.Size = New System.Drawing.Size(167, 11)
        Me.LabelAuthor.TabIndex = 3
        Me.LabelAuthor.Text = "(c) by Gothrek"
        '
        'FormFLMAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.BackgroundImage = Global.GotScraper.My.Resources.Resources.FLMRampage22
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(444, 606)
        Me.Controls.Add(Me.LabelAuthor)
        Me.Controls.Add(Me.LabelVersion)
        Me.Controls.Add(Me.LabelFLM)
        Me.Controls.Add(Me.LabelFEEL)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFLMAbout"
        Me.Text = "F.L.M. - F.E.(E.L.) Layout Manager - About"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelFEEL As Label
    Friend WithEvents LabelFLM As Label
    Friend WithEvents LabelVersion As Label
    Friend WithEvents LabelAuthor As Label
End Class
