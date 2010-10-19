using System;

namespace XBMC.JsonRpc
{
    public class XbmcMediaPlaylist : XbmcJsonRpcNamespace
    {
        #region Private variables

        private string playlistName;

        #endregion

        #region Constructor

        protected XbmcMediaPlaylist(string playlistName, JsonRpcClient client)
            : base(client)
        {
            if (string.IsNullOrEmpty(playlistName))
            {
                throw new ArgumentException();
            }

            this.playlistName = playlistName;
        }

        #endregion

        #region JSON RPC Call

        public virtual bool Play()
        {
            return (this.client.Call(this.playlistName + ".Play") != null);
        }

        public virtual bool SkipPrevious()
        {
            return (this.client.Call(this.playlistName + ".SkipPrevious") != null);
        }

        public virtual bool SkipNext()
        {
            return (this.client.Call(this.playlistName + ".SkipNext") != null);
        }

        public virtual bool GetItems()
        {
            // TODO: MediaPlaylist.GetItems()
            throw new NotImplementedException();
        }

        public virtual bool Add()
        {
            // TODO: MediaPlaylist.Add()
            throw new NotImplementedException();
        }

        public virtual bool Clear()
        {
            return (this.client.Call(this.playlistName + ".Clear") != null);
        }

        public virtual bool Shuffle()
        {
            return (this.client.Call(this.playlistName + ".Shuffle") != null);
        }

        public virtual bool UnShuffle()
        {
            return (this.client.Call(this.playlistName + ".UnShuffle") != null);
        }

        #endregion
    }
}
