// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace NetworkLib.Helpers;

/// <summary>
/// BITS.
/// </summary>
public static class Bits
{
    public static byte[] Not(byte[] bytes)
    {
        return bytes.Select(b => (byte)~b).ToArray();
    }

    public static byte[] And(byte[] a, byte[] b)
    {
        return a.Zip(b, (a, b) => (byte)(a & b)).ToArray();
    }

    public static byte[] Or(byte[] a, byte[] b)
    {
        return a.Zip(b, (a, b) => (byte)(a | b)).ToArray();
    }

    public static bool Ge(byte[] a, byte[] b)
    {
        return a.Zip(b, (a, b) => a == b ? 0 : a < b ? 1 : -1)
            .SkipWhile(c => c == 0)
            .FirstOrDefault() >= 0;
    }

    public static bool Le(byte[] a, byte[] b)
    {
        return a.Zip(b, (a, b) => a == b ? 0 : a < b ? 1 : -1)
            .SkipWhile(c => c == 0)
            .FirstOrDefault() <= 0;
    }

    public static byte[] GetBitMask(int sizeOfBuff, int bitLen)
    {
        byte[] maskBytes = new byte[sizeOfBuff];
        int bytesLen = bitLen / 8;
        int bitsLen = bitLen % 8;
        for (int i = 0; i < bytesLen; i++)
        {
            maskBytes[i] = 0xff;
        }
        if (bitsLen > 0) maskBytes[bytesLen] = (byte)~Enumerable.Range(1, 8 - bitsLen).Select(n => 1 << n - 1).Aggregate((a, b) => a | b);
        return maskBytes;
    }

    /// <summary>
    /// Counts the number of leading 1's in a bitmask. Returns null if value is invalid as a bitmask.
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static int? GetBitMaskLength(byte[] bytes)
    {
        if (bytes == null) throw new ArgumentNullException(nameof(bytes));

        int bitLength = 0;
        int idx = 0;

        // find beginning 0xFF
        for (; idx < bytes.Length && bytes[idx] == 0xff; idx++) ;
        bitLength = 8 * idx;

        if (idx < bytes.Length)
        {
            switch (bytes[idx])
            {
                case 0xFE: bitLength += 7; break;
                case 0xFC: bitLength += 6; break;
                case 0xF8: bitLength += 5; break;
                case 0xF0: bitLength += 4; break;
                case 0xE0: bitLength += 3; break;
                case 0xC0: bitLength += 2; break;
                case 0x80: bitLength += 1; break;
                case 0x00: break;
                default: // invalid bitmask
                    return null;
            }
            // remainder must be 0x00
            if (bytes.Skip(idx + 1).Any(x => x != 0x00)) return null;
        }
        return bitLength;
    }

    public static byte[] Increment(byte[] bytes)
    {
        if (bytes == null) throw new ArgumentNullException(nameof(bytes));

        int incrementIndex = Array.FindLastIndex(bytes, x => x < byte.MaxValue);
        if (incrementIndex < 0) throw new OverflowException();
        return bytes
            .Take(incrementIndex)
            .Concat(new byte[] { (byte)(bytes[incrementIndex] + 1) })
            .Concat(new byte[bytes.Length - incrementIndex - 1])
            .ToArray();
    }
}
