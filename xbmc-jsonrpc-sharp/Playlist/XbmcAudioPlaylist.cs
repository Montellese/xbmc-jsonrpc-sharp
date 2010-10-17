using System;

namespace XBMC.JsonRpc
{
    public class XbmcAudioPlaylist : XbmcMediaPlaylist
    {
        #region Constructor

        internal XbmcAudioPlaylist(JsonRpcClient client)
            : base("AudioPlaylist", client)
        { }

        #endregion

        #region JSON RPC Calls

        #endregion
    }
}
