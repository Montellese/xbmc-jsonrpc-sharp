using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcMusicVideo : XbmcVideo
    {
        #region Private variables

        #endregion

        #region Public variables

        #endregion

        #region Constructors

        internal XbmcMusicVideo(int id)
            : base(id)
        {
            // TODO: XbmcMusicVideo.ctor()
        }

        #endregion

        #region Internal static functions

        internal static new XbmcMusicVideo FromJson(JObject obj)
        {
            // TODO: XbmcMusicVideo.FromJson()
            throw new NotImplementedException();
        }

        #endregion
    }
}
