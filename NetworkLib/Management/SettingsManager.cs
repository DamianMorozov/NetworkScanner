// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Xml.Linq;
using NetworkLib.Assembly;
using NetworkLib.Models;
using Object = NetworkLib.Models.Object;

namespace NetworkLib.Management;

internal static class SettingsManager
{
    internal static int MaxThreads = 100;
    internal static int ThreadDelay = 0;
    internal static int PingProbes = 3;
    internal static int PingTimeout = 1000;
    internal static bool SkipUnassaigned = true;
    internal static bool AskForConfirmation = true;
    internal static bool ShowStatisticsDialog = true;
    internal static Fetchers Fetchers = new(true, true, true, true);
    internal static Dictionary<string, string> Favorites = new();
    internal static string SettingsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Sharp Scanner\settings.xml";

    internal static void SaveSettings()
    {
        // Check if the save path exists and create it if it doesn't.
        if (!Directory.Exists(Path.GetDirectoryName(SettingsPath))) { Directory.CreateDirectory(Path.GetDirectoryName(SettingsPath)); }

        // Save our settings file.
        XDocument doc = SettingsData();
        doc.Save(SettingsPath);
    }

    internal static void LoadSettings()
    {
        // Check if a settings file exists.
        if (File.Exists(SettingsPath))
        {
            try
            {
                // Create a list of objects to update the list with.
                List<Object> objects = new();

                // Create a node to obtain our settings from.
                XDocument doc = XDocument.Load(SettingsPath);

                // Get the values for settings.
                var data = from item in doc.Descendants("settings")
                           select new
                           {
                               threads = item.TryGetElementValue("MaxThreads"),
                               delay = item.TryGetElementValue("ThreadDelay"),
                               probes = item.TryGetElementValue("PingProbes"),
                               timeout = item.TryGetElementValue("PingTimeout"),
                               skip = item.TryGetElementValue("SkipUnassigned"),
                               ask = item.TryGetElementValue("AskForConfirmation"),
                               show = item.TryGetElementValue("ShowStatisticsDialog"),
                               f = item.TryGetElementValue("Fetchers")
                           };

                // Set our settings to our xml values.
                foreach (var item in data)
                {
                    int.TryParse(item.threads, out MaxThreads);
                    int.TryParse(item.delay, out ThreadDelay);
                    int.TryParse(item.probes, out PingProbes);
                    int.TryParse(item.timeout, out PingTimeout);
                    bool.TryParse(item.skip, out SkipUnassaigned);
                    bool.TryParse(item.ask, out AskForConfirmation);
                    bool.TryParse(item.show, out ShowStatisticsDialog);
                    bool hostname = true, mac = true, ping = true, online = true;
                    try
                    {
                        string[] split = item.f.Split('|');
                        if (split[0] == "False") { hostname = false; }
                        if (split[1] == "False") { mac = false; }
                        if (split[2] == "False") { ping = false; }
                        if (split[3] == "False") { online = false; }
                    }
                    catch { } // Let the default fetchers roll.
                    Fetchers = new(hostname, mac, ping, online);
                }

                // Get values for favorites.
                var favs = from item in doc.Descendants("favorite")
                           select new
                           {
                               name = item.TryGetElementValue("Name"),
                               data = item.TryGetElementValue("Data")
                           };

                // Setup a new dictionary.
                foreach (var item in favs)
                {
                    if (item.name != null && item.data != null)
                        Favorites.Add(item.name, item.data);
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Sharp Scanner couldn't load settings due to file corruption.", "Sharp Scanner", 
                //MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }

    private static XDocument SettingsData()
    {
        // Create the root node.
        XElement root = new("SharpScanner");

        // Create nodes for settings.
        XElement row = new("settings");
        XElement col = new("MaxThreads", MaxThreads.ToString());
        row.Add(col);
        col = new("ThreadDelay", ThreadDelay.ToString());
        row.Add(col);
        col = new("PingProbes", PingProbes.ToString());
        row.Add(col);
        col = new("PingTimeout", PingTimeout.ToString());
        row.Add(col);
        col = new("SkipUnassigned", SkipUnassaigned.ToString());
        row.Add(col);
        col = new("AskForConfirmation", AskForConfirmation.ToString());
        row.Add(col);
        col = new("ShowStatisticsDialog", ShowStatisticsDialog.ToString());
        row.Add(col);
        col = new("Fetchers", Fetchers.Hostname + "|" +
                              Fetchers.Mac + "|" +
                              Fetchers.Ping + "|" +
                              Fetchers.Online);
        row.Add(col);
        root.Add(row);

        // Create nodes for favorites.
        row = new("favorites");
        for (int i = 0; i < Favorites.Count; i++)
        {
            XElement newRow = new("favorite");
            row.Add(newRow);
            col = new("Name", Favorites.ElementAt(i).Key);
            newRow.Add(col);
            col = new("Data", Favorites.ElementAt(i).Value);
            newRow.Add(col);
        }
        root.Add(row);

        XDocument doc = new(
            new("1.0", "utf-8", "yes"),
            new XComment("Generated by Sharp Scanner 1.0.0"),
            new XComment("Website: https://github.com/CloneMerge/sharpscanner"),
            root);

        return doc;
    }
}
