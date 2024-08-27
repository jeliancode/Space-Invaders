using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Model;
public class PlayerShip: Ship
{
    public int _lives {  get; set; }
    public Bullet _bullet { get; private set; }

    public PlayerShip(ICanvas canvas, double xPosition, double yPosition, int speed, int initialLives, int point)
    : base(canvas, ImageCreator.PlayerShip, xPosition, yPosition, speed, point)
    {
        _lives = initialLives;
        canvas.MoveImage(_shipImage, _xPosition, _yPosition);
    }

    private void LimitPosition(double canvasWidth)
    {
        double leftLimit = 0;
        double rightLimit = canvasWidth - _shipImage.ActualWidth;
        _xPosition = Math.Max(leftLimit, Math.Min(_xPosition, rightLimit));
    }

    public void MoveLeft(double canvasWith)
    {
        _xPosition -= _speed;
        LimitPosition(canvasWith);
        _canvas.MoveImage(_shipImage, _xPosition, _yPosition);
    }

    public void MoveRight(double canvasWidth)
    {
        _xPosition += _speed;
        LimitPosition(canvasWidth);
        _canvas.MoveImage(_shipImage, _xPosition, _yPosition);
    }

    public void Shoot(CollisionDetector collisionDetector)
    {
        if(_bullet == null || !_bullet._isLiving)
        {
            double xPosition =  _xPosition + (_shipImage.Width - ImageCreator.Bullet.Width) / 2;
            double yPosition = _yPosition;
            int bulletSpeed = 5;

            _bullet = new Bullet(_canvas, collisionDetector, xPosition, yPosition, bulletSpeed, BulletSource.PlayerShip);
            _canvas.CreateImage(_bullet._bulletImage, _bullet._xPosition, _bullet._yPosition);
        }
    }
}
