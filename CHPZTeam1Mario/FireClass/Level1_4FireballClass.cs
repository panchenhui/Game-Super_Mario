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
    public class Level1_4FireballClass : IFire
    {
        public ISprite Sprite { get; set; }
        public SuperMario Mygame { get; set; }
        private Vector2 velocity;
        private Vector2 pos;
        private bool ifDead = false;

        private bool start = false;

        public Rectangle rectangle { get; set; }


        public Level1_4FireballClass(SuperMario game, Vector2 position)
        {
            this.Mygame = game;
            this.Sprite = new Level1_4FireballSprite(Mygame.enemies);
            pos = position;
            velocity = new Vector2(0.0f, 0.0f);
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, 48, 16);
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

        public void Crashing(IEnemy enemy)
        {
        }

        public void Attack(IPlayer mario)
        {
            if (!ifDead)
                mario.TakeDamage();
        }
        public void Update()
        {
            if (!start && rectangle.X < Mygame.camera.cameraPositionX + 800)
            {
                velocity = new Vector2(-1.5f, 0);
                start = true;
            }

            Sprite.Update();
            rectangle = new Rectangle(rectangle.X + (int)velocity.X, rectangle.Y + (int)velocity.Y, rectangle.Width, rectangle.Height);
        }

        public void Draw(SpriteBatch sb, int worldPositionX, int worldPositionY)
        {

            Sprite.Draw(sb, new Vector2(rectangle.X - worldPositionX, rectangle.Y));
        }

        public void Crashing(IFire fire)
        {
            throw new NotImplementedException();
        }
    }
}
