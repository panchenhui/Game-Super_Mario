using CHPZTeam1Mario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Collision
{
    public class FBEnemyCollisionHandler
    {
        public static void Update(IProjectile fireball, IEnemy enemy, Collision.CollisionType collisionType)
        {
            switch (collisionType)
            {
                case Collision.CollisionType.Above:
                    fireball.Attack(enemy);
                    
                    return;
                case Collision.CollisionType.Below:
                    fireball.Attack(enemy);
                    
                    return;
                case Collision.CollisionType.Left:
                    fireball.Attack(enemy);
                    
                    return;
                case Collision.CollisionType.Right:
                    fireball.Attack(enemy);
                    
                    return;
                default:
                    return;
            }
        }
    }
}
