// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Net.NetworkInformation;
using System.Text;

namespace NetworkLib.Helpers;

/// <summary>
/// ARP request result.
/// </summary>
public class ArpRequestResult
{
    /// <summary>
    /// Exception.
    /// </summary>
    public Exception Exception { get; }

    /// <summary>
    /// Address.
    /// </summary>
    public PhysicalAddress Address { get; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="address"></param>
    public ArpRequestResult(PhysicalAddress address)
    {
        Exception = null;
        Address = address;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="exception"></param>
    public ArpRequestResult(Exception exception)
    {
        Exception = exception;
        Address = null;
    }

    /// <summary>
    /// To string.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        StringBuilder sb = new();
        if (Address == null)
            sb.Append("no address");
        else
        {
            sb.Append("address: ");
            sb.Append(Address);
        }
        sb.Append(", ");
        if (Exception == null)
            sb.Append("no exception");
        else
        {
            sb.Append("exception: ");
            sb.Append(Exception.Message);
        }
        return sb.ToString();
    }
}
