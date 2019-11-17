<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUtility
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
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FullName")
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Name")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Region")
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Attrib1")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Attrib2")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Attrib3")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Attrib4")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Attrib5")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Note")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.LabelScan = New System.Windows.Forms.Label()
        Me.ButtonScan = New System.Windows.Forms.Button()
        Me.LabelDirectory = New System.Windows.Forms.Label()
        Me.ButtonDirectory = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelScan
        '
        Me.LabelScan.AutoSize = True
        Me.LabelScan.Location = New System.Drawing.Point(620, 17)
        Me.LabelScan.Name = "LabelScan"
        Me.LabelScan.Size = New System.Drawing.Size(39, 13)
        Me.LabelScan.TabIndex = 8
        Me.LabelScan.Text = "Label2"
        '
        'ButtonScan
        '
        Me.ButtonScan.Location = New System.Drawing.Point(539, 12)
        Me.ButtonScan.Name = "ButtonScan"
        Me.ButtonScan.Size = New System.Drawing.Size(75, 23)
        Me.ButtonScan.TabIndex = 7
        Me.ButtonScan.Text = "Scan"
        Me.ButtonScan.UseVisualStyleBackColor = True
        '
        'LabelDirectory
        '
        Me.LabelDirectory.AutoSize = True
        Me.LabelDirectory.Location = New System.Drawing.Point(93, 17)
        Me.LabelDirectory.Name = "LabelDirectory"
        Me.LabelDirectory.Size = New System.Drawing.Size(39, 13)
        Me.LabelDirectory.TabIndex = 6
        Me.LabelDirectory.Text = "Label1"
        '
        'ButtonDirectory
        '
        Me.ButtonDirectory.Location = New System.Drawing.Point(12, 12)
        Me.ButtonDirectory.Name = "ButtonDirectory"
        Me.ButtonDirectory.Size = New System.Drawing.Size(75, 23)
        Me.ButtonDirectory.TabIndex = 5
        Me.ButtonDirectory.Text = "Directory"
        Me.ButtonDirectory.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'UltraGrid1
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UltraGrid1.DisplayLayout.Appearance = Appearance1
        UltraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn1.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        UltraGridColumn1.Header.Editor = Nothing
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn2.AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.VisibleRows
        UltraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn2.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        UltraGridColumn2.FilterClearButtonVisible = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridColumn2.FilterOperandDropDownItems = Infragistics.Win.UltraWinGrid.FilterOperandDropDownItems.ShowNone
        UltraGridColumn2.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.None
        UltraGridColumn2.FilterOperatorDropDownItems = Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.None
        UltraGridColumn2.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        UltraGridColumn2.Header.AllowEditing = Infragistics.Win.UltraWinGrid.AllowHeaderEditing.None
        UltraGridColumn2.Header.Editor = Nothing
        UltraGridColumn2.Header.VisiblePosition = 1
        UltraGridColumn2.Width = 75
        UltraGridColumn3.AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.VisibleRows
        UltraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn3.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        UltraGridColumn3.FilterClearButtonVisible = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridColumn3.FilterOperandDropDownItems = Infragistics.Win.UltraWinGrid.FilterOperandDropDownItems.ShowNone
        UltraGridColumn3.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.None
        UltraGridColumn3.FilterOperatorDropDownItems = Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.None
        UltraGridColumn3.Header.Editor = Nothing
        UltraGridColumn3.Header.VisiblePosition = 2
        UltraGridColumn3.Width = 84
        UltraGridColumn11.AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.VisibleRows
        UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn11.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        UltraGridColumn11.FilterClearButtonVisible = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridColumn11.FilterOperandDropDownItems = Infragistics.Win.UltraWinGrid.FilterOperandDropDownItems.ShowNone
        UltraGridColumn11.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.None
        UltraGridColumn11.FilterOperatorDropDownItems = Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.None
        UltraGridColumn11.Header.Editor = Nothing
        UltraGridColumn11.Header.VisiblePosition = 3
        UltraGridColumn11.Width = 84
        UltraGridColumn4.AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.VisibleRows
        UltraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn4.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        UltraGridColumn4.FilterClearButtonVisible = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridColumn4.FilterOperandDropDownItems = Infragistics.Win.UltraWinGrid.FilterOperandDropDownItems.ShowNone
        UltraGridColumn4.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.None
        UltraGridColumn4.FilterOperatorDropDownItems = Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.None
        UltraGridColumn4.Header.Editor = Nothing
        UltraGridColumn4.Header.VisiblePosition = 4
        UltraGridColumn4.Width = 84
        UltraGridColumn5.AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.VisibleRows
        UltraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn5.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        UltraGridColumn5.FilterClearButtonVisible = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridColumn5.FilterOperandDropDownItems = Infragistics.Win.UltraWinGrid.FilterOperandDropDownItems.ShowNone
        UltraGridColumn5.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.None
        UltraGridColumn5.FilterOperatorDropDownItems = Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.None
        UltraGridColumn5.Header.Editor = Nothing
        UltraGridColumn5.Header.VisiblePosition = 5
        UltraGridColumn5.Width = 84
        UltraGridColumn6.AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.VisibleRows
        UltraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn6.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        UltraGridColumn6.FilterClearButtonVisible = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridColumn6.FilterOperandDropDownItems = Infragistics.Win.UltraWinGrid.FilterOperandDropDownItems.ShowNone
        UltraGridColumn6.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.None
        UltraGridColumn6.FilterOperatorDropDownItems = Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.None
        UltraGridColumn6.Header.Editor = Nothing
        UltraGridColumn6.Header.VisiblePosition = 6
        UltraGridColumn6.Width = 84
        UltraGridColumn7.AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.VisibleRows
        UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn7.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        UltraGridColumn7.FilterClearButtonVisible = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridColumn7.FilterOperandDropDownItems = Infragistics.Win.UltraWinGrid.FilterOperandDropDownItems.ShowNone
        UltraGridColumn7.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.None
        UltraGridColumn7.FilterOperatorDropDownItems = Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.None
        UltraGridColumn7.Header.Editor = Nothing
        UltraGridColumn7.Header.VisiblePosition = 7
        UltraGridColumn7.Width = 84
        UltraGridColumn8.AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.VisibleRows
        UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn8.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        UltraGridColumn8.FilterClearButtonVisible = Infragistics.Win.DefaultableBoolean.[False]
        UltraGridColumn8.FilterOperandDropDownItems = Infragistics.Win.UltraWinGrid.FilterOperandDropDownItems.ShowNone
        UltraGridColumn8.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.None
        UltraGridColumn8.FilterOperatorDropDownItems = Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.None
        UltraGridColumn8.Header.Editor = Nothing
        UltraGridColumn8.Header.VisiblePosition = 8
        UltraGridColumn8.Width = 84
        UltraGridColumn9.AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.VisibleRows
        UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        UltraGridColumn9.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        UltraGridColumn9.Header.Editor = Nothing
        UltraGridColumn9.Header.VisiblePosition = 9
        UltraGridColumn9.Width = 84
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn11, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9})
        Me.UltraGrid1.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.UltraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UltraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance2.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGrid1.DisplayLayout.GroupByBox.Appearance = Appearance2
        Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGrid1.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
        Me.UltraGrid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance4.BackColor2 = System.Drawing.SystemColors.Control
        Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UltraGrid1.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
        Me.UltraGrid1.DisplayLayout.MaxColScrollRegions = 1
        Me.UltraGrid1.DisplayLayout.MaxRowScrollRegions = 1
        Appearance5.BackColor = System.Drawing.SystemColors.Window
        Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UltraGrid1.DisplayLayout.Override.ActiveCellAppearance = Appearance5
        Appearance6.BackColor = System.Drawing.SystemColors.Highlight
        Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.UltraGrid1.DisplayLayout.Override.ActiveRowAppearance = Appearance6
        Me.UltraGrid1.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
        Me.UltraGrid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.UltraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UltraGrid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance7.BackColor = System.Drawing.SystemColors.Window
        Me.UltraGrid1.DisplayLayout.Override.CardAreaAppearance = Appearance7
        Appearance8.BorderColor = System.Drawing.Color.Silver
        Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UltraGrid1.DisplayLayout.Override.CellAppearance = Appearance8
        Me.UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UltraGrid1.DisplayLayout.Override.CellPadding = 0
        Me.UltraGrid1.DisplayLayout.Override.ColumnSizingArea = Infragistics.Win.UltraWinGrid.ColumnSizingArea.CellsOnly
        Appearance9.BackColor = System.Drawing.SystemColors.Control
        Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance9.BorderColor = System.Drawing.SystemColors.Window
        Me.UltraGrid1.DisplayLayout.Override.GroupByRowAppearance = Appearance9
        Appearance10.TextHAlignAsString = "Left"
        Me.UltraGrid1.DisplayLayout.Override.HeaderAppearance = Appearance10
        Me.UltraGrid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance11.BackColor = System.Drawing.SystemColors.Window
        Appearance11.BorderColor = System.Drawing.Color.Silver
        Me.UltraGrid1.DisplayLayout.Override.RowAppearance = Appearance11
        Me.UltraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.UltraGrid1.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.AutoFixed
        Me.UltraGrid1.DisplayLayout.Override.RowSizingArea = Infragistics.Win.UltraWinGrid.RowSizingArea.EntireRow
        Me.UltraGrid1.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.UltraGrid1.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
        Me.UltraGrid1.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UltraGrid1.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
        Me.UltraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UltraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UltraGrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGrid1.Location = New System.Drawing.Point(11, 41)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(785, 397)
        Me.UltraGrid1.TabIndex = 9
        Me.UltraGrid1.Text = "UltraGrid1"
        '
        'FormUtility
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.LabelScan)
        Me.Controls.Add(Me.ButtonScan)
        Me.Controls.Add(Me.LabelDirectory)
        Me.Controls.Add(Me.ButtonDirectory)
        Me.Name = "FormUtility"
        Me.Text = "FormUtility"
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelScan As Label
    Friend WithEvents ButtonScan As Button
    Friend WithEvents LabelDirectory As Label
    Friend WithEvents ButtonDirectory As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents Timer1 As Timer
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
