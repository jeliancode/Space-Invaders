using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;

namespace SpaceInvaders.Model;
public class Shield
{
    public List<Block> _blocks { get; set; }
    public double _xPosition {  get; set; }
    public double _yPosition { get; set; }
    public ICanvas _canvas { get; set; }

    public Shield(ICanvas canvas)
    {
        _canvas = canvas;
        _blocks = new List<Block>
        {
            new Block(ImageCreator.MainBlock, 5),
            new Block(ImageCreator.MainBlock, 5),
            new Block(ImageCreator.MainBlock, 5),
            new Block(ImageCreator.MainBlock, 5),
            new Block(ImageCreator.MainBlock, 5),
        };
    }

    public bool CollisionWithBullet(double bulletLeft, double bulletTop, double bulletWidth, double bulletHeight, bool fromPlayer)
    {
        foreach (Block block in _blocks)
        {
            double blockLeft = Canvas.GetLeft(block._blockImage);
            double blockTop = Canvas.GetTop(block._blockImage);
            double blockWidth = block._blockImage.ActualWidth;
            double blockHeight = block._blockImage.ActualHeight;

            if (bulletLeft < blockLeft + blockWidth && 
                bulletLeft + bulletWidth > blockLeft && 
                bulletTop < blockTop + blockHeight &&
                bulletTop + bulletHeight > blockTop)
            {
                if (block.DecreaceEndurance(fromPlayer))
                {
                    _blocks.Remove(block);
                    _canvas.RemoveImage(block._blockImage);
                }
                return true;
            }
        }
        return false;
    }

    public void CreateShields(){
        double blockSize = 25;
        int blockByRow = 3;
        int mainRow = 1;
        int halfBlocksPerRow = blockByRow / 2;
        double initialXPosition = _xPosition +(blockSize * blockByRow);
        double initialYPosition = _yPosition;

        for (int i = 0; i < _blocks.Count; i++)
        {
            int columna = i % blockByRow;
            int fila = i / blockByRow;

            if (fila == mainRow && columna == halfBlocksPerRow)
            {
                initialXPosition += blockSize;
            }

            double posicionX = initialXPosition + columna * blockSize;
            double posicionY = initialYPosition + fila * blockSize;

            _canvas.CreateImage(_blocks[i]._blockImage, posicionX, posicionY);
        }
    }
}
