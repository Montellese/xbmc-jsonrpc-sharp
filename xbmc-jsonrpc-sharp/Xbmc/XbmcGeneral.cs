using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcGeneral : XbmcJsonRpcNamespace
    {
        #region Private variables

        private XbmcSystem system;

        #endregion

        #region Public variables

        public string BuildVersion
        {
            get { return this.system.GetInfoLabel("System.BuildVersion"); }
        }

        public DateTime BuildDate
        {
            get { return DateTime.Parse(this.system.GetInfoLabel("System.BuildDate")); }
        }

        #endregion

        #region Constructor

        internal XbmcGeneral(JsonRpcClient client)
            : base(client)
        { 
            this.system = new XbmcSystem(client);
        }

        #endregion

        #region JSON RPC Calls

        public int GetVolume()
        {
            return (int)this.client.Call("XBMC.GetVolume");
        }

        public bool SetVolume(int value)
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 100)
            {
                value = 100;
            }

            return (this.client.Call("XBMC.SetVolume", value) != null);
        }

        public int ToggleMute()
        {
            return (int)this.client.Call("XBMC.ToggleMute");
        }

        public bool Log(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException();
            }

            return (this.client.Call("XBMC.Log", message) != null);
        }

        public bool Log(string message, XbmcLogLevel logLevel)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException();
            }

            JObject args = new JObject();
            args.Add(new JProperty("message", message));
            args.Add(new JProperty("level", logLevel.ToString().ToLowerInvariant()));

            return (this.client.Call("XBMC.Log", args) != null);
        }

        public bool StartSlideshow(string directory)
        {
            if (string.IsNullOrEmpty(directory))
            {
                throw new ArgumentException();
            }

            return (this.client.Call("XBMC.StartSlideshow", directory) != null);
        }

        public bool StartSlideshow(string directory, bool random, bool recursive)
        {
            if (string.IsNullOrEmpty(directory))
            {
                throw new ArgumentException();
            }

            JObject args = new JObject();
            args.Add(new JProperty("directory", directory));
            args.Add(new JProperty("random", random));
            args.Add(new JProperty("recursive", recursive));

            return (this.client.Call("XBMC.StartSlideshow", args) != null);
        }

        public bool Play(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentException("file");
            }

            JObject args = new JObject();
            args.Add(new JProperty("file", file));

            return (this.client.Call("XBMC.Play", args) != null);
        }

        public bool Play(XbmcArtist artist)
        {
            if (artist == null) {
                throw new ArgumentNullException("artist");
            }
            if (artist.Id < 0)
            {
                throw new ArgumentException("Invalid artist ID");
            }

            JObject args = new JObject();
            args.Add(new JProperty("artistid", artist.Id));

            return (this.client.Call("XBMC.Play", args) != null);
        }

        public bool Play(XbmcAlbum album)
        {
            if (album == null)
            {
                throw new ArgumentNullException("album");
            }
            if (album.Id < 0)
            {
                throw new ArgumentException("Invalid album ID");
            }

            JObject args = new JObject();
            args.Add(new JProperty("albumid", album.Id));

            return (this.client.Call("XBMC.Play", args) != null);
        }

        public bool Play(XbmcSong song)
        {
            if (song == null)
            {
                throw new ArgumentNullException("song");
            }
            if (song.Id < 0)
            {
                throw new ArgumentException("Invalid song ID");
            }

            JObject args = new JObject();
            args.Add(new JProperty("songid", song.Id));

            return (this.client.Call("XBMC.Play", args) != null);
        }

        public bool Play(XbmcMusicVideo musicVideo)
        {
            if (musicVideo == null)
            {
                throw new ArgumentNullException("musicVideo");
            }
            if (musicVideo.Id < 0)
            {
                throw new ArgumentException("Invalid musicVideo ID");
            }

            JObject args = new JObject();
            args.Add(new JProperty("musicvideoid", musicVideo.Id));

            return (this.client.Call("XBMC.Play", args) != null);
        }

        public bool Play(XbmcTvEpisode episode)
        {
            if (episode == null)
            {
                throw new ArgumentNullException("episode");
            }
            if (episode.Id < 0)
            {
                throw new ArgumentException("Invalid episode ID");
            }

            JObject args = new JObject();
            args.Add(new JProperty("episodeid", episode.Id));

            return (this.client.Call("XBMC.Play", args) != null);
        }

        public bool Play(XbmcMovie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException("movie");
            }
            if (movie.Id < 0)
            {
                throw new ArgumentException("Invalid movie ID");
            }

            JObject args = new JObject();
            args.Add(new JProperty("movieid", movie.Id));

            return (this.client.Call("XBMC.Play", args) != null);
        }

        public bool Quit()
        {
            return (this.client.Call("XBMC.Quit") != null);
        }

        #endregion

        #region Helper functions

        #endregion
    }
}
