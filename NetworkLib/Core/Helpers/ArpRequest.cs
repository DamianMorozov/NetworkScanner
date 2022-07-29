// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Net;
using System.Net.NetworkInformation;

namespace NetworkLib.Core.Helpers;

/// <summary>
/// ARP request.
/// </summary>
public static class ArpRequest
{
    /// <summary>
    /// Send request.
    /// </summary>
    /// <param name="destination"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static ArpRequestResult Send(IPAddress destination)
    {
        if (destination == null)
            throw new ArgumentNullException(nameof(destination));

        int destIp = BitConverter.ToInt32(destination.GetAddressBytes(), 0);

        byte[] addr = new byte[6];
        uint len = (uint)addr.Length;

        Vanara.PInvoke.Win32Error res = Vanara.PInvoke.IpHlpApi.SendARP(destIp, 0, addr, ref len);

        if (res == 0)
            return new(new PhysicalAddress(addr));
        return new(res.GetException());
    }
}
