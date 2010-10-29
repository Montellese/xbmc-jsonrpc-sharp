using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcJsonRpc : XbmcJsonRpcNamespace
    {
        #region Constructor

        internal XbmcJsonRpc(JsonRpcClient client)
            : base(client)
        { }

        #endregion

        #region JSON RPC Calls

        public ICollection<XbmcJsonRpcMethod> Introspect()
        {
            return this.Introspect(true, true, true);
        }

        public ICollection<XbmcJsonRpcMethod> Introspect(bool getPermissions, bool getDescriptions, bool filterByTransport)
        {
            JObject args = new JObject();
            args.Add(new JProperty("getpermissions", getPermissions));
            args.Add(new JProperty("getDescriptions", getDescriptions));
            args.Add(new JProperty("filterbytransport", filterByTransport));

            JObject query = this.client.Call("JSONRPC.Introspect", args) as JObject;

            List<XbmcJsonRpcMethod> methods = new List<XbmcJsonRpcMethod>();

            if (query["commands"] != null)
            {
                foreach (JObject item in (JArray)query["commands"])
                {
                    methods.Add(XbmcJsonRpcMethod.FromJson(item));
                }
            }

            return methods;
        }

        public int Version()
        {
            JObject query = this.client.Call("JSONRPC.Version") as JObject;

            if (query == null || query["version"] == null)
            {
                return -1;
            }

            return (int)query["version"];
        }

        public ICollection<string> Permission()
        {
            JObject query = this.client.Call("JSONRPC.Permission") as JObject;

            List<string> permissions = new List<string>();

            if (query["permission"] != null)
            {
                foreach (string item in ((JArray)query["permission"]))
                {
                    permissions.Add(item);
                }
            }

            return permissions;
        }

        public string Ping()
        {
            object query = this.client.Call("JSONRPC.Ping");
            if (query == null) 
            {
                return string.Empty;
            }

            return query.ToString();
        }

        public void Announce(string sender, string message)
        {
            this.Announce(sender, message, null);
        }

        public void Announce(string sender, string message, object data)
        {
            JObject args = new JObject();
            args.Add(new JProperty("sender", sender));
            args.Add(new JProperty("message", message));
            if (data != null)
            {
                args.Add(new JProperty("data", message));
            }

            this.client.Call("JSONRPC.Announce", args);
        }

        #endregion

        #region Helper functions

        #endregion
    }
}
