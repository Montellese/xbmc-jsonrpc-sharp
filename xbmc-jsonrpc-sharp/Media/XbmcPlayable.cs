using System;
using System.Collections.Generic;
using System.Text;

namespace XBMC.JsonRpc
{
    public class XbmcPlayable : XbmcMedia
    {
        #region Private variables

        protected string title;
        protected string genre;
        protected int year;
        protected double rating;

        #endregion

        #region Public variables

        public virtual string Title
        {
            get { return this.title; }
        }

        public virtual string Genre
        {
            get { return this.genre; }
        }

        public virtual int Year
        {
            get { return this.year; }
        }

        public virtual double Rating
        {
            get { return this.rating; }
        }

        #endregion

        #region Constructors

        protected XbmcPlayable(int id, string thumbnail, string fanart,
                          string title, string genre, int year, double rating)
            : base(id, thumbnail, fanart)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("title");
            }

            this.title = title;
            this.genre = genre;
            this.year = year;
            this.rating = rating;
        }

        #endregion
    }
}
