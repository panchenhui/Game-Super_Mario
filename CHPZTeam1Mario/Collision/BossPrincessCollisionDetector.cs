using CHPZTeam1Mario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Collision
{
    public class BossPrincessCollisionDetector
    {
        public static Collision.CollisionType colli;
        public static List<int> colliList = new List<int>();

        public static void Update(ILevel level)
        {
                int getCond;

                level.BossPr.ChangeMovement(0);
                foreach (IBlock block in level.BlockList)
                {
                    colli = Collision.GetCollision(level.BossPr, block);
                    getCond = BossPrincessBlockCollisionHandler.Update(level.BossPr, block, colli);
                    colliList.Add(getCond);
                }

                foreach (int i in colliList)
                    if (i != 0)
                        level.BossPr.ChangeMovement(i);
                colliList.Clear();
            


        }
    }
}
