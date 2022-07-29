namespace NetworkLib.Models;

/// <summary>
/// IScanner interface.
/// </summary>
public interface IScanner
{
    /// <summary>
    /// The amount of requests to send to a destination address in order to determine a ping response.
    /// </summary>
    int Probes { get; set; }

    /// <summary>
    /// The amount of time � in milliseconds � a probe should take before sending another request.
    /// </summary>
    int Timeout { get; set; }

    /// <summary>
    /// A collection of information types that should be retrieved during a scan.
    /// </summary>
    ScanFetchers Fetchers { get; set; }

    /// <summary>
    /// Occurs when a scan has been completed.
    /// </summary>
    event ScanCompleteHandler ScanComplete;

    /// <summary>
    /// Occurs when an asynchronous scan has been completed.
    /// </summary>
    event ScanAsyncCompleteHandler ScanAsyncComplete;

    /// <summary>
    /// Occurs when a range scan has been completed.
    /// </summary>
    event ScanRangeCompleteHandler ScanRangeComplete;

    /// <summary>
    /// Occurs when an asynchronous range scan has been completed.
    /// </summary>
    event ScanRangeAsyncCompleteHandler ScanRangeAsyncComplete;

    /// <summary>
    /// Occurs when a list scan has been completed.
    /// </summary>
    event ScanListCompleteHandler ScanListComplete;

    /// <summary>
    /// Occurs when an asynchronous list scan has been completed.
    /// </summary>
    event ScanListAsyncCompleteHandler ScanListAsyncComplete;

    /// <summary>
    /// Occurs when a port knock scan has been completed.
    /// </summary>
    event PortKnockCompleteHandler PortKnockComplete;

    /// <summary>
    /// Occurs when an asynchronous port knock scan has been completed.
    /// </summary>
    event PortKnockAsyncCompeleteHandler PortKnockAsyncComplete;

    /// <summary>
    /// Occurs when a range port knock scan has been completed.
    /// </summary>
    event PortKnockRangeCompleteHandler PortKnockRangeComplete;

    /// <summary>
    /// Occurs when an asynchronous range port knock scan has been completed.
    /// </summary>
    event PortKnockRangeAsyncCompleteHandler PortKnockRangeAsyncComplete;

    /// <summary>
    /// Occurs when a list port knock scan has been completed.
    /// </summary>
    event PortKnockListCompleteHandler PortKnockListComplete;

    /// <summary>
    /// Occurs when an asynchronous list port knock scan has been completed.
    /// </summary>
    event PortKnockListAsyncCompleteHandler PortKnockListAsyncComplete;

    /// <summary>
    /// Occurs when progress has been updated in a scan.
    /// </summary>
    event ScanProgressChangedHandler ScanProgressChanged;

    /// <summary>
    /// Occurs when progress has been updated in an asynchronous scan.
    /// </summary>
    event ScanAsyncProgressChangedHandler ScanAsyncProgressChanged;

    /// <summary>
    /// Occurs when progress has been updated in a range scan.
    /// </summary>
    event ScanRangeProgressChangedHandler ScanRangeProgressChanged;

    /// <summary>
    /// Occurs when progress has been updated in an asynchronous range scan.
    /// </summary>
    event ScanRangeAsyncProgressChangedHandler ScanRangeAsyncProgressChanged;

    /// <summary>
    /// Occurs when progress has been updated in a list scan.
    /// </summary>
    event ScanListProgressChangedHandler ScanListProgressChanged;

    /// <summary>
    /// Occurs when progress has been updated in an asynchronous list scan.
    /// </summary>
    event ScanListAsyncProgressChangedHandler ScanListAsyncProgressChanged;

    /// <summary>
    /// Occurs when progress has been updated in a port knock scan.
    /// </summary>
    event PortKnockProgressChangedHandler PortKnockProgressChanged;

    /// <summary>
    /// Occurs when progress has been updated in an asynchronous port knock scan.
    /// </summary>
    event PortKnockAsyncProgressChangedHandler PortKnockAsyncProgressChanged;

    /// <summary>
    /// Occurs when progress has been updated in a range port knock scan.
    /// </summary>
    event PortKnockRangeProgressChangedHandler PortKnockRangeProgressChanged;

    /// <summary>
    /// Occurs when progress has been updated in an asynchronous range port knock scan.
    /// </summary>
    event PortKnockRangeAsyncProgressChangedHandler PortKnockRangeAsyncProgressChanged;

    /// <summary>
    /// Occurs when progress has been updated in a list port knock scan.
    /// </summary>
    event PortKnockListProgressChangedHandler PortKnockListProgressChanged;

    /// <summary>
    /// Occurs when progress has been updated in an asynchronous list port knock scan.
    /// </summary>
    event PortKnockListAsyncProgressChangedHandler PortKnockListAsyncProgressChanged;

    /// <summary>
    /// Synchronously scan a single local IP address in order to obtain more information about it.
    /// </summary>
    /// <param name="ip">The endpoint to enumerate information from.</param>
    /// <returns></returns>
    IpScanObject Scan(string ip);

    /// <summary>
    /// Asynchronously scan a single local IP address in order to obtain more information about it.
    /// </summary>
    /// <param name="ip">The endpoint to enumerate information from.</param>
    /// <returns></returns>
    Task<IpScanObject> ScanAsync(string ip);

    /// <summary>
    /// Synchronously scan a subsequent range of IP addresses for information.
    /// </summary>
    /// <param name="ip1">The beginning endpoint that intializes the scan.</param>
    /// <param name="ip2">The ending endpoint that the scan will stop after.</param>
    List<IpScanObject> ScanRange(string ip1, string ip2);

    /// <summary>
    /// Asynchronously scan a subsequent range of IP addresses for information.
    /// </summary>
    /// <param name="ip1">The starting endpoint that initializes the scan.</param>
    /// <param name="ip2">The ending endpoint that the scan will stop after.</param>
    /// <returns></returns>
    Task<List<IpScanObject>> ScanRangeAsync(string ip1, string ip2);

    /// <summary>
    /// Synchronously scan a pre-formatted list of IP addresses for information.
    /// </summary>
    /// <param name="list">A list of IPs formatted as such: "address1, address2, address3, ..."</param>
    List<IpScanObject> ScanList(string list);

    /// <summary>
    /// Asynchronously scan a pre-formatted list of IP addresses for information.
    /// </summary>
    /// <param name="list">A list of IPs formatted as such: "address1, address2, address3, ..."</param>
    /// <returns></returns>
    Task<List<IpScanObject>> ScanListAsync(string list);

    /// <summary>
    /// Synchronoulsy scan an endpoint for open ports and their services.
    /// </summary>
    /// <param name="ip">The endpoint that should be scanned.</param>
    PkScanObject PortKnock(string ip);

    /// <summary>
    /// Asynchronously scan an endpoint for open ports and their services.
    /// </summary>
    /// <param name="ip">The endpoint that should be scanned.</param>
    /// <returns></returns>
    Task<PkScanObject> PortKnockAsync(string ip);

    /// <summary>
    /// Synchronously scan a subsequent range of endpoints for open ports and their services.
    /// </summary>
    /// <param name="ip1">The starting endpoint which initializaes the scan.</param>
    /// <param name="ip2">The ending endpoint which the scan will stop after.</param>
    List<PkScanObject> PortKnockRange(string ip1, string ip2);

    /// <summary>
    /// Asynchronously scan a subsequent range of a endpoints for open ports and their services.
    /// </summary>
    /// <param name="ip1">The starting endpoint which initializes the scan.</param>
    /// <param name="ip2">The ending endpoint which the scan will stop after.</param>
    /// <returns></returns>
    Task<List<PkScanObject>> PortKnockRangeAsync(string ip1, string ip2);

    /// <summary>
    /// Synchronously scan a pre-formatted list of IP addresses for open ports and their services.
    /// </summary>
    /// <param name="list">A list of IPs formatted as such: "address1, address2, address3, ..."</param>
    List<PkScanObject> PortKnockList(string list);

    /// <summary>
    /// Asynchronously scan a pre-formatted list of IP addresses for open ports and their services.
    /// </summary>
    /// <param name="list">A list of IPs formatted as such: "address1, address2, address3, ...</param>
    /// <returns></returns>
    Task<List<PkScanObject>> PortKnockListAsync(string list);
}