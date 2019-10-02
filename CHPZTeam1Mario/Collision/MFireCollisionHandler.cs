using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.MarioClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CHPZTeam1Mario.Collision
{
    class MFireCollisionHandler 
    {
        public static int Update(IPlayer mario,IFire fire, Collision.CollisionType collisionType)
        {
            switch (collisionType)
            {
                case Collision.CollisionType.Above:
                    fire.Attack(mario);

                    return (int)Enum.DisableMovementType.Down;
                case Collision.CollisionType.Below:
                    fire.Attack(mario);
 
                    return (int)Enum.DisableMovementType.Up;

                case Collision.CollisionType.Left:
            
                    fire.Attack(mario);

                    return (int)Enum.DisableMovementType.Right;

                case Collision.CollisionType.Right:

                    fire.Attack(mario);
                    return (int)Enum.DisableMovementType.Left;
                default:
                    return (int)Enum.DisableMovementType.None;
                
            }
        }

    }
}
