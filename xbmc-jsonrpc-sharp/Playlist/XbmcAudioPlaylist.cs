using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcAudioPlaylist : XbmcMediaPlaylist<XbmcSong>
    {
        #region Constructor

        internal XbmcAudioPlaylist(JsonRpcClient client)
            : base("AudioPlaylist", client)
        { }

        #endregion

        #region JSON RPC Calls

        #endregion

        #region Overrides of XbmcMediaPlaylist<XbmcVideo>

        public override XbmcSong GetCurrentItem(params string[] fields)
        {
            JObject query = this.getItems(fields, XbmcSong.Fields, -1, -1);
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

            return XbmcSong.FromJson((JObject)items[current]);
        }

        public override XbmcPlaylist<XbmcSong> GetItems(params string[] fields)
        {
            return this.GetItems(-1, -1, fields);
        }

        public override XbmcPlaylist<XbmcSong> GetItems(int start, int end, params string[] fields)
        {
            JObject query = this.getItems(fields, XbmcSong.Fields, start, end);
            if (query == null || query["items"] == null)
            {
                return null;
            }

            XbmcPlaylist<XbmcSong> playlist = XbmcPlaylist<XbmcSong>.FromJson(query);
            foreach (JObject item in (JArray)query["items"])
            {
                playlist.Add(XbmcSong.FromJson(item));
            }

            return playlist;
        }

        #endregion
    }
}
