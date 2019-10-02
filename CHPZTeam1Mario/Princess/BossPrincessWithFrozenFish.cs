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
    public class BossPrincessWithFrozenFish : IBoss
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
        public BossPrincessWithFrozenFish(IBoss princess)
        {
            decoratedBoss = princess;
            myGame = princess.myGame;
            mySprite = princess.mySprite;
            rectangle = princess.rectangle;
            acc = new Vector2(0.0f, 0.2f);
            velocity = new Vector2(0.0f, -7.0f);
            decoratedBoss.velocity = velocity;
            health = princess.health;
            Sound.Instance.Freeze();
            Sound.Instance.Freeze();
            Sound.Instance.Freeze();
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
            int counter = order % 5;
            Vector2 pos = new Vector2(rectangle.X, rectangle.Y);
            int direction = 1;
            if (rectangle.X < myGame.Mario.rectangle.X)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }
            switch (counter)
            {
                case 1:

                    myGame.World.AddProjectile(new FrozenFish(pos, mySprite.Texture, new Vector2(direction * 6.0f, 0.0f)));
                    break;
                case 2:
                    myGame.World.AddProjectile(new FrozenFish(pos, mySprite.Texture, new Vector2(direction * 4.243f, -4.243f)));
                    break;
                case 3:
                    myGame.World.AddProjectile(new FrozenFish(pos, mySprite.Texture, new Vector2(direction * 5.196f, 3.0f)));
                    break;
                case 4:
                    myGame.World.AddProjectile(new FrozenFish(pos, mySprite.Texture, new Vector2(direction * 5.196f, -3.0f)));
                    break;
                case 5:
                    myGame.World.AddProjectile(new FrozenFish(pos, mySprite.Texture, new Vector2(direction * 4.243f, 4.243f)));
                    break;
                default:
                    break;
            }
        }

        private void RemoveSkillState()
        {
            decoratedBoss.velocity = new Vector2(0.0f, 0.0f);
            myGame.World.Level.BossPr = decoratedBoss;
        }
        public void TakeDamage()
        {
            decoratedBoss.TakeDamage();
        }
        public void Update()
        {

                skillTimer++;
                if (skillTimer % skillReleaseSpeed == 0)
                {
                    skillOrder++;
                    if (skillOrder <= 8)
                    {
                        FireInOrder(skillOrder);
                    }
                    else
                    {
                        RemoveSkillState();
                    }
                }
            
                decoratedBoss.Update();
                rectangle = decoratedBoss.rectangle;
            
        }
        public void Draw(SpriteBatch sb, Vector2 vector)
        {
            decoratedBoss.Draw(sb, vector);
        }
    }
}
