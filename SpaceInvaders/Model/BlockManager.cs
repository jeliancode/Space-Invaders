using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Model;
public class BlockManager
{
    private List<Image> _blocksDestroyedByPlayer;
    private List<Image> _blocksDestroyedByEnemy;

    public BlockManager() 
    {
        _blocksDestroyedByPlayer = new List<Image>
        {
            ImageCreator.PlayerBlock_1,
            ImageCreator.PlayerBlock_2,
            ImageCreator.PlayerBlock_3,
            ImageCreator.PlayerBlock_4,
        };

        _blocksDestroyedByEnemy = new List<Image>
        {
            ImageCreator.EnemyBlock_1,
            ImageCreator.EnemyBlock_2,
            ImageCreator.EnemyBlock_3,
            ImageCreator.EnemyBlock_4,
        };
    }

    public Image GetDestroyedImage(int endurence, bool isFromPlayer)
    {
        if (isFromPlayer)
        {
            return _blocksDestroyedByPlayer[5 - endurence];
        }
        else
        {
            return _blocksDestroyedByEnemy[5 - endurence];
        }
    }
}
