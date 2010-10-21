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
            JObject query = this.getItems(fields, XbmcVideo.Fields, -1, -1);
            if (query == null || query["current"] == null || query["items"] == null)
            {
                return null;
            }

            int current = (int)query["current"];
            JArray items = (JArray)query["items"];
            if (current < 0 || items == null || current > items.Count)
            {
                return null;
            }

            // TODO: XbmcVideoPlaylist differ between movies, tvshows etc
            return XbmcVideo.FromJson((JObject)items[current]);
        }

        public override XbmcPlaylist<XbmcVideo> GetItems(params string[] fields)
        {
            return this.GetItems(-1, -1, fields);
        }

        public override XbmcPlaylist<XbmcVideo> GetItems(int start, int end, params string[] fields)
        {
            JObject query = this.getItems(fields, XbmcVideo.Fields, start, end);
            if (query == null || query["items"] == null)
            {
                return null;
            }

            XbmcPlaylist<XbmcVideo> playlist = XbmcPlaylist<XbmcVideo>.FromJson(query);
            foreach (JObject item in (JArray)query["items"])
            {
                // TODO: XbmcVideoPlaylist differ between movies, tvshows etc
                playlist.Add(XbmcVideo.FromJson(item));
            }

            return playlist;
        }

        #endregion
    }
}
