using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcAudio : XbmcMedia
    {
        #region Private variables

        protected string title;
        protected string artist;
        protected string genre;
        protected int year;
        protected int rating;

        #endregion

        #region Public variables

        public string Titel
        {
            get { return this.title; }
        }

        public string Artist
        {
            get { return this.artist; }
        }

        public int Year
        {
            get { return this.year; }
        }

        public int Rating
        {
            get { return this.rating; }
        }

        public string Genre
        {
            get { return this.genre; }
        }

        #endregion

        #region Constructors

        protected XbmcAudio(int id, string thumbnail, string fanart,
                            string title, string artist, string genre, int year, int rating)
            : base(id, thumbnail, fanart)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("title");
            }
            if (string.IsNullOrEmpty(artist))
            {
                throw new ArgumentException("artist");
            }

            this.title = title;
            this.artist = artist;
            this.genre = genre;
            this.year = year;
            this.rating = rating;
        }

        #endregion

        #region Internal static functions

        #endregion
    }
}
