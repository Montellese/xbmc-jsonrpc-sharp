using System;
using System.Collections.Generic;

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
            // TODO: XbmcVideoLibrary.GetMovies()
            throw new NotImplementedException();
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
