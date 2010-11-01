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
            this.client.LogMessage("XbmcPicturePlayer.MoveLeft()");

            return (this.client.Call("PicturePlayer.MoveLeft") != null);
        }

        public virtual bool MoveRight()
        {
            this.client.LogMessage("XbmcPicturePlayer.MoveRight()");

            return (this.client.Call("PicturePlayer.MoveRight") != null);
        }

        public virtual bool MoveDown()
        {
            this.client.LogMessage("XbmcPicturePlayer.MoveDown()");

            return (this.client.Call("PicturePlayer.MoveDown") != null);
        }

        public virtual bool MoveUp()
        {
            this.client.LogMessage("XbmcPicturePlayer.MoveUp()");

            return (this.client.Call("PicturePlayer.MoveUp") != null);
        }

        public virtual bool ZoomOut()
        {
            this.client.LogMessage("XbmcPicturePlayer.ZoomOut()");

            return (this.client.Call("PicturePlayer.ZoomOut") != null);
        }

        public virtual bool ZoomIn()
        {
            this.client.LogMessage("XbmcPicturePlayer.ZoomIn()");

            return (this.client.Call("PicturePlayer.ZoomIn") != null);
        }

        public virtual bool Zoom(int level)
        {
            this.client.LogMessage("XbmcPicturePlayer.Zoom(" + level + ")");

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
            this.client.LogMessage("XbmcPicturePlayer.Rotate()");

            return (this.client.Call("PicturePlayer.Rotate") != null);
        }

        #endregion
    }
}
