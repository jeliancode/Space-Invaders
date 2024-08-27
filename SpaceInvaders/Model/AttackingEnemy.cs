using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Model;
public class AttackingEnemy:Ship
{
    public Bullet bullet;

    public AttackingEnemy(ICanvas canvas, Image image, double xPosition, double yPosition, double speed, int points)
    : base(canvas, image, xPosition, yPosition, speed, points)
    {
    }

    public void Shoot(CollisionDetector collisionDetector)
    {
        double xBulletPosition = _xPosition + 2;
        double yBulletPosition = _yPosition + 22;
        int bulletSpeed = 5;
        bullet = new Bullet(_canvas, collisionDetector, xBulletPosition, yBulletPosition, bulletSpeed, BulletSource.EnemyShip);
        _canvas.CreateImage(bullet._bulletImage, bullet._xPosition, bullet._yPosition);

    }
}
