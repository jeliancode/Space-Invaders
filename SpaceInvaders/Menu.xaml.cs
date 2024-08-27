
namespace SpaceInvaders;

public sealed partial class Menu : Page
{
    public Menu()
    {
        this.InitializeComponent();
    }

    private void Jugar_Click(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(MainPage));
    }

    private void Score_Click(object sender, RoutedEventArgs e)
    {
    }

    private void ManualJuego_Click(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(Controls));
    }
}
