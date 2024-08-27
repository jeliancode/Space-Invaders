using Microsoft.UI.Xaml.Media.Imaging;


namespace SpaceInvaders.Model;
public static class ImageCreator
{
    public static Image PlayerShip => SetImage("ms-appx:///Assets/Images/playerShip.png", 32,32,new Thickness(0,0,0,0));
    public static Image Enemy1 => SetImage("ms-appx:///Assets/Images/enemy3.png", 32,32,new Thickness(0,0,0,0));
    public static Image Enemy2 => SetImage("ms-appx:///Assets/Images/enemy1.png", 32, 32, new Thickness(0, 0, 0, 0));
    public static Image Enemy3 => SetImage("ms-appx:///Assets/Images/enemy2.png", 32, 32, new Thickness(0, 0, 0, 0));
    public static Image Bullet => SetImage("ms-appx:///Assets/Images/bullet.png", 20, 20, new Thickness(0, 0, 10, 0));
    public static Image Live => SetImage("ms-appx:///Assets/Images/live.png", 32, 32, new Thickness(0, 0, 10, 0));

    public static Image PlayerBlock_1 => SetImage("ms-appx:///Assets/Images/destroyedByPlayer1.png", 25, 25, new Thickness(0, 0, 0, 0));
    public static Image PlayerBlock_2 => SetImage("ms-appx:///Assets/Images/destroyedByPlayer2.png", 25, 25, new Thickness(0, 0, 0, 0));
    public static Image PlayerBlock_3 => SetImage("ms-appx:///Assets/Images/destroyedByPlayer3.png", 25, 25, new Thickness(0, 0, 0, 0));
    public static Image PlayerBlock_4 => SetImage("ms-appx:///Assets/Images/destroyedByPlayer4.png", 25, 25, new Thickness(0, 0, 0, 0));
    public static Image EnemyBlock_1 => SetImage("ms-appx:///Assets/Images/destroyedByEnemy1.png", 25, 25, new Thickness(0, 0, 0, 0));
    public static Image EnemyBlock_2 => SetImage("ms-appx:///Assets/Images/destroyedByEnemy2.png", 25, 25, new Thickness(0, 0, 0, 0));
    public static Image EnemyBlock_3 => SetImage("ms-appx:///Assets/Images/destroyedByEnemy3.png", 25, 25, new Thickness(0, 0, 0, 0));
    public static Image EnemyBlock_4 => SetImage("ms-appx:///Assets/Images/destroyedByEnemy4.png", 25, 25, new Thickness(0, 0, 0, 0));
    public static Image MainBlock => SetImage("ms-appx:///Assets/Images/muroPrincipal.png", 25, 25, new Thickness(0, 0, 0, 0));



    private static Image SetImage(string uri, double width, double height, Thickness margin)
    {
        Image image = new Image
        {
            Source = new BitmapImage(new Uri(uri)),
            Width = width,
            Height = height,
            Margin = margin
        };

        return image;
    }
}
