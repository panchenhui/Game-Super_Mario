using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Collision
{
    public class ICollisionDetector
    {

        public static Collision.CollisionType colli;
        public static List<int> colliList = new List<int>();

        public static void Update(ILevel level)
        {
            int getCond;
            foreach (IItem item in level.ItemList)
            {
                item.ChangeMovement(0);
                foreach (IBlock block in level.BlockList)
                {
                    colli = Collision.GetCollision(item, block);
                    getCond = IBlockCollisionHandler.Update(item, block, colli);
                    colliList.Add(getCond);
                }
                
                foreach (int i in colliList)
                    if (i != 0)
                        item.ChangeMovement(i);
                colliList.Clear();
            }


        }
    }
}
