namespace Puzzler.Pages;

[QueryProperty(nameof(Level), nameof(Level))]
public partial class LevelPage : ContentPage
{
    public Level Level { get; set; }

    public LevelPage()
    {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        TitleLabel.Text = Level.Name;
        SubtitleLabel.Text = Level.Difficulty.ToString();

        SlidingTiles.Level = Level;
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        if (width > 0)
        {
            var smallest = Math.Min(width, height);
#if WINDOWS
            SlidingTiles.WidthRequest = smallest / 2;
            SlidingTiles.HeightRequest = smallest / 2;
#else
            SlidingTiles.WidthRequest = smallest;
            SlidingTiles.HeightRequest = smallest;
#endif
        }
    }

    private async void OnSlidingTilesCompleted(object sender, EventArgs e)
    {
        await this.DisplayAlert("Congratulations", "Party time", "Whoop whoop");

        await Shell.Current.GoToAsync("..");
    }
}