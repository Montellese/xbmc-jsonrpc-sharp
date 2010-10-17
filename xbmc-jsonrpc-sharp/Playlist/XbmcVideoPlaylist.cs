using System;

namespace XBMC.JsonRpc
{
    public class XbmcVideoPlaylist : XbmcMediaPlaylist
    {
        #region Constructor

        internal XbmcVideoPlaylist(JsonRpcClient client)
            : base("VideoPlaylist", client)
        { }

        #endregion

        #region JSON RPC Calls

        #endregion
    }
}
