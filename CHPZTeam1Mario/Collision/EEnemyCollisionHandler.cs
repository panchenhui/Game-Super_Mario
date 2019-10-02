using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.MarioClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CHPZTeam1Mario.Collision
{
    class EEnemyCollisionHandler 
    {
        public static int Update(IEnemy enemy1,IEnemy enemy2, Collision.CollisionType collisionType)
        {
            switch (collisionType)
            {
                case Collision.CollisionType.Above:
                    return (int)Enum.DisableMovementType.Down;
                case Collision.CollisionType.Below:
                    return (int)Enum.DisableMovementType.Up;
                case Collision.CollisionType.Left:
                    enemy1.Crashing(enemy2);
                    return (int)Enum.DisableMovementType.Right;
                case Collision.CollisionType.Right:
                    enemy1.Crashing(enemy2);
                    return (int)Enum.DisableMovementType.Left;
                default:
                    return (int)Enum.DisableMovementType.None;
                
            }
        }

    }
}
