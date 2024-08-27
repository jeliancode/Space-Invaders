using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Model;
public class Ship
{
    public Image _shipImage {  get; set; }
    public double _xPosition {  get; set; }
    public double _yPosition { get; set; }
    public double _speed { get; set; }
    public bool _isLiving { get; set; }
    public int _points {  get; set; }
    public ICanvas _canvas { get; set; }

    public Ship(ICanvas canvas, Image shipImage, double xPosition, double yPosition, double speed, int points)
    {
        this._canvas = canvas;
        _shipImage = shipImage;
        _xPosition = xPosition;
        _yPosition = yPosition;
        _speed = speed;
        _isLiving = true;
        _points = points;
    }

    public void Create()
    {
        _canvas.CreateImage(_shipImage, _xPosition, _yPosition);
    }

    public void Remove()
    {
        _canvas.RemoveImage(_shipImage);
    }

    public void Move()
    {
        _canvas.MoveImage(_shipImage, _xPosition, _yPosition);
    }

    public bool Collided(double bulletLeft, double bulletTop, double bulletWidth, double bulletHeight)
    {
        double shipLeft = _xPosition;
        double shipTop = _yPosition;
        double shipWidth = _shipImage.ActualWidth;
        double shipHeight = _shipImage.ActualHeight;
        bool collision = bulletLeft + bulletWidth > shipLeft && bulletLeft < shipLeft + shipWidth &&
               bulletTop + bulletHeight > shipTop && bulletTop < shipTop + shipHeight;

        return collision;
    }
}
