using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcArtist : XbmcMedia
    {
        #region Private variables

        private string name;

        #endregion

        #region Internal variables

        internal static string[] Fields
        {
            get { return (fields != null ? fields : new string[0]); }
        }

        #endregion

        #region Public variables

        public string Name 
        {
            get { return this.name; }
        }

        #endregion

        #region Constructors

        static XbmcArtist()
        {
            fields = new string[] { "artistid", "artist" };
        }

        private XbmcArtist(int id, string name, string thumbnail, string fanart)
            : base(id, thumbnail, fanart)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException();
            }

            this.name = name;
        }
        
        #endregion

        #region Internal static functions

        internal static XbmcArtist FromJson(JObject obj)
        {
            if (obj == null)
            {
                return null;
            }

            return new XbmcArtist(JsonRpcClient.GetField<int>(obj, "artistid"),
                                  JsonRpcClient.GetField<string>(obj, "artist"),
                                  JsonRpcClient.GetField<string>(obj, "thumbnail"),
                                  JsonRpcClient.GetField<string>(obj, "fanart"));
        }

        #endregion
    }
}
