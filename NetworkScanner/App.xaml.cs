// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace NetworkScanner;

/// <summary>
/// Main app.
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
