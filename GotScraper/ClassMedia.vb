Imports System.Text
Imports System.Runtime.InteropServices

Namespace ClassMedia

    Public Class OpenFileEventArgs
        Inherits EventArgs
        Public Sub New(ByVal filename As String)
            Me.FileName = filename
        End Sub
        Public ReadOnly FileName As String
    End Class

    Public Class PlayFileEventArgs
        Inherits EventArgs
        Public Sub New()
        End Sub
    End Class

    Public Class PauseFileEventArgs
        Inherits EventArgs
        Public Sub New()
        End Sub
    End Class

    Public Class StopFileEventArgs
        Inherits EventArgs
        Public Sub New()
        End Sub
    End Class

    Public Class CloseFileEventArgs
        Inherits EventArgs
        Public Sub New()
        End Sub
    End Class

    Public Class ErrorEventArgs
        Inherits EventArgs
        Public Sub New(ByVal Err As Long)
            Me.ErrNum = Err
        End Sub

        Public ReadOnly ErrNum As Long
    End Class


    Public Class MP3Player
        Private Pcommand As String, FName As String
        Private Opened As Boolean, Playing As Boolean, Paused As Boolean, [Loop] As Boolean, MutedAll As Boolean, MutedLeft As Boolean,
         MutedRight As Boolean
        Private rVolume As Integer, lVolume As Integer, aVolume As Integer, tVolume As Integer, bVolume As Integer, VolBalance As Integer
        Private Lng As Int64
        Private Err As Long

        <DllImport("winmm.dll")>
        Private Shared Function mciSendString(ByVal strCommand As String, ByVal strReturn As StringBuilder, ByVal iReturnLength As Integer, ByVal hwndCallback As IntPtr) As Long
        End Function

        Public Sub New()
            Opened = False
            Pcommand = ""
            FName = ""
            Playing = False
            Paused = False
            [Loop] = False
            MutedAll = False
            MutedLeft = False
            MutedRight = False
            rVolume = 1000
            lVolume = 1000
            aVolume = 1000
            tVolume = 1000
            bVolume = 1000
            Lng = 0

            VolBalance = 0
            Err = 0
        End Sub

#Region "Volume"
        Public Property MuteAll() As Boolean
            Get
                Return MutedAll
            End Get
            Set(ByVal Value As Boolean)
                MutedAll = Value
                If MutedAll Then
                    Pcommand = "setaudio MediaFile off"
                    If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                        OnError(New ErrorEventArgs(Err))
                    End If

                Else
                    Pcommand = "setaudio MediaFile on"
                    If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                        OnError(New ErrorEventArgs(Err))
                    End If
                End If
            End Set
        End Property


        Public Property MuteLeft() As Boolean
            Get
                Return MutedLeft
            End Get
            Set(ByVal Value As Boolean)
                MutedLeft = Value
                If MutedLeft Then
                    Pcommand = "setaudio MediaFile left off"
                    If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                        OnError(New ErrorEventArgs(Err))
                    End If
                Else
                    Pcommand = "setaudio MediaFile left on"
                    If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                        OnError(New ErrorEventArgs(Err))
                    End If
                End If
            End Set
        End Property


        Public Property MuteRight() As Boolean
            Get
                Return MutedRight
            End Get
            Set(ByVal Value As Boolean)
                MutedRight = Value
                If MutedRight Then
                    Pcommand = "setaudio MediaFile right off"
                    If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                        OnError(New ErrorEventArgs(Err))
                    End If
                Else
                    Pcommand = "setaudio MediaFile right on"
                    If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                        OnError(New ErrorEventArgs(Err))
                    End If
                End If
            End Set
        End Property


        Public Property VolumeAll() As Integer
            Get
                Return aVolume
            End Get
            Set(ByVal Value As Integer)
                If Opened AndAlso (Value >= 0 AndAlso Value <= 1000) Then
                    aVolume = Value
                    Pcommand = [String].Format("setaudio MediaFile" + " volume to {0}", aVolume)
                    If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                        OnError(New ErrorEventArgs(Err))
                    End If
                End If
            End Set
        End Property

        Public Property VolumeLeft() As Integer
            Get
                Return lVolume
            End Get
            Set(ByVal Value As Integer)
                If Opened AndAlso (Value >= 0 AndAlso Value <= 1000) Then
                    lVolume = Value
                    Pcommand = [String].Format("setaudio MediaFile" + " left volume to {0}", lVolume)
                    If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                        OnError(New ErrorEventArgs(Err))
                    End If
                End If
            End Set
        End Property

        Public Property VolumeRight() As Integer
            Get
                Return rVolume
            End Get
            Set(ByVal Value As Integer)
                If Opened AndAlso (Value >= 0 AndAlso Value <= 1000) Then
                    rVolume = Value
                    Pcommand = [String].Format("setaudio" + " MediaFile right volume to {0}", rVolume)
                    If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                        OnError(New ErrorEventArgs(Err))
                    End If
                End If
            End Set
        End Property

        Public Property VolumeTreble() As Integer
            Get
                Return tVolume
            End Get
            Set(ByVal Value As Integer)
                If Opened AndAlso (Value >= 0 AndAlso Value <= 1000) Then
                    tVolume = Value
                    Pcommand = [String].Format("setaudio MediaFile" + " treble to {0}", tVolume)
                    If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                        OnError(New ErrorEventArgs(Err))
                    End If
                End If
            End Set
        End Property

        Public Property VolumeBass() As Integer
            Get
                Return bVolume
            End Get
            Set(ByVal Value As Integer)
                If Opened AndAlso (Value >= 0 AndAlso Value <= 1000) Then
                    bVolume = Value
                    Pcommand = [String].Format("setaudio MediaFile bass to {0}", bVolume)
                    If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                        OnError(New ErrorEventArgs(Err))
                    End If
                End If
            End Set
        End Property

        Public Property Balance() As Integer
            Get
                Return VolBalance
            End Get
            Set(ByVal Value As Integer)
                If Opened AndAlso (Value >= -1000 AndAlso Value <= 1000) Then
                    VolBalance = Value
                    If Value < 0 Then
                        Pcommand = "setaudio MediaFile left volume to 1000"
                        If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                            OnError(New ErrorEventArgs(Err))
                        End If
                        Pcommand = [String].Format("setaudio MediaFile right" + " volume to {0}", 1000 + Value)
                        If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                            OnError(New ErrorEventArgs(Err))
                        End If
                    Else
                        Pcommand = "setaudio MediaFile right volume to 1000"
                        If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                            OnError(New ErrorEventArgs(Err))
                        End If
                        Pcommand = [String].Format("setaudio MediaFile" + " left volume to {0}", 1000 - Value)
                        If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                            OnError(New ErrorEventArgs(Err))
                        End If
                    End If
                End If
            End Set
        End Property
#End Region
#Region "Main Functions"

        Public ReadOnly Property FileName() As String
            Get
                Return FName
            End Get
        End Property

        Public Property Looping() As Boolean
            Get
                Return [Loop]
            End Get
            Set(ByVal Value As Boolean)
                [Loop] = Value
            End Set
        End Property

        Public Sub Seek(ByVal Millisecs As Int64)
            If Opened AndAlso Millisecs <= Lng Then
                If Playing Then
                    If Paused Then
                        Pcommand = [String].Format("seek MediaFile to {0}", Millisecs)
                        If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                            OnError(New ErrorEventArgs(Err))
                        End If
                    Else
                        Pcommand = [String].Format("seek MediaFile to {0}", Millisecs)
                        If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                            OnError(New ErrorEventArgs(Err))
                        End If
                        Pcommand = "play MediaFile"
                        If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                            OnError(New ErrorEventArgs(Err))
                        End If
                    End If
                End If
            End If
        End Sub

        Private Sub CalculateLength()
            Dim str As New StringBuilder(128)
            mciSendString("status MediaFile length", str, 128, IntPtr.Zero)
            Lng = Int64.Parse(str.ToString())
        End Sub

        Public ReadOnly Property AudioLength() As Int64
            Get
                If Opened Then
                    Return Lng
                Else
                    Return 0
                End If
            End Get
        End Property

        Public Sub Close()
            If Opened Then
                Pcommand = "close MediaFile"
                If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                    OnError(New ErrorEventArgs(Err))
                End If
                Opened = False
                Playing = False
                Paused = False
                OnCloseFile(New CloseFileEventArgs)
            End If
        End Sub

        Public Sub Open(ByVal sFileName As String)
            If Not Opened Then
                Pcommand = "open """ + sFileName + """ type mpegvideo alias MediaFile"
                If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                    OnError(New ErrorEventArgs(Err))
                End If
                FName = sFileName
                Opened = True
                Playing = False
                Paused = False
                Pcommand = "set MediaFile time format milliseconds"
                If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                    OnError(New ErrorEventArgs(Err))
                End If
                Pcommand = "set MediaFile seek exactly on"
                If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                    OnError(New ErrorEventArgs(Err))
                End If
                CalculateLength()
                OnOpenFile(New OpenFileEventArgs(sFileName))
            Else
                Me.Close()
                Me.Open(sFileName)
            End If
        End Sub

        Public Sub Play()
            If Opened Then
                If Not Playing Then
                    Playing = True
                    Pcommand = "play MediaFile"
                    If [Loop] Then
                        Pcommand += " REPEAT"
                    End If
                    If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                        OnError(New ErrorEventArgs(Err))
                    End If
                    OnPlayFile(New PlayFileEventArgs)
                Else
                    If Not Paused Then
                        Pcommand = "seek MediaFile to start"
                        If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                            OnError(New ErrorEventArgs(Err))
                        End If
                        Pcommand = "play MediaFile"
                        If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                            OnError(New ErrorEventArgs(Err))
                        End If
                        OnPlayFile(New PlayFileEventArgs)
                    Else
                        Paused = False
                        Pcommand = "play MediaFile"
                        If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                            OnError(New ErrorEventArgs(Err))
                        End If
                        OnPlayFile(New PlayFileEventArgs)
                    End If
                End If
            End If
        End Sub

        Public Sub Pause()
            If Opened Then
                If Not Paused Then
                    Paused = True
                    Pcommand = "pause MediaFile"
                    If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                        OnError(New ErrorEventArgs(Err))
                    End If
                    OnPauseFile(New PauseFileEventArgs)
                Else
                    Paused = False
                    Pcommand = "play MediaFile"
                    If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                        OnError(New ErrorEventArgs(Err))
                    End If
                    OnPlayFile(New PlayFileEventArgs)
                End If
            End If
        End Sub

        Public Sub [Stop]()
            If Opened AndAlso Playing Then
                Playing = False
                Paused = False
                Pcommand = "seek MediaFile to start"
                If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                    OnError(New ErrorEventArgs(Err))
                End If
                Pcommand = "stop MediaFile"
                If ((Err = mciSendString(Pcommand, Nothing, 0, IntPtr.Zero)) <> 0) Then
                    OnError(New ErrorEventArgs(Err))
                End If
                OnStopFile(New StopFileEventArgs)
            End If
        End Sub

        Public ReadOnly Property CurrentPosition() As Int64
            Get
                If Opened AndAlso Playing Then
                    Dim s As New StringBuilder(128)
                    Pcommand = "status MediaFile position"
                    If ((Err = mciSendString(Pcommand, s, 128, IntPtr.Zero)) <> 0) Then
                        OnError(New ErrorEventArgs(Err))
                    End If

                    Return Int64.Parse(s.ToString())


                Else
                    Return 0
                End If
            End Get
        End Property

#End Region

#Region "Event Handling"

        Public Delegate Sub OpenFileEventHandler(ByVal sender As [Object], ByVal oea As OpenFileEventArgs)

        Public Delegate Sub PlayFileEventHandler(ByVal sender As [Object], ByVal pea As PlayFileEventArgs)

        Public Delegate Sub PauseFileEventHandler(ByVal sender As [Object], ByVal paea As PauseFileEventArgs)

        Public Delegate Sub StopFileEventHandler(ByVal sender As [Object], ByVal sea As StopFileEventArgs)

        Public Delegate Sub CloseFileEventHandler(ByVal sender As [Object], ByVal cea As CloseFileEventArgs)

        Public Delegate Sub ErrorEventHandler(ByVal sender As [Object], ByVal eea As ErrorEventArgs)

        Public Event OpenFile As OpenFileEventHandler

        Public Event PlayFile As PlayFileEventHandler

        Public Event PauseFile As PauseFileEventHandler

        Public Event StopFile As StopFileEventHandler

        Public Event CloseFile As CloseFileEventHandler

        Public Event [Error] As ErrorEventHandler

        Protected Overridable Sub OnOpenFile(ByVal oea As OpenFileEventArgs)
            RaiseEvent OpenFile(Me, oea)
        End Sub

        Protected Overridable Sub OnPlayFile(ByVal pea As PlayFileEventArgs)
            RaiseEvent PlayFile(Me, pea)
        End Sub

        Protected Overridable Sub OnPauseFile(ByVal paea As PauseFileEventArgs)
            RaiseEvent PauseFile(Me, paea)
        End Sub

        Protected Overridable Sub OnStopFile(ByVal sea As StopFileEventArgs)
            RaiseEvent StopFile(Me, sea)
        End Sub

        Protected Overridable Sub OnCloseFile(ByVal cea As CloseFileEventArgs)
            RaiseEvent CloseFile(Me, cea)
        End Sub

        Protected Overridable Sub OnError(ByVal eea As ErrorEventArgs)
            RaiseEvent [Error](Me, eea)
        End Sub

#End Region
    End Class
End Namespace
