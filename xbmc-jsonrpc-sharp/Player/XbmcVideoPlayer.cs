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
    }
}
