using System;

using XBMC.JsonRpc;

namespace Test
{
    class Program
    {
        private static bool aborted;

        static void Main(string[] args)
        {
            using (XbmcJsonRpcConnection xbmc = new XbmcJsonRpcConnection("127.0.0.1", 8080))
            {
                Console.Out.Write("Connecting to XBMC...");
                if (!xbmc.Open())
                {
                    Console.Out.WriteLine("failed");
                }
                else
                {
                    xbmc.Aborted += xbmc_Aborted;
                    xbmc.Player.PlaybackStarted += xbmc_PlaybackStarted;
                    xbmc.Player.PlaybackPaused += xbmc_PlaybackPaused;
                    xbmc.Player.PlaybackResumed += xbmc_PlaybackResumed;
                    xbmc.Player.PlaybackStopped += xbmc_PlaybackStopped;
                    xbmc.Player.PlaybackSeek += xbmc_PlaybackSeek;
                    xbmc.Player.PlaybackSpeedChanged += xbmc_PlaybackSpeedChanged;

                    Console.Out.WriteLine("succeeded (Version {0})",     xbmc.JsonRpc.Version());
                    Console.Out.WriteLine("Press <Enter> to disconnect...");

                    while (!aborted)
                    {
                        int ch = Console.In.Peek();
                        if (ch == '\n' || ch == '\r')
                        {
                            Console.In.ReadLine();
                            break;
                        }
                    }
                }
            }

            Console.Out.Write("Press <Enter> to close...");
            Console.In.ReadLine();
        }

        #region Event handlers

        private static void xbmc_Aborted(object sender, EventArgs e)
        {
            Console.Out.WriteLine("XBMC has been closed and the connection aborted!");
            aborted = true;
        }

        private static void xbmc_PlaybackStarted(object sender, XbmcPlayerPlaybackChangedEventArgs e) 
        {
            Console.Out.WriteLine("Playback in {0} started", e.Player.ToString());
        }

        private static void xbmc_PlaybackPaused(object sender, XbmcPlayerPlaybackPositionChangedEventArgs e)
        {
            Console.Out.WriteLine("Playback in {0} paused at {1} of {2}", e.Player.ToString(), e.Position, e.Length);
        }

        private static void xbmc_PlaybackResumed(object sender, XbmcPlayerPlaybackPositionChangedEventArgs e)
        {
            Console.Out.WriteLine("Playback in {0} resumed from {1} of {2}", e.Player.ToString(), e.Position, e.Length);
        }

        private static void xbmc_PlaybackStopped(object sender, EventArgs e)
        {
            Console.Out.WriteLine("Playback  stopped");
        }

        private static void xbmc_PlaybackSeek(object sender, XbmcPlayerPlaybackPositionChangedEventArgs e)
        {
            Console.Out.WriteLine("Playback in {0} seeked to {1} of {2}", e.Player.ToString(), e.Position, e.Length);
        }

        private static void xbmc_PlaybackSpeedChanged(object sender, XbmcPlayerPlaybackChangedEventArgs e)
        {
            Console.Out.WriteLine("Playback speed in {0} changed", e.Player.ToString());
        }

        #endregion
    }
}
