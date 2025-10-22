using CommunityToolkit.Mvvm.Input;
using Puzzler.Views;
namespace Puzzler.ViewModels
{
    public partial class HomePageViewModel
    {

        [RelayCommand]
        private async Task PlayButtonClicked()
        {
            await Shell.Current.GoToAsync(nameof(LevelSelectionPage));
        }
    }
}
