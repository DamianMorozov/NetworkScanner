// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace NetworkLib.Models;

internal class StatsObject
{
    public string Type { get; private set; }
    public string TotalTime { get; private set; }
    public string AverageTime { get; private set; }
    public string TotalHosts { get; private set; }
    public string OnlineHosts { get; private set; }
    public string OpenHosts { get; private set; }

    public StatsObject(string type, string elapsed, string average, string hosts, string online, string open)
    {
        Type = type;
        TotalTime = elapsed;
        AverageTime = average;
        TotalHosts = hosts;
        OnlineHosts = online;
        OpenHosts = open;
    }
}
