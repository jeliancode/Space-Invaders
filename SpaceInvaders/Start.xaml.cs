namespace SpaceInvaders;

public sealed partial class InicioSesion : Page
{
    public InicioSesion()
    {
        this.InitializeComponent();

    }

    private void Play_Click(object sender, RoutedEventArgs e)
    {
        Frame.Navigate(typeof(MainPage));
    }
}
