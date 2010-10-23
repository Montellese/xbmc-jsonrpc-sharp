using System;

namespace XBMC.JsonRpc
{
    public class XbmcPlayerPlaybackSpeedChangedEventArgs : XbmcPlayerPlaybackChangedEventArgs
    {
        #region Private variables

        private int speed;

        #endregion

        #region Public variables

        public int Speed
        {
            get { return this.speed; }
        }

        #endregion

        #region Constructors

        internal XbmcPlayerPlaybackSpeedChangedEventArgs(XbmcMediaPlayer player, int speed)
            : base(player)
        {
            this.speed = speed;
        }

        #endregion
    }
}
