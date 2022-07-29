// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace NetworkLib.Models;

/// <summary>
/// Scan fetchers.
/// </summary>
public class ScanFetchers
{
    /// <summary>
    /// Obtain the hostname of the IP being scanned.
    /// </summary>
    public bool Hostname { get; private set; } = true;
    /// <summary>
    /// Obtain the physical address of the IP being scanned.
    /// </summary>
    public bool Mac { get; private set; } = true;
    /// <summary>
    /// Obtain the length of time — in milliseconds — it takes to reach the destination address.
    /// </summary>
    public bool Ping { get; private set; } = true;
    /// <summary>
    /// Obtain whether or not the destination address is available or not.
    /// </summary>
    public bool Online { get; private set; } = true;

    /// <summary>
    /// A container of parameters for a <see cref="Scanner"/> object which allows the retrieval of set information types.
    /// </summary>
    /// <param name="hostname">Obtain the hostname of the IP being scanned.</param>
    /// <param name="mac">Obtain the physical address of the IP being scanned.</param>
    /// <param name="ping">Obtain the length of time — in milliseconds — it takes to reach the destination address.</param>
    /// <param name="online">Obtain whether or not the destination address is available or not.</param>
    public ScanFetchers(bool hostname = true, bool mac = true, bool ping = true, bool online = true)
    {
        Hostname = hostname;
        Mac = mac;
        Ping = ping;
        Online = online;
    }
}
