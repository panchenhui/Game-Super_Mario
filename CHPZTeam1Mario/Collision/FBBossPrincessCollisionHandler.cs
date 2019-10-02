using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Princess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Collision
{
    public class FBBossPrincessCollisionHandler
    {
        public static void Update(IProjectile fireball, IBoss BossPr, Collision.CollisionType collisionType)
        {
            switch (collisionType)
            {
                case Collision.CollisionType.Above:
                    fireball.Attack(BossPr);
                    
                    return;
                case Collision.CollisionType.Below:
                    fireball.Attack(BossPr);
                    
                    return;
                case Collision.CollisionType.Left:
                    fireball.Attack(BossPr);
                    
                    return;
                case Collision.CollisionType.Right:
                    fireball.Attack(BossPr);
                    
                    return;
                default:
                    return;
            }
        }
    }
}
