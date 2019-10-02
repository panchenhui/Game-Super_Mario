using CHPZTeam1Mario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Collision
{
    public class FBBlockCollisionHandler
    {
        public static void Update(IProjectile fireball, IBlock block, Collision.CollisionType collisionType)
        {
            switch (collisionType)
            {
                case Collision.CollisionType.Above:
                    fireball.TouchDown();
                    return;
                case Collision.CollisionType.Below:
                    fireball.Boom();
                    return;
                case Collision.CollisionType.Left:
                    fireball.Boom();
                    return;
                case Collision.CollisionType.Right:
                    fireball.Boom();
                    return;
                default:
                    return;
            }
        }
    }
}
