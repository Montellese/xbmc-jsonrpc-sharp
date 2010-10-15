using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcJsonRpcMethod
    {
        #region Private variables

        private string name;
        private string description;
        private string permission;
        private bool executable;

        #endregion

        #region Public variables

        public string Name
        {
            get { return this.name; }
        }

        public string Description
        {
            get { return this.description; }
        }

        public string Permission
        {
            get { return this.permission; }
        }

        public bool Executable
        {
            get { return this.executable; }
        }

        #endregion

        #region Constructor

        internal XbmcJsonRpcMethod(string name, string description, string permission, bool executable)
        {
            this.name = name;
            this.description = description;
            this.permission = permission;
            this.executable = executable;
        }

        #endregion

        #region Public functions

        internal static XbmcJsonRpcMethod FromJsonObject(JObject obj)
        {
            if (obj == null) 
            {
                return null;
            }

            return new XbmcJsonRpcMethod(
                obj["command"].Value<JValue>().Value.ToString(),
                obj["description"].Value<JValue>().Value.ToString(),
                obj["permission"].Value<JValue>().Value.ToString(),
                Boolean.Parse(obj["executable"].Value<JValue>().Value.ToString()));
        }

        #endregion
    }
}
