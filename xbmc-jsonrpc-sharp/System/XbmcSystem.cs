using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcSystem : XbmcJsonRpcNamespace
    {
        #region Private variables

        private bool checkedLabels;

        private bool canShutdown;
        private bool canSuspend;
        private bool canHibernate;
        private bool canReboot;

        #endregion

        #region Public variables

        public bool CanShutdown 
        {
            get 
            {
                this.checkLabels();

                return this.canShutdown;
            }
        }

        public bool CanSuspend
        {
            get
            {
                this.checkLabels();

                return this.canSuspend;
            }
        }

        public bool CanHibernate
        {
            get
            {
                this.checkLabels();

                return this.canHibernate;
            }
        }

        public bool CanReboot
        {
            get
            {
                this.checkLabels();

                return this.canReboot;
            }
        }

        #endregion

        #region Events

        public event EventHandler ShuttingDown;
        public event EventHandler Suspending;
        public event EventHandler Hibernating;
        public event EventHandler Rebooting;
        public event EventHandler Sleeping;
        public event EventHandler Waking;
        public event EventHandler Resuming;
        public event EventHandler LowBattery;

        #endregion

        #region Constructor

        internal XbmcSystem(JsonRpcClient client)
            : base(client)
        { }

        #endregion

        #region JSON RPC Calls

        public bool Shutdown() 
        {
            if (!this.CanShutdown) 
            {
                return false;
            }

            return (this.client.Call("System.Shutdown") != null);
        }

        public bool Suspend() 
        {
            if (!this.CanSuspend) 
            {
                return false;
            }

            return (this.client.Call("System.Suspend") != null);
        }

        public bool Hibernate() 
        {
            if (!this.CanHibernate) 
            {
                return false;
            }

            return (this.client.Call("System.Hibernate") != null);
        }

        public bool Reboot() 
        {
            if (!this.CanReboot) 
            {
                return false;
            }

            return (this.client.Call("System.Reboot") != null);
        }

        public IDictionary<string, string> GetInfoLabels(params string[] labels) 
        {
            if (labels == null)
            {
                throw new ArgumentNullException("labels");
            }
            if (labels.Length <= 0)
            {
                throw new ArgumentException();
            }

            JObject results = this.client.Call("System.GetInfoLabels", labels) as JObject;
            Dictionary<string, string> list = new Dictionary<string, string>();
            if (results != null)
            {
                int index = 0;
                foreach (string label in labels)
                {
                    if (results[label] != null)
                    {
                        list.Add(label, (string)results[label]);
                    }

                    index += 1;
                }
            }

            return list;
        }

        public string GetInfoLabel(string label)
        {
            if (label == null)
            {
                throw new ArgumentNullException("label");
            }

            JObject result = this.client.Call("System.GetInfoLabels", new string[] { label }) as JObject;
            if (result == null || result[label] == null)
            {
                return null;
            }

            return (string)result[label];
        }

        public IDictionary<string, bool> GetInfoBooleans(params string[] labels)
        {
            if (labels == null)
            {
                throw new ArgumentNullException("labels");
            }
            if (labels.Length <= 0)
            {
                throw new ArgumentException();
            }

            JObject results = this.client.Call("System.GetInfoBooleans", labels) as JObject;
            Dictionary<string, bool> list = new Dictionary<string, bool>();
            if (results != null)
            {
                int index = 0;
                foreach (string label in labels)
                {
                    if (results[label] != null)
                    {
                        list.Add(label, (bool)results[label]);
                    }

                    index += 1;
                }
            }

            return list;
        }

        public bool GetInfoBoolean(string label)
        {
            if (label == null)
            {
                throw new ArgumentNullException("label");
            }

            JObject result = this.client.Call("System.GetInfoBooleans", new string[] { label }) as JObject;
            if (result == null || result[label] == null)
            {
                return false;
            }

            return (bool)result[label];
        }

        #endregion

        #region Internal functions

        internal void OnShutdown()
        {
            if (this.ShuttingDown != null)
            {
                this.ShuttingDown(this, null);
            }
        }

        internal void OnSuspend()
        {
            if (this.Suspending != null)
            {
                this.Suspending(this, null);
            }
        }

        internal void OnHibernate()
        {
            if (this.Hibernating != null)
            {
                this.Hibernating(this, null);
            }
        }

        internal void OnReboot()
        {
            if (this.Rebooting != null)
            {
                this.Rebooting(this, null);
            }
        }

        internal void OnSleep()
        {
            if (this.Sleeping != null)
            {
                this.Sleeping(this, null);
            }
        }

        internal void OnWake()
        {
            if (this.Waking != null)
            {
                this.Waking(this, null);
            }
        }

        internal void OnResume()
        {
            if (this.Resuming != null)
            {
                this.Resuming(this, null);
            }
        }

        internal void OnLowBattery()
        {
            if (this.LowBattery != null)
            {
                this.LowBattery(this, null);
            }
        }

        #endregion

        #region Helper functions

        private void checkLabels()
        {
            if (this.checkedLabels)
            {
                return;
            }

            IDictionary<string, bool> labels = this.GetInfoBooleans("System.CanShutdown", "System.CanSuspend", "System.CanHibernate", "System.CanReboot");
            if (labels.ContainsKey("System.CanShutdown"))
            {
                this.canShutdown = labels["System.CanShutdown"];
            }
            if (labels.ContainsKey("System.CanSuspend"))
            {
                this.canSuspend = labels["System.CanSuspend"];
            }
            if (labels.ContainsKey("System.CanHibernate"))
            {
                this.canHibernate = labels["System.CanHibernate"];
            }
            if (labels.ContainsKey("System.CanReboot"))
            {
                this.canReboot = labels["System.CanReboot"];
            }

            this.checkedLabels = true;
        }

        #endregion
    }
}
