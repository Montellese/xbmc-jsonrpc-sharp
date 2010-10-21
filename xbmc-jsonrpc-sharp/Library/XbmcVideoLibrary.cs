using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcVideoLibrary : XbmcMediaLibrary
    {
        #region Constructor

        internal XbmcVideoLibrary(JsonRpcClient client)
            : base("VideoLibrary", client)
        { }

        #endregion

        #region JSON RPC Calls

        public ICollection<XbmcMovie> GetMovies(params string[] fields)
        {
            return this.GetMovies(-1, -1, fields);
        }

        public ICollection<XbmcMovie> GetMovies(int start, int end, params string[] fields)
        {
            JObject args = new JObject();
            if (fields != null && fields.Length > 0)
            {
                string[] fieldCopy = new string[fields.Length + 2];
                fieldCopy[0] = "movieid";
                fieldCopy[1] = "title";
                Array.Copy(fields, 0, fieldCopy, 2, fields.Length);
                args.Add(new JProperty("fields", fieldCopy));
            }
            else
            {
                args.Add(new JProperty("fields", XbmcMovie.Fields));
            }
            if (start >= 0)
            {
                args.Add(new JProperty("start", start));
            }
            if (end >= 0)
            {
                args.Add(new JProperty("end", end));
            }

            JObject query = this.client.Call("VideoLibrary.GetMovies", args) as JObject;
            if (query == null || query["movies"] == null)
            {
                return null;
            }

            List<XbmcMovie> movies = new List<XbmcMovie>();
            foreach (JObject item in (JArray)query["movies"])
            {
                movies.Add(XbmcMovie.FromJson(item));
            }

            return movies;
        }

        public ICollection<XbmcTvShow> GetTvShows(params string[] fields)
        {
            // TODO: XbmcVideoLibrary.GetTvShows()
            throw new NotImplementedException();
        }

        public ICollection<XbmcTvSeason> GetTvSeasons(params string[] fields)
        {
            // TODO: XbmcVideoLibrary.GetTvSeasons()
            throw new NotImplementedException();
        }

        public ICollection<XbmcTvEpisode> GetTvEpisodes(params string[] fields)
        {
            // TODO: XbmcVideoLibrary.GetTvEpisodes()
            throw new NotImplementedException();
        }

        public ICollection<XbmcMusicVideo> GetMusicVideos(params string[] fields)
        {
            // TODO: XbmcVideoLibrary.GetMusicVideos()
            throw new NotImplementedException();
        }

        public ICollection<XbmcMovie> GetRecentlyAddedMovies(params string[] fields)
        {
            // TODO: XbmcVideoLibrary.GetRecentlyAddedMovies()
            throw new NotImplementedException();
        }

        public ICollection<XbmcTvEpisode> GetRecentlyAddedTvEpisodes(params string[] fields)
        {
            // TODO: XbmcVideoLibrary.GetRecentlyAddedTvEpisodes()
            throw new NotImplementedException();
        }

        public ICollection<XbmcMusicVideo> GetRecentlyAddedMusicVideos(params string[] fields)
        {
            // TODO: XbmcVideoLibrary.GetRecentlyAddedMusicVideos()
            throw new NotImplementedException();
        }

        #endregion

        #region Helper functions

        #endregion
    }
}
