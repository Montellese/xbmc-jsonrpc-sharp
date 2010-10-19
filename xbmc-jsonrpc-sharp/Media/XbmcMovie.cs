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

        internal XbmcMovie(int id)
            : base(id)
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
