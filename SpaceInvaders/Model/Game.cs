using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Model;
public class Game
{
    public ICanvas _canvas;
    public List<Ship> _enemies { get; }
    public Enemy _enemyManager;
    public CollisionDetector _collisionDetector;
    public EnemyShoot _enemiesShoot;
    public int _enemySpeed = 1;
    public List<Shield> _shields { get; }

    public Game(ICanvas canvas) 
    {
        _canvas = canvas;
        int initialXPosition = 0;
        _enemies = new List<Ship>();
        SetEnemies();

        _shields = new List<Shield>();
        SetShieldsInCanvas();
    }

    public CollisionDetector CollisionDetector
    {
        set {
            _collisionDetector = value;
            StartShootingTimer();
        }
    }

    private void StartShootingTimer()
    {
        _enemiesShoot = new EnemyShoot(_enemies, _collisionDetector);
        _enemyManager = new Enemy(_canvas, _enemies, _collisionDetector);
        _enemyManager.NewEnemiesGenerated += GenerateNewEnemies;
    }

    private void GenerateNewEnemies(object sender, EventArgs e)
    {
        SetEnemies();
    }

    private void SetShipInRow(int rowsAmount, int rowBase, int columns, double yPosition)
    {
        double space = 35;
        double initialPosition = 45;

        for (int row = 0; row < rowsAmount; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                double xPosition = (column * space) + initialPosition;
                double currnetYPosition = yPosition + (row + rowBase) * space;

                Ship ship = null;
                if (rowBase == 0)
                {
                    ship = new AttackingEnemy(_canvas, ImageCreator.Enemy1, xPosition, currnetYPosition, _enemySpeed, 500);
                }
                else if (rowBase == 1)
                {
                    ship = new CommonEnemy(_canvas, ImageCreator.Enemy3, xPosition, currnetYPosition, _enemySpeed, 300);
                }
                else if (rowBase == 2)
                {
                    ship = new CommonEnemy(_canvas, ImageCreator.Enemy2, xPosition, currnetYPosition, _enemySpeed, 500);
                }
                _enemies.Add(ship);
                ship.Create();
            }
        }
    }

    private void SetEnemies()
    {
        SetShipInRow(1, 0, 10, 110);
        SetShipInRow(2, 1, 10, 110);
        SetShipInRow(2, 2, 10, 140);
    }

    public void SetShieldsInCanvas()
    {
        int initialXPosition = 0;
        int distanceBetweenShiels = 150;
        int initialYPosition = 350;
        int shieldAmount = 4;

        for(int i = 0; i < shieldAmount; i++)
        {
            Shield newShield = new Shield(_canvas);
            newShield._xPosition = initialXPosition + i *distanceBetweenShiels;
            newShield._yPosition = initialYPosition;
            _shields.Add(newShield);
            newShield.CreateShields();
        }
    }
}
