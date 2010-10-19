using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcTvSeason : XbmcVideo
    {
        #region Private variables

        #endregion

        #region Public variables

        #endregion

        #region Constructors

        internal XbmcTvSeason(int id)
            : base(id)
        {
            // TODO: XbmcTvSeason.ctor()
        }

        #endregion

        #region Internal static functions

        internal static new XbmcTvSeason FromJson(JObject obj)
        {
            // TODO: XbmcTvSeason.FromJson()
            throw new NotImplementedException();
        }

        #endregion
    }
}
