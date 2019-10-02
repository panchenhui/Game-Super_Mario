using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Projectile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Princess
{
    public class BossPrincessWithJusticeSkill : IBoss
    {
        public SuperMario myGame { get; set; }
        public int health { get; set; }
        public Rectangle rectangle { get; set; }
        public ISprite mySprite { get; set; }
        public Vector2 acc { get; set; }
        public Vector2 velocity { get; set; }
        public bool ifDead { get; set; }

        private IBoss decoratedBoss;

        private int skillTimer = 0;
        private int skillReleaseSpeed = 20;
        private int skillOrder = 0;
        public BossPrincessWithJusticeSkill(IBoss princess)
        {
            decoratedBoss = princess;
            myGame = princess.myGame;
            mySprite = princess.mySprite;
            rectangle = princess.rectangle;
            acc = new Vector2(0.0f, 0.2f);
            velocity = new Vector2(0.0f, -11.0f);
            decoratedBoss.velocity = velocity;
            health = princess.health;
            Sound.Instance.Justice();
            Sound.Instance.Justice();
            Sound.Instance.Justice();
        }
        public void ChangeMovement(int i)
        {
            decoratedBoss.ChangeMovement(i);
            rectangle = decoratedBoss.rectangle;
        }

        public void Attack(IPlayer mario)
        {
        }

        private void FireInOrder(int order)
        {
            if (skillOrder % 2 == 0)
            {
                decoratedBoss.myGame.World.AddProjectile(new JusticeFireBall(new Vector2(decoratedBoss.rectangle.X, decoratedBoss.rectangle.Y)
                    ,decoratedBoss.mySprite.Texture,new Vector2(-4.0f,0.0f)));
                decoratedBoss.myGame.World.AddProjectile(new JusticeFireBall(new Vector2(decoratedBoss.rectangle.X, decoratedBoss.rectangle.Y)
                    , decoratedBoss.mySprite.Texture, new Vector2(-1.531f, -3.696f)));
                
                decoratedBoss.myGame.World.AddProjectile(new JusticeFireBall(new Vector2(decoratedBoss.rectangle.X, decoratedBoss.rectangle.Y)
                    , decoratedBoss.mySprite.Texture, new Vector2(0.0f, -4.0f)));
                decoratedBoss.myGame.World.AddProjectile(new JusticeFireBall(new Vector2(decoratedBoss.rectangle.X, decoratedBoss.rectangle.Y)
                    , decoratedBoss.mySprite.Texture, new Vector2(3.696f, -1.531f)));
                
                decoratedBoss.myGame.World.AddProjectile(new JusticeFireBall(new Vector2(decoratedBoss.rectangle.X, decoratedBoss.rectangle.Y)
                    , decoratedBoss.mySprite.Texture, new Vector2(4.0f, 0.0f)));
                decoratedBoss.myGame.World.AddProjectile(new JusticeFireBall(new Vector2(decoratedBoss.rectangle.X, decoratedBoss.rectangle.Y)
                   , decoratedBoss.mySprite.Texture, new Vector2(1.531f, 3.696f)));
                
                decoratedBoss.myGame.World.AddProjectile(new JusticeFireBall(new Vector2(decoratedBoss.rectangle.X, decoratedBoss.rectangle.Y)
                    , decoratedBoss.mySprite.Texture, new Vector2(0.0f, 4.0f)));
                decoratedBoss.myGame.World.AddProjectile(new JusticeFireBall(new Vector2(decoratedBoss.rectangle.X, decoratedBoss.rectangle.Y)
                    , decoratedBoss.mySprite.Texture, new Vector2(-3.696f, 1.531f)));
                
            }
            else
            {
                decoratedBoss.myGame.World.AddProjectile(new JusticeFireBall(new Vector2(decoratedBoss.rectangle.X, decoratedBoss.rectangle.Y)
                                    , decoratedBoss.mySprite.Texture, new Vector2(-3.696f, -1.531f)));
                decoratedBoss.myGame.World.AddProjectile(new JusticeFireBall(new Vector2(decoratedBoss.rectangle.X, decoratedBoss.rectangle.Y)
                    , decoratedBoss.mySprite.Texture, new Vector2(-2.828f, -2.828f)));

                decoratedBoss.myGame.World.AddProjectile(new JusticeFireBall(new Vector2(decoratedBoss.rectangle.X, decoratedBoss.rectangle.Y)
                    , decoratedBoss.mySprite.Texture, new Vector2(1.531f, -3.696f)));
                decoratedBoss.myGame.World.AddProjectile(new JusticeFireBall(new Vector2(decoratedBoss.rectangle.X, decoratedBoss.rectangle.Y)
                    , decoratedBoss.mySprite.Texture, new Vector2(2.828f, -2.828f)));

                decoratedBoss.myGame.World.AddProjectile(new JusticeFireBall(new Vector2(decoratedBoss.rectangle.X, decoratedBoss.rectangle.Y)
                    , decoratedBoss.mySprite.Texture, new Vector2(3.696f,1.531f)));
                decoratedBoss.myGame.World.AddProjectile(new JusticeFireBall(new Vector2(decoratedBoss.rectangle.X, decoratedBoss.rectangle.Y)
                     , decoratedBoss.mySprite.Texture, new Vector2(2.828f, 2.828f)));

                decoratedBoss.myGame.World.AddProjectile(new JusticeFireBall(new Vector2(decoratedBoss.rectangle.X, decoratedBoss.rectangle.Y)
                    , decoratedBoss.mySprite.Texture, new Vector2(-1.531f, 3.696f)));
                decoratedBoss.myGame.World.AddProjectile(new JusticeFireBall(new Vector2(decoratedBoss.rectangle.X, decoratedBoss.rectangle.Y)
                    , decoratedBoss.mySprite.Texture, new Vector2(-2.828f, 2.828f)));
            }
        }

        private void RemoveSkillState()
        {
            decoratedBoss.velocity = new Vector2(0.0f,0.0f);
            myGame.World.Level.BossPr = decoratedBoss;
        }
        public void TakeDamage()
        {
            decoratedBoss.TakeDamage();
        }
        public void Update()
        {
            if (decoratedBoss.rectangle.Y<=150)
            {
                skillTimer++;
                if (skillTimer % skillReleaseSpeed == 0)
                {
                    skillOrder++;
                    if (skillOrder <= 10)
                    {
                        FireInOrder(skillOrder);
                    }
                    else
                    {
                        RemoveSkillState();
                    }
                }
            }
            else
            {
                decoratedBoss.Update();
                rectangle = decoratedBoss.rectangle;
            }
        }
        public void Draw(SpriteBatch sb, Vector2 vector)
        {
            decoratedBoss.Draw(sb,vector);
        }
    }
}
