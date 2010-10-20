using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcTvEpisode : XbmcVideo
    {
        #region Private variables

        #endregion

        #region Public variables

        #endregion

        #region Constructors

        private XbmcTvEpisode(int id, string thumbnail, string fanart)
            : base(id, thumbnail, fanart)
        {
            // TODO: XbmcTvEpisode.ctor()
        }

        #endregion

        #region Internal static functions

        internal static new XbmcTvEpisode FromJson(JObject obj)
        {
            // TODO: XbmcTvEpisode.FromJson()
            throw new NotImplementedException();
        }

        #endregion
    }
}
