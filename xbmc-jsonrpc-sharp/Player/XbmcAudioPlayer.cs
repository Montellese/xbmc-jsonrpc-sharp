using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcAudioPlayer : XbmcMediaPlayer
    {
        #region Constructor

        internal XbmcAudioPlayer(JsonRpcClient client)
            : base("AudioPlayer", "MusicPlayer", client)
        { }

        #endregion

        #region JSON RPC Calls

        public virtual bool Record()
        {
            return (this.client.Call("AudioPlayer.Record") != null);
        }

        #endregion

        #region JSON RPC Info Labels

        public virtual int Bitrate
        {
            get { return base.getInfo<int>("MusicPlayer.BitRate"); }
        }

        public virtual int Channels
        {
            get { return base.getInfo<int>("MusicPlayer.Channels"); }
        }

        public virtual string Codec
        {
            get { return base.getInfo<string>("MusicPlayer.Codec"); }
        }

        #endregion

        #region Helper functions

        #endregion
    }
}
