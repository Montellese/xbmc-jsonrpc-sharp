using System;
using System.Collections.Generic;

namespace XBMC.JsonRpc
{
    public class XbmcAudioLibrary : XbmcMediaLibrary
    {
        #region Constructor

        internal XbmcAudioLibrary(JsonRpcClient client)
            : base("AudioLibrary", client)
        { }

        #endregion

        #region JSON RPC Calls

        public ICollection<XbmcArtist> GetArtists(params string[] fields)
        {
            // TODO: XbmcAudioLibrary.GetArtists()
            throw new NotImplementedException();
        }

        public ICollection<XbmcAlbum> GetAlbums(params string[] fields)
        {
            // TODO: XbmcAudioLibrary.GetAlbums()
            throw new NotImplementedException();
        }

        public ICollection<XbmcSong> GetSongs(params string[] fields)
        {
            // TODO: XbmcAudioLibrary.GetSongs()
            throw new NotImplementedException();
        }

        #endregion

        #region Helper functions

        #endregion
    }
}
