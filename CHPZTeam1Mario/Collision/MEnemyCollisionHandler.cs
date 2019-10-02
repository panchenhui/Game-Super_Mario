using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.MarioClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CHPZTeam1Mario.Collision
{
    class MEnemyCollisionHandler 
    {
        public static int Update(IPlayer mario,IEnemy enemy, Collision.CollisionType collisionType)
        {
            switch (collisionType)
            {
                case Collision.CollisionType.Above:
                    enemy.TakeDamage();
                    
                    return (int)Enum.DisableMovementType.Down;
                case Collision.CollisionType.Below:

                    enemy.Attack(mario);
                    mario.Attack(enemy);
                    return (int)Enum.DisableMovementType.Up;

                case Collision.CollisionType.Left:

                    enemy.Attack(mario);
                    mario.Attack(enemy);
                    return (int)Enum.DisableMovementType.Right;

                case Collision.CollisionType.Right:

                    enemy.Attack(mario);
                    mario.Attack(enemy);
                    return (int)Enum.DisableMovementType.Left;
                default:
                    return (int)Enum.DisableMovementType.None;
                
            }
        }

    }
}
