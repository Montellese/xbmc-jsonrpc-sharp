using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcPlaylist<TMediaType> where TMediaType : XbmcMedia
    {
        #region Private variables

        private int current;
        private int start;
        private int total;

        private List<TMediaType> items;

        #endregion

        #region Public variables

        public int Current
        {
            get { return this.current; }
        }

        public int Start
        {
            get { return this.start; }
        }

        public int End
        {
            get { return this.start + this.Count; }
        }

        public int Total
        {
            get { return this.total; }
        }

        public int Count
        {
            get { return this.items.Count; }
        }

        public ICollection<TMediaType> Items
        {
            get { return this.items; }
        }

        #endregion

        #region Constructors

        internal XbmcPlaylist(int current, int start, int total)
        {
            this.current = current;
            this.start = start;
            this.total = total;

            this.items = new List<TMediaType>();
        }

        #endregion

        #region Internal functions

        internal void Add(TMediaType item)
        {
            if (item == null)
            {
                return;
            }

            this.items.Add(item);
        }

        #endregion

        #region Internal static functions

        internal static XbmcPlaylist<TMediaType> FromJson(JObject obj)
        {
            return new XbmcPlaylist<TMediaType>((int)obj["current"], (int)obj["start"], (int)obj["total"]);
        }

        #endregion
    }
}
