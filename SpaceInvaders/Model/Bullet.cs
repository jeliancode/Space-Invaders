using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Model;
public class Bullet
{
    public Image _bulletImage { get; } = ImageCreator.Bullet;
    public double _xPosition { get; set; }
    public double _yPosition { get; set; }
    public int _speed { get; set; }
    public bool _isLiving { get; set; }
    public BulletSource _source { get; }
    private DispatcherTimer timer;
    public CollisionDetector _collisionDetector;
    public ICanvas _canvas;

    public Bullet(ICanvas canvas, CollisionDetector collisionDetector, double xPosition, double yPosition, int speed, BulletSource source)
    {
        _canvas = canvas;
        _collisionDetector = collisionDetector;
        _xPosition = xPosition;
        _yPosition = yPosition;
        _speed = speed;
        _isLiving = true;
        _source = source;

        timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromMilliseconds(16);
        timer.Tick += Timer_Tick;
        timer.Start();
    }

    private void Timer_Tick(object sender, object e)
    {
        if (_isLiving)
        {
            if (_source.Equals(BulletSource.PlayerShip))
            {
                MoveUp();
            }
            else
            {
                MoveDown();
            }
            VerifyCollision();
        }
    }

    private void VerifyCollision()
    {
        Canvas.SetTop(_bulletImage, _yPosition);

        double bulletLeft = Canvas.GetLeft(_bulletImage);
        double bulletTop = Canvas.GetTop(_bulletImage);
        double bulletWidth = _bulletImage.ActualWidth;
        double bulletHeight = _bulletImage.ActualHeight;

        if (_collisionDetector != null && _canvas != null && _bulletImage != null && _source != null)
        {
            if (_collisionDetector.Collided(_source, bulletLeft, bulletTop, bulletWidth, bulletHeight))
            {
                _canvas.RemoveImage(_bulletImage);
                _isLiving = false;
            }
        }
    }

    public void MoveUp()
    {
        double topDistance = 50;
        if (_yPosition < topDistance)
        {
            _canvas.RemoveImage(_bulletImage);
            _isLiving = false;
        }
        _yPosition -= _speed;
        _canvas.MoveImage(_bulletImage, _xPosition, _yPosition);
    }

    public void MoveDown()
    {
        if (_yPosition > _canvas._heightCanvas - 20)
        {
            _canvas.RemoveImage(_bulletImage);
            _isLiving = false;
        }
        _yPosition += _speed;
        _canvas.MoveImage(_bulletImage, _xPosition, _yPosition);
    }
}
