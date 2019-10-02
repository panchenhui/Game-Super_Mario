using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Collision
{
    public class CollisionDetector
    {
        public static Collision.CollisionType colli;
        public static List<int> colliList = new List<int>();
        private static bool blockEnable = true;

        public static void Update(ILevel level)
        {
            level.Mygame.Mario.DisableMovement(0);
            int getCond;

            foreach (IEnemy enemy in level.EnemyList)
            {
                colli = Collision.GetCollision(level.Mygame.Mario, enemy);
                                    
                getCond=MEnemyCollisionHandler.Update(level.Mygame.Mario, enemy, colli);
                colliList.Add(getCond);
                                
            }
            foreach (IFire fire in level.FireList)
            {
                colli = Collision.GetCollision(level.Mygame.Mario, fire);

                getCond = MFireCollisionHandler.Update(level.Mygame.Mario, fire, colli);
                colliList.Add(getCond);

            }

            foreach (IItem item in level.ItemList)
            {

                colli = Collision.GetCollision(level.Mygame.Mario, item);
                if (colli != Collision.CollisionType.None)
                {
                    MItemCollisionHandler.Update(level.Mygame.Mario, item, colli);
                }
            }


            
            foreach (IBlock block in level.BlockList)
            {
                colli = Collision.GetCollision(level.Mygame.Mario, block);
                if (colli == Collision.CollisionType.Below)
                {
                    if (blockEnable)
                    {
                        getCond = MBlockCollisionHandler.Update(level.Mygame.Mario, block, colli);
                        colliList.Add(getCond);
                        blockEnable = false;
                    }
                }
                else {
                    getCond = MBlockCollisionHandler.Update(level.Mygame.Mario, block, colli);
                    colliList.Add(getCond);
                }
            }

            foreach (int i in colliList)
                if (i != 0)
                    level.Mygame.Mario.DisableMovement(i);
            colliList.Clear();

            blockEnable = true;

        }
    }
}
