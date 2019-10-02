using CHPZTeam1Mario.BlockClass;
using CHPZTeam1Mario.Blocks;
using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Collision
{
    class MBlockCollisionHandler
    {
        public static int Update(IPlayer mario, IBlock block, Collision.CollisionType collisionType)
        {
            if(block is FlagpoleClass && collisionType!=Collision.CollisionType.None)
            {
                block.Used();              
            }
            switch (collisionType)
            {
                case Collision.CollisionType.Above:
                    if(block is PenetrablePipeClass)
                    {
                        if(mario.State is SMLeftCrouchState || mario.State is SMRightCrouchState || mario.State is BMLeftCrouchState|| mario.State is BMRightCrouchState||mario.State is FMLeftCrouchState||mario.State is FMRightCrouchState)
                        {
                            block.Used();
                        }
                    }
                    return (int) Enum.DisableMovementType.Down;
                case Collision.CollisionType.Below:
                    if (block is BrickClass)
                    {
                        if (mario.State is SMLeftJumpState || mario.State is SMRightJumpState )
                        {
                            block.Shake();
                        }else {
                            block.Used();
                        }
                    }                    
                    else
                    {
                        block.Used();
                    }

                    return (int)Enum.DisableMovementType.Up;

                case Collision.CollisionType.Left:
                    if(block is UndergroundPipeClass)
                    {
                        block.Used();
                    }
                    return (int)Enum.DisableMovementType.Right;

                case Collision.CollisionType.Right:
                    return (int)Enum.DisableMovementType.Left;
                default:
                    return (int)Enum.DisableMovementType.None;
            }
        }
    }
}
