using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Collision
{
    public class FBCollisionDetector
    {
        public static Collision.CollisionType colli;
        public static List<int> colliList = new List<int>();

        public static void Update(ILevel level)
        {
            foreach (IProjectile fireball in level.ProjectileQueue)
            {
                if (level.EnemyList.Count != 0)
                {
                    foreach (IEnemy enemy in level.EnemyList)
                    {
                        colli = Collision.GetCollision(fireball, enemy);
                        FBEnemyCollisionHandler.Update(fireball, enemy, colli);

                    }
                }
                if (level.BlockList.Count != 0)
                {
                    foreach (IBlock block in level.BlockList)
                    {
                        colli = Collision.GetCollision(fireball, block);
                        FBBlockCollisionHandler.Update(fireball, block, colli);
                    }
                }

                if (level.BossPr != null)
                {
                    colli = Collision.GetCollision(fireball, level.BossPr);
                    FBBossPrincessCollisionHandler.Update(fireball, level.BossPr, colli);
                }
                if (level.Mygame.Mario != null)
                {
                    colli = Collision.GetCollision(fireball, level.Mygame.Mario);
                    FBMarioCollisionHandler.Update(fireball, level.Mygame.Mario, colli);
                }
            }


        }
    }
}
