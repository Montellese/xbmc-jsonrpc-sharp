using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcMedia
    {
        #region Private variables

        protected static string[] fields;

        private int id;

        private string thumbnail;
        private string fanart;

        #endregion

        #region Internal variables

        internal static string[] Fields
        {
            get { return (fields != null ? fields : new string[0]); }
        }

        #endregion

        #region Public variables

        public int Id
        {
            get { return this.id; }
        }

        public string Thumbnail
        {
            get { return this.thumbnail; }
        }

        public string Fanart
        {
            get { return this.fanart; }
        }

        #endregion

        #region Constructors

        protected XbmcMedia(int id, string thumbnail, string fanart)
        {
            this.id = id;
            this.thumbnail = thumbnail != null ? thumbnail : string.Empty;
            this.fanart = fanart != null ? fanart : string.Empty;
        }

        #endregion
    }
}
