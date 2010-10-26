using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcAudio : XbmcPlayable
    {
        #region Private variables

        protected string artist;

        #endregion

        #region Public variables

        public string Artist
        {
            get { return this.artist; }
        }

        #endregion

        #region Constructors

        protected XbmcAudio(int id, string thumbnail, string fanart,
                            string title, string artist, string genre, int year, int rating)
            : base(id, thumbnail, fanart,
                   title, genre, year, rating)
        {
            if (string.IsNullOrEmpty(artist))
            {
                throw new ArgumentException("artist");
            }

            this.artist = artist;
        }

        #endregion

        #region Internal static functions

        #endregion
    }
}
