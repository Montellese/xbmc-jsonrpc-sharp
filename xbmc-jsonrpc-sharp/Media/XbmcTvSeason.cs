using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcTvSeason : XbmcVideo
    {
        #region Hidden properties of XbmcVideo

        private new int Id
        {
            get { return -1; }
        }

        private new int Year
        {
            get { return -1; }
        }

        private new string File
        {
            get { return string.Empty; }
        }

        private new string Director
        {
            get { return string.Empty; }
        }

        private new string Trailer
        {
            get { return string.Empty; }
        }

        private new string Tagline
        {
            get { return string.Empty; }
        }

        private new string Plot
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

        private new DateTime LastPlayed
        {
            get { return new DateTime(); }
        }

        private new TimeSpan Duration
        {
            get { return new TimeSpan(); }
        }

        private new string Writer
        {
            get { return string.Empty; }
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

        static XbmcTvSeason()
        {
            fields = new string[] { "title", "genre", "rating", "showtitle",
                                    "season", "episode", "playcount", "studio", "mpaa" };
        }

        private XbmcTvSeason(string thumbnail, string fanart,  string title, string genre, double rating, 
                             string showTitle, int season, int episodeCount,
                             int playCount, string studio, string mpaa)
            : base(-1, thumbnail, fanart, title, genre, 0, rating, playCount, studio,
                   string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, -1, string.Empty, mpaa,
                   showTitle, season, episodeCount, string.Empty, string.Empty, string.Empty, string.Empty)
        {
            if (string.IsNullOrEmpty(showTitle))
            {
                throw new ArgumentException("showTitle");
            }
            if (season < 0)
            {
                throw new ArgumentException("season");
            }
        }

        #endregion

        #region Internal static functions

        internal static new XbmcTvSeason FromJson(JObject obj)
        {
            if (obj == null)
            {
                return null;
            }

            try 
            {
                return new XbmcTvSeason(JsonRpcClient.GetField<string>(obj, "thumbnail"),
                                        JsonRpcClient.GetField<string>(obj, "fanart"),
                                        JsonRpcClient.GetField<string>(obj, "title"),
                                        JsonRpcClient.GetField<string>(obj, "genre", string.Empty),
                                        JsonRpcClient.GetField<double>(obj, "rating"),
                                        JsonRpcClient.GetField<string>(obj, "showtitle"),
                                        JsonRpcClient.GetField<int>(obj, "season"),
                                        JsonRpcClient.GetField<int>(obj, "episode"),
                                        JsonRpcClient.GetField<int>(obj, "playcount"),
                                        JsonRpcClient.GetField<string>(obj, "studio", string.Empty),
                                        JsonRpcClient.GetField<string>(obj, "mpaa", string.Empty));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
