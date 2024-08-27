using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media.Animation;

namespace SpaceInvaders.Model;
public class User
{
    public int _lives = 3;
    public int _speed = 5;
    public int _socre = 0;

    public PlayerShip _playerShip { get; }
    public ICanvas _canvas { get; }

    public User(ICanvas canvas)
    {
        _canvas = canvas;

        double initialYPosition = canvas._heightCanvas - ImageCreator.PlayerShip.Height;
        double initialXPosition = (canvas._widthCanvas - ImageCreator.PlayerShip.Width) / 2;

        _playerShip = new PlayerShip(canvas, initialXPosition, initialYPosition, _speed, _lives, _socre);
        canvas.CreateImage(_playerShip._shipImage, _playerShip._xPosition, _playerShip._yPosition);
    }

    public void MoveRigth(double canvasWidth)
    {
        _playerShip.MoveRight(canvasWidth);
    }

    public void MoveLeft(double canvasWidth)
    {
        _playerShip.MoveLeft(canvasWidth);
    }

    public void ShootBullet(CollisionDetector collisionDetector)
    {
        _playerShip.Shoot(collisionDetector);
    }
}
