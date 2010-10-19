using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcVideo : XbmcMedia
    {
        #region Private variables

        #endregion

        #region Public variables

        #endregion

        #region Constructors

        internal XbmcVideo(int id)
            : base(id)
        { 
            // TODO: XbmcVideo.ctor()
        }

        #endregion

        #region Internal static functions

        internal static XbmcVideo FromJson(JObject obj)
        {
            // TODO: XbmcVideo.FromJson()
            throw new NotImplementedException();
        }

        #endregion
    }
}
