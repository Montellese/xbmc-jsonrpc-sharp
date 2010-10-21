using System;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace XBMC.JsonRpc
{
    public class XbmcMovie : XbmcVideo
    {
        #region Private variables

        string file;

        private string title;
        private string genre;
        private int year;
        private double rating;
        private string director;
        private string trailer;
        private string tagline;
        private string plot;
        private string outline;
        private string originalTitle;
        private DateTime lastPlayed;
        private TimeSpan duration;
        private int playCount;
        private string writer;
        private string studio;
        private string mpaa;

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

        public int PlayCount
        {
            get { return this.playCount; }
        }

        public string Writer
        {
            get { return this.writer; }
        }

        public string Studio
        {
            get { return this.studio; }
        }

        public string Mpaa
        {
            get { return this.mpaa; }
        }

        #endregion

        #region Constructors

        static XbmcMovie()
        {
            fields = new string[] { "title", "genre", "year", "rating", "director", 
                                    "trailer", "tagline", "plot", "plotoutline", "originaltitle", 
                                    "lastplayed", "duration", "playcount", "writer", "studio", 
                                    "mpaa", "movieid" };
        }

        private XbmcMovie(int id, string thumbnail, string fanart, string file,
                          string title, string genre, int year, double rating, string director,
                          string trailer, string tagline, string plot, string outline, string originalTitle,
                          string lastPlayed, int duration, int playCount, string writer, string studio,
                          string mpaa)
            : base(id, thumbnail, fanart)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentException("file");
            }
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("title");
            }

            DateTimeFormatInfo format = (DateTimeFormatInfo)DateTimeFormatInfo.InvariantInfo.Clone();
            format.FullDateTimePattern = "yyyy-MM-dd HH:mm:ss";

            this.file = file;
            this.title = title;
            this.genre = genre;
            this.year = year;
            this.rating = rating;
            this.director = director;
            this.trailer = trailer;
            this.tagline = tagline;
            this.plot = plot;
            this.outline = outline;
            this.originalTitle = originalTitle;
            this.lastPlayed = !string.IsNullOrEmpty(lastPlayed) ? DateTime.ParseExact(lastPlayed, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture) : new DateTime();
            this.duration = TimeSpan.FromSeconds(duration);
            this.playCount = playCount;
            this.writer = writer;
            this.studio = studio;
            this.mpaa = mpaa;
        }

        #endregion

        #region Internal static functions

        internal static new XbmcMovie FromJson(JObject obj)
        {
            if (obj == null)
            {
                return null;
            }

            return new XbmcMovie(JsonRpcClient.GetField<int>(obj, "movieid"),
                                 JsonRpcClient.GetField<string>(obj, "thumbnail"),
                                 JsonRpcClient.GetField<string>(obj, "fanart"),
                                 JsonRpcClient.GetField<string>(obj, "file"),
                                 JsonRpcClient.GetField<string>(obj, "title"),
                                 JsonRpcClient.GetField<string>(obj, "genre", string.Empty),
                                 JsonRpcClient.GetField<int>(obj, "year"),
                                 JsonRpcClient.GetField<double>(obj, "rating"),
                                 JsonRpcClient.GetField<string>(obj, "director", string.Empty),
                                 JsonRpcClient.GetField<string>(obj, "trailer", string.Empty),
                                 JsonRpcClient.GetField<string>(obj, "tagline", string.Empty),
                                 JsonRpcClient.GetField<string>(obj, "plot", string.Empty),
                                 JsonRpcClient.GetField<string>(obj, "plotoutline", string.Empty),
                                 JsonRpcClient.GetField<string>(obj, "originaltitle", string.Empty),
                                 JsonRpcClient.GetField<string>(obj, "lastplayed", string.Empty),
                                 JsonRpcClient.GetField<int>(obj, "duration"),
                                 JsonRpcClient.GetField<int>(obj, "playcount"),
                                 JsonRpcClient.GetField<string>(obj, "writer", string.Empty),
                                 JsonRpcClient.GetField<string>(obj, "studio", string.Empty),
                                 JsonRpcClient.GetField<string>(obj, "mpaa", string.Empty));
        }

        #endregion
    }
}
