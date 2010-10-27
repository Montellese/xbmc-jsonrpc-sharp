using System;

namespace XBMC.JsonRpc
{
    public class XbmcPlayerPlaybackSpeedChangedEventArgs : XbmcPlayerPlaybackPositionChangedEventArgs
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

        internal XbmcPlayerPlaybackSpeedChangedEventArgs(XbmcMediaPlayer player, TimeSpan position, TimeSpan length, int speed)
            : base(player, position, length)
        {
            this.speed = speed;
        }

        #endregion
    }
}
