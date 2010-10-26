using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcVideo : XbmcPlayable
    {
        #region Private variables

        protected int playCount;
        protected string studio;

        protected string file;

        protected string director;
        protected string trailer;
        protected string tagline;
        protected string plot;
        protected string outline;
        protected string originalTitle;
        protected DateTime lastPlayed;
        protected TimeSpan duration;
        protected string writer;
        protected string mpaa;

        protected string showTitle;
        protected int season;
        protected int episodes;
        protected DateTime premiered;
        protected DateTime firstAired;

        protected string artist;
        protected string album;

        #endregion

        #region Internal variables

        internal static new string[] Fields
        {
            get { return (fields != null ? fields : new string[0]); }
        }

        #endregion

        #region Public variables

        public virtual int PlayCount
        {
            get { return this.playCount; }
        }

        public virtual string Studio
        {
            get { return this.studio; }
        }

        public virtual string File
        {
            get { return this.file; }
        }

        public virtual string Director
        {
            get { return this.director; }
        }

        public virtual string Trailer
        {
            get { return this.trailer; }
        }

        public virtual string Tagline
        {
            get { return this.tagline; }
        }

        public virtual string Plot
        {
            get { return this.plot; }
        }

        public virtual string Outline
        {
            get { return this.outline; }
        }

        public virtual string OriginalTitle
        {
            get { return this.originalTitle; }
        }

        public virtual DateTime LastPlayed
        {
            get { return this.lastPlayed; }
        }

        public virtual TimeSpan Duration
        {
            get { return this.duration; }
        }

        public virtual string Writer
        {
            get { return this.writer; }
        }

        public virtual string Mpaa
        {
            get { return this.mpaa; }
        }

        public virtual string ShowTitle
        {
            get { return this.showTitle; }
        }

        public virtual int Season
        {
            get { return this.season; }
        }

        public virtual int Episodes
        {
            get { return this.episodes; }
        }

        public virtual DateTime Premiered
        {
            get { return this.premiered; }
        }

        public virtual DateTime FirstAired
        {
            get { return this.firstAired; }
        }

        public virtual string Artist
        {
            get { return this.artist; }
        }

        public virtual string Album
        {
            get { return this.album; }
        }

        #endregion

        #region Constructors

        static XbmcVideo()
        {
            fields = new string[] { "title", "artist", "genre", "year", "rating", 
                                    "director", "trailer", "tagline", "plot", "plotoutline",
                                    "originaltitle", "lastplayed", "showtitle", "firstaired", "duration",
                                    "season", "episode", "runtime", "playcount", "writer",
                                    "studio", "mpaa", "premiered", "album" };
        }

        protected XbmcVideo(int id, string thumbnail, string fanart,
                          string title, string genre, int year, double rating, int playCount, string studio, 
                          string file, string director, string trailer, string tagline, string plot, 
                          string outline, string originalTitle, string lastPlayed, int duration, string writer,
                          string mpaa, string showTitle, int season, int episodeCount, string premiered,
                          string firstAired, string artist, string album)
            : base(id, thumbnail, fanart,
                   title, genre, year, rating)
        {
            this.playCount = playCount;
            this.studio = studio;

            this.file = file;
            this.director = director;
            this.trailer = trailer;
            this.tagline = tagline;
            this.plot = plot;
            this.outline = outline;
            this.originalTitle = originalTitle;
            this.lastPlayed = !string.IsNullOrEmpty(lastPlayed) ? DateTime.Parse(lastPlayed) : new DateTime();
            this.duration = TimeSpan.FromSeconds(duration);
            this.writer = writer;
            this.mpaa = mpaa;

            this.showTitle = showTitle;
            this.firstAired = !string.IsNullOrEmpty(firstAired) ? DateTime.Parse(firstAired) : new DateTime();
            this.season = season;
            this.episodes = episodeCount;
            this.premiered = !string.IsNullOrEmpty(premiered) ? DateTime.Parse(premiered) : new DateTime();

            this.artist = artist;
            this.album = album;
        }

        #endregion

        #region Internal static functions

        internal static XbmcVideo FromJson(JObject obj)
        {
            if (obj == null)
            {
                return null;
            }

            // If there is a showtitle field and it has a value, the retrieved item is a XbmcTvEpisode
            if (obj["showtitle"] != null && !string.IsNullOrEmpty(JsonRpcClient.GetField<string>(obj, "showtitle")))
            {
                return XbmcTvEpisode.FromJson(obj);
            }
            // If there is a artist field and it has a vaue, the retrieved item is a XbmcMusicVideo
            if (obj["artist"] != null && !string.IsNullOrEmpty(JsonRpcClient.GetField<string>(obj, "artist")))
            {
                return XbmcMusicVideo.FromJson(obj);
            }
            
            // Otherwise it must be a movie
            return XbmcMovie.FromJson(obj);
        }

        #endregion
    }
}
