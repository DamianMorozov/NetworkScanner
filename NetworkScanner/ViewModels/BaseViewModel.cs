// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace NetworkScanner.ViewModels;

/// <summary>
/// Base view model.
/// </summary>
public partial class BaseViewModel : ObservableObject
{
    #region Public and private fields, properties, constructor

    [ObservableProperty]
    public string text;

    [ObservableProperty]
    public string title;

    [ObservableProperty]
    [AlsoNotifyChangeFor(nameof(IsNotBusy))]
    public bool isBusy;
    public bool IsNotBusy => !IsBusy;

    /// <summary>
    /// Database helper.
    /// </summary>
    public DbHelper Db { get; } = DbHelper.Instance;

    #endregion

    #region Public and private methods

    /// <summary>
    /// Go back command.
    /// </summary>
    [ICommand]
    public async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }

    #endregion
}
