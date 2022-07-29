// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Net;

namespace NetworkLib.Models;

public enum Status { Alive, Dead, Open, Unknown }

public class Object
{
    public IPAddress Ip { get; set; }
    public string Address { get; set; }
    public string Hostname { get; set; }
    public string Mac { get; set; }
    public string Ping { get; set; }
    public PkScanObject Ports { get; set; }
    public string Online { get; set; }
    public Status Status { get; set; }
    public string Comments { get; set; } = "n/a";
    
    public Object(IPAddress ip, string address, string hostname, string mac, string ping, PkScanObject ports, string online, Status status = Status.Unknown)
    {
        Ip = ip;
        Address = address;
        Hostname = hostname;
        Mac = mac;
        Ping = ping;
        Ports = ports;
        Online = online;
        Status = status;
    }
}
