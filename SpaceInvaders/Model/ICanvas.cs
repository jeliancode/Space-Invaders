using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Model;
public interface ICanvas
{
    double _widthCanvas { get; }
    double _heightCanvas { get; }
    void CreateImage(Image image, double xPosition, double yPosition);
    void RemoveImage(Image image);
    void MoveImage(Image image, double newXPosition, double newYPosition);
}
