// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NetworkScanner.Views;

namespace NetworkScanner;

/// <summary>
/// App shell.
/// </summary>
public partial class AppShell : Shell
{
    #region Public and private fields, properties, constructor

    /// <summary>
    /// Constructor.
    /// </summary>
    public AppShell()
    {
        InitializeComponent();

        if (DeviceInfo.Idiom == DeviceIdiom.Phone)
        {
            Current.CurrentItem = PhoneTabs;
        }
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        Routing.RegisterRoute(nameof(TagsPage), typeof(TagsPage));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
    }

    #endregion

    #region Public and private methods

    private async Task GoBack()
    {
        await Current.GoToAsync("..");
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        Current.GoToAsync($"{nameof(AppShell)}");
    }

    #endregion
}
