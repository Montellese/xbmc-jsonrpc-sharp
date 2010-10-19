using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcAudio : XbmcMedia
    {
        #region Private variables

        #endregion

        #region Public variables

        #endregion

        #region Constructors

        internal XbmcAudio(int id)
            : base(id)
        {
            // TODO: XbmcAudio.ctor()
        }

        #endregion

        #region Internal static functions

        internal static XbmcAudio FromJson(JObject obj)
        {
            // TODO: XbmcAudio.FromJson()
            throw new NotImplementedException();
        }

        #endregion
    }
}
