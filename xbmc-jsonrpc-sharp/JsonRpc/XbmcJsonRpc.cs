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
            this.client.LogMessage("XbmcJsonRpc.Introspect()");

            JObject args = new JObject();
            args.Add(new JProperty("getpermissions", getPermissions));
            args.Add(new JProperty("getDescriptions", getDescriptions));
            args.Add(new JProperty("filterbytransport", filterByTransport));

            JObject query = this.client.Call("JSONRPC.Introspect", args) as JObject;
            List<XbmcJsonRpcMethod> methods = new List<XbmcJsonRpcMethod>();

            if (query == null || query["commands"] == null)
            {
                this.client.LogErrorMessage("JSONRPC.Introspect: Invalid response");

                return methods;
            }

            foreach (JObject item in (JArray)query["commands"])
            {
                methods.Add(XbmcJsonRpcMethod.FromJson(item));
            }

            return methods;
        }

        public int Version()
        {
            this.client.LogMessage("XbmcJsonRpc.Version()");

            JObject query = this.client.Call("JSONRPC.Version") as JObject;

            if (query == null || query["version"] == null)
            {
                this.client.LogErrorMessage("JSONRPC.Version: Invalid response");

                return -1;
            }

            return (int)query["version"];
        }

        public ICollection<string> Permission()
        {
            this.client.LogMessage("XbmcJsonRpc.Permission()");

            JObject query = this.client.Call("JSONRPC.Permission") as JObject;

            List<string> permissions = new List<string>();

            if (query["permission"] == null)
            {
                this.client.LogErrorMessage("JSONRPC.Permission: Invalid response");

                return permissions;
            }
                
            foreach (string item in ((JArray)query["permission"]))
            {
                permissions.Add(item);
            }

            return permissions;
        }

        public string Ping()
        {
            this.client.LogMessage("XbmcJsonRpc.Ping()");

            object query = this.client.Call("JSONRPC.Ping");
            if (query == null) 
            {
                this.client.LogErrorMessage("JSONRPC.Ping: Invalid response");

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
            this.client.LogMessage("XbmcJsonRpc.Announce()");

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
