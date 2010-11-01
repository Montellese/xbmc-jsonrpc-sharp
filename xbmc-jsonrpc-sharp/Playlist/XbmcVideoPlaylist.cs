using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcVideoPlaylist : XbmcMediaPlaylist<XbmcVideo>
    {
        #region Constructor

        internal XbmcVideoPlaylist(JsonRpcClient client)
            : base("VideoPlaylist", client)
        { }

        #endregion

        #region JSON RPC Calls

        #endregion

        #region Overrides of XbmcMediaPlaylist<XbmcVideo>

        public override XbmcVideo GetCurrentItem(params string[] fields)
        {
            this.client.LogMessage("XbmcVideoPlaylist.GetCurrentItem()");

            JObject query = base.getItems(fields, XbmcVideo.Fields, -1, -1);
            if (query == null || query["current"] == null || query["items"] == null)
            {
                this.client.LogErrorMessage("VideoPlaylist.GetItems(): Invalid response");

                return null;
            }

            int current = (int)query["current"];
            JArray items = (JArray)query["items"];
            if (current < 0 || items == null || current > items.Count)
            {
                return null;
            }

            return XbmcVideo.FromJson((JObject)items[current]);
        }

        public override XbmcPlaylist<XbmcVideo> GetItems(params string[] fields)
        {
            return this.GetItems(-1, -1, fields);
        }

        public override XbmcPlaylist<XbmcVideo> GetItems(int start, int end, params string[] fields)
        {
            this.client.LogMessage("XbmcVideoPlaylist.GetItems()");

            JObject query = this.getItems(fields, XbmcVideo.Fields, start, end);
            if (query == null || query["items"] == null)
            {
                this.client.LogErrorMessage("VideoPlaylist.GetItems(): Invalid response");

                return null;
            }

            XbmcPlaylist<XbmcVideo> playlist = XbmcPlaylist<XbmcVideo>.FromJson(query);
            foreach (JObject item in (JArray)query["items"])
            {
                playlist.Add(XbmcVideo.FromJson(item));
            }

            return playlist;
        }

        public bool Add(XbmcVideo video)
        {
            this.client.LogMessage("XbmcVideoPlaylist.Add()");

            if (video == null)
            {
                throw new ArgumentNullException("video");
            }
            if (string.IsNullOrEmpty(video.File))
            {
                throw new ArgumentException("The given video has no file assigned to it.");
            }

            return base.Add(video.File);
        }

        #endregion
    }
}
