using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

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

        // TODO: XbmcAudioLibrary: Add sorting

        public ICollection<XbmcArtist> GetArtists()
        {
            return this.GetArtists(-1, -1);
        }

        public ICollection<XbmcArtist> GetArtists(int start, int end)
        {
            this.client.LogMessage("XbmcAudioLibrary.GetArtists()");
            
            JObject args = new JObject();
            args.Add(new JProperty("fields", XbmcArtist.Fields));
            if (start >= 0)
            {
                args.Add(new JProperty("start", start));
            }
            if (end >= 0)
            {
                args.Add(new JProperty("end", end));
            }

            JObject query = this.client.Call("AudioLibrary.GetArtists", args) as JObject;
            if (query == null || query["artists"] == null)
            {
                this.client.LogErrorMessage("AudioLibrary.GetArtists(): Invalid response");

                return null;
            }

            List<XbmcArtist> artists = new List<XbmcArtist>();
            foreach (JObject item in (JArray)query["artists"])
            {
                artists.Add(XbmcArtist.FromJson(item));
            }

            return artists;
        }

        public ICollection<XbmcAlbum> GetAlbums(params string[] fields)
        {
            return this.getAlbums(-1, -1, -1, -1, fields);
        }

        public ICollection<XbmcAlbum> GetAlbums(int start, int end, params string[] fields)
        {
            return this.getAlbums(-1, -1, start, end, fields);
        }

        public ICollection<XbmcAlbum> GetAlbums(XbmcArtist artist, params string[] fields)
        {
            if (artist == null) 
            {
                throw new ArgumentNullException("artist");
            }

            return this.getAlbums(artist.Id, -1, -1, -1, fields);
        }

        public ICollection<XbmcAlbum> GetAlbums(XbmcArtist artist, int start, int end, params string[] fields)
        {
            if (artist == null)
            {
                throw new ArgumentNullException("artist");
            }

            return this.getAlbums(artist.Id, -1, start, end, fields);
        }

        public ICollection<XbmcAlbum> GetAlbums(int genreId, params string[] fields)
        {
            return this.getAlbums(-1, genreId, -1, -1, fields);
        }

        public ICollection<XbmcAlbum> GetAlbums(int genreId, int start, int end, params string[] fields)
        {
            return this.getAlbums(-1, genreId, start, end, fields);
        }

        public ICollection<XbmcSong> GetSongs(params string[] fields)
        {
            return this.getSongs(-1, -1, -1, -1, -1, fields);
        }

        public ICollection<XbmcSong> GetSongs(int start, int end, params string[] fields)
        {
            return this.getSongs(-1, -1, -1, start, end, fields);
        }

        public ICollection<XbmcSong> GetSongs(XbmcAlbum album, params string[] fields)
        {
            if (album == null)
            {
                throw new ArgumentNullException("album");
            }

            return this.getSongs(album.Id, -1, -1, -1, -1, fields);
        }

        public ICollection<XbmcSong> GetSongs(XbmcAlbum album, int start, int end, params string[] fields)
        {
            if (album == null)
            {
                throw new ArgumentNullException("album");
            }

            return this.getSongs(album.Id, -1, -1, start, end, fields);
        }

        public ICollection<XbmcSong> GetSongs(XbmcArtist artist, params string[] fields)
        {
            if (artist == null)
            {
                throw new ArgumentNullException("artist");
            }

            return this.getSongs(-1, artist.Id, -1, -1, -1, fields);
        }

        public ICollection<XbmcSong> GetSongs(XbmcArtist artist, int start, int end, params string[] fields)
        {
            if (artist == null)
            {
                throw new ArgumentNullException("artist");
            }

            return this.getSongs(-1, artist.Id, -1, start, end, fields);
        }

        public ICollection<XbmcSong> GetSongs(int genreId, params string[] fields)
        {
            return this.getSongs(-1, -1, genreId, -1, -1, fields);
        }

        public ICollection<XbmcSong> GetSongs(int genreId, int start, int end, params string[] fields)
        {
            return this.getSongs(-1, -1, genreId, start, end, fields);
        }

        #endregion

        #region Helper functions

        private ICollection<XbmcSong> getSongs(int albumId, int artistId, int genreId, int start, int end, params string[] fields)
        {
            this.client.LogMessage("XbmcAudioLibrary.GetSongs()");

            JObject args = new JObject();
            if (albumId >= 0)
            {
                args.Add(new JProperty("albumid", albumId));
            }
            if (artistId >= 0)
            {
                args.Add(new JProperty("artistid", artistId));
            }
            if (genreId >= 0)
            {
                args.Add(new JProperty("genreid", genreId));
            }
            if (fields != null && fields.Length > 0)
            {
                string[] fieldCopy = new string[fields.Length + 3];
                fieldCopy[0] = "title";
                fieldCopy[1] = "artist";
                fieldCopy[2] = "album";
                Array.Copy(fields, 0, fieldCopy, 3, fields.Length);
                args.Add(new JProperty("fields", fieldCopy));
            }
            else
            {
                args.Add(new JProperty("fields", XbmcSong.Fields));
            }
            if (start >= 0)
            {
                args.Add(new JProperty("start", start));
            }
            if (end >= 0)
            {
                args.Add(new JProperty("end", end));
            }

            JObject query = this.client.Call("AudioLibrary.GetSongs", args) as JObject;
            if (query == null || query["songs"] == null)
            {
                this.client.LogErrorMessage("AudioLibrary.GetSongs(): Invalid response");

                return null;
            }

            List<XbmcSong> songs = new List<XbmcSong>();
            foreach (JObject item in (JArray)query["songs"])
            {
                songs.Add(XbmcSong.FromJson(item));
            }

            return songs;
        }

        private ICollection<XbmcAlbum> getAlbums(int artistId, int genreId, int start, int end, params string[] fields)
        {
            this.client.LogMessage("XbmcAudioLibrary.GetAlbums()");

            JObject args = new JObject();
            if (artistId >= 0)
            {
                args.Add(new JProperty("artistid", artistId));
            }
            if (genreId >= 0)
            {
                args.Add(new JProperty("genreid", genreId));
            }
            if (fields != null && fields.Length > 0)
            {
                string[] fieldCopy = new string[fields.Length + 2];
                fieldCopy[0] = "albumid";
                fieldCopy[1] = "album_artist";
                Array.Copy(fields, 0, fieldCopy, 2, fields.Length);
                args.Add(new JProperty("fields", fieldCopy));
            }
            else
            {
                args.Add(new JProperty("fields", XbmcAlbum.Fields));
            }
            if (start >= 0)
            {
                args.Add(new JProperty("start", start));
            }
            if (end >= 0)
            {
                args.Add(new JProperty("end", end));
            }

            JObject query = this.client.Call("AudioLibrary.GetAlbums", args) as JObject;
            if (query == null || query["albums"] == null)
            {
                this.client.LogErrorMessage("AudioLibrary.GetAlbums(): Invalid response");

                return null;
            }

            List<XbmcAlbum> albums = new List<XbmcAlbum>();
            foreach (JObject item in (JArray)query["albums"])
            {
                albums.Add(XbmcAlbum.FromJson(item));
            }

            return albums;
        }

        #endregion
    }
}
