// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Net;
using System.Collections;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using NetworkLib.Helpers;
/* Unmerged change from project 'NetworkLib (net6.0-windows10.0.19041.0)'
Before:
using NetworkLib.Core.Helpers;

namespace NetworkLib.Core.Objects;
After:
using NetworkLib.Core.Helpers;
using NetworkLib;
using NetworkLib.Core;
using NetworkLib.Core.Objects;
*/

namespace NetworkLib.Models;

/// <summary>
/// IP address range.
/// </summary>
[Serializable]
public class IpAddressRange : ISerializable, IEnumerable<IPAddress>
{
    // Pattern 1. CIDR range: "192.168.0.0/24", "fe80::/10"
    private static Regex _m1Regex = new(@"^(?<adr>[\da-f\.:]+)/(?<maskLen>\d+)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    // Pattern 2. Uni address: "127.0.0.1", ":;1"
    private static Regex _m2Regex = new(@"^(?<adr>[\da-f\.:]+)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    // Pattern 3. Begin end range: "169.258.0.0-169.258.0.255"
    private static Regex _m3Regex = new(@"^(?<begin>[\da-f\.:]+)[\-–](?<end>[\da-f\.:]+)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    // Pattern 4. Bit mask range: "192.168.0.0/255.255.255.0"
    private static Regex _m4Regex = new(@"^(?<adr>[\da-f\.:]+)/(?<bitmask>[\da-f\.:]+)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    /// <summary>
    /// The beginning IP address a scan will start from.
    /// </summary>
    public IPAddress Begin { get; set; }
    /// <summary>
    /// The ending IP address a scan will stop with.
    /// </summary>
    public IPAddress End { get; set; }

    /// <summary>
    /// Creates an empty range object, equivalent to "0.0.0.0/0".
    /// </summary>
    public IpAddressRange() : this(new IPAddress(0L)) { }

    /// <summary>
    /// Creates a new range with the same start/end address (range of one).
    /// </summary>
    /// <param name="singleAddress"></param>
    public IpAddressRange(IPAddress singleAddress)
    {
        if (singleAddress == null)
            throw new ArgumentNullException(nameof(singleAddress));

        Begin = End = singleAddress;
    }

    /// <summary>
    /// Create a new range from a begin and end address.
    /// Throws an exception if Begin comes after End, or the
    /// addresses are not in the same family.
    /// </summary>
    public IpAddressRange(IPAddress begin, IPAddress end)
    {
        Begin = begin ?? throw new ArgumentNullException(nameof(begin));
        End = end ?? throw new ArgumentNullException(nameof(end));

        if (Begin.AddressFamily != End.AddressFamily) throw new ArgumentException("Elements must be of the same address family", nameof(end));

        byte[] beginBytes = Begin.GetAddressBytes();
        byte[] endBytes = End.GetAddressBytes();
        if (!Bits.Le(endBytes, beginBytes)) throw new ArgumentException("Begin must be smaller than the End", nameof(begin));
    }

    /// <summary>
    /// Creates a range from a base address and mask bits.
    /// This can also be used with <see cref="SubnetMaskLength"/> to create a
    /// range based on a subnet mask.
    /// </summary>
    /// <param name="baseAddress"></param>
    /// <param name="maskLength"></param>
    public IpAddressRange(IPAddress baseAddress, int maskLength)
    {
        if (baseAddress == null)
            throw new ArgumentNullException(nameof(baseAddress));

        byte[] baseAdrBytes = baseAddress.GetAddressBytes();
        if (baseAdrBytes.Length * 8 < maskLength) throw new FormatException();
        byte[] maskBytes = Bits.GetBitMask(baseAdrBytes.Length, maskLength);
        baseAdrBytes = Bits.And(baseAdrBytes, maskBytes);

        Begin = new(baseAdrBytes);
        End = new(Bits.Or(baseAdrBytes, Bits.Not(maskBytes)));
    }

    [Obsolete("Use the IPAddressRange.Parse static method instead.")]
    public IpAddressRange(string ipRangeString)
    {
        IpAddressRange parsed = Parse(ipRangeString);
        Begin = parsed.Begin;
        End = parsed.End;
    }

    protected IpAddressRange(SerializationInfo info, StreamingContext context)
    {
        List<string> names = new();
        foreach (SerializationEntry item in info) names.Add(item.Name);

        Func<string, IPAddress> deserialize = (name) => names.Contains(name) ?
             IPAddress.Parse(info.GetValue(name, typeof(object)).ToString()) :
             new(0L);

        Begin = deserialize("Begin");
        End = deserialize("End");
    }

    /// <summary>
    /// Checks if an IP address is already contained within the range.
    /// </summary>
    /// <param name="ipaddress">The IP address to check.</param>
    public bool Contains(IPAddress ipaddress)
    {
        if (ipaddress == null)
            throw new ArgumentNullException(nameof(ipaddress));

        if (ipaddress.AddressFamily != Begin.AddressFamily) return false;
        byte[] adrBytes = ipaddress.GetAddressBytes();
        return Bits.Ge(Begin.GetAddressBytes(), adrBytes) && Bits.Le(End.GetAddressBytes(), adrBytes);
    }

    /// <summary>
    /// Checks if an IP address range is already set.
    /// </summary>
    /// <param name="range">The IP address range to check for.</param>
    public bool Contains(IpAddressRange range)
    {
        if (range == null)
            throw new ArgumentNullException(nameof(range));

        if (Begin.AddressFamily != range.Begin.AddressFamily) return false;

        return
            Bits.Ge(Begin.GetAddressBytes(), range.Begin.GetAddressBytes()) &&
            Bits.Le(End.GetAddressBytes(), range.End.GetAddressBytes());

        throw new NotImplementedException();
    }

    /// <summary>
    /// Obtains serialization info about an <see cref="IpAddressRange"/> object.
    /// </summary>
    /// <param name="info">The info to get data for.</param>
    /// <param name="context"></param>
    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        if (info == null) throw new ArgumentNullException(nameof(info));

        info.AddValue("Begin", Begin != null ? Begin.ToString() : "");
        info.AddValue("End", End != null ? End.ToString() : "");
    }

    /// <summary>
    /// Parses an IP address range string into an <see cref="IpAddressRange"/> object.
    /// </summary>
    /// <param name="ipRangeString">The IP range string to parse.</param>
    public static IpAddressRange Parse(string ipRangeString)
    {
        if (ipRangeString == null) throw new ArgumentNullException(nameof(ipRangeString));

        // remove all spaces.
        ipRangeString = ipRangeString.Replace(" ", string.Empty);

        // Pattern 1. CIDR range: "192.168.0.0/24", "fe80::/10"
        Match m1 = _m1Regex.Match(ipRangeString);
        if (m1.Success)
        {
            byte[] baseAdrBytes = IPAddress.Parse(m1.Groups["adr"].Value).GetAddressBytes();
            int maskLen = int.Parse(m1.Groups["maskLen"].Value);
            if (baseAdrBytes.Length * 8 < maskLen) throw new FormatException();
            byte[] maskBytes = Bits.GetBitMask(baseAdrBytes.Length, maskLen);
            baseAdrBytes = Bits.And(baseAdrBytes, maskBytes);
            return new(new(baseAdrBytes), new IPAddress(Bits.Or(baseAdrBytes, Bits.Not(maskBytes))));
        }

        // Pattern 2. Uni address: "127.0.0.1", ":;1"
        Match m2 = _m2Regex.Match(ipRangeString);
        if (m2.Success)
        {
            return new(IPAddress.Parse(ipRangeString));
        }

        // Pattern 3. Begin end range: "169.258.0.0-169.258.0.255"
        Match m3 = _m3Regex.Match(ipRangeString);
        if (m3.Success)
        {
            return new(IPAddress.Parse(m3.Groups["begin"].Value), IPAddress.Parse(m3.Groups["end"].Value));
        }

        // Pattern 4. Bit mask range: "192.168.0.0/255.255.255.0"
        Match m4 = _m4Regex.Match(ipRangeString);
        if (m4.Success)
        {
            byte[] baseAdrBytes = IPAddress.Parse(m4.Groups["adr"].Value).GetAddressBytes();
            byte[] maskBytes = IPAddress.Parse(m4.Groups["bitmask"].Value).GetAddressBytes();
            baseAdrBytes = Bits.And(baseAdrBytes, maskBytes);
            return new(new(baseAdrBytes), new IPAddress(Bits.Or(baseAdrBytes, Bits.Not(maskBytes))));
        }

        throw new FormatException("Unknown IP range string.");
    }

    /// <summary>
    /// Parses an IP range string into an <see cref="IpAddressRange"/> object.
    /// </summary>
    /// <param name="ipRangeString">The range string to parse.</param>
    /// <param name="ipRange">The <see cref="IpAddressRange"/> object to parse to.</param>
    /// <returns>A flag determining whether or not the operation was successful.</returns>
    public static bool TryParse(string ipRangeString, out IpAddressRange ipRange)
    {
        try
        {
            ipRange = Parse(ipRangeString);
            return true;
        }
        catch (Exception)
        {
            ipRange = null;
            return false;
        }
    }

    /// <summary>
    /// Takes a subnetmask (eg, "255.255.254.0") and returns the CIDR bit length of that
    /// address. Throws an exception if the passed address is not valid as a subnet mask.
    /// </summary>
    /// <param name="subnetMask">The subnet mask to use</param>
    /// <returns></returns>
    public static int SubnetMaskLength(IPAddress subnetMask)
    {
        if (subnetMask == null)
            throw new ArgumentNullException(nameof(subnetMask));

        int? length = Bits.GetBitMaskLength(subnetMask.GetAddressBytes());
        if (length == null) throw new ArgumentException("Not a valid subnet mask", "subnetMask");
        return length.Value;
    }

    public IEnumerator<IPAddress> GetEnumerator()
    {
        byte[] first = Begin.GetAddressBytes();
        byte[] last = End.GetAddressBytes();
        for (byte[] ip = first; Bits.Ge(ip, last); ip = Bits.Increment(ip))
            yield return new(ip);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Returns the range in the format "begin-end", or 
    /// as a single address if End is the same as Begin.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return Equals(Begin, End) ? Begin.ToString() : string.Format("{0}-{1}", Begin, End);
    }

    public int GetPrefixLength()
    {
        byte[] byteBegin = Begin.GetAddressBytes();
        byte[] byteEnd = End.GetAddressBytes();

        // Handle single IP
        if (Begin.Equals(End))
        {
            return byteBegin.Length * 8;
        }

        int length = byteBegin.Length * 8;

        for (int i = 0; i < length; i++)
        {
            byte[] mask = Bits.GetBitMask(byteBegin.Length, i);
            if (new IPAddress(Bits.And(byteBegin, mask)).Equals(Begin))
            {
                if (new IPAddress(Bits.Or(byteBegin, Bits.Not(mask))).Equals(End))
                {
                    return i;
                }
            }
        }
        throw new FormatException(string.Format("{0} is not a CIDR Subnet", ToString()));
    }

    /// <summary>
    /// Returns a Cidr String if this matches exactly a Cidr subnet.
    /// </summary>
    public string ToCidrString()
    {
        return string.Format("{0}/{1}", Begin, GetPrefixLength());
    }
}
