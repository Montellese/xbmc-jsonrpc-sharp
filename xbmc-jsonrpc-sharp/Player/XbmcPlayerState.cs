using System;

namespace XBMC.JsonRpc
{
    [Flags]
    public enum XbmcPlayerState
    {
        Unavailable = 1,
        Playing     = 2,
        Paused      = 4,
        PartyMode   = 8
    }
}