using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Puzzler.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Puzzler.ViewModels
{
    public partial class LevelSelectionPageViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial ObservableCollection<Level> Levels { get; set; }

        [ObservableProperty]
        public partial Level SelectedLevel { get; set; }
        [ObservableProperty]
        public partial bool IsEnabled { get; set; } = false;
        private int childCount = 0;

        public ICommand LoadImageCommand { get; }



        partial void OnSelectedLevelChanged(Level value)
        {
            if (value is not null)
            {
                // Navigate to LevelPage with query parameter
                Shell.Current.GoToAsync(nameof(LevelPage), new Dictionary<string, object>
                {
                    { "Level", value }
                });
            }
        }
        public LevelSelectionPageViewModel()
        {
            Levels = [];
            Levels = LoadLevels();
            LoadImageCommand = new Command<string>(async (imageName) =>
            {
                // Load image logic here
                await Task.CompletedTask;
            });
        }

        private static ObservableCollection<Level> LoadLevels()
        {
            // Load your levels here
            List<Level> source = [];
            source.Add(new Level { Name = "First", ImageName = "first.jpg", Difficulty = LevelDifficulty.Easy });
            source.Add(new Level { Name = "Cheetah", ImageName = "cheetah.jpg", Difficulty = LevelDifficulty.Easy });
            source.Add(new Level { Name = "Koala", ImageName = "koala.jpg", Difficulty = LevelDifficulty.Easy });
            source.Add(new Level { Name = "Giraffe", ImageName = "giraffe.jpg", Difficulty = LevelDifficulty.Easy });

            source.Add(new Level { Name = "First", ImageName = "first.jpg", Difficulty = LevelDifficulty.Medium });
            source.Add(new Level { Name = "Cheetah", ImageName = "cheetah.jpg", Difficulty = LevelDifficulty.Medium });
            source.Add(new Level { Name = "Koala", ImageName = "koala.jpg", Difficulty = LevelDifficulty.Medium });
            source.Add(new Level { Name = "Giraffe", ImageName = "giraffe.jpg", Difficulty = LevelDifficulty.Medium });

            source.Add(new Level { Name = "First", ImageName = "first.jpg", Difficulty = LevelDifficulty.Hard });
            source.Add(new Level { Name = "Cheetah", ImageName = "cheetah.jpg", Difficulty = LevelDifficulty.Hard });
            source.Add(new Level { Name = "Koala", ImageName = "koala.jpg", Difficulty = LevelDifficulty.Hard });
            source.Add(new Level { Name = "Giraffe", ImageName = "giraffe.jpg", Difficulty = LevelDifficulty.Hard });
            return new ObservableCollection<Level>(source);
        }
        [RelayCommand]
        private async Task OnChildAdded(Element element)
        {
            // Handle layout logic or animations
            if (element is VisualElement visualElement)
            {
                // Move the item off screen.
                visualElement.TranslationY = DeviceDisplay.Current.MainDisplayInfo.Height;

                await Task.Delay(250 + (childCount++ * 100));

                await visualElement.TranslateTo(0, -20, length: 650, Easing.SinInOut);
                await visualElement.TranslateTo(0, 10, length: 250, Easing.SinInOut);
                await visualElement.TranslateTo(0, 0, length: 150, Easing.SinInOut);
            }
        }

    }
}
