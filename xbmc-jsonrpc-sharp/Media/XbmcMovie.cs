using System;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace XBMC.JsonRpc
{
    public class XbmcMovie : XbmcVideo
    {
        #region Hidden properties of XbmcVideo

        private new string ShowTitle
        {
            get { return string.Empty; }
        }

        private new int Season
        {
            get { return -1; }
        }

        private new int EpisodeCount
        {
            get { return -1; }
        }

        private new DateTime Premiered
        {
            get { return new DateTime(); }
        }

        private new DateTime FirstAired
        {
            get { return new DateTime(); }
        }

        private new string Artist
        {
            get { return string.Empty; }
        }

        private new string Album
        {
            get { return string.Empty; }
        }

        #endregion

        #region Internal variables

        internal static new string[] Fields
        {
            get { return (fields != null ? fields : new string[0]); }
        }

        #endregion

        #region Constructors

        static XbmcMovie()
        {
            fields = new string[] { "title", "genre", "year", "rating", "director", "file",
                                    "trailer", "tagline", "plot", "plotoutline", "originaltitle", 
                                    "lastplayed", "duration", "playcount", "writer", "studio", 
                                    "mpaa", "movieid" };
        }

        private XbmcMovie(int id, string thumbnail, string fanart, string file,
                          string title, string genre, int year, double rating, string director,
                          string trailer, string tagline, string plot, string outline, string originalTitle,
                          string lastPlayed, int duration, int playCount, string writer, string studio,
                          string mpaa)
            : base(id, thumbnail, fanart, title, genre, year, rating, playCount, studio, 
                   file, director, trailer, tagline, plot, outline, originalTitle, lastPlayed, duration, writer, mpaa,
                   string.Empty, -1, -1, string.Empty, string.Empty, string.Empty, string.Empty)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentException("file");
            }
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
