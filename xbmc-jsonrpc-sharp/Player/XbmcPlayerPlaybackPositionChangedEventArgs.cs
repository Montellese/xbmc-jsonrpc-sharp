using System;

namespace XBMC.JsonRpc
{
    public class XbmcPlayerPlaybackPositionChangedEventArgs : XbmcPlayerPlaybackChangedEventArgs
    {
        #region Private variables

        private TimeSpan position;
        private TimeSpan length;

        #endregion

        #region Public variables

        public TimeSpan Position
        {
            get { return this.position; }
        }

        public TimeSpan Length
        {
            get { return this.length; }
        }

        #endregion

        #region Constructors

        internal XbmcPlayerPlaybackPositionChangedEventArgs(XbmcMediaPlayer player, TimeSpan position, TimeSpan length)
            : base(player)
        {
            if (position == null)
            {
                throw new ArgumentNullException("position");
            }
            if (length == null)
            {
                throw new ArgumentNullException("length");
            }

            this.position = position;
            this.length = length;
        }

        #endregion
    }
}
