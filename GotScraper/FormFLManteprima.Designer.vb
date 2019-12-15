<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormFLManteprima
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PanelRominputcontrol = New System.Windows.Forms.Panel()
        Me.PanelRomcategory = New System.Windows.Forms.Panel()
        Me.PanelRommanufacturer = New System.Windows.Forms.Panel()
        Me.PanelMarquee = New System.Windows.Forms.Panel()
        Me.PanelCabinet = New System.Windows.Forms.Panel()
        Me.PanelRomstatus = New System.Windows.Forms.Panel()
        Me.PanelMenu = New System.Windows.Forms.Panel()
        Me.LabelMenu = New System.Windows.Forms.Label()
        Me.LabelMenuOra = New System.Windows.Forms.Label()
        Me.LabelMenuExit = New System.Windows.Forms.Label()
        Me.LabelMenuOthers = New System.Windows.Forms.Label()
        Me.LabelMenuAbout = New System.Windows.Forms.Label()
        Me.LabelMenuCheckForUpdates = New System.Windows.Forms.Label()
        Me.LabelMenuShowFEELparameters = New System.Windows.Forms.Label()
        Me.LabelMenuReloadConfiguration = New System.Windows.Forms.Label()
        Me.LabelMenuServiceMenu = New System.Windows.Forms.Label()
        Me.LabelMenuOptions = New System.Windows.Forms.Label()
        Me.LabelMenuTools = New System.Windows.Forms.Label()
        Me.LabelMenuSelectTOPGAMES = New System.Windows.Forms.Label()
        Me.LabelMenuSelectEmulator = New System.Windows.Forms.Label()
        Me.LabelMenuSelectPlatform = New System.Windows.Forms.Label()
        Me.LabelMenuBuildList = New System.Windows.Forms.Label()
        Me.PanelRomdescription = New System.Windows.Forms.Panel()
        Me.PanelRomname = New System.Windows.Forms.Panel()
        Me.PanelRomdisplaytype = New System.Windows.Forms.Panel()
        Me.PanelEmulatorname = New System.Windows.Forms.Panel()
        Me.PanelGamelistname = New System.Windows.Forms.Panel()
        Me.PanelPlatformname = New System.Windows.Forms.Panel()
        Me.PanelRomcounter = New System.Windows.Forms.Panel()
        Me.PanelRomlist = New System.Windows.Forms.Panel()
        Me.PanelSnapshot = New System.Windows.Forms.Panel()
        Me.PanelBackground = New System.Windows.Forms.Panel()
        Me.TimerMain = New System.Windows.Forms.Timer(Me.components)
        Me.TimerMainDelay = New System.Windows.Forms.Timer(Me.components)
        Me.TimerActors = New System.Windows.Forms.Timer(Me.components)
        Me.TimerActorsDelay = New System.Windows.Forms.Timer(Me.components)
        Me.TimerBezel = New System.Windows.Forms.Timer(Me.components)
        Me.TimerBezelDelay = New System.Windows.Forms.Timer(Me.components)
        Me.PanelMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelRominputcontrol
        '
        Me.PanelRominputcontrol.BackColor = System.Drawing.Color.Transparent
        Me.PanelRominputcontrol.Location = New System.Drawing.Point(518, 423)
        Me.PanelRominputcontrol.Name = "PanelRominputcontrol"
        Me.PanelRominputcontrol.Size = New System.Drawing.Size(72, 17)
        Me.PanelRominputcontrol.TabIndex = 29
        Me.PanelRominputcontrol.Tag = "0"
        '
        'PanelRomcategory
        '
        Me.PanelRomcategory.BackColor = System.Drawing.Color.Transparent
        Me.PanelRomcategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelRomcategory.Location = New System.Drawing.Point(360, 423)
        Me.PanelRomcategory.Name = "PanelRomcategory"
        Me.PanelRomcategory.Size = New System.Drawing.Size(145, 17)
        Me.PanelRomcategory.TabIndex = 31
        Me.PanelRomcategory.Tag = "0"
        '
        'PanelRommanufacturer
        '
        Me.PanelRommanufacturer.BackColor = System.Drawing.Color.Transparent
        Me.PanelRommanufacturer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelRommanufacturer.Location = New System.Drawing.Point(360, 404)
        Me.PanelRommanufacturer.Name = "PanelRommanufacturer"
        Me.PanelRommanufacturer.Size = New System.Drawing.Size(230, 17)
        Me.PanelRommanufacturer.TabIndex = 27
        Me.PanelRommanufacturer.Tag = "0"
        '
        'PanelMarquee
        '
        Me.PanelMarquee.BackColor = System.Drawing.Color.Transparent
        Me.PanelMarquee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelMarquee.Location = New System.Drawing.Point(490, 313)
        Me.PanelMarquee.Name = "PanelMarquee"
        Me.PanelMarquee.Size = New System.Drawing.Size(136, 164)
        Me.PanelMarquee.TabIndex = 20
        Me.PanelMarquee.Tag = "0"
        Me.PanelMarquee.Visible = False
        '
        'PanelCabinet
        '
        Me.PanelCabinet.BackColor = System.Drawing.Color.Transparent
        Me.PanelCabinet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelCabinet.Location = New System.Drawing.Point(500, 314)
        Me.PanelCabinet.Name = "PanelCabinet"
        Me.PanelCabinet.Size = New System.Drawing.Size(136, 164)
        Me.PanelCabinet.TabIndex = 19
        Me.PanelCabinet.Tag = "0"
        '
        'PanelRomstatus
        '
        Me.PanelRomstatus.BackColor = System.Drawing.Color.Transparent
        Me.PanelRomstatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelRomstatus.Location = New System.Drawing.Point(0, 40)
        Me.PanelRomstatus.Name = "PanelRomstatus"
        Me.PanelRomstatus.Size = New System.Drawing.Size(50, 50)
        Me.PanelRomstatus.TabIndex = 30
        Me.PanelRomstatus.Tag = "0"
        Me.PanelRomstatus.Visible = False
        '
        'PanelMenu
        '
        Me.PanelMenu.BackColor = System.Drawing.Color.Transparent
        Me.PanelMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelMenu.Controls.Add(Me.LabelMenu)
        Me.PanelMenu.Controls.Add(Me.LabelMenuOra)
        Me.PanelMenu.Controls.Add(Me.LabelMenuExit)
        Me.PanelMenu.Controls.Add(Me.LabelMenuOthers)
        Me.PanelMenu.Controls.Add(Me.LabelMenuAbout)
        Me.PanelMenu.Controls.Add(Me.LabelMenuCheckForUpdates)
        Me.PanelMenu.Controls.Add(Me.LabelMenuShowFEELparameters)
        Me.PanelMenu.Controls.Add(Me.LabelMenuReloadConfiguration)
        Me.PanelMenu.Controls.Add(Me.LabelMenuServiceMenu)
        Me.PanelMenu.Controls.Add(Me.LabelMenuOptions)
        Me.PanelMenu.Controls.Add(Me.LabelMenuTools)
        Me.PanelMenu.Controls.Add(Me.LabelMenuSelectTOPGAMES)
        Me.PanelMenu.Controls.Add(Me.LabelMenuSelectEmulator)
        Me.PanelMenu.Controls.Add(Me.LabelMenuSelectPlatform)
        Me.PanelMenu.Controls.Add(Me.LabelMenuBuildList)
        Me.PanelMenu.Location = New System.Drawing.Point(230, 20)
        Me.PanelMenu.Name = "PanelMenu"
        Me.PanelMenu.Size = New System.Drawing.Size(200, 366)
        Me.PanelMenu.TabIndex = 32
        Me.PanelMenu.Tag = "0"
        '
        'LabelMenu
        '
        Me.LabelMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LabelMenu.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMenu.ForeColor = System.Drawing.Color.Khaki
        Me.LabelMenu.Location = New System.Drawing.Point(0, 0)
        Me.LabelMenu.Name = "LabelMenu"
        Me.LabelMenu.Size = New System.Drawing.Size(200, 25)
        Me.LabelMenu.TabIndex = 0
        Me.LabelMenu.Text = "FEEL - Menu"
        Me.LabelMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelMenuOra
        '
        Me.LabelMenuOra.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LabelMenuOra.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMenuOra.ForeColor = System.Drawing.Color.Khaki
        Me.LabelMenuOra.Location = New System.Drawing.Point(0, 350)
        Me.LabelMenuOra.Name = "LabelMenuOra"
        Me.LabelMenuOra.Size = New System.Drawing.Size(200, 15)
        Me.LabelMenuOra.TabIndex = 14
        Me.LabelMenuOra.Text = "h. mm.ss"
        Me.LabelMenuOra.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelMenuExit
        '
        Me.LabelMenuExit.BackColor = System.Drawing.Color.Transparent
        Me.LabelMenuExit.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.LabelMenuExit.ForeColor = System.Drawing.Color.White
        Me.LabelMenuExit.Location = New System.Drawing.Point(60, 325)
        Me.LabelMenuExit.Name = "LabelMenuExit"
        Me.LabelMenuExit.Size = New System.Drawing.Size(137, 25)
        Me.LabelMenuExit.TabIndex = 13
        Me.LabelMenuExit.Text = "   Exit"
        Me.LabelMenuExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelMenuOthers
        '
        Me.LabelMenuOthers.BackColor = System.Drawing.Color.Transparent
        Me.LabelMenuOthers.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.LabelMenuOthers.ForeColor = System.Drawing.Color.Khaki
        Me.LabelMenuOthers.Location = New System.Drawing.Point(60, 275)
        Me.LabelMenuOthers.Name = "LabelMenuOthers"
        Me.LabelMenuOthers.Size = New System.Drawing.Size(137, 25)
        Me.LabelMenuOthers.TabIndex = 12
        Me.LabelMenuOthers.Text = "Others"
        Me.LabelMenuOthers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelMenuAbout
        '
        Me.LabelMenuAbout.BackColor = System.Drawing.Color.Transparent
        Me.LabelMenuAbout.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.LabelMenuAbout.ForeColor = System.Drawing.Color.White
        Me.LabelMenuAbout.Location = New System.Drawing.Point(60, 300)
        Me.LabelMenuAbout.Name = "LabelMenuAbout"
        Me.LabelMenuAbout.Size = New System.Drawing.Size(137, 25)
        Me.LabelMenuAbout.TabIndex = 11
        Me.LabelMenuAbout.Text = "   About"
        Me.LabelMenuAbout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelMenuCheckForUpdates
        '
        Me.LabelMenuCheckForUpdates.BackColor = System.Drawing.Color.Transparent
        Me.LabelMenuCheckForUpdates.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.LabelMenuCheckForUpdates.ForeColor = System.Drawing.Color.White
        Me.LabelMenuCheckForUpdates.Location = New System.Drawing.Point(60, 250)
        Me.LabelMenuCheckForUpdates.Name = "LabelMenuCheckForUpdates"
        Me.LabelMenuCheckForUpdates.Size = New System.Drawing.Size(137, 25)
        Me.LabelMenuCheckForUpdates.TabIndex = 10
        Me.LabelMenuCheckForUpdates.Text = "   Check for updates"
        Me.LabelMenuCheckForUpdates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelMenuShowFEELparameters
        '
        Me.LabelMenuShowFEELparameters.BackColor = System.Drawing.Color.Transparent
        Me.LabelMenuShowFEELparameters.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.LabelMenuShowFEELparameters.ForeColor = System.Drawing.Color.White
        Me.LabelMenuShowFEELparameters.Location = New System.Drawing.Point(60, 225)
        Me.LabelMenuShowFEELparameters.Name = "LabelMenuShowFEELparameters"
        Me.LabelMenuShowFEELparameters.Size = New System.Drawing.Size(137, 25)
        Me.LabelMenuShowFEELparameters.TabIndex = 9
        Me.LabelMenuShowFEELparameters.Text = "   Show FEEL parameters"
        Me.LabelMenuShowFEELparameters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelMenuReloadConfiguration
        '
        Me.LabelMenuReloadConfiguration.BackColor = System.Drawing.Color.Transparent
        Me.LabelMenuReloadConfiguration.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.LabelMenuReloadConfiguration.ForeColor = System.Drawing.Color.White
        Me.LabelMenuReloadConfiguration.Location = New System.Drawing.Point(60, 200)
        Me.LabelMenuReloadConfiguration.Name = "LabelMenuReloadConfiguration"
        Me.LabelMenuReloadConfiguration.Size = New System.Drawing.Size(137, 25)
        Me.LabelMenuReloadConfiguration.TabIndex = 8
        Me.LabelMenuReloadConfiguration.Text = "   Reload configuration"
        Me.LabelMenuReloadConfiguration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelMenuServiceMenu
        '
        Me.LabelMenuServiceMenu.BackColor = System.Drawing.Color.Transparent
        Me.LabelMenuServiceMenu.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.LabelMenuServiceMenu.ForeColor = System.Drawing.Color.Khaki
        Me.LabelMenuServiceMenu.Location = New System.Drawing.Point(60, 175)
        Me.LabelMenuServiceMenu.Name = "LabelMenuServiceMenu"
        Me.LabelMenuServiceMenu.Size = New System.Drawing.Size(137, 25)
        Me.LabelMenuServiceMenu.TabIndex = 7
        Me.LabelMenuServiceMenu.Text = "Service menu"
        Me.LabelMenuServiceMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelMenuOptions
        '
        Me.LabelMenuOptions.BackColor = System.Drawing.Color.Transparent
        Me.LabelMenuOptions.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.LabelMenuOptions.ForeColor = System.Drawing.Color.White
        Me.LabelMenuOptions.Location = New System.Drawing.Point(60, 150)
        Me.LabelMenuOptions.Name = "LabelMenuOptions"
        Me.LabelMenuOptions.Size = New System.Drawing.Size(137, 25)
        Me.LabelMenuOptions.TabIndex = 6
        Me.LabelMenuOptions.Text = "   Options"
        Me.LabelMenuOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelMenuTools
        '
        Me.LabelMenuTools.BackColor = System.Drawing.Color.Transparent
        Me.LabelMenuTools.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.LabelMenuTools.ForeColor = System.Drawing.Color.Khaki
        Me.LabelMenuTools.Location = New System.Drawing.Point(60, 125)
        Me.LabelMenuTools.Name = "LabelMenuTools"
        Me.LabelMenuTools.Size = New System.Drawing.Size(137, 25)
        Me.LabelMenuTools.TabIndex = 5
        Me.LabelMenuTools.Text = "Tools"
        Me.LabelMenuTools.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelMenuSelectTOPGAMES
        '
        Me.LabelMenuSelectTOPGAMES.BackColor = System.Drawing.Color.Transparent
        Me.LabelMenuSelectTOPGAMES.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.LabelMenuSelectTOPGAMES.ForeColor = System.Drawing.Color.White
        Me.LabelMenuSelectTOPGAMES.Location = New System.Drawing.Point(60, 100)
        Me.LabelMenuSelectTOPGAMES.Name = "LabelMenuSelectTOPGAMES"
        Me.LabelMenuSelectTOPGAMES.Size = New System.Drawing.Size(137, 25)
        Me.LabelMenuSelectTOPGAMES.TabIndex = 4
        Me.LabelMenuSelectTOPGAMES.Text = "   Select * TOP GAMES *"
        Me.LabelMenuSelectTOPGAMES.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelMenuSelectEmulator
        '
        Me.LabelMenuSelectEmulator.BackColor = System.Drawing.Color.Transparent
        Me.LabelMenuSelectEmulator.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.LabelMenuSelectEmulator.ForeColor = System.Drawing.Color.White
        Me.LabelMenuSelectEmulator.Location = New System.Drawing.Point(60, 75)
        Me.LabelMenuSelectEmulator.Name = "LabelMenuSelectEmulator"
        Me.LabelMenuSelectEmulator.Size = New System.Drawing.Size(137, 25)
        Me.LabelMenuSelectEmulator.TabIndex = 3
        Me.LabelMenuSelectEmulator.Text = "   Select emulator"
        Me.LabelMenuSelectEmulator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelMenuSelectPlatform
        '
        Me.LabelMenuSelectPlatform.BackColor = System.Drawing.Color.Transparent
        Me.LabelMenuSelectPlatform.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LabelMenuSelectPlatform.ForeColor = System.Drawing.Color.White
        Me.LabelMenuSelectPlatform.Location = New System.Drawing.Point(60, 50)
        Me.LabelMenuSelectPlatform.Name = "LabelMenuSelectPlatform"
        Me.LabelMenuSelectPlatform.Size = New System.Drawing.Size(137, 25)
        Me.LabelMenuSelectPlatform.TabIndex = 2
        Me.LabelMenuSelectPlatform.Text = "   Select platform"
        Me.LabelMenuSelectPlatform.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelMenuBuildList
        '
        Me.LabelMenuBuildList.BackColor = System.Drawing.Color.Transparent
        Me.LabelMenuBuildList.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMenuBuildList.ForeColor = System.Drawing.Color.White
        Me.LabelMenuBuildList.Location = New System.Drawing.Point(60, 25)
        Me.LabelMenuBuildList.Name = "LabelMenuBuildList"
        Me.LabelMenuBuildList.Size = New System.Drawing.Size(137, 25)
        Me.LabelMenuBuildList.TabIndex = 1
        Me.LabelMenuBuildList.Text = "   Build List"
        Me.LabelMenuBuildList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelRomdescription
        '
        Me.PanelRomdescription.BackColor = System.Drawing.Color.Transparent
        Me.PanelRomdescription.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelRomdescription.Location = New System.Drawing.Point(360, 143)
        Me.PanelRomdescription.Name = "PanelRomdescription"
        Me.PanelRomdescription.Size = New System.Drawing.Size(230, 17)
        Me.PanelRomdescription.TabIndex = 26
        Me.PanelRomdescription.Tag = "0"
        '
        'PanelRomname
        '
        Me.PanelRomname.BackColor = System.Drawing.Color.Transparent
        Me.PanelRomname.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelRomname.Location = New System.Drawing.Point(30, 423)
        Me.PanelRomname.Name = "PanelRomname"
        Me.PanelRomname.Size = New System.Drawing.Size(154, 18)
        Me.PanelRomname.TabIndex = 25
        Me.PanelRomname.Tag = "0"
        '
        'PanelRomdisplaytype
        '
        Me.PanelRomdisplaytype.BackColor = System.Drawing.Color.Transparent
        Me.PanelRomdisplaytype.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelRomdisplaytype.Location = New System.Drawing.Point(0, 0)
        Me.PanelRomdisplaytype.Name = "PanelRomdisplaytype"
        Me.PanelRomdisplaytype.Size = New System.Drawing.Size(50, 50)
        Me.PanelRomdisplaytype.TabIndex = 28
        Me.PanelRomdisplaytype.Tag = "0"
        Me.PanelRomdisplaytype.Visible = False
        '
        'PanelEmulatorname
        '
        Me.PanelEmulatorname.BackColor = System.Drawing.Color.Transparent
        Me.PanelEmulatorname.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelEmulatorname.Location = New System.Drawing.Point(67, 77)
        Me.PanelEmulatorname.Name = "PanelEmulatorname"
        Me.PanelEmulatorname.Size = New System.Drawing.Size(196, 25)
        Me.PanelEmulatorname.TabIndex = 23
        Me.PanelEmulatorname.Tag = "0"
        '
        'PanelGamelistname
        '
        Me.PanelGamelistname.BackColor = System.Drawing.Color.Transparent
        Me.PanelGamelistname.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelGamelistname.Location = New System.Drawing.Point(67, 100)
        Me.PanelGamelistname.Name = "PanelGamelistname"
        Me.PanelGamelistname.Size = New System.Drawing.Size(196, 18)
        Me.PanelGamelistname.TabIndex = 24
        Me.PanelGamelistname.Tag = "0"
        '
        'PanelPlatformname
        '
        Me.PanelPlatformname.BackColor = System.Drawing.Color.Transparent
        Me.PanelPlatformname.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelPlatformname.Location = New System.Drawing.Point(360, 92)
        Me.PanelPlatformname.Name = "PanelPlatformname"
        Me.PanelPlatformname.Size = New System.Drawing.Size(230, 35)
        Me.PanelPlatformname.TabIndex = 22
        Me.PanelPlatformname.Tag = "0"
        '
        'PanelRomcounter
        '
        Me.PanelRomcounter.BackColor = System.Drawing.Color.Transparent
        Me.PanelRomcounter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelRomcounter.Location = New System.Drawing.Point(196, 423)
        Me.PanelRomcounter.Name = "PanelRomcounter"
        Me.PanelRomcounter.Size = New System.Drawing.Size(102, 18)
        Me.PanelRomcounter.TabIndex = 21
        Me.PanelRomcounter.Tag = "0"
        '
        'PanelRomlist
        '
        Me.PanelRomlist.BackColor = System.Drawing.Color.Transparent
        Me.PanelRomlist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelRomlist.Location = New System.Drawing.Point(27, 142)
        Me.PanelRomlist.Name = "PanelRomlist"
        Me.PanelRomlist.Size = New System.Drawing.Size(274, 275)
        Me.PanelRomlist.TabIndex = 16
        Me.PanelRomlist.Tag = "0"
        '
        'PanelSnapshot
        '
        Me.PanelSnapshot.BackColor = System.Drawing.Color.Transparent
        Me.PanelSnapshot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelSnapshot.Location = New System.Drawing.Point(361, 196)
        Me.PanelSnapshot.Name = "PanelSnapshot"
        Me.PanelSnapshot.Size = New System.Drawing.Size(228, 171)
        Me.PanelSnapshot.TabIndex = 18
        Me.PanelSnapshot.Tag = "0"
        '
        'PanelBackground
        '
        Me.PanelBackground.AllowDrop = True
        Me.PanelBackground.BackColor = System.Drawing.Color.Transparent
        Me.PanelBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelBackground.Location = New System.Drawing.Point(0, 0)
        Me.PanelBackground.Name = "PanelBackground"
        Me.PanelBackground.Size = New System.Drawing.Size(640, 480)
        Me.PanelBackground.TabIndex = 17
        Me.PanelBackground.Tag = "0"
        '
        'TimerMain
        '
        '
        'TimerMainDelay
        '
        '
        'TimerActors
        '
        '
        'TimerActorsDelay
        '
        '
        'TimerBezel
        '
        '
        'TimerBezelDelay
        '
        '
        'FormFLManteprima
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(640, 480)
        Me.Controls.Add(Me.PanelMenu)
        Me.Controls.Add(Me.PanelRominputcontrol)
        Me.Controls.Add(Me.PanelRomcategory)
        Me.Controls.Add(Me.PanelRommanufacturer)
        Me.Controls.Add(Me.PanelMarquee)
        Me.Controls.Add(Me.PanelCabinet)
        Me.Controls.Add(Me.PanelRomstatus)
        Me.Controls.Add(Me.PanelRomdescription)
        Me.Controls.Add(Me.PanelRomname)
        Me.Controls.Add(Me.PanelRomdisplaytype)
        Me.Controls.Add(Me.PanelEmulatorname)
        Me.Controls.Add(Me.PanelGamelistname)
        Me.Controls.Add(Me.PanelPlatformname)
        Me.Controls.Add(Me.PanelRomcounter)
        Me.Controls.Add(Me.PanelRomlist)
        Me.Controls.Add(Me.PanelSnapshot)
        Me.Controls.Add(Me.PanelBackground)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFLManteprima"
        Me.Text = "FormFLManteprima"
        Me.PanelMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelRominputcontrol As Panel
    Friend WithEvents PanelRomcategory As Panel
    Friend WithEvents PanelRommanufacturer As Panel
    Friend WithEvents PanelMarquee As Panel
    Friend WithEvents PanelCabinet As Panel
    Friend WithEvents PanelRomstatus As Panel
    Friend WithEvents PanelMenu As Panel
    Friend WithEvents PanelRomdescription As Panel
    Friend WithEvents PanelRomname As Panel
    Friend WithEvents PanelRomdisplaytype As Panel
    Friend WithEvents PanelEmulatorname As Panel
    Friend WithEvents PanelGamelistname As Panel
    Friend WithEvents PanelPlatformname As Panel
    Friend WithEvents PanelRomcounter As Panel
    Friend WithEvents PanelRomlist As Panel
    Friend WithEvents PanelSnapshot As Panel
    Friend WithEvents PanelBackground As Panel
    Friend WithEvents LabelMenuSelectTOPGAMES As Label
    Friend WithEvents LabelMenuSelectEmulator As Label
    Friend WithEvents LabelMenuSelectPlatform As Label
    Friend WithEvents LabelMenuBuildList As Label
    Friend WithEvents LabelMenu As Label
    Friend WithEvents LabelMenuOra As Label
    Friend WithEvents LabelMenuExit As Label
    Friend WithEvents LabelMenuOthers As Label
    Friend WithEvents LabelMenuAbout As Label
    Friend WithEvents LabelMenuCheckForUpdates As Label
    Friend WithEvents LabelMenuShowFEELparameters As Label
    Friend WithEvents LabelMenuReloadConfiguration As Label
    Friend WithEvents LabelMenuServiceMenu As Label
    Friend WithEvents LabelMenuOptions As Label
    Friend WithEvents LabelMenuTools As Label
    Friend WithEvents TimerMain As Timer
    Friend WithEvents TimerMainDelay As Timer
    Friend WithEvents TimerActors As Timer
    Friend WithEvents TimerActorsDelay As Timer
    Friend WithEvents TimerBezel As Timer
    Friend WithEvents TimerBezelDelay As Timer
End Class
