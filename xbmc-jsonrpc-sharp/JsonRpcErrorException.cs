using System;

namespace XBMC.JsonRpc
{
    public class JsonRpcErrorException : Exception
    {
        #region Private variables

        private int code;

        #endregion

        #region Public variables

        public int Code
        {
            get { return this.code; }
        }

        #endregion

        #region Constructors

        internal JsonRpcErrorException(int code, string message)
            : this(code, message, null)
        { }

        internal JsonRpcErrorException(int code, string message, Exception innerException)
            : base(message, innerException)
        {
            this.code = code;
        }

        #endregion
    }
}
