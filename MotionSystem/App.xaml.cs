namespace MotionSystem;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new Views.TodayPage())
        {
            BarBackgroundColor = Colors.Transparent,
            BarTextColor = Colors.Transparent
        };
    }
}
