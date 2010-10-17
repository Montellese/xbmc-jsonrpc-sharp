using System;

namespace XBMC.JsonRpc
{
    public class XbmcPicturePlayer : XbmcMediaPlayer
    {
        #region Constructor

        internal XbmcPicturePlayer(JsonRpcClient client)
            : base("PicturePlayer", client)
        { }

        #endregion

        #region JSON RPC Calls

        public virtual bool MoveLeft()
        {
            throw new NotImplementedException();
        }

        public virtual bool MoveRight()
        {
            throw new NotImplementedException();
        }

        public virtual bool MoveDown()
        {
            throw new NotImplementedException();
        }

        public virtual bool MoveUp()
        {
            throw new NotImplementedException();
        }

        public virtual bool ZoomOut()
        {
            throw new NotImplementedException();
        }

        public virtual bool ZoomIn()
        {
            throw new NotImplementedException();
        }

        public virtual bool Zoom(int level)
        {
            throw new NotImplementedException();
        }

        public virtual bool Rotate()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Hiding inherited methods

        private new XbmcPlayerState State
        {
            get { throw new NotSupportedException(); }
        }

        private new bool BigSkipBackward()
        {
            throw new NotSupportedException();
        }

        private new bool BigSkipForward()
        {
            throw new NotSupportedException();
        }

        private new bool SmallSkipBackward()
        {
            throw new NotSupportedException();
        }

        private new bool SmallSkipForward()
        {
            throw new NotSupportedException();
        }

        private new bool Rewind()
        {
            throw new NotSupportedException();
        }

        private new bool Forward()
        {
            throw new NotSupportedException();
        }

        private new XbmcPlayerState GetTime(out TimeSpan currentPosition, out TimeSpan totalLength)
        {
            throw new NotSupportedException();
        }

        private new int GetPercentage()
        {
            throw new NotSupportedException();
        }

        private new bool SeekTime(int seconds)
        {
            throw new NotSupportedException();
        }

        private new bool SeekTime(TimeSpan position)
        {
            return this.SeekTime(Convert.ToInt32(position.TotalSeconds));
        }

        private new bool SeekPercentage(int percentage)
        {
            throw new NotSupportedException();
        }

        #endregion
    }
}
