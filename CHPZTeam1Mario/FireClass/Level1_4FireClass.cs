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
    public class Level1_4FireClass : IFire
    {
        public ISprite Sprite { get; set; }
        public SuperMario Mygame { get; set; }
        private Vector2 pos;
        private bool ifDead = false;

        public Rectangle rectangle { get; set; }


        public Level1_4FireClass(SuperMario game, Vector2 position)
        {
            this.Mygame = game;
            this.Sprite = new FireSprite(Mygame.enemies);
            pos = position;
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, 28, 32);
            

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
            if (rectangle.X <= Mygame.camera.cameraPositionX + 1000)
            {
                if (rectangle.X == Mygame.camera.cameraPositionX + 1000)
                {
                    Sound.Instance.BowserFire();
                }
                Sprite.Update();
                rectangle = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
            }
        }

        public void Draw(SpriteBatch sb, int worldPositionX, int worldPositionY)
        {

            Sprite.Draw(sb, new Vector2(rectangle.X - worldPositionX, rectangle.Y));
        }
    }
}
