using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using Windows.System;

namespace SpaceInvadersJM;

public sealed partial class MainPage : Page
{
    private const int NumAliens = 10;
    private const int NumRows = 4;
    private const int AlienSize = 40;
    private const int AlienSpeed = 3;

    private double alienDirection = 1;
    private DispatcherTimer gameTimer;

    public MainPage()
    {
        this.InitializeComponent();
        shipWindows.Focus(FocusState.Programmatic);
        KeyDown += Canvas_KeyDown;
        InitializeInvaders();
        StartGame();
    }

    private void StartGame()
    {
        gameTimer = new DispatcherTimer();
        gameTimer.Interval = TimeSpan.FromMilliseconds(10);
        gameTimer.Tick += GameTimer_Tick;
        gameTimer.Start();
    }

    private void GameTimer_Tick(object sender, object e)
    {
        MoveAliens();
    }

    private void Canvas_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        var playerLeft = Canvas.GetLeft(playerShip);
        var key = e.Key;
        double movement = 10;
        double newLeft = playerLeft - movement;
        double newRight = playerLeft + movement;

        switch (key)
        {
            case VirtualKey.Left:
                if (newLeft >= 0)
                {
                    Canvas.SetLeft(playerShip, newLeft);
                }
                break;
            case VirtualKey.Right:
                if (newRight > 0)
                {
                    Canvas.SetLeft(playerShip, newRight);
                }
                break;
        }
    }

    private void InitializeInvaders()
    {
        for (int row = 0; row < NumRows; row++)
        {
            for (int col = 0; col < NumAliens; col++)
            {
                var alienImage = new Image
                {
                    Width = AlienSize,
                    Height = AlienSize,
                    Margin = new Thickness(5),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };

                alienImage.Source = new BitmapImage(new Uri("https://static.vecteezy.com/system/resources/previews/009/400/796/original/ufo-spaceship-concept-clipart-design-illustration-free-png.png"));

                double left = col * (AlienSize + alienImage.Margin.Left + alienImage.Margin.Right);
                double top = row * (AlienSize + alienImage.Margin.Top + alienImage.Margin.Bottom);
                alienImage.Margin = new Thickness(left, top, 0, 0);

                invadersWindows.Children.Add(alienImage);
            }
        }
    }

    private void MoveAliens()
    {
        double newX = Canvas.GetLeft(invadersWindows.Children[0]) + (AlienSpeed * alienDirection);
        double minY = 0;
        double maxY = invadersWindows.Height - (NumRows * AlienSize) - ((NumRows - 1) * 5);
        double maxX = invadersWindows.Width - (NumAliens * AlienSize) - ((NumAliens - 1) * 5);

        if (newX <= 0 || newX >= maxX)
        {
            alienDirection *= -1;
            foreach (Image alien in invadersWindows.Children)
            { 
                double newY = Canvas.GetTop(alien);
                Canvas.SetTop(alien, newY + AlienSize);
            }
        }
        else
        {
            foreach (Image alien in invadersWindows.Children)
            {
                double currentX = Canvas.GetLeft(alien);
                Canvas.SetLeft(alien, currentX + (AlienSpeed * alienDirection));
            }
        }

        foreach (Image alien in invadersWindows.Children)
        {
            double currentY = Canvas.GetTop(alien);
            if (currentY >= maxY)
            {
                gameTimer.Stop();
            }
        }
    }
}
