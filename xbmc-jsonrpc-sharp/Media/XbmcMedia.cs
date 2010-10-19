using System;

namespace XBMC.JsonRpc
{
    public class XbmcMedia
    {
        #region Private variables

        private int id;

        #endregion

        #region Public variables

        public int Id
        {
            get { return this.id; }
        }

        #endregion

        #region Constructors

        protected XbmcMedia(int id)
        {
            this.id = id;
        }

        #endregion
    }
}
