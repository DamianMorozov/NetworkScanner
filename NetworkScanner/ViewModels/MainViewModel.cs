// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

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
    [ObservableProperty]
    public ObservableCollection<string> items;

    /// <summary>
    /// Constructor.
    /// </summary>
    //public MainViewModel(IConnectivity connectivity)
    public MainViewModel()
    {
        items = new();
        //Connectivity = connectivity;
        Db.FillIpRanges(IpRanges, items).ConfigureAwait(true);
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
    private Task Delete(string s)
    {
        if (Items.Contains(s))
        {
            Items.Remove(s);
        }
        return Task.CompletedTask;
    }

    [ICommand]
    private Task Tap(string s)
    {
        return Shell.Current.GoToAsync($"{nameof(MainViewModel)}?Text={s}");
    }

    #endregion
}
