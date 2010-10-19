using System;

namespace XBMC.JsonRpc
{
    public class XbmcLibrary : XbmcJsonRpcNamespace
    {
        #region Private variables

        private XbmcAudioLibrary audio;
        private XbmcVideoLibrary video;

        #endregion

        #region Public variables

        public XbmcAudioLibrary Audio
        {
            get { return this.audio; }
        }

        public XbmcVideoLibrary Video
        {
            get { return this.video; }
        }

        #endregion

        #region Constructor

        internal XbmcLibrary(JsonRpcClient client)
            : base(client)
        {
            this.audio = new XbmcAudioLibrary(client);
            this.video = new XbmcVideoLibrary(client);
        }

        #endregion
    }
}
