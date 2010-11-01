using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcTvEpisode : XbmcVideo
    {
        #region Hidden properties of XbmcVideo

        private new string Genre
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

        private new string Outline
        {
            get { return string.Empty; }
        }

        private new string OriginalTitle
        {
            get { return string.Empty; }
        }

        private new int Episodes
        {
            get { return -1; }
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

        #region Public variables

        public int Number
        {
            get { return this.episodes; }
        }

        #endregion

        #region Constructors

        static XbmcTvEpisode()
        {
            fields = new string[] { "title", "year", "rating", 
                                    "director", "plot", "lastplayed", "showtitle", "firstaired", 
                                    "duration", "season", "episode", "playcount", "writer",
                                    "studio", "mpaa", "premiered", "episodeid" };
        }

        private XbmcTvEpisode(int id, string thumbnail, string fanart, string file, 
                              string title, int year, double rating, string director,
                              string plot, string lastPlayed, string showTitle, string firstAired, int duration,
                              int season, int episode, int playCount, string writer, string studio,
                              string mpaa, string premiered)
            : base(id, thumbnail, fanart, title, string.Empty, year, rating, playCount, studio,
                   file, director, string.Empty, string.Empty, plot, string.Empty, string.Empty, lastPlayed, duration, writer, mpaa,
                   showTitle, season, episode, premiered, firstAired, string.Empty, string.Empty)
        {
            if (string.IsNullOrEmpty(showTitle))
            {
                throw new ArgumentException("showTitle");
            }
            if (season < 0)
            {
                throw new ArgumentException("season");
            }
            if (episode < 0)
            {
                throw new ArgumentException("episode");
            }
        }

        #endregion

        #region Internal static functions

        internal static new XbmcTvEpisode FromJson(JObject obj)
        {
            if (obj == null)
            {
                return null;
            }

            try 
            {
                return new XbmcTvEpisode(JsonRpcClient.GetField<int>(obj, "episodeid"),
                                         JsonRpcClient.GetField<string>(obj, "thumbnail"),
                                         JsonRpcClient.GetField<string>(obj, "fanart"),
                                         JsonRpcClient.GetField<string>(obj, "file"),
                                         JsonRpcClient.GetField<string>(obj, "title"),
                                         JsonRpcClient.GetField<int>(obj, "year"),
                                         JsonRpcClient.GetField<double>(obj, "rating"),
                                         JsonRpcClient.GetField<string>(obj, "director", string.Empty),
                                         JsonRpcClient.GetField<string>(obj, "plot", string.Empty),
                                         JsonRpcClient.GetField<string>(obj, "lastplayed", string.Empty),
                                         JsonRpcClient.GetField<string>(obj, "showtitle"),
                                         JsonRpcClient.GetField<string>(obj, "firstaired"),
                                         JsonRpcClient.GetField<int>(obj, "duration"),
                                         JsonRpcClient.GetField<int>(obj, "season"),
                                         JsonRpcClient.GetField<int>(obj, "episode"),
                                         JsonRpcClient.GetField<int>(obj, "playcount"),
                                         JsonRpcClient.GetField<string>(obj, "writer", string.Empty),
                                         JsonRpcClient.GetField<string>(obj, "studio", string.Empty),
                                         JsonRpcClient.GetField<string>(obj, "mpaa", string.Empty),
                                         JsonRpcClient.GetField<string>(obj, "premiered", string.Empty));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
