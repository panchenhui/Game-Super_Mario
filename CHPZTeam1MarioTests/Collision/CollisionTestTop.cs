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
    public class CollisionTests
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
        public void GetCollisionTestTopNone()
        {
            TestObject mario = new TestObject(100,50,20,20);
            TestObject nonMario = new TestObject(90,100,50,50);
            for(int y = 0; y <= 30; y++)
            {
                mario.rectangle = new Rectangle(100, 50+y, 20, 20);
                Collision.CollisionType colli= Collision.GetCollision(mario, nonMario);
                if(colli != Collision.CollisionType.None)
                {
                    Assert.Fail();
                }
            }
        }
        [TestMethod()]
        public void GetCollisionTestTopAbove()
        {
            TestObject mario = new TestObject(100, 50, 20, 20);
            TestObject nonMario = new TestObject(90, 100, 50, 50);
            for (int y = 31; y <= 49; y++)
            {
                mario.rectangle = new Rectangle(100, 50 + y, 20, 20);
                Collision.CollisionType colli = Collision.GetCollision(mario, nonMario);
                if (colli != Collision.CollisionType.Above)
                {
                    Assert.Fail();
                }
            }
        }
    }
}