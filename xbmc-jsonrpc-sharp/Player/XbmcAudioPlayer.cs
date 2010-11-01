using System;

namespace XBMC.JsonRpc
{
    public class XbmcAudioPlayer : XbmcMediaPlayer
    {
        #region Public variables

        public XbmcPlayerState State
        {
            get
            {
                return base.state;
            }
        }

        #endregion

        #region Constructor

        internal XbmcAudioPlayer(JsonRpcClient client)
            : base("AudioPlayer", "MusicPlayer", client)
        { }

        #endregion

        #region JSON RPC Calls

        public bool BigSkipBackward()
        {
            return base.bigSkipBackward();
        }

        public bool BigSkipForward()
        {
            return base.bigSkipForward();
        }

        public bool SmallSkipBackward()
        {
            return base.smallSkipBackward();
        }

        public bool SmallSkipForward()
        {
            return base.smallSkipForward();
        }

        public bool Rewind()
        {
            return base.rewind();
        }

        public bool Forward()
        {
            return base.forward();
        }

        public XbmcPlayerState GetTime(out TimeSpan currentPosition, out TimeSpan totalLength)
        {
            return base.getTime(out currentPosition, out totalLength);
        }

        public int GetPercentage()
        {
            return base.getPercentage();
        }

        public bool SeekTime(int seconds)
        {
            return base.seekTime(seconds);
        }

        public bool SeekTime(TimeSpan position)
        {
            return this.SeekTime(Convert.ToInt32(position.TotalSeconds));
        }

        public bool SeekPercentage(int percentage)
        {
            return base.seekPercentage(percentage);
        }

        public virtual bool Record()
        {
            this.client.LogMessage("XbmcAudioPlayer.Record()");

            return (this.client.Call("AudioPlayer.Record") != null);
        }

        #endregion

        #region JSON RPC Info Labels

        public virtual int Bitrate
        {
            get
            {
                this.client.LogMessage("XbmcAudioPlayer.Bitrate");

                return base.getInfo<int>("MusicPlayer.BitRate");
            }
        }

        public virtual int Channels
        {
            get
            {
                this.client.LogMessage("XbmcAudioPlayer.Channels");

                return base.getInfo<int>("MusicPlayer.Channels");
            }
        }

        public virtual string Codec
        {
            get
            {
                this.client.LogMessage("XbmcAudioPlayer.Codec");

                return base.getInfo<string>("MusicPlayer.Codec");
            }
        }

        #endregion

        #region Helper functions

        #endregion
    }
}
