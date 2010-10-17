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

        private static void xbmc_Aborted(object sender, EventArgs e)
        {
            Console.Out.WriteLine("XBMC has been closed and the connection aborted!");
            aborted = true;
        }
    }
}
