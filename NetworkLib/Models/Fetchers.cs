// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace NetworkLib.Models;

internal class Fetchers
{
    public bool Hostname = true;
    public bool Mac = true;
    public bool Ping = true;
    public bool Online = true;

    public Fetchers(bool hostname, bool mac, bool ping, bool online)
    {
        Hostname = hostname;
        Mac = mac;
        Ping = ping;
        Online = online;
    }
}
