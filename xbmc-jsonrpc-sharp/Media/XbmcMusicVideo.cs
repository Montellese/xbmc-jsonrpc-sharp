using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcMusicVideo : XbmcVideo
    {
        #region Hidden properties of XbmcVideo

        private new string Trailer
        {
            get { return string.Empty; }
        }

        private new string Tagline
        {
            get { return string.Empty; }
        }

        private new string Outline
        {
            get { return string.Empty; }
        }

        private new string OriginalTitle
        {
            get { return string.Empty; }
        }

        private new string Writer
        {
            get { return string.Empty; }
        }

        private new string Mpaa
        {
            get { return string.Empty; }
        }

        private new string ShowTitle
        {
            get { return string.Empty; }
        }

        private new int Season
        {
            get { return -1; }
        }

        private new int Episodes
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

        #endregion

        #region Internal variables

        internal static new string[] Fields
        {
            get { return (fields != null ? fields : new string[0]); }
        }

        #endregion

        #region Constructors

        static XbmcMusicVideo()
        {
            fields = new string[] { "title", "artist", "genre", "year", "rating", "file",
                                    "director", "plot", "lastplayed", "duration",
                                    "playcount", "studio", "album", "musicvideoid" };
        }

        private XbmcMusicVideo(int id, string thumbnail, string fanart, string file,
                               string title, string genre, int year, double rating, string director,
                               string plot, string lastPlayed, int duration, int playCount, string studio,
                               string artist, string album)
            : base(id, thumbnail, fanart, title, genre, year, rating, playCount, studio,
                   file, director, string.Empty, string.Empty, plot, string.Empty, string.Empty, lastPlayed, duration, string.Empty, string.Empty,
                   string.Empty, -1, -1, string.Empty, string.Empty, artist, album)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentException("file");
            }
            if (string.IsNullOrEmpty(artist))
            {
                throw new ArgumentException("artist");
            }
        }

        #endregion

        #region Internal static functions

        internal static new XbmcMusicVideo FromJson(JObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            return new XbmcMusicVideo(JsonRpcClient.GetField<int>(obj, "musicvideoid"),
                                 JsonRpcClient.GetField<string>(obj, "thumbnail"),
                                 JsonRpcClient.GetField<string>(obj, "fanart"),
                                 JsonRpcClient.GetField<string>(obj, "file"),
                                 JsonRpcClient.GetField<string>(obj, "title"),
                                 JsonRpcClient.GetField<string>(obj, "genre", string.Empty),
                                 JsonRpcClient.GetField<int>(obj, "year"),
                                 JsonRpcClient.GetField<double>(obj, "rating"),
                                 JsonRpcClient.GetField<string>(obj, "director", string.Empty),
                                 JsonRpcClient.GetField<string>(obj, "plot", string.Empty),
                                 JsonRpcClient.GetField<string>(obj, "lastplayed", string.Empty),
                                 JsonRpcClient.GetField<int>(obj, "duration"),
                                 JsonRpcClient.GetField<int>(obj, "playcount"),
                                 JsonRpcClient.GetField<string>(obj, "studio", string.Empty),
                                 JsonRpcClient.GetField<string>(obj, "artist"),
                                 JsonRpcClient.GetField<string>(obj, "album", string.Empty));
        }

        #endregion
    }
}
