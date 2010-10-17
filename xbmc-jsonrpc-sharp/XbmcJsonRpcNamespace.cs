using System;

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
    }
}
