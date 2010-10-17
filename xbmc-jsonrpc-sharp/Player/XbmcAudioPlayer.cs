using System;

namespace XBMC.JsonRpc
{
    public class XbmcAudioPlayer : XbmcMediaPlayer
    {
        #region Constructor

        internal XbmcAudioPlayer(JsonRpcClient client)
            : base("AudioPlayer", client)
        { }

        #endregion

        #region JSON RPC Calls

        public virtual bool Record()
        {
            return (this.client.Call("AudioPlayer.Record") != null);
        }

        #endregion
    }
}
