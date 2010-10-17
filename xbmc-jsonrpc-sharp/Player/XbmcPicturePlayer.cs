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
            return (this.client.Call("PicturePlayer.MoveLeft") != null);
        }

        public virtual bool MoveRight()
        {
            return (this.client.Call("PicturePlayer.MoveRight") != null);
        }

        public virtual bool MoveDown()
        {
            return (this.client.Call("PicturePlayer.MoveDown") != null);
        }

        public virtual bool MoveUp()
        {
            return (this.client.Call("PicturePlayer.MoveUp") != null);
        }

        public virtual bool ZoomOut()
        {
            return (this.client.Call("PicturePlayer.ZoomOut") != null);
        }

        public virtual bool ZoomIn()
        {
            return (this.client.Call("PicturePlayer.ZoomIn") != null);
        }

        public virtual bool Zoom(int level)
        {
            if (level < 1)
            {
                level = 1;
            }
            else if (level > 10)
            {
                level = 10;
            }

            return (this.client.Call("PicturePlayer.Zoom", level) != null);
        }

        public virtual bool Rotate()
        {
            return (this.client.Call("PicturePlayer.Rotate") != null);
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
