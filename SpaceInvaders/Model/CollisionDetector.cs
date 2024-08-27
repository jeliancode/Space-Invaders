using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Model;
public class CollisionDetector
{
    public event EventHandler<int> _lives;
    public event EventHandler<int> _score;
    private List<Ship> _enemyShips;
    private PlayerShip _playerShip;
    private List<Shield> _shields;

    public CollisionDetector(List<Ship> enemyShips, PlayerShip playerShip, List<Shield> shields)
    {
        _enemyShips = enemyShips;
        _playerShip = playerShip;
        _lives?.Invoke(this, playerShip._lives);
        _shields = shields;
    }

    public bool ShipsCollided(double shipLeft, double shipTop, double shipWidth, double shipHeight)
    {
        if(_playerShip._isLiving && _playerShip.Collided(shipLeft, shipTop, shipWidth, shipHeight))
        {
            return true;
        }
        return false;
    }

    public bool Collided(BulletSource source, double bulletLeft, double bulletTop, double bulletWidth, double bulletHeight) 
    {
        if (source.Equals(BulletSource.EnemyShip))
        {
            foreach(var shield in _shields)
            {
                if(shield.CollisionWithBullet(bulletLeft, bulletTop, bulletWidth, bulletHeight, false))
                {
                    return true;
                }
            }
            if (_playerShip._isLiving && _playerShip.Collided(bulletLeft, bulletTop, bulletWidth, bulletHeight))
            {
                _playerShip._lives -= 1;
                _lives?.Invoke(this, _playerShip._lives);
                return true;
            }
        }
        else if (source.Equals(BulletSource.PlayerShip)) 
        {
            foreach (var shield in _shields)
            {
                if (shield.CollisionWithBullet(bulletLeft, bulletTop, bulletWidth, bulletHeight, true))
                {
                    return true;
                }
            }
            foreach (var enemyShip in _enemyShips)
            {
                if(enemyShip._isLiving && enemyShip.Collided(bulletLeft, bulletTop, bulletWidth, bulletHeight))
                {
                    _playerShip._points += enemyShip._points;
                    _score?.Invoke(this, _playerShip._points);
                    _enemyShips.Remove(enemyShip);
                    enemyShip.Remove();
                    return true;
                }
            }
        }
        return false;
    }
}
