using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcAlbum : XbmcAudio
    {
        #region Private variables

        #endregion

        #region Public variables

        #endregion

        #region Constructors

        internal XbmcAlbum(int id)
            : base(id)
        {
            // TODO: XbmcAlbum.ctor()
        }

        #endregion

        #region Internal static functions

        internal static new XbmcAlbum FromJson(JObject obj)
        {
            // TODO: XbmcAlbum.FromJson()
            throw new NotImplementedException();
        }

        #endregion
    }
}
