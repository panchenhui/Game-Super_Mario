using Microsoft.VisualStudio.TestTools.UnitTesting;
using CHPZTeam1Mario.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.MarioClass;
using Microsoft.Xna.Framework;
namespace CHPZTeam1Mario.Collision.Tests
{
    [TestClass()]
    public class CollisionTestsRight
    {
        public class TestObject : IObject
        {
            public Rectangle rectangle { get; set; }
            public TestObject(int startX,int startY, int width, int height)
            {
                this.rectangle = new Rectangle(startX, startY, width, height);
            }
        }
        [TestMethod()]
        public void GetCollisionTestRightNone()
        {
            TestObject mario =  new TestObject(100, 90, 50, 50);
            TestObject nonMario = new TestObject(50, 100, 20, 20);
            for (int y = 0; y <= 30; y++)
            {
                mario.rectangle = new Rectangle(100 - y, 90, 50, 50);
                Collision.CollisionType colli= Collision.GetCollision(mario, nonMario);
                if(colli != Collision.CollisionType.None)
                {
                    Assert.Fail();
                }
            }
        }
        [TestMethod()]
        public void GetCollisionTestRight()
        {
            TestObject mario =  new TestObject(100, 90, 50, 50);
            TestObject nonMario = new TestObject(50, 100, 20, 20);
            for (int y = 31; y <= 49; y++)
            {
                mario.rectangle = new Rectangle(100 - y, 90, 50, 50);
                Collision.CollisionType colli = Collision.GetCollision(mario, nonMario);
                if (colli != Collision.CollisionType.Right)
                {
                    Assert.Fail();
                }
            }
        }
    }
}