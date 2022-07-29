// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace NetworkLib.Models;

#region Completed event handlers

public delegate void ScanCompleteHandler(object sender, ScanCompleteEventArgs e);
public delegate void ScanAsyncCompleteHandler(object sender, ScanAsyncCompleteEventArgs e);
public delegate void ScanRangeCompleteHandler(object sender, ScanRangeCompleteEventArgs e);
public delegate void ScanRangeAsyncCompleteHandler(object sender, ScanRangeAsyncCompleteEventArgs e);
public delegate void ScanListCompleteHandler(object sender, ScanListCompleteEventArgs e);
public delegate void ScanListAsyncCompleteHandler(object sender, ScanListAsyncCompleteEventArgs e);
public delegate void PortKnockCompleteHandler(object sender, PortKnockCompleteEventArgs e);
public delegate void PortKnockAsyncCompeleteHandler(object sender, PortKnockAsyncCompleteEventArgs e);
public delegate void PortKnockRangeCompleteHandler(object sender, PortKnockRangeCompleteEventArgs e);
public delegate void PortKnockRangeAsyncCompleteHandler(object sender, PortKnockRangeAsyncCompleteEventArgs e);
public delegate void PortKnockListCompleteHandler(object sender, PortKnockListCompleteEventArgs e);
public delegate void PortKnockListAsyncCompleteHandler(object sender, PortKnockListAsyncCompleteEventArgs e);

#endregion

#region Progress changed event handlers

public delegate void ScanProgressChangedHandler(object sender, ScanProgressChangedEventArgs e);
public delegate void ScanAsyncProgressChangedHandler(object sender, ScanAsyncProgressChangedEventArgs e);
public delegate void ScanRangeProgressChangedHandler(object sender, ScanRangeProgressChangedEventArgs e);
public delegate void ScanRangeAsyncProgressChangedHandler(object sender, ScanRangeAsyncProgressChangedEventArgs e);
public delegate void ScanListProgressChangedHandler(object sender, ScanListProgressChangedEventArgs e);
public delegate void ScanListAsyncProgressChangedHandler(object sender, ScanListAsyncProgressChangedEventArgs e);
public delegate void PortKnockProgressChangedHandler(object sender, PortKnockProgressChangedEventArgs e);
public delegate void PortKnockAsyncProgressChangedHandler(object sender, PortKnockAsyncProgressChangedEventArgs e);
public delegate void PortKnockRangeProgressChangedHandler(object sender, PortKnockRangeProgressChangedEventArgs e);
public delegate void PortKnockRangeAsyncProgressChangedHandler(object sender, PortKnockRangeAsyncProgressChangedEventArgs e);
public delegate void PortKnockListProgressChangedHandler(object sender, PortKnockListProgressChangedEventArgs e);
public delegate void PortKnockListAsyncProgressChangedHandler(object sender, PortKnockListAsyncProgressChangedEventArgs e);

#endregion

#region Compeletd event args

public class ScanCompleteEventArgs : EventArgs
{
    public IpScanObject Result { get; private set; }
    public ScanCompleteEventArgs(IpScanObject result)
    {
        Result = result;
    }
}

public class ScanAsyncCompleteEventArgs : EventArgs
{
    public IpScanObject Result { get; private set; }
    public ScanAsyncCompleteEventArgs(IpScanObject result)
    {
        Result = result;
    }
}

public class ScanRangeCompleteEventArgs : EventArgs
{
    public List<IpScanObject> Results { get; private set; }
    public ScanRangeCompleteEventArgs(List<IpScanObject> results)
    {
        Results = results;
    }
}

public class ScanRangeAsyncCompleteEventArgs : EventArgs
{
    public List<IpScanObject> Results { get; private set; }
    public ScanRangeAsyncCompleteEventArgs(List<IpScanObject> results)
    {
        Results = results;
    }
}

public class ScanListCompleteEventArgs : EventArgs
{
    public List<IpScanObject> Results { get; private set; }
    public ScanListCompleteEventArgs(List<IpScanObject> results)
    {
        Results = results;
    }
}

public class ScanListAsyncCompleteEventArgs : EventArgs
{
    public List<IpScanObject> Results { get; private set; }
    public ScanListAsyncCompleteEventArgs(List<IpScanObject> results)
    {
        Results = results;
    }
}

public class PortKnockCompleteEventArgs : EventArgs
{
    public PkScanObject Result { get; private set; }
    public PortKnockCompleteEventArgs(PkScanObject result)
    {
        Result = result;
    }
}

public class PortKnockAsyncCompleteEventArgs : EventArgs
{
    public PkScanObject Result { get; private set; }
    public PortKnockAsyncCompleteEventArgs(PkScanObject result)
    {
        Result = result;
    }
}

public class PortKnockRangeCompleteEventArgs : EventArgs
{
    public List<PkScanObject> Results { get; private set; }
    public PortKnockRangeCompleteEventArgs(List<PkScanObject> results)
    {
        Results = results;
    }
}

public class PortKnockRangeAsyncCompleteEventArgs : EventArgs
{
    public List<PkScanObject> Results { get; private set; }
    public PortKnockRangeAsyncCompleteEventArgs(List<PkScanObject> results)
    {
        Results = results;
    }
}

public class PortKnockListCompleteEventArgs : EventArgs
{
    public List<PkScanObject> Results { get; private set; }
    public PortKnockListCompleteEventArgs(List<PkScanObject> results)
    {
        Results = results;
    }
}

public class PortKnockListAsyncCompleteEventArgs : EventArgs
{
    public List<PkScanObject> Results { get; private set; }
    public PortKnockListAsyncCompleteEventArgs(List<PkScanObject> results)
    {
        Results = results;
    }
}

#endregion

#region Progress changed event args

public class ScanProgressChangedEventArgs : EventArgs
{
    public int Progress { get; private set; }
    public ScanProgressChangedEventArgs(int progress)
    {
        Progress = progress;
    }
}

public class ScanAsyncProgressChangedEventArgs : EventArgs
{
    public int Progress { get; private set; }
    public ScanAsyncProgressChangedEventArgs(int progress)
    {
        Progress = progress;
    }
}

public class ScanRangeProgressChangedEventArgs : EventArgs
{
    public int Progress { get; private set; }
    public string CurrentlyScanning { get; private set; }
    public ScanRangeProgressChangedEventArgs(int progress, string current = "Unknown")
    {
        Progress = progress;
        CurrentlyScanning = current;
    }
}

public class ScanRangeAsyncProgressChangedEventArgs : EventArgs
{
    public int Progress { get; private set; }
    public string CurrentlyScanning { get; private set; }
    public ScanRangeAsyncProgressChangedEventArgs(int progress, string current = "Unknown")
    {
        Progress = progress;
        CurrentlyScanning = current;
    }
}

public class ScanListProgressChangedEventArgs : EventArgs
{
    public int Progress { get; private set; }
    public string CurrentlyScanning { get; private set; }
    public ScanListProgressChangedEventArgs(int progress, string current = "Unknown")
    {
        Progress = progress;
        CurrentlyScanning = current;
    }
}

public class ScanListAsyncProgressChangedEventArgs : EventArgs
{
    public int Progress { get; private set; }
    public string CurrentlyScanning { get; private set; }
    public ScanListAsyncProgressChangedEventArgs(int progress, string current = "Unknown")
    {
        Progress = progress;
        CurrentlyScanning = current;
    }
}

public class PortKnockProgressChangedEventArgs : EventArgs
{
    public int Progress { get; private set; }
    public PortKnockProgressChangedEventArgs(int progress)
    {
        if (progress > Progress)
            Progress = progress;
    }
}

public class PortKnockAsyncProgressChangedEventArgs : EventArgs
{
    public int Progress { get; private set; }
    public PortKnockAsyncProgressChangedEventArgs(int progress)
    {
        if (progress > Progress)
            Progress = progress;
    }
}

public class PortKnockRangeProgressChangedEventArgs : EventArgs
{
    public int Progress { get; private set; }
    public string CurrentlyScanning { get; private set; }
    public PortKnockRangeProgressChangedEventArgs(int progress, string current = "Unknown")
    {
        Progress = progress;
        CurrentlyScanning = current;
    }
}

public class PortKnockRangeAsyncProgressChangedEventArgs : EventArgs
{
    public int Progress { get; private set; }
    public string CurrentlyScanning { get; private set; }
    public PortKnockRangeAsyncProgressChangedEventArgs(int progress, string current = "Unknown")
    {
        Progress = progress;
        CurrentlyScanning = current;
    }
}

public class PortKnockListProgressChangedEventArgs : EventArgs
{
    public int Progress { get; private set; }
    public string CurrentlyScanning { get; private set; }
    public PortKnockListProgressChangedEventArgs(int progress, string current = "Unknown")
    {
        Progress = progress;
        CurrentlyScanning = current;
    }
}

public class PortKnockListAsyncProgressChangedEventArgs : EventArgs
{
    public int Progress { get; private set; }
    public string CurrentlyScanning { get; private set; }
    public PortKnockListAsyncProgressChangedEventArgs(int progress, string current = "Unknown")
    {
        Progress = progress;
        CurrentlyScanning = current;
    }
}

#endregion
