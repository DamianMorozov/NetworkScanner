// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace NetworkLib.Models;

public class FavoriteObject
{
    public string Name { get; set; }
    public string Data { get; set; }
    public FavoriteObject(string name, string data)
    {
        Name = name;
        Data = data;
    }
}
