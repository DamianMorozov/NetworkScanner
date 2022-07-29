// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace NetworkLib.Core.Objects;

/// <summary>
/// Scan object.
/// </summary>
public class PkScanObject
{
    /// <summary>
    /// A collection of ports that have been scanned or are waiting to be scanned.
    /// </summary>
    public List<PkServiceObject> Services = new();

    /// <summary>
    /// General exception object which is set upon an error.
    /// </summary>
    public Exception Errors { get; set; }
}
