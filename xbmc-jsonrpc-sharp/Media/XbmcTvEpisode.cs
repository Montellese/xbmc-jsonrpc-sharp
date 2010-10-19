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

        internal XbmcTvEpisode(int id)
            : base(id)
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
