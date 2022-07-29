// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Xml.Linq;

namespace NetworkLib.Assembly;

/// <summary>
/// XML extensions.
/// </summary>
public static class XElementExtensions
{
    public static string TryGetElementValue(this XElement parentElement, string elementName, string defaultValue = null)
    {
        XElement foundElement = parentElement.Element(elementName);
        if (foundElement != null) { return foundElement.Value; }
        return defaultValue;
    }
}
