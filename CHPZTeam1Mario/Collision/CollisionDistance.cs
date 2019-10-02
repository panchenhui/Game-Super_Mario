using CHPZTeam1Mario.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Collision
{
    public class CollisionDistance
    {


        public static int Distance(IObject object1, IObject object2, Collision.CollisionType collisionType)
        {
            int result = 0;
            Rectangle intersection = Rectangle.Intersect(object1.rectangle, object2.rectangle);
            if (intersection.IsEmpty)
            {                
                return result;
            }
            else
            {
                if (collisionType== Collision.CollisionType.Above|| collisionType == Collision.CollisionType.Below)
                {
                    result = intersection.Height;
                    return result;
                }
                else if (collisionType == Collision.CollisionType.Right || collisionType == Collision.CollisionType.Left)
                {
                    result = intersection.Width;
                    return result;
                }
                else
                {
                    return result;
                }
            }

        }
    }
}
