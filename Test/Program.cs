using System;

using XBMC.JsonRpc;

namespace Test
{
    class Program
    {
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
                    Console.Out.WriteLine("succeeded (Version {0})", xbmc.JsonRpc.Version());

                    Console.Out.WriteLine("Press <Enter> to finish...");
                    Console.In.ReadLine();
                }
            }

            Console.In.ReadLine();
        }
    }
}
