using System.IO;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using SpaceInvaders.Model;
using Windows.Media.Core;
using Windows.Media.Playback;


namespace SpaceInvaders;

public sealed partial class MainPage : Page
{
    private Game _game;
    private User _user;
    private ICanvas _canvas;
    private SoundsMaker _soundMaker;
    private Uri shipSound;
    private CollisionDetector _detector;

    public MainPage()
    {

        this.InitializeComponent();
        this.KeyDown += MainPage_KeyDown;
        _canvas = new CanvasManager(mainCanvas);
        _user = new User(_canvas);
        _game = new Game(_canvas);
        _detector = new CollisionDetector(_game._enemies, _user._playerShip, _game._shields);
        _game.CollisionDetector = _detector;
        _game._enemyManager.RequestGameOver += GameOverRequest;
        _detector._lives += UpdateLives;
        _detector._score += UpdateScore;
        UpdateLives(this, _user._playerShip._lives);
        _soundMaker = new SoundsMaker();
        shipSound = new Uri($"E:\\Jelian Files\\2024\\Temp 2\\Programming 3.2\\PROYECTO\\SpaceInvaders\\SpaceInvaders\\spaceinvaders_jesusmaldonado\\SpaceInvaders\\Assets\\Sounds\\ShipSound.mp3");
    }

    private void MainPage_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        switch (e.Key)
        {
            case Windows.System.VirtualKey.Left:
                _user.MoveLeft(_canvas._widthCanvas);
                break;
            case Windows.System.VirtualKey.Right:
                _user.MoveRigth(_canvas._widthCanvas);              
                break;
            case Windows.System.VirtualKey.Space:
                _user.ShootBullet(_detector);
                _soundMaker.MakeSound(shipSound);
                break;
        }
    }

    private void MainCanvas_PointerPressed(object sender, PointerRoutedEventArgs e)
    {
        mainCanvas.Focus(FocusState.Programmatic);
    }

    private void GameOverRequest(object sender, EventArgs e)
    {
        Frame.Navigate(typeof(GameOver), _user._playerShip._points);
    }

    private void UpdateLives(object sender, int lives)
    {
        imageStackPanel.Children.Clear();
        lives = Math.Min(lives, 6);
        for (int i = 0; i < lives; i++)
        {
            Image newImage = ImageCreator.Live;
            imageStackPanel.Children.Add(newImage);
        }

        if(lives == 0)
        {
            GameOverRequest(this, EventArgs.Empty);
        }
    }

    private void UpdateScore(object sender, int points)
    {
        score.Text = points.ToString();
    }
}
