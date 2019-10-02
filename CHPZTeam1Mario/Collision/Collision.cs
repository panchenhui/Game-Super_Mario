using CHPZTeam1Mario.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Collision
{
    public class Collision
    {
        public static Rectangle intersection;

        public enum CollisionType { None,Above,Below,Left,Right};

        public static CollisionType Side;

        public static CollisionType GetCollision(IObject object1,IObject object2)
        {                   
            intersection = Rectangle.Intersect(object1.rectangle, object2.rectangle);
            if (intersection.IsEmpty)
            {
                Side = CollisionType.None;
                return Side;
            }
            else {
                if (intersection.Width > intersection.Height)
                {
                    if (object1.rectangle.Top < object2.rectangle.Top)
                    {
                        Side = CollisionType.Above;
                        return Side;
                    }
                    else
                    {
                        Side = CollisionType.Below;
                        return Side;
                    }
                }
                else if(intersection.Width < intersection.Height)
                {
                    if (object1.rectangle.Left < object2.rectangle.Left)
                    {
                        Side = CollisionType.Left;
                        return Side;
                    }
                    else
                    {
                        Side = CollisionType.Right;
                        return Side;
                    }


                }
                else
                {
                    Side = CollisionType.None;
                    return Side;
                }
            }
         
        }
        
    }
}
