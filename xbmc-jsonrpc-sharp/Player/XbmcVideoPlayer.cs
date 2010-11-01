using System;

namespace XBMC.JsonRpc
{
    public class XbmcVideoPlayer : XbmcMediaPlayer
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

        internal XbmcVideoPlayer(JsonRpcClient client)
            : base("VideoPlayer", client)
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

        #endregion

        #region JSON RPC Info Labels

        public virtual string VideoCodec
        {
            get
            {
                this.client.LogMessage("XbmcVideoPlayer.VideoCodec");

                return base.getInfo<string>("VideoPlayer.VideoCodec");
            }
        }

        public virtual int Resolution
        {
            get
            {
                this.client.LogMessage("XbmcVideoPlayer.Resolution");

                return base.getInfo<int>("VideoPlayer.VideoResolution");
            }
        }

        public virtual double AspectRatio
        {
            get
            {
                this.client.LogMessage("XbmcVideoPlayer.AspectRatio");

                return base.getInfo<double>("VideoPlayer.VideoAspect");
            }
        }

        public virtual int AudioChannels
        {
            get
            {
                this.client.LogMessage("XbmcVideoPlayer.AudioChannels");

                return base.getInfo<int>("VideoPlayer.AudioChannels");
            }
        }

        public virtual string AudioCodec
        {
            get
            {
                this.client.LogMessage("XbmcVideoPlayer.AudioCodec");

                return base.getInfo<string>("VideoPlayer.AudioCodec");
            }
        }

        #endregion
    }
}
