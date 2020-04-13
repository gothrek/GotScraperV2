using System;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace GotScraper.ClassMedia
{
    public class OpenFileEventArgs : EventArgs
    {
        public OpenFileEventArgs(string filename)
        {
            FileName = filename;
        }

        public readonly string FileName;
    }

    public class PlayFileEventArgs : EventArgs
    {
        public PlayFileEventArgs()
        {
        }
    }

    public class PauseFileEventArgs : EventArgs
    {
        public PauseFileEventArgs()
        {
        }
    }

    public class StopFileEventArgs : EventArgs
    {
        public StopFileEventArgs()
        {
        }
    }

    public class CloseFileEventArgs : EventArgs
    {
        public CloseFileEventArgs()
        {
        }
    }

    public class ErrorEventArgs : EventArgs
    {
        public ErrorEventArgs(long Err)
        {
            ErrNum = Err;
        }

        public readonly long ErrNum;
    }

    public class MP3Player
    {
        private string Pcommand;
        private string FName;
        private bool Opened;
        private bool Playing;
        private bool Paused;
        private bool Loop;
        private bool MutedAll;
        private bool MutedLeft;
        private bool MutedRight;
        private int rVolume;
        private int lVolume;
        private int aVolume;
        private int tVolume;
        private int bVolume;
        private int VolBalance;
        private long Lng;
        private long Err;

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        public MP3Player()
        {
            Opened = false;
            Pcommand = "";
            FName = "";
            Playing = false;
            Paused = false;
            Loop = false;
            MutedAll = false;
            MutedLeft = false;
            MutedRight = false;
            rVolume = 1000;
            lVolume = 1000;
            aVolume = 1000;
            tVolume = 1000;
            bVolume = 1000;
            Lng = 0;
            VolBalance = 0;
            Err = 0;
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public bool MuteAll
        {
            get
            {
                return MutedAll;
            }

            set
            {
                MutedAll = value;
                if (MutedAll)
                {
                    Pcommand = "setaudio MediaFile off";
                    if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                    {
                        OnError(new ErrorEventArgs(Err));
                    }
                }
                else
                {
                    Pcommand = "setaudio MediaFile on";
                    if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                    {
                        OnError(new ErrorEventArgs(Err));
                    }
                }
            }
        }

        public bool MuteLeft
        {
            get
            {
                return MutedLeft;
            }

            set
            {
                MutedLeft = value;
                if (MutedLeft)
                {
                    Pcommand = "setaudio MediaFile left off";
                    if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                    {
                        OnError(new ErrorEventArgs(Err));
                    }
                }
                else
                {
                    Pcommand = "setaudio MediaFile left on";
                    if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                    {
                        OnError(new ErrorEventArgs(Err));
                    }
                }
            }
        }

        public bool MuteRight
        {
            get
            {
                return MutedRight;
            }

            set
            {
                MutedRight = value;
                if (MutedRight)
                {
                    Pcommand = "setaudio MediaFile right off";
                    if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                    {
                        OnError(new ErrorEventArgs(Err));
                    }
                }
                else
                {
                    Pcommand = "setaudio MediaFile right on";
                    if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                    {
                        OnError(new ErrorEventArgs(Err));
                    }
                }
            }
        }

        public int VolumeAll
        {
            get
            {
                return aVolume;
            }

            set
            {
                if (Opened && value >= 0 && value <= 1000)
                {
                    aVolume = value;
                    Pcommand = string.Format("setaudio MediaFile" + " volume to {0}", aVolume);
                    if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                    {
                        OnError(new ErrorEventArgs(Err));
                    }
                }
            }
        }

        public int VolumeLeft
        {
            get
            {
                return lVolume;
            }

            set
            {
                if (Opened && value >= 0 && value <= 1000)
                {
                    lVolume = value;
                    Pcommand = string.Format("setaudio MediaFile" + " left volume to {0}", lVolume);
                    if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                    {
                        OnError(new ErrorEventArgs(Err));
                    }
                }
            }
        }

        public int VolumeRight
        {
            get
            {
                return rVolume;
            }

            set
            {
                if (Opened && value >= 0 && value <= 1000)
                {
                    rVolume = value;
                    Pcommand = string.Format("setaudio" + " MediaFile right volume to {0}", rVolume);
                    if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                    {
                        OnError(new ErrorEventArgs(Err));
                    }
                }
            }
        }

        public int VolumeTreble
        {
            get
            {
                return tVolume;
            }

            set
            {
                if (Opened && value >= 0 && value <= 1000)
                {
                    tVolume = value;
                    Pcommand = string.Format("setaudio MediaFile" + " treble to {0}", tVolume);
                    if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                    {
                        OnError(new ErrorEventArgs(Err));
                    }
                }
            }
        }

        public int VolumeBass
        {
            get
            {
                return bVolume;
            }

            set
            {
                if (Opened && value >= 0 && value <= 1000)
                {
                    bVolume = value;
                    Pcommand = string.Format("setaudio MediaFile bass to {0}", bVolume);
                    if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                    {
                        OnError(new ErrorEventArgs(Err));
                    }
                }
            }
        }

        public int Balance
        {
            get
            {
                return VolBalance;
            }

            set
            {
                if (Opened && value >= -1000 && value <= 1000)
                {
                    VolBalance = value;
                    if (value < 0)
                    {
                        Pcommand = "setaudio MediaFile left volume to 1000";
                        if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                        {
                            OnError(new ErrorEventArgs(Err));
                        }

                        Pcommand = string.Format("setaudio MediaFile right" + " volume to {0}", 1000 + value);
                        if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                        {
                            OnError(new ErrorEventArgs(Err));
                        }
                    }
                    else
                    {
                        Pcommand = "setaudio MediaFile right volume to 1000";
                        if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                        {
                            OnError(new ErrorEventArgs(Err));
                        }

                        Pcommand = string.Format("setaudio MediaFile" + " left volume to {0}", 1000 - value);
                        if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                        {
                            OnError(new ErrorEventArgs(Err));
                        }
                    }
                }
            }
        }
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia *//* TODO ERROR: Skipped RegionDirectiveTrivia */
        public string FileName
        {
            get
            {
                return FName;
            }
        }

        public bool Looping
        {
            get
            {
                return Loop;
            }

            set
            {
                Loop = value;
            }
        }

        public void Seek(long Millisecs)
        {
            if (Opened && Millisecs <= Lng)
            {
                if (Playing)
                {
                    if (Paused)
                    {
                        Pcommand = string.Format("seek MediaFile to {0}", Millisecs);
                        if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                        {
                            OnError(new ErrorEventArgs(Err));
                        }
                    }
                    else
                    {
                        Pcommand = string.Format("seek MediaFile to {0}", Millisecs);
                        if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                        {
                            OnError(new ErrorEventArgs(Err));
                        }

                        Pcommand = "play MediaFile";
                        if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                        {
                            OnError(new ErrorEventArgs(Err));
                        }
                    }
                }
            }
        }

        private void CalculateLength()
        {
            var str = new StringBuilder(128);
            mciSendString("status MediaFile length", str, 128, IntPtr.Zero);
            Lng = long.Parse(str.ToString());
        }

        public long AudioLength
        {
            get
            {
                if (Opened)
                {
                    return Lng;
                }
                else
                {
                    return 0;
                }
            }
        }

        public void Close()
        {
            if (Opened)
            {
                Pcommand = "close MediaFile";
                if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                {
                    OnError(new ErrorEventArgs(Err));
                }

                Opened = false;
                Playing = false;
                Paused = false;
                OnCloseFile(new CloseFileEventArgs());
            }
        }

        public void Open(string sFileName)
        {
            if (!Opened)
            {
                Pcommand = "open \"" + sFileName + "\" type mpegvideo alias MediaFile";
                if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                {
                    OnError(new ErrorEventArgs(Err));
                }

                FName = sFileName;
                Opened = true;
                Playing = false;
                Paused = false;
                Pcommand = "set MediaFile time format milliseconds";
                if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                {
                    OnError(new ErrorEventArgs(Err));
                }

                Pcommand = "set MediaFile seek exactly on";
                if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                {
                    OnError(new ErrorEventArgs(Err));
                }

                CalculateLength();
                OnOpenFile(new OpenFileEventArgs(sFileName));
            }
            else
            {
                Close();
                Open(sFileName);
            }
        }

        public void Play()
        {
            if (Opened)
            {
                if (!Playing)
                {
                    Playing = true;
                    Pcommand = "play MediaFile";
                    if (Loop)
                    {
                        Pcommand += " REPEAT";
                    }

                    if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                    {
                        OnError(new ErrorEventArgs(Err));
                    }

                    OnPlayFile(new PlayFileEventArgs());
                }
                else if (!Paused)
                {
                    Pcommand = "seek MediaFile to start";
                    if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                    {
                        OnError(new ErrorEventArgs(Err));
                    }

                    Pcommand = "play MediaFile";
                    if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                    {
                        OnError(new ErrorEventArgs(Err));
                    }

                    OnPlayFile(new PlayFileEventArgs());
                }
                else
                {
                    Paused = false;
                    Pcommand = "play MediaFile";
                    if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                    {
                        OnError(new ErrorEventArgs(Err));
                    }

                    OnPlayFile(new PlayFileEventArgs());
                }
            }
        }

        public void Pause()
        {
            if (Opened)
            {
                if (!Paused)
                {
                    Paused = true;
                    Pcommand = "pause MediaFile";
                    if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                    {
                        OnError(new ErrorEventArgs(Err));
                    }

                    OnPauseFile(new PauseFileEventArgs());
                }
                else
                {
                    Paused = false;
                    Pcommand = "play MediaFile";
                    if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                    {
                        OnError(new ErrorEventArgs(Err));
                    }

                    OnPlayFile(new PlayFileEventArgs());
                }
            }
        }

        public void Stop()
        {
            if (Opened && Playing)
            {
                Playing = false;
                Paused = false;
                Pcommand = "seek MediaFile to start";
                if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                {
                    OnError(new ErrorEventArgs(Err));
                }

                Pcommand = "stop MediaFile";
                if (Conversions.ToInteger(Err == mciSendString(Pcommand, null, 0, IntPtr.Zero)) != 0)
                {
                    OnError(new ErrorEventArgs(Err));
                }

                OnStopFile(new StopFileEventArgs());
            }
        }

        public long CurrentPosition
        {
            get
            {
                if (Opened && Playing)
                {
                    var s = new StringBuilder(128);
                    Pcommand = "status MediaFile position";
                    if (Conversions.ToInteger(Err == mciSendString(Pcommand, s, 128, IntPtr.Zero)) != 0)
                    {
                        OnError(new ErrorEventArgs(Err));
                    }

                    return long.Parse(s.ToString());
                }
                else
                {
                    return 0;
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public delegate void OpenFileEventHandler(object sender, OpenFileEventArgs oea);

        public delegate void PlayFileEventHandler(object sender, PlayFileEventArgs pea);

        public delegate void PauseFileEventHandler(object sender, PauseFileEventArgs paea);

        public delegate void StopFileEventHandler(object sender, StopFileEventArgs sea);

        public delegate void CloseFileEventHandler(object sender, CloseFileEventArgs cea);

        public delegate void ErrorEventHandler(object sender, ErrorEventArgs eea);

        public event OpenFileEventHandler OpenFile;
        public event PlayFileEventHandler PlayFile;
        public event PauseFileEventHandler PauseFile;
        public event StopFileEventHandler StopFile;
        public event CloseFileEventHandler CloseFile;
        public event ErrorEventHandler Error;

        protected virtual void OnOpenFile(OpenFileEventArgs oea)
        {
            OpenFile?.Invoke(this, oea);
        }

        protected virtual void OnPlayFile(PlayFileEventArgs pea)
        {
            PlayFile?.Invoke(this, pea);
        }

        protected virtual void OnPauseFile(PauseFileEventArgs paea)
        {
            PauseFile?.Invoke(this, paea);
        }

        protected virtual void OnStopFile(StopFileEventArgs sea)
        {
            StopFile?.Invoke(this, sea);
        }

        protected virtual void OnCloseFile(CloseFileEventArgs cea)
        {
            CloseFile?.Invoke(this, cea);
        }

        protected virtual void OnError(ErrorEventArgs eea)
        {
            Error?.Invoke(this, eea);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}