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
            this.client.LogMessage("XbmcFiles.GetSources(" + mediaType + ")");

            JObject args = new JObject();
            args.Add(new JProperty("media", getMediaType(mediaType)));

            JObject query = this.client.Call("Files.GetSources", args) as JObject;
            List<XbmcFileSource> sources = new List<XbmcFileSource>();
            if (query == null || query["shares"] == null)
            {
                this.client.LogErrorMessage("Files.GetSources(" + getMediaType(mediaType) + "): Invalid response");

                return sources;
            }

            foreach (JObject source in (JArray)query["shares"])
            {
                XbmcFileSource src = XbmcFileSource.FromJson(source);
                if (src != null)
                {
                    sources.Add(src);
                }
            }

            return sources;
        }

        public string GetDownloadUrl(string file)
        {
            this.client.LogMessage("XbmcFiles.GetDownloadUrl(" + file + ")");

            JObject query = this.client.Call("Files.Download", file) as JObject;
            if (query == null || query["path"] == null)
            {
                this.client.LogErrorMessage("Files.Download(" + file + "): Invalid response");

                return null;
            }

            return (string)query["path"];
        }

        public string GetDirectory(string directory, XbmcMediaType mediaType)
        {
            this.client.LogMessage("XbmcFiles.GetDirectory(" + directory + ", " + mediaType + ")");

            if (string.IsNullOrEmpty(directory))
            {
                throw new ArgumentException();
            }

            JObject args = new JObject();
            args.Add(new JProperty("directory", directory));
            args.Add(new JProperty("media", getMediaType(mediaType)));

            object path = this.client.Call("Files.GetDirectory", args);
            if (path == null)
            {
                this.client.LogErrorMessage("Files.GetDirectory(" + directory + ", " + getMediaType(mediaType) + "): Invalid response");

                return string.Empty;
            }

            return (string)path;
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
