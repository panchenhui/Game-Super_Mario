using Microsoft.VisualStudio.TestTools.UnitTesting;
using CHPZTeam1Mario.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHPZTeam1Mario.Interfaces;
using Microsoft.Xna.Framework;

namespace CHPZTeam1Mario.Collision.Tests
{
    [TestClass()]
    public class CollisionTestBelow
    {
        public class TestObject : IObject
        {
            public Rectangle rectangle { get; set; }
            public TestObject(int startX, int startY, int width, int height)
            {
                this.rectangle = new Rectangle(startX, startY, width, height);
            }
        }
        [TestMethod()]
        public void GetCollisionTestBottomNone()
        {
            TestObject nonMario = new TestObject(100, 50, 20, 20);
            TestObject mario = new TestObject(90, 100, 50, 50);
            for (int y = 0; y <= 30; y++)
            {
                mario.rectangle = new Rectangle(90, 100 - y, 50, 50);
                Collision.CollisionType colli = Collision.GetCollision(mario, nonMario);
                if (colli != Collision.CollisionType.None)
                {
                    Assert.Fail();
                }
            }
        }
        [TestMethod()]
        public void GetCollisionTestBottomAbove()
        {
            TestObject nonMario = new TestObject(100, 50, 20, 20);
            TestObject mario = new TestObject(90, 100, 50, 50);
            for (int y = 31; y <= 49; y++)
            {
                mario.rectangle = new Rectangle(90, 100- y, 50, 50);
                Collision.CollisionType colli = Collision.GetCollision(mario, nonMario);
                if (colli != Collision.CollisionType.Below)
                {
                    Assert.Fail();
                }
            }
        }
    }
}