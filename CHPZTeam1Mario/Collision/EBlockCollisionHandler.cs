using CHPZTeam1Mario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Collision
{
    class EBlockCollisionHandler
    {
        public static int Update(IEnemy enemy, IBlock block, Collision.CollisionType collisionType)
        {
            switch (collisionType)
            {
                case Collision.CollisionType.Above:
                    return (int)Enum.DisableMovementType.Down;
                case Collision.CollisionType.Below:
                    return (int)Enum.DisableMovementType.Up;
                case Collision.CollisionType.Left:
                    return (int)Enum.DisableMovementType.Right;
                case Collision.CollisionType.Right:
                    return (int)Enum.DisableMovementType.Left;
                default:
                    return (int)Enum.DisableMovementType.None;
            }
        }
    }
}
