using CHPZTeam1Mario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Collision
{
    class MItemCollisionHandler
    {
        public static void Update(IPlayer mario, IItem item, Collision.CollisionType collisionType)
        {
            switch (collisionType)
            {
                case Collision.CollisionType.Above:
                    item.Used();
                    break;
                case Collision.CollisionType.Below:
                    item.Used();
                    break;

                case Collision.CollisionType.Left:
                    item.Used();
                    break;

                case Collision.CollisionType.Right:
                    item.Used();
                    break;
            }
        }
    }
}
