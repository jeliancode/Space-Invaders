using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Model;
public class EnemyShoot
{
    private readonly List<Ship> _enemyShips;
    private readonly CollisionDetector _collisionDetector;

    public EnemyShoot(List<Ship> enemyShips, CollisionDetector collisionDetector)
    {
        _enemyShips = enemyShips;
        _collisionDetector = collisionDetector;
        StartTimer();
    }

    private void StartTimer()
    {
        var shootTimer = new DispatcherTimer();
        shootTimer.Interval = TimeSpan.FromSeconds(1);
        shootTimer.Tick += SelectEnemyShip;
        shootTimer.Start();
    }

    private void SelectEnemyShip(object sender, object e)
    {
        Random random = new Random();
        int index = random.Next(0, _enemyShips.Count);
        Ship currentShip = _enemyShips[index];

        if(currentShip is AttackingEnemy enemyShooter && enemyShooter._isLiving)
        {
            enemyShooter.Shoot(_collisionDetector);
        }
    }
}
