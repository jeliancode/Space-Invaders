using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Model;
public class CommonEnemy:Ship
{
    public CommonEnemy(ICanvas canvas, Image image, double xPosition, double yPosition, double speed, int points)
    : base(canvas, image, xPosition, yPosition, speed, points)
    {
    }
}
