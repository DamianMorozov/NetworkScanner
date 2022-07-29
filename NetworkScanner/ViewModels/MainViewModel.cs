// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NetworkScanner.Views;

namespace NetworkScanner.ViewModels;

/// <summary>
/// Main view model.
/// </summary>
public partial class MainViewModel : BaseViewModel
{
    #region Public and private fields, properties, constructor

    //public readonly IConnectivity Connectivity;
    /// <summary>
    /// IP ranges.
    /// </summary>
    public ObservableCollection<IpRangeEntity> IpRanges { get; set; } = new();
    [ObservableProperty] public ObservableCollection<string> _items;

    /// <summary>
    /// Constructor.
    /// </summary>
    //public MainViewModel(IConnectivity connectivity)
    public MainViewModel()
    {
        Items = new();
        //Connectivity = connectivity;
        Db.FillIpRanges(IpRanges, Items);
    }

    #endregion

    #region Public and private methods

    [ICommand]
    private async Task Add()
    {
        if (string.IsNullOrWhiteSpace(Text))
            return;

        //if (Connectivity.NetworkAccess != NetworkAccess.Internet)
        //{
        //    await Shell.Current.DisplayAlert("Uh Oh!", "No Internet", "OK");
        //    return;
        //}
        Items.Add(Text);
        IpRangeEntity ipRange = new()
        {
            Name = Text,
        };
        _ = await Db.AddIpRange(ipRange);
        Text = string.Empty;
    }

    [ICommand]
    private async Task Delete(string s)
    {
        if (Items.Contains(s))
        {
            Items.Remove(s);
        }
    }

    [ICommand]
    private async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(MainViewModel)}?Text={s}");
    }

    #endregion
}
