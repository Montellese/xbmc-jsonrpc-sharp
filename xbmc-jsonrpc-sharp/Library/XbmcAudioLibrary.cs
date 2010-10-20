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

        // TODO: AudioLibrary: Add sorting
        // TODO: AudioLibrary: Add start & end

        public ICollection<XbmcArtist> GetArtists()
        {
            JObject args = new JObject();
            args.Add(new JProperty("fields", XbmcArtist.Fields));            

            JObject query = this.client.Call("AudioLibrary.GetArtists", args) as JObject;
            if (query == null || query["artists"] == null)
            {
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
            return this.GetAlbums(-1, -1, fields);
        }

        public ICollection<XbmcAlbum> GetAlbums(int artistId, int genreId, params string[] fields)
        {
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

            JObject query = this.client.Call("AudioLibrary.GetAlbums", args) as JObject;
            if (query == null || query["albums"] == null)
            {
                return null;
            }

            List<XbmcAlbum> albums = new List<XbmcAlbum>();
            foreach (JObject item in (JArray)query["albums"])
            {
                albums.Add(XbmcAlbum.FromJson(item));
            }

            return albums;
        }

        public ICollection<XbmcAlbum> GetAlbumsByArtist(int artistId, params string[] fields)
        {
            return this.GetAlbums(artistId, -1, fields);
        }

        public ICollection<XbmcAlbum> GetAlbumsByArtist(XbmcArtist artist, params string[] fields)
        {
            if (artist == null) 
            {
                throw new ArgumentNullException("artist");
            }

            return this.GetAlbums(artist.Id, -1, fields);
        }

        public ICollection<XbmcAlbum> GetAlbumsByGenre(int genreId, params string[] fields)
        {
            return this.GetAlbums(-1, genreId, fields);
        }

        public ICollection<XbmcSong> GetSongs(params string[] fields)
        {
            return this.GetSongs(-1, -1, -1, fields);
        }

        public ICollection<XbmcSong> GetSongs(int albumId, int artistId, int genreId, params string[] fields)
        {
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

            JObject query = this.client.Call("AudioLibrary.GetSongs", args) as JObject;
            if (query == null || query["songs"] == null)
            {
                return null;
            }

            List<XbmcSong> songs = new List<XbmcSong>();
            foreach (JObject item in (JArray)query["songs"])
            {
                songs.Add(XbmcSong.FromJson(item));
            }

            return songs;
        }

        public ICollection<XbmcSong> GetSongsByAlbum(int albumId, params string[] fields)
        {
            return this.GetSongs(albumId, -1, -1, fields);
        }

        public ICollection<XbmcSong> GetSongsByAlbum(XbmcAlbum album, params string[] fields)
        {
            if (album == null)
            {
                throw new ArgumentNullException("album");
            }

            return this.GetSongs(album.Id, -1, -1, fields);
        }

        public ICollection<XbmcSong> GetSongsByArtist(int artistId, params string[] fields)
        {
            return this.GetSongs(-1, artistId, -1, fields);
        }

        public ICollection<XbmcSong> GetSongsByArtist(XbmcArtist artist, params string[] fields)
        {
            if (artist == null)
            {
                throw new ArgumentNullException("artist");
            }

            return this.GetSongs(-1, artist.Id, -1, fields);
        }

        public ICollection<XbmcSong> GetSongsByGenre(int genreId, params string[] fields)
        {
            return this.GetSongs(-1, -1, genreId, fields);
        }

        #endregion

        #region Helper functions

        #endregion
    }
}
