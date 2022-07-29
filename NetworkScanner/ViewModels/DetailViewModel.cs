namespace NetworkScanner.ViewModels;

/// <summary>
/// Detail view model.
/// </summary>
[QueryProperty("Text", "Text")]
public partial class DetailViewModel : BaseViewModel
{
    #region Public and private methods

    [ICommand]
    private async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailViewModel)}?Text={s}");
    }

    #endregion
}
