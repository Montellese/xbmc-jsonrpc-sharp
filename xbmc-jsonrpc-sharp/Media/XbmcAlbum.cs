using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcAlbum : XbmcAudio
    {
        #region Private variables

        private string mood;
        private string theme;
        private string style;
        private string type;
        private string label;
        private string description;

        #endregion

        #region Internal variables

        internal static new string[] Fields
        {
            get { return (fields != null ? fields : new string[0]); }
        }

        #endregion

        #region Public variables

        public string Mood
        {
            get { return this.mood; }
        }

        public string Theme
        {
            get { return this.theme; }
        }

        public string Style
        {
            get { return this.style; }
        }

        public string Type
        {
            get { return this.type; }
        }

        public string Label
        {
            get { return this.label; }
        }

        public string Description
        {
            get { return this.description; }
        }

        #endregion

        #region Constructors

        static XbmcAlbum()
        {
            fields = new string[] { "albumid", "album_artist", "album_description", "album_genre",
                                    "album_label", "album_mood", "album_rating", "album_style",
                                    "album_theme", "album_title", "album_type", "year" };
        }

        private XbmcAlbum(int id, string thumbnail, string fanart, string title, string artist, int year, int rating,
            string genre, string mood, string theme, string style, string type, string label, string description)
            : base(id, thumbnail, fanart, title, artist, genre, year, rating)
        {
            this.mood = mood;
            this.theme = theme;
            this.style = style;
            this.type = type;
            this.label = label;
            this.description = description;
        }

        #endregion

        #region Internal static functions

        internal static XbmcAlbum FromJson(JObject obj)
        {
            if (obj == null)
            {
                return null;
            }

            return new XbmcAlbum(JsonRpcClient.GetField<int>(obj, "albumid"),
                                 JsonRpcClient.GetField<string>(obj, "thumbnail"),
                                 JsonRpcClient.GetField<string>(obj, "fanart"),
                                 JsonRpcClient.GetField<string>(obj, "album_title"),
                                 JsonRpcClient.GetField<string>(obj, "album_artist"),
                                 JsonRpcClient.GetField<int>(obj, "year"),
                                 JsonRpcClient.GetField<int>(obj, "album_rating"),
                                 JsonRpcClient.GetField<string>(obj, "album_genre", string.Empty),
                                 JsonRpcClient.GetField<string>(obj, "album_mood", string.Empty),
                                 JsonRpcClient.GetField<string>(obj, "album_theme", string.Empty),
                                 JsonRpcClient.GetField<string>(obj, "album_style", string.Empty),
                                 JsonRpcClient.GetField<string>(obj, "album_type", string.Empty),
                                 JsonRpcClient.GetField<string>(obj, "album_label", string.Empty),
                                 JsonRpcClient.GetField<string>(obj, "album_description", string.Empty));
        }

        #endregion
    }
}
