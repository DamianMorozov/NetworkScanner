// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace NetworkLib.Models;

/// <summary>
/// Data transfer protocols.
/// </summary>
public enum EnumProtocol
{
    /// <summary>
    /// TCP.
    /// </summary>
    Tcp,
    /// <summary>
    /// UDP.
    /// </summary>
    Udp
}

/// <summary>
/// PK service object.
/// </summary>
public class PkServiceObject
{
    /// <summary>
    /// Initial IP address that was scanned.
    /// </summary>
    public string Ip { get; set; }

    /// <summary>
    /// Initial port that was scanned.
    /// </summary>
    public int Port { get; set; }

    /// <summary>
    /// The transfer protocol that the port is running on.
    /// </summary>
    public EnumProtocol Protocol { get; set; }

    /// <summary>
    /// Status of the port itself; open or closed.
    /// </summary>
    public bool Status { get; set; }

    /// <summary>
    /// Default Constructor.
    /// </summary>
    public PkServiceObject() { }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="ip">Initial ip that was scanned.</param>
    /// <param name="port">Initial port that was scanned.</param>
    /// <param name="protocol">The transfer protocol that the port is running on.</param>
    /// <param name="status">Status of the port itself; open or closed.</param>
    public PkServiceObject(string ip, int port, EnumProtocol protocol, bool status)
    {
        Ip = ip;
        Port = port;
        Protocol = protocol;
        Status = status;
    }
}
