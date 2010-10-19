using System;

namespace XBMC.JsonRpc
{
    public class XbmcMediaLibrary : XbmcJsonRpcNamespace
    {
        #region Private variables

        private string libraryName;

        #endregion

        #region Public variables

        #endregion

        #region Constructors

        protected XbmcMediaLibrary(string libraryName, JsonRpcClient client)
            : base(client)
        {
            if (string.IsNullOrEmpty(libraryName))
            {
                throw new ArgumentException();
            }

            this.libraryName = libraryName;
        }

        #endregion

        #region JSON RPC Calls

        public virtual bool ScanForContent()
        {
            return (this.client.Call(this.libraryName + ".ScanForContent") != null);
        }

        #endregion

        #region Helper functions

        #endregion
    }
}
