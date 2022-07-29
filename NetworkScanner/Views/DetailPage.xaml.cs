// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace NetworkScanner.Views;

/// <summary>
/// Detail page.
/// </summary>
public partial class DetailPage : ContentPage
{
    #region Public and private fields, properties, constructor

    public DetailPage(DetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }

	#endregion
}
