using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
namespace Puzzler.ViewModels
{
    public partial class LevelPageViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial Level Level { get; set; }
        [ObservableProperty]
        public partial string Title { get; set; }
        [ObservableProperty]
        public partial string SubTitle { get; set; }
        [ObservableProperty]
        public partial Level SlidingTilesLevel { get; set; }
        [ObservableProperty]
        public partial double SlidingTilesWidth { get; set; }
        [ObservableProperty]
        public partial double SlidingTilesHeight { get; set; }

        [RelayCommand]
        private static async Task SlidingTilesCompleted()
        {
            await App.Current.Windows[0].Page.DisplayAlert("Congratulations", "Party time", "Whoop whoop");
            await Shell.Current.GoToAsync("..");
        }
        partial void OnLevelChanged(Level value)
        {
            SlidingTilesLevel = value;
        }

    }
}
