using System;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace XBMC.JsonRpc
{
    public class XbmcFileSource
    {
        #region Private variables

        private const string MultiPath = "multipath://";

        private string label;
        private ICollection<string> paths;
        private string fanart;

        #endregion

        #region Public variables

        public string Label
        {
            get { return this.label; }
        }

        public ICollection<string> Paths
        {
            get { return this.paths; }
        }

        public string Fanart
        {
            get { return this.fanart; }
        }

        #endregion

        #region Constructor

        internal XbmcFileSource(string label, string paths, string fanart)
        {
            this.label = label;
            this.paths = new List<string>();
            this.fanart = fanart;

            if (paths.StartsWith(MultiPath))
            {
                foreach (string path in HttpUtility.UrlDecode(paths.Remove(0, MultiPath.Length)).Split('/'))
                {
                    if (!string.IsNullOrEmpty(path))
                    {
                        this.paths.Add(path);
                    }
                }
            }
            else
            {
                this.paths.Add(paths);
            }
        }

        internal XbmcFileSource(string label, ICollection<string> paths, string fanart)
        {
            this.label = label;
            this.paths = paths;
            this.fanart = fanart;
        }

        #endregion

        #region Public functions

        internal static XbmcFileSource FromJsonObject(JObject obj)
        {
            if (obj == null) 
            {
                return null;
            }

            return new XbmcFileSource(
                (string)obj["label"],
                (string)obj["file"],
                (string)obj["fanart"]);
        }

        #endregion
    }
}
