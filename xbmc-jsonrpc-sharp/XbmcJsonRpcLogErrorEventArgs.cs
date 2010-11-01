using System;
using System.Collections.Generic;
using System.Text;

namespace XBMC.JsonRpc
{
    public class XbmcJsonRpcLogErrorEventArgs : XbmcJsonRpcLogEventArgs
    {
        #region Private variables

        private Exception exception;

        #endregion

        #region Public variables

        public Exception Exception
        {
            get { return this.exception; }
        }

        #endregion

        #region Constructors

        public XbmcJsonRpcLogErrorEventArgs(string message) 
            : base(message)
        { }

        public XbmcJsonRpcLogErrorEventArgs(string message, Exception exception) 
            : base(message)
        {
            this.exception = exception;
        }

        #endregion
    }
}
