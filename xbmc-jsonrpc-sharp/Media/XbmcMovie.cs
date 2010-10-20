using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcMovie : XbmcVideo
    {
        #region Private variables

        #endregion

        #region Public variables

        #endregion

        #region Constructors

        private XbmcMovie(int id, string thumbnail, string fanart)
            : base(id, thumbnail, fanart)
        {
            // TODO: XbmcMovie.ctor()
        }

        #endregion

        #region Internal static functions

        internal static new XbmcMovie FromJson(JObject obj)
        {
            // TODO: XbmcMovie.FromJson()
            throw new NotImplementedException();
        }

        #endregion
    }
}
