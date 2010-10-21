using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcSong : XbmcAudio
    {
        #region Private variables

        private string file;

        private string album;
        private int track;
        private int disc;
        private TimeSpan duration;
        private string comment;
        private string lyrics;

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

        static XbmcSong()
        {
            fields = new string[] { "title", "artist", "genre", "year",
                                    "rating", "album", "tracknumber", "discnumber", 
                                    "duration", "comment", "lyrics" };
        }

        private XbmcSong(int id, string thumbnail, string fanart, string file,
                         string title, string artist, string genre, int year,
                         int rating, string album, int track, int disc,
                         int duration, string comment, string lyrics)
            : base(id, thumbnail, fanart, title, artist, genre, year, rating)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentException("file");
            }

            this.file = file;
            this.album = album;
            this.track = track;
            this.disc = disc;
            this.duration = TimeSpan.FromSeconds(duration);
            this.comment = comment;
            this.lyrics = lyrics;
        }

        #endregion

        #region Internal static functions

        internal static XbmcSong FromJson(JObject obj)
        {
            if (obj == null)
            {
                return null;
            }

            return new XbmcSong(JsonRpcClient.GetField<int>(obj, "songid"),
                                JsonRpcClient.GetField<string>(obj, "thumbnail"),
                                JsonRpcClient.GetField<string>(obj, "fanart"),
                                JsonRpcClient.GetField<string>(obj, "file"),
                                JsonRpcClient.GetField<string>(obj, "title"),
                                JsonRpcClient.GetField<string>(obj, "artist"),
                                JsonRpcClient.GetField<string>(obj, "genre", string.Empty),
                                JsonRpcClient.GetField<int>(obj, "year"),
                                JsonRpcClient.GetField<int>(obj, "rating"),
                                JsonRpcClient.GetField<string>(obj, "album", string.Empty),
                                JsonRpcClient.GetField<int>(obj, "tracknumber"),
                                JsonRpcClient.GetField<int>(obj, "discnumber"),
                                JsonRpcClient.GetField<int>(obj, "duration"),
                                JsonRpcClient.GetField<string>(obj, "comment", string.Empty),
                                JsonRpcClient.GetField<string>(obj, "lyrics", string.Empty));
        }

        #endregion
    }
}
