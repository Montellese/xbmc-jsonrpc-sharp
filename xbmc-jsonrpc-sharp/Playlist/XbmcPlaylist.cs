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
            this.client.LogMessage("XbmcPlaylist.Create(" + playlist + ")");

            if (string.IsNullOrEmpty(playlist))
            {
                return false;
            }

            return (this.client.Call("Playlist.Create", this.getPlaylistArgument(playlist)) != null);
        }

        public bool Destroy(string playlist)
        {
            this.client.LogMessage("XbmcPlaylist.Destroy(" + playlist + ")");

            if (string.IsNullOrEmpty(playlist))
            {
                return false;
            }

            return (this.client.Call("Playlist.Destroy", this.getPlaylistArgument(playlist)) != null);
        }

        [Obsolete("Use XbmcAudioPlaylist.GetItems() or XbmcVideoPlaylist.GetItems()", true)]
        public bool GetItems()
        {
            this.client.LogErrorMessage("XbmcPlaylist.GetItems() is obsolete");

            throw new NotSupportedException();
        }

        [Obsolete("Use XbmcAudioPlaylist.GetItems() or XbmcVideoPlaylist.GetItems()", true)]
        public bool GetItems(string playlist)
        {
            this.client.LogErrorMessage("XbmcPlaylist.GetItems(playlist) is obsolete");

            throw new NotSupportedException();
        }

        [Obsolete("Use XbmcAudioPlaylist.Add() or XbmcVideoPlaylist.Add()", true)]
        public bool Add(string playlist, string file)
        {
            this.client.LogErrorMessage("XbmcPlaylist.Add() is obsolete");

            throw new NotSupportedException();
        }

        [Obsolete("Use XbmcAudioPlaylist.Remove() or XbmcVideoPlaylist.Remove()", true)]
        public bool Remove(string playlist, int item)
        {
            this.client.LogErrorMessage("XbmcPlaylist.Remove() is obsolete");

            throw new NotSupportedException();
        }

        [Obsolete("Use XbmcAudioPlaylist.Swap() or XbmcVideoPlaylist.Swap()", true)]
        public bool Swap(string playlist, int item1, int item2)
        {
            this.client.LogErrorMessage("XbmcPlaylist.Swap() is obsolete");

            throw new NotSupportedException();
        }

        public bool Shuffle(string playlist)
        {
            this.client.LogMessage("XbmcPlaylist.Shuffle(" + playlist + ")");

            if (string.IsNullOrEmpty(playlist))
            {
                return false;
            }

            return (this.client.Call("Playlist.Shuffle", this.getPlaylistArgument(playlist)) != null);
        }

        public bool UnShuffle(string playlist)
        {
            this.client.LogMessage("XbmcPlaylist.UnShuffle(" + playlist + ")");

            if (string.IsNullOrEmpty(playlist))
            {
                return false;
            }

            return (this.client.Call("Playlist.UnShuffle", this.getPlaylistArgument(playlist)) != null);
        }

        #endregion

        #region JSON RPC Info Labels

        public virtual int Position
        {
            get
            {
                this.client.LogMessage("XbmcPlaylist.Position");

                return base.getInfo<int>("Playlist.Position", -1);
            }
        }

        public virtual int Length
        {
            get
            {
                this.client.LogMessage("XbmcPlaylist.Length");

                return base.getInfo<int>("Playlist.Length", -1);
            }
        }

        public virtual bool Random
        {
            get 
            {
                this.client.LogMessage("XbmcPlaylist.Random");

                string random = base.getInfo<string>("Playlist.Random");
                if (random == "Random")
                {
                    return true;
                }

                return false;
            }
        }

        public virtual XbmcRepeatTypes Repeat
        {
            get
            {
                this.client.LogMessage("XbmcPlaylist.Repeat");

                string repeat = base.getInfo<string>("Playlist.Repeat");
                if (repeat == "One")
                {
                    return XbmcRepeatTypes.One;
                }
                else if (repeat == "All")
                {
                    return XbmcRepeatTypes.All;
                }

                return XbmcRepeatTypes.Off;
            }
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
