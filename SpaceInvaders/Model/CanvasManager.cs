using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;

namespace SpaceInvaders.Model
{
    public class CanvasManager : ICanvas
    {
        private readonly Canvas _canvas;
        public double _widthCanvas => _canvas.Width;
        public double _heightCanvas => _canvas.Height;

        public CanvasManager(Canvas canvas)
        {
            _canvas = canvas;
        }

        public void CreateImage(Image image, double xPosition, double yPosition)
        {
            Canvas.SetLeft(image, xPosition);
            Canvas.SetTop(image, yPosition);
            _canvas.Children.Add(image);
        }

        public void MoveImage(Image image, double newXPosition, double newYPosition)
        {
            Canvas.SetLeft((Image)image, newXPosition);
            Canvas.SetTop((Image)image, newYPosition);
        }

        public void RemoveImage(Image image)
        {
            _canvas.Children.Remove(image);
        }
    }

}
