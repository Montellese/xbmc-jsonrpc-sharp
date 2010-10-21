using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcVideo : XbmcMedia
    {
        #region Private variables

        #endregion

        #region Internal variables

        internal static new string[] Fields
        {
            get { return (fields != null ? fields : new string[0]); }
        }

        #endregion

        #region Public variables

        #endregion

        #region Constructors

        static XbmcVideo()
        {
            fields = new string[] { "title", "artist", "genre", "year", "rating", 
                                    "director", "trailer", "tagline", "plot", "plotoutline",
                                    "originaltitle", "lastplayed", "showtitle", "firstaired", "duration",
                                    "season", "episode", "runtime", "playcount", "writer",
                                    "studio", "mpaa", "premiered", "album" };
        }

        protected XbmcVideo(int id, string thumbnail, string fanart)
            : base(id, thumbnail, fanart)
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
