using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public abstract class XbmcMediaPlayer : XbmcJsonRpcNamespace
    {
        #region Private variables

        private string playerName;

        #endregion

        #region Public variables

        public virtual XbmcPlayerState State
        {
            get
            {
                return this.parsePlayerState(this.client.Call(this.playerName + ".State") as JObject);
            }
        }

        #endregion

        #region Constructors

        protected XbmcMediaPlayer(string playerName, JsonRpcClient client)
            : base(client)
        {
            if (string.IsNullOrEmpty(playerName))
            {
                throw new ArgumentException();
            }

            this.playerName = playerName;
        }

        #endregion

        #region JSON RPC Calls

        public virtual XbmcPlayerState PlayPause()
        {
            return this.parsePlayerState(this.client.Call(this.playerName + ".PlayPause") as JObject);
        }

        public virtual bool Stop()
        {
            return (this.client.Call(this.playerName + ".Stop") != null);
        }

        public virtual bool SkipPrevious()
        {
            return (this.client.Call(this.playerName + ".SkipPrevious") != null);
        }

        public virtual bool SkipNext()
        {
            return (this.client.Call(this.playerName + ".SkipNext") != null);
        }

        public virtual bool BigSkipBackward()
        {
            return (this.client.Call(this.playerName + ".BigSkipBackward") != null);
        }

        public virtual bool BigSkipForward()
        {
            return (this.client.Call(this.playerName + ".BigSkipForward") != null);
        }

        public virtual bool SmallSkipBackward()
        {
            return (this.client.Call(this.playerName + ".SmallSkipBackward") != null);
        }

        public virtual bool SmallSkipForward()
        {
            return (this.client.Call(this.playerName + ".SmallSkipForward") != null);
        }

        public virtual bool Rewind()
        {
            return (this.client.Call(this.playerName + ".Rewind") != null);
        }

        public virtual bool Forward()
        {
            return (this.client.Call(this.playerName + ".Forward") != null);
        }

        public virtual XbmcPlayerState GetTime(out TimeSpan currentPosition, out TimeSpan totalLength)
        {
            currentPosition = new TimeSpan();
            totalLength = new TimeSpan();

            JObject query = this.client.Call(this.playerName + ".GetTimeMS") as JObject;
            if (query != null && query["time"] != null && query["total"] != null &&
                query["playing"] != null && query["paused"] != null)
            {
                currentPosition = TimeSpan.FromMilliseconds(Convert.ToDouble((int)query["time"]));
                totalLength = TimeSpan.FromMilliseconds(Convert.ToDouble((int)query["total"]));

                if ((bool)query["playing"])
                {
                    return XbmcPlayerState.Playing;
                }
                if ((bool)query["paused"])
                {
                    return XbmcPlayerState.Paused;
                }
            }

            return XbmcPlayerState.Unavailable;
        }

        public virtual int GetPercentage()
        {
            JObject query = this.client.Call(this.playerName + ".GetPercentage") as JObject;
            if (query == null)
            {
                return -1;
            }

            return (int)query;
        }

        public virtual bool SeekTime(int seconds)
        {
            if (seconds < 0)
            {
                seconds = 0;
            }
            
            return (this.client.Call(this.playerName + ".SeekTime", seconds) != null);
        }

        public virtual bool SeekTime(TimeSpan position)
        {
            return this.SeekTime(Convert.ToInt32(position.TotalSeconds));
        }

        public virtual bool SeekPercentage(int percentage)
        {
            if (percentage < 0)
            {
                percentage = 0;
            }
            else if (percentage > 100)
            {
                percentage = 100;
            }

            return (this.client.Call(this.playerName + ".SeekPercentage", percentage) != null);
        }

        #endregion

        #region Helper functions

        private XbmcPlayerState parsePlayerState(JObject obj)
        {
            if (obj == null || obj["playing"] == null || obj["paused"] == null || obj["partymode"] == null)
            {
                return XbmcPlayerState.Unavailable;
            }

            XbmcPlayerState state = XbmcPlayerState.Unavailable;
            bool set = false;

            if ((bool)obj["playing"])
            {
                set = true;
                state = XbmcPlayerState.Playing;
            }
            if ((bool)obj["paused"])
            {
                if (set)
                {
                    state |= XbmcPlayerState.Paused;
                }
                else
                {
                    state = XbmcPlayerState.Paused;
                    set = true;
                }
            }
            if ((bool)obj["partymode"])
            {
                if (set)
                {
                    state |= XbmcPlayerState.PartyMode;
                }
                else
                {
                    state = XbmcPlayerState.PartyMode;
                    set = true;
                }
            }

            if ((state & XbmcPlayerState.Playing) != XbmcPlayerState.Playing &&
                (state & XbmcPlayerState.Paused) != XbmcPlayerState.Paused)
            {
                if (set)
                {
                    state |= XbmcPlayerState.Unavailable;
                }
                else
                {
                    state = XbmcPlayerState.Unavailable;
                    set = true;
                }
            }

            return state;
        }

        #endregion
    }
}
