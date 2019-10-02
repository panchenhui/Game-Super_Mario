using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Sprites.EmptyScreen;
using CHPZTeam1Mario.Sprites.Enemies;
using CHPZTeam1Mario.Sprites.Projectile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.EnemyClass
{
    public class Level1_4UpFireClass : IFire
    {
        public ISprite Sprite { get; set; }
        public SuperMario Mygame { get; set; }
        private Vector2 velocity;
        private Vector2 pos;
        private bool ifDead = false;
        private int time=240;
        int x;
        int y;
        public Rectangle rectangle { get; set; }


        public Level1_4UpFireClass(SuperMario game, Vector2 position)
        {
            this.Mygame = game;
            this.Sprite = new FireSprite(Mygame.enemies);
            pos = position;
            velocity = new Vector2(0, -2f);
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, 28, 32);
            x = rectangle.X;
            y = rectangle.Y;
            Sound.Instance.BowserFire();

        }
        public void ChangeDirection()
        {
        }

        public void ChangeMovement(int i)
        {
        }

        public void TakeDamage()
        {

        }

        public void Crashing(IFire fire)
        {
        }

        public void Attack(IPlayer mario)
        {
            if (!ifDead)
                mario.TakeDamage();
        }
        public void Update()
        {
            time--;
            if (time == 0)
            {
                rectangle = new Rectangle(x, y, rectangle.Width, rectangle.Height);
                time = 240;
            }
            else {
                rectangle = new Rectangle(rectangle.X, rectangle.Y + (int)velocity.Y, rectangle.Width, rectangle.Height);
            }
            Sprite.Update();
        }

        public void Draw(SpriteBatch sb, int worldPositionX, int worldPositionY)
        {

            Sprite.Draw(sb, new Vector2(rectangle.X - worldPositionX, rectangle.Y));
        }
    }
}
