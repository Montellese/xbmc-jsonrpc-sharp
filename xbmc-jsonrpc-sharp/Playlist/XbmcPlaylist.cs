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

        #region Events

        public event EventHandler ItemQueued;

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

        [Obsolete("Use XbmcAudioPlaylist.GetItems() or XbmcVideoPlaylist.GetItems()", true)]
        public bool GetItems()
        {
            throw new NotSupportedException();
        }

        [Obsolete("Use XbmcAudioPlaylist.GetItems() or XbmcVideoPlaylist.GetItems()", true)]
        public bool GetItems(string playlist)
        {
            throw new NotSupportedException();
        }

        [Obsolete("Use XbmcAudioPlaylist.Add() or XbmcVideoPlaylist.Add()", true)]
        public bool Add(string playlist, string file)
        {
            throw new NotSupportedException();
        }

        [Obsolete("Use XbmcAudioPlaylist.Remove() or XbmcVideoPlaylist.Remove()", true)]
        public bool Remove(string playlist, int item)
        {
            throw new NotSupportedException();
        }

        [Obsolete("Use XbmcAudioPlaylist.Swap() or XbmcVideoPlaylist.Swap()", true)]
        public bool Swap(string playlist, int item1, int item2)
        {
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

        #region Internal functions

        internal void OnItemQueued()
        {
            if (this.ItemQueued != null)
            {
                this.ItemQueued(this, null);
            }
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
