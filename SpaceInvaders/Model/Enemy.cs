using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Model;
public class Enemy
{
    private readonly List<Ship> _enemyShips;
    private readonly ICanvas _canvas;
    private int _xDirection = 1;
    private DispatcherTimer _movementTimer;
    public event EventHandler NewEnemiesGenerated;
    private readonly CollisionDetector _collisionDetector;
    public event EventHandler RequestGameOver;

    public Enemy(ICanvas canvas, List<Ship> enemyShips, CollisionDetector collisionDetector)
    {
        _enemyShips = enemyShips;
        _canvas = canvas;
        _collisionDetector = collisionDetector;
        StartTimer();
    }

    public void StartTimer() 
    { 
        _movementTimer = new DispatcherTimer();
        _movementTimer.Interval = TimeSpan.FromMicroseconds(200);
        _movementTimer.Tick += (sender, e) => MoveShips();
        _movementTimer?.Start();
    }

    private void DownShips()
    {
        double yDistance = 15;
        foreach (var ship in _enemyShips) 
        {
            if (ship._isLiving) 
            {
                //ship._speed += 1;
                ship._yPosition += yDistance;
                ship.Move();
            }
        }

    }

    public void MoveShips()
    {
        bool enemiesAreLiving = false;
        bool isChangingDirection = false;

        foreach (var enemy in _enemyShips)
        {
            if (enemy._isLiving)
            {
                enemiesAreLiving = true;
                enemy._xPosition += _xDirection * enemy._speed;
                enemy.Move();

                if (enemy._xPosition + _xDirection * enemy._speed + enemy._shipImage.ActualWidth > _canvas._widthCanvas || enemy._xPosition + _xDirection * enemy._speed < 0)
                {
                    isChangingDirection = true; 
                }

                if (_collisionDetector.ShipsCollided(enemy._xPosition, enemy._yPosition, enemy._shipImage.ActualWidth, enemy._shipImage.ActualHeight))
                {
                    _movementTimer.Stop();
                    GameOver();
                }
            }
        }

        if (!enemiesAreLiving)
        {
            NewBlock();
        }

        if (isChangingDirection) 
        {
            _xDirection *= -1;
            DownShips();
        }
    }

    private void NewBlock()
    {
        NewEnemiesGenerated?.Invoke(this, EventArgs.Empty);
    }

    private void GameOver()
    {
        RequestGameOver?.Invoke(this, EventArgs.Empty);
    }
}
