using System;

namespace XBMC.JsonRpc
{
    public class XbmcVideoPlayer : XbmcMediaPlayer
    {
        #region Constructor

        internal XbmcVideoPlayer(JsonRpcClient client)
            : base("VideoPlayer", client)
        { }

        #endregion

        #region JSON RPC Info Labels

        public virtual string VideoCodec
        {
            get { return base.getInfo<string>("VideoPlayer.VideoCodec"); }
        }

        public virtual int Resolution
        {
            get { return base.getInfo<int>("VideoPlayer.VideoResolution"); }
        }

        public virtual double AspectRatio
        {
            get { return base.getInfo<double>("VideoPlayer.VideoAspect"); }
        }

        public virtual int AudioChannels
        {
            get { return base.getInfo<int>("VideoPlayer.AudioChannels"); }
        }

        public virtual string AudioCodec
        {
            get { return base.getInfo<string>("VideoPlayer.AudioCodec"); }
        }

        #endregion
    }
}
