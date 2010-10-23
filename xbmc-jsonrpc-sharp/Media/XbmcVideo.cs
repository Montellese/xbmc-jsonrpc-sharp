using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcVideo : XbmcMedia
    {
        #region Private variables

        protected string title;
        protected string genre;
        protected int year;
        protected double rating;
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
        protected int episodeCount;
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

        public string Title
        {
            get { return this.title; }
        }

        public string Genre
        {
            get { return this.genre; }
        }

        public int Year
        {
            get { return this.year; }
        }

        public double Rating
        {
            get { return this.rating; }
        }

        public int PlayCount
        {
            get { return this.playCount; }
        }

        public string Studio
        {
            get { return this.studio; }
        }

        public string File
        {
            get { return this.file; }
        }

        public string Director
        {
            get { return this.director; }
        }

        public string Trailer
        {
            get { return this.trailer; }
        }

        public string Tagline
        {
            get { return this.tagline; }
        }

        public string Plot
        {
            get { return this.plot; }
        }

        public string Outline
        {
            get { return this.outline; }
        }

        public string OriginalTitle
        {
            get { return this.originalTitle; }
        }

        public DateTime LastPlayed
        {
            get { return this.lastPlayed; }
        }

        public TimeSpan Duration
        {
            get { return this.duration; }
        }

        public string Writer
        {
            get { return this.writer; }
        }

        public string Mpaa
        {
            get { return this.mpaa; }
        }

        public string ShowTitle
        {
            get { return this.showTitle; }
        }

        public int Season
        {
            get { return this.season; }
        }

        public int EpisodeCount
        {
            get { return this.episodeCount; }
        }

        public DateTime Premiered
        {
            get { return this.premiered; }
        }

        public DateTime FirstAired
        {
            get { return this.firstAired; }
        }

        public string Artist
        {
            get { return this.artist; }
        }

        public string Album
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
            : base(id, thumbnail, fanart)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("title");
            }

            this.title = title;
            this.genre = genre;
            this.year = year;
            this.rating = rating;
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
            this.episodeCount = episodeCount;
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
