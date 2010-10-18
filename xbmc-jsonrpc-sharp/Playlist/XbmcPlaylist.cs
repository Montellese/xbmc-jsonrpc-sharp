using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcPlaylist : XbmcJsonRpcNamespace
    {
        #region Private variables

        private XbmcAudioPlaylist audio;
        private XbmcVideoPlaylist video;

        #endregion

        #region Public variables

        public XbmcAudioPlaylist Audio
        {
            get { return this.audio; }
        }

        public XbmcVideoPlaylist Video
        {
            get { return this.video; }
        }

        #endregion

        #region Constructor

        internal XbmcPlaylist(JsonRpcClient client)
            : base(client)
        {
            this.audio = new XbmcAudioPlaylist(client);
            this.video = new XbmcVideoPlaylist(client);
        }

        #endregion

        #region JSON RPC Call

        public bool Create(string playlist)
        {
            if (string.IsNullOrEmpty(playlist))
            {
                return false;
            }

            return (this.client.Call("Playlist.Create", this.getPlaylistArgument(playlist)) != null);
        }

        public bool Destroy(string playlist)
        {
            if (string.IsNullOrEmpty(playlist))
            {
                return false;
            }

            return (this.client.Call("Playlist.Destroy", this.getPlaylistArgument(playlist)) != null);
        }

        public bool GetItems()
        {
            // TODO: Playlist.GetItems()
            throw new NotSupportedException();
        }

        public bool GetItems(string playlist)
        {
            // TODO: Playlist.GetItems(playlist)
            throw new NotSupportedException();
        }

        public bool Add(string playlist, string file)
        {
            // TODO: Playlist.Add
            throw new NotSupportedException();
        }

        public bool Remove(string playlist, int item)
        {
            // TODO: Playlist.Remove
            throw new NotSupportedException();
        }

        public bool Swap(string playlist, int item1, int item2)
        {
            if (string.IsNullOrEmpty(playlist))
            {
                return false;
            }

            // TODO: Playlist.Swap
            throw new NotSupportedException();
        }

        public bool Shuffle(string playlist)
        {
            if (string.IsNullOrEmpty(playlist))
            {
                return false;
            }

            return (this.client.Call("Playlist.Shuffle", this.getPlaylistArgument(playlist)) != null);
        }

        public bool UnShuffle(string playlist)
        {
            if (string.IsNullOrEmpty(playlist))
            {
                return false;
            }

            return (this.client.Call("Playlist.UnShuffle", this.getPlaylistArgument(playlist)) != null);
        }

        #endregion

        #region Helper functions

        private JObject getPlaylistArgument(string playlist)
        {
            JObject args = new JObject();
            args.Add(new JProperty("playlist", playlist));

            return args;
        }

        #endregion
    }
}
