// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Net;

namespace NetworkLib.Core.Objects;

/// <summary>
/// IP scan object.
/// </summary>
public class IpScanObject
{
    /// <summary>
    /// The original IP address in a string representation that was provided to the IPScanObject.
    /// </summary>
    public string Address { get; private set; } // The originally scanned IP

    /// <summary>
    /// The original IP address provided to the IPScanObject parsed to an IPAddress object.
    /// </summary>
    public IPAddress Ip { get; private set; } // The originally scanned IP

    /// <summary>
    /// The average response time in milliseconds for a data packet to be sent and replied to.
    /// </summary>
    public long Ping { get; private set; } // The average response time for a ping request

    /// <summary>
    /// The name of the device sitting at an endpoint.
    /// </summary>
    public string Hostname { get; private set; } // The actual name of the host

    /// <summary>
    /// The physical address of a device at a specific endpoint.
    /// </summary>
    public string Mac { get; private set; } // The physical address of the computer

    /// <summary>
    /// Collection of scanned ports.
    /// </summary>
    public PkScanObject Ports { get; private set; }

    /// <summary>
    /// The online status of a device at a specific endpoint.
    /// </summary>
    public bool IsOnline { get; private set; }

    /// <summary>
    /// Total amount of time for current object's scan to complete.
    /// </summary>
    public double Elapsed { get; set; }

    /// <summary>
    /// General exception object which is set upon an error.
    /// </summary>
    public Exception Errors { get; set; }

    /// <summary>
    /// Default Constructor.
    /// </summary>
    public IpScanObject() { }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="address">The original IP.</param>
    /// <param name="pingTime">The average response time in milliseconds for a ping request.</param>
    /// <param name="hostname">The actual name of a device at an endpoint.</param>
    /// <param name="mac">The physical address of a device.</param>
    /// <param name="ports">Collection of scanned ports.</param>
    /// <param name="online">The online status of a device.</param>
    /// <param name="elapsed">Total amount of time for current object's scan to compelte.</param>
    public IpScanObject(string address, long pingTime, string hostname, string mac, PkScanObject ports, bool online, double elapsed = 0)
    {
        Address = address;
        try { Ip = IPAddress.Parse(address); } catch { } // The provided IP wasn't formatted correctly.
        Ping = pingTime;
        Hostname = hostname;
        Mac = mac;
        Ports = ports;
        IsOnline = online;
        Elapsed = elapsed;
    }
}
