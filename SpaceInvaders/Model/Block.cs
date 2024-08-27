using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Model;
public class Block
{
    public Image _blockImage {  get; set; }
    public int _endurance { get; set; }

    private BlockManager _blockManager;

    public Block(Image image, int endurance)
    {
        _blockImage = image;
        _endurance = endurance;
        _blockManager = new BlockManager();
    }   

    public bool DecreaceEndurance(bool isFromPLayer)
    {
        if(_endurance > 1)
        {
            Image destroyedBlock = _blockManager.GetDestroyedImage(_endurance, isFromPLayer);
            _blockImage.Source =  destroyedBlock.Source;
            _endurance--;
            return false;
        }

        return true;
    }
}
