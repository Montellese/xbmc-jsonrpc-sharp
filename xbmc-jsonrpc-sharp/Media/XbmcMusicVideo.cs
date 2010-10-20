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

        private XbmcMusicVideo(int id, string thumbnail, string fanart)
            : base(id, thumbnail, fanart)
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
