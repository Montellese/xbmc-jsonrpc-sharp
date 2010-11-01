using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcJsonRpcNamespace
    {
        #region Private variables

        protected JsonRpcClient client;

        #endregion

        #region Constructor

        protected XbmcJsonRpcNamespace(JsonRpcClient client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }

            this.client = client;
        }

        #endregion

        #region Helper functions

        protected TType getInfo<TType>(string label)
        {
            return this.getInfo<TType>(label, default(TType));
        }

        protected TType getInfo<TType>(string label, TType defaultValue)
        {
            this.client.LogMessage("System.GetInfoLabels(" + label + ")");

            JObject result = this.client.Call("System.GetInfoLabels", new string[] { label }) as JObject;
            if (result == null || result[label] == null)
            {
                this.client.LogErrorMessage("System.GetInfoLabels(" + label + "): Invalid response");

                return defaultValue;
            }

            return JsonRpcClient.GetField<TType>(result, label, defaultValue);
        }

        #endregion
    }
}
