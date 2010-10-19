using System;
using Newtonsoft.Json.Linq;

namespace XBMC.JsonRpc
{
    public class XbmcSong : XbmcAudio
    {
        #region Private variables

        private string label;
        private string fanart;
        private string thumbnail;
        private string file;

        private string title;
        private string artist;
        private string genre;
        private int year;
        private int rating;
        private string album;
        private string albumArtist;
        private int track;
        private int disc;
        private int trackAndDisc;
        private TimeSpan duration;
        private string comment;
        private string lyrics;
        private string musicbrainzTrackId;
        private string musicbrainzArtistId;
        private string musicbrainzAlbumId;
        private string musicbrainzAlbumartistId;
        private string musicbrainzTRMId;

        #endregion

        #region Public variables

        #endregion

        #region Constructors

        internal XbmcSong(int id)
            : base(id)
        {
            // TODO: XbmcSong.ctor()
        }

        #endregion

        #region Internal static functions

        internal static new XbmcSong FromJson(JObject obj)
        {
            // TODO: XbmcSong.FromJson()
            return new XbmcSong(-1);
        }

        #endregion
    }
}
