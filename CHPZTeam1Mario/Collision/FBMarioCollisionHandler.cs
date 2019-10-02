using CHPZTeam1Mario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Collision
{
    public class FBMarioCollisionHandler
    {
        public static void Update(IProjectile fireball, IPlayer mario, Collision.CollisionType collisionType)
        {
            switch (collisionType)
            {
                case Collision.CollisionType.Above:
                    fireball.Attack(mario);

                    return;
                case Collision.CollisionType.Below:
                    fireball.Attack(mario);

                    return;
                case Collision.CollisionType.Left:
                    fireball.Attack(mario);

                    return;
                case Collision.CollisionType.Right:
                    fireball.Attack(mario);

                    return;
                default:
                    return;
            }
        }
    }
}
