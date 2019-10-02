using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Collision
{
    public class ECollisionDetector
    {
        public static Collision.CollisionType colli;
        public static List<int> colliList = new List<int>();

        public static void Update(ILevel level)
        {
            int getCond;
            foreach (IEnemy enemy1 in level.EnemyList)
            {
                enemy1.ChangeMovement(0);
                foreach (IBlock block in level.BlockList)
                {
                    colli = Collision.GetCollision(enemy1, block);
                    getCond = EBlockCollisionHandler.Update(enemy1, block, colli);
                    colliList.Add(getCond);
                }
                foreach (IEnemy enemy2 in level.EnemyList)
                 {
                    if (!enemy1.Equals(enemy2))
                    {
                        colli = Collision.GetCollision(enemy1, enemy2);
                        getCond = EEnemyCollisionHandler.Update(enemy1, enemy2, colli);
                        colliList.Add(getCond);
                    }
                 }
                foreach (int i in colliList)
                    if(i!=0)
                        enemy1.ChangeMovement(i);
                colliList.Clear();
            }


        }
    }
}
