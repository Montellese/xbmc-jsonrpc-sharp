using System;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using System.Text;

namespace XBMC.JsonRpc
{
    public class XbmcJsonRpcConnection : IDisposable
    {
        #region Constants

        private const int AnnouncementPort = 9090;
        private const string AnnouncementEnd = "}}";
        private const string AnnouncementEndAlternative = "}\n}\n";
        private const string AnnouncementMethod = "Announcement";
        private const string AnnouncementSender = "xbmc";
        private const string PingResponse = "pong";

        #endregion

        #region Private variables

        private bool disposed;

        private JsonRpcClient client;
        private Socket socket;

        private XbmcJsonRpc jsonRpc;
        private XbmcPlayer player;
        private XbmcSystem system;
        private XbmcGeneral xbmc;
        private XbmcFiles files;
        private XbmcPlaylist playlist;
        private XbmcLibrary library;

        #endregion

        #region Public variables

        public bool IsAlive
        {
            get
            {
                if (!this.socket.Connected)
                {
                    return false;
                }

                string ping = this.jsonRpc.Ping();
                if (string.IsNullOrEmpty(ping) || string.CompareOrdinal(ping, PingResponse) != 0)
                {
                    return false;
                }

                return true;
            }
        }

        public XbmcJsonRpc JsonRpc
        {
            get { return this.jsonRpc; }
        }

        public XbmcPlayer Player
        {
            get { return this.player; }
        }

        public XbmcSystem System
        {
            get { return this.system; }
        }

        public XbmcGeneral Xbmc
        {
            get { return this.xbmc; }
        }

        public XbmcFiles Files
        {
            get { return this.files; }
        }

        public XbmcPlaylist Playlist
        {
            get { return this.playlist; }
        }

        public XbmcLibrary Library
        {
            get { return this.library; }
        }

        #endregion

        #region Events

        public event EventHandler Aborted;

        #endregion

        #region Constructors

        public XbmcJsonRpcConnection(Uri uri)
            : this(uri, null, null)
        { }

        public XbmcJsonRpcConnection(Uri uri, string username, string password)
        {
            this.client = new JsonRpcClient(uri, username, password);
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            this.jsonRpc = new XbmcJsonRpc(this.client);
            this.player = new XbmcPlayer(this.client);
            this.system = new XbmcSystem(this.client);
            this.xbmc = new XbmcGeneral(this.client);
            this.files = new XbmcFiles(this.client);
            this.playlist = new XbmcPlaylist(this.client);
            this.library = new XbmcLibrary(this.client);
        }

        public XbmcJsonRpcConnection(string address, int port)
            : this(address, port, null, null)
        { }

        public XbmcJsonRpcConnection(string address, int port, string username, string password)
            : this(new Uri("http://" + address + ":" + port + "/jsonrpc"), username, password)
        { }

        #endregion

        #region Public functions

        public bool Open() 
        {
            try
            {
                this.socket.Connect(this.client.Uri.Host, AnnouncementPort);
                // Send a ping to XBMC
                if (!this.IsAlive)
                {
                    this.Close();
                    return false;
                }
                
                this.receive(new SocketStateObject());
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message + ": " + ex.StackTrace);
                return false;
            }

            return true;
        }

        public void Close()
        {
            if (this.socket.Connected)
            {
                this.socket.Disconnect(true);
            }
        }

        #endregion

        #region Implementations of IDisposable

        public void Dispose()
        {
            if (!this.disposed) 
            {
                lock (this.socket)
                {
                    this.Close();
                    this.socket.Close();
                }

                this.disposed = true;
                GC.SuppressFinalize(this);
            }
        }

        #endregion

        #region Private functions

        private void onAborted()
        {
            if (this.Aborted == null)
            {
                return;
            }

            this.Aborted(this, null);
        }

        private void onAnnouncement(string data)
        {
            JObject announcement = JObject.Parse(data);
            JObject param = announcement["params"] as JObject;
            if (announcement["method"] == null || string.CompareOrdinal((string)announcement["method"], AnnouncementMethod) != 0
                || param == null)
            {
                return;
            }

            if (param["sender"] == null || string.CompareOrdinal((string)param["sender"], AnnouncementSender) != 0
                || param["message"] == null)
            {
                return;
            }

            string type = (string)param["message"];

            if (string.CompareOrdinal(type, "PlaybackStarted") == 0)
            {
                this.player.OnPlaybackStarted();
            }
            else if (string.CompareOrdinal(type, "PlaybackPaused") == 0)
            {
                this.player.OnPlaybackPaused();
            }
            else if (string.CompareOrdinal(type, "PlaybackResumed") == 0)
            {
                this.player.OnPlaybackResumed();
            }
            else if (string.CompareOrdinal(type, "PlaybackStopped") == 0)
            {
                this.player.OnPlaybackStopped();
            }
            else if (string.CompareOrdinal(type, "PlaybackEnded") == 0)
            {
                this.player.OnPlaybackEnded();
            }
            else if (string.CompareOrdinal(type, "PlaybackSeek") == 0)
            {
                this.player.OnPlaybackSeek();
            }
            else if (string.CompareOrdinal(type, "PlaybackSeekChapter") == 0)
            {
                this.player.OnPlaybackSeekChapter();
            }
            else if (string.CompareOrdinal(type, "PlaybackSpeedChanged") == 0)
            {
                this.player.OnPlaybackSpeedChanged();
            }
            else if (string.CompareOrdinal(type, "QueueNextItem") == 0)
            {
                this.playlist.OnItemQueued();
            }
            else if (string.CompareOrdinal(type, "ApplicationStop") == 0)
            {
                this.Close();
                this.onAborted();
            }
            else if (string.CompareOrdinal(type, "Shutdown") == 0)
            {
                this.Close();
                this.system.OnShutdown();
            }
            else if (string.CompareOrdinal(type, "Suspend") == 0)
            {
                this.Close();
                this.system.OnSuspend();
            }
            else if (string.CompareOrdinal(type, "Hibernate") == 0)
            {
                this.Close();
                this.system.OnHibernate();
            }
            else if (string.CompareOrdinal(type, "Reboot") == 0)
            {
                this.Close();
                this.system.OnReboot();
            }
            else if (string.CompareOrdinal(type, "Sleep") == 0)
            {
                this.Close();
                this.system.OnSleep();
            }
            else if (string.CompareOrdinal(type, "Wake") == 0)
            {
                this.system.OnWake();
            }
            else if (string.CompareOrdinal(type, "Resume") == 0)
            {
                this.system.OnResume();
            }
            else if (string.CompareOrdinal(type, "LowBattery") == 0)
            {
                this.system.OnLowBattery();
            }
        }

        private void receiveAnnouncements(IAsyncResult result)
        {
            if (this.disposed)
            {
                return;
            }

            try 
            {
                lock (this.socket)
                {
                    SocketStateObject state = result.AsyncState as SocketStateObject;
                    if (state == null || this.socket == null || !this.socket.Connected)
                    {
                        return;
                    }

                    int read = this.socket.EndReceive(result);
                    if (read > 0)
                    {
                        state.Builder.Append(Encoding.UTF8.GetString(state.Buffer, 0, read));

                        this.receive(state);
                    }

                    string data = state.Builder.ToString();
                    if (data.Length > 0 && data.Contains(AnnouncementEnd) || data.Contains(AnnouncementEndAlternative))
                    {
                        int pos = data.IndexOf(AnnouncementEnd);
                        if (pos < 0)
                        {
                            pos = data.IndexOf(AnnouncementEndAlternative) + AnnouncementEndAlternative.Length;
                        }
                        else
                        {
                            pos += AnnouncementEnd.Length;
                        }
                        state.Builder.Remove(0, pos);
                        this.onAnnouncement(data.Substring(0, pos));
                    }

                    this.receive(state);
                }
            }
            catch (Exception ex) 
            {
                Console.Out.WriteLine(ex.Message + ": " + ex.StackTrace);
            }
        }

        private void receive(SocketStateObject state)
        {
            if (state == null || this.socket == null || !this.socket.Connected)
            {
                return;
            }

            this.socket.BeginReceive(state.Buffer, 0, SocketStateObject.BufferSize,
                    0, new AsyncCallback(this.receiveAnnouncements), state);
        }

        #endregion
    }
}
