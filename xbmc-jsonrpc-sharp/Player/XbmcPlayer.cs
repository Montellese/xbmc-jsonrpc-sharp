using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcPlayer : XbmcJsonRpcNamespace
    {
        #region Private variables

        private XbmcAudioPlayer audio;
        private XbmcVideoPlayer video;
        private XbmcPicturePlayer pictures;

        #endregion

        #region Public variables

        public XbmcAudioPlayer Audio
        {
            get 
            {
                bool audioPlayer, videoPlayer, picturePlayer;
                if (!this.GetActivePlayers(out videoPlayer, out audioPlayer, out picturePlayer) || !audioPlayer)
                {
                    return null;
                }

                return this.audio;
            }
        }

        public XbmcVideoPlayer Video
        {
            get
            {
                bool audioPlayer, videoPlayer, picturePlayer;
                if (!this.GetActivePlayers(out videoPlayer, out audioPlayer, out picturePlayer) || !videoPlayer)
                {
                    return null;
                }

                return this.video;
            }
        }

        public XbmcPicturePlayer Pictures
        {
            get
            {
                bool audioPlayer, videoPlayer, picturePlayer;
                if (!this.GetActivePlayers(out videoPlayer, out audioPlayer, out picturePlayer) || !picturePlayer)
                {
                    return null;
                }

                return this.pictures;
            }
        }

        #endregion

        #region Events

        public event EventHandler<XbmcPlayerPlaybackChangedEventArgs> PlaybackStarted;
        public event EventHandler<XbmcPlayerPlaybackPositionChangedEventArgs> PlaybackPaused;
        public event EventHandler<XbmcPlayerPlaybackPositionChangedEventArgs> PlaybackResumed;
        public event EventHandler<XbmcPlayerPlaybackChangedEventArgs> PlaybackStopped;

        public event EventHandler<XbmcPlayerPlaybackPositionChangedEventArgs> PlaybackSeek;
        public event EventHandler<XbmcPlayerPlaybackChangedEventArgs> PlaybackSpeedChanged;

        #endregion

        #region Constructor

        internal XbmcPlayer(JsonRpcClient client)
            : base(client)
        {
            this.audio = new XbmcAudioPlayer(client);
            this.video = new XbmcVideoPlayer(client);
            this.pictures = new XbmcPicturePlayer(client);
        }

        #endregion

        #region JSON RPC Calls

        public bool GetActivePlayers(out bool video, out bool audio, out bool picture)
        {
            video = false;
            audio = false;
            picture = false;

            JObject query = this.client.Call("Player.GetActivePlayers") as JObject;
            if (query == null)
            {
                return false;
            }

            if (query["video"] != null)
            {
                video = (bool)query["video"];
            }
            if (query["audio"] != null)
            {
                audio = (bool)query["audio"];
            }
            if (query["picture"] != null)
            {
                picture = (bool)query["picture"];
            }

            return true;
        }

        #endregion

        #region Internal functions

        internal void OnPlaybackStarted()
        {
            if (this.PlaybackStarted == null)
            {
                return;
            }

            XbmcMediaPlayer player = this.getActivePlayer();
            if (player == null) 
            {
                return;
            }

            this.PlaybackStarted(this, new XbmcPlayerPlaybackChangedEventArgs(player));
        }

        internal void OnPlaybackPaused()
        {
            if (this.PlaybackPaused == null)
            {
                return;
            }

            XbmcMediaPlayer player = this.getActivePlayer();
            if (player == null) 
            {
                return;
            }

            throw new NotImplementedException();
        }

        internal void OnPlaybackResumed()
        {
            if (this.PlaybackPaused == null)
            {
                return;
            }

            XbmcMediaPlayer player = this.getActivePlayer();
            if (player == null)
            {
                return;
            }

            throw new NotImplementedException();
        }

        internal void OnPlaybackStopped()
        {
            if (this.PlaybackPaused == null)
            {
                return;
            }

            XbmcMediaPlayer player = this.getActivePlayer();
            if (player == null)
            {
                return;
            }

            throw new NotImplementedException();
        }

        internal void OnPlaybackSeek()
        {
            if (this.PlaybackPaused == null)
            {
                return;
            }

            XbmcMediaPlayer player = this.getActivePlayer();
            if (player == null)
            {
                return;
            }

            throw new NotImplementedException();
        }

        internal void OnPlaybackSpeedChanged()
        {
            if (this.PlaybackPaused == null)
            {
                return;
            }

            XbmcMediaPlayer player = this.getActivePlayer();
            if (player == null)
            {
                return;
            }

            throw new NotImplementedException();
        }

        #endregion

        #region Helper functions

        private XbmcMediaPlayer getActivePlayer()
        {
            bool video, audio, picture;
            if (!this.GetActivePlayers(out video, out audio, out picture))
            {
                return null;
            }

            if (video)
            {
                return this.video;
            }
            if (audio)
            {
                return this.audio;
            }
            if (picture)
            {
                return this.pictures;
            }
            
            return null;
        }

        #endregion
    }
}
