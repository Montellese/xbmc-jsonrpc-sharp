using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcTvShow : XbmcVideo
    {
        #region Private variables

        #endregion

        #region Public variables

        #endregion

        #region Constructors

        internal XbmcTvShow(int id)
            : base(id)
        {
            // TODO: XbmcTvShow.ctor()
        }

        #endregion

        #region Internal static functions

        internal static new XbmcTvShow FromJson(JObject obj)
        {
            // TODO: XbmcTvShow.FromJson()
            throw new NotImplementedException();
        }

        #endregion
    }
}
