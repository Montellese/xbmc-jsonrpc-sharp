using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace XBMC.JsonRpc
{
    public class XbmcFiles : XbmcJsonRpcNamespace
    {
        #region Constructor

        internal XbmcFiles(JsonRpcClient client)
            : base(client)
        { }

        #endregion

        #region JSON RPC Calls

        public ICollection<XbmcFileSource> GetSources(XbmcMediaType mediaType)
        {
            JObject args = new JObject();
            args.Add(new JProperty("media", getMediaType(mediaType)));

            JObject query = this.client.Call("Files.GetSources", args) as JObject;
            List<XbmcFileSource> sources = new List<XbmcFileSource>();
            if (query != null && query["shares"] != null)
            {
                foreach (JObject source in (JArray)query["shares"])
                {
                    XbmcFileSource src = XbmcFileSource.FromJson(source);
                    if (src != null)
                    {
                        sources.Add(src);
                    }
                }
            }

            return sources;
        }

        public string GetDownloadUrl(string file)
        {
            return (string)this.client.Call("Files.Download", file);
        }

        public string GetDirectory(string directory, XbmcMediaType mediaType)
        {
            if (string.IsNullOrEmpty(directory))
            {
                throw new ArgumentException();
            }

            JObject args = new JObject();
            args.Add(new JProperty("directory", directory));
            args.Add(new JProperty("media", getMediaType(mediaType)));

            return (string)this.client.Call("Files.GetDirectory", args);
        }

        #endregion

        #region Helper functions

        private static string getMediaType(XbmcMediaType mediaType)
        {
            switch (mediaType)
            {
                case XbmcMediaType.Video:
                    return "video";

                case XbmcMediaType.Audio:
                    return "music";

                case XbmcMediaType.Picture:
                    return "pictures";

                case XbmcMediaType.File:
                    return "files";
            }

            return null;
        }

        #endregion
    }
}
