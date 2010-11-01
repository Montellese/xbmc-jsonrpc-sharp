using System;
using System.Collections.Generic;
using System.Text;

namespace XBMC.JsonRpc
{
    public class XbmcJsonRpcLogEventArgs : EventArgs
    {
        #region Private variables

        private string message;

        #endregion

        #region Public variables

        public string Message
        {
            get { return this.message; }
        }

        #endregion

        #region Constructors

        public XbmcJsonRpcLogEventArgs(string message) 
            : base()
        {
            this.message = message;
        }

        #endregion
    }
}
