using System;

namespace XBMC.JsonRpc
{
    public class XbmcPlayerPlaybackChangedEventArgs : EventArgs
    {
        #region Private variables

        private XbmcMediaPlayer player;

        #endregion

        #region Public variables

        public XbmcMediaPlayer Player
        {
            get { return this.player; }
        }

        #endregion

        #region Constructors

        internal XbmcPlayerPlaybackChangedEventArgs(XbmcMediaPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentNullException();
            }

            this.player = player;
        }

        #endregion
    }
}
