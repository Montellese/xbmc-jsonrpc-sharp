using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcGeneral : XbmcJsonRpcNamespace
    {
        #region Private variables

        private XbmcSystem system;

        #endregion

        #region Public variables

        public string BuildVersion
        {
            get { return this.system.GetInfoLabel("System.BuildVersion"); }
        }

        public DateTime BuildData
        {
            get { return DateTime.Parse(this.system.GetInfoLabel("System.BuildDate")); }
        }

        #endregion

        #region Constructor

        internal XbmcGeneral(JsonRpcClient client)
            : base(client)
        { 
            this.system = new XbmcSystem(client);
        }

        #endregion

        #region JSON RPC Calls

        public int GetVolume()
        {
            return (int)this.client.Call("XBMC.GetVolume");
        }

        public bool SetVolume(int value)
        {
            if (value < 0)
            {
                value = 0;
            }
            else if (value > 100)
            {
                value = 100;
            }

            return (this.client.Call("XBMC.SetVolume", value) != null);
        }

        public int ToggleMute()
        {
            return (int)this.client.Call("XBMC.ToggleMute");
        }

        public bool Log(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException();
            }

            return (this.client.Call("XBMC.Log", message) != null);
        }

        public bool Log(string message, XbmcLogLevel logLevel)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException();
            }

            JObject args = new JObject();
            args.Add(new JProperty("message", message));
            args.Add(new JProperty("level", logLevel.ToString().ToLowerInvariant()));

            return (this.client.Call("XBMC.Log", args) != null);
        }

        public bool StartSlideshow(string directory)
        {
            if (string.IsNullOrEmpty(directory))
            {
                throw new ArgumentException();
            }

            return (this.client.Call("XBMC.StartSlideshow", directory) != null);
        }

        public bool StartSlideshow(string directory, bool random, bool recursive)
        {
            if (string.IsNullOrEmpty(directory))
            {
                throw new ArgumentException();
            }

            JObject args = new JObject();
            args.Add(new JProperty("directory", directory));
            args.Add(new JProperty("random", random));
            args.Add(new JProperty("recursive", recursive));

            return (this.client.Call("XBMC.StartSlideshow", args) != null);
        }

        public bool Play()
        {
            throw new NotImplementedException();
        }

        public bool Quit()
        {
            return (this.client.Call("XBMC.Quit") != null);
        }

        #endregion

        #region Helper functions

        #endregion
    }
}
