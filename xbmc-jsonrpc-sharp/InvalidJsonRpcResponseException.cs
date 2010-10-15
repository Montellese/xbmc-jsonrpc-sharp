using System;
using System.Collections.Generic;
using System.Text;

namespace XBMC.JsonRpc
{
    public class InvalidJsonRpcResponseException : Exception
    {
        #region Private variables

        private string response;

        #endregion

        #region Public variables

        public string Response
        {
            get { return this.response; }
        }

        #endregion

        #region Constructors

        internal InvalidJsonRpcResponseException(string response)
            : this(response, null)
        { }

        internal InvalidJsonRpcResponseException(string response, string message)
            : this(response, message, null)
        { }

        internal InvalidJsonRpcResponseException(string response, string message, Exception innerException)
            : base(message, innerException)
        {
            this.response = response;
        }

        #endregion
    }
}
