using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Sprites.Projectile;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Projectile
{
    public class FrozenFish : IProjectile
    {
        public Rectangle rectangle { get; set; }

        public Vector2 position { get; set; }

        public Vector2 acc { get; set; }

        public Vector2 velocity { get; set; }

        public ISprite mySprite { get; set; }
        private Texture2D myTexture;
        private bool ifBoom = false;
        public FrozenFish(Vector2 pos, Texture2D texture, Vector2 v)
        {
            this.position = pos;
            if (v.X < 0.0f)
            {
                this.mySprite = new BossPrincessFrozenFishSprite(texture);
            }
            else
            {
                this.mySprite = new BossPrincessRightFrozenFish(texture);
            }
            myTexture = texture;
            this.rectangle = new Rectangle((int)pos.X, (int)pos.Y, mySprite.Height(), mySprite.Height());
            this.acc = new Vector2(0.0f, 0.05f);
            this.velocity = v;
            Sound.Instance.FireBall();
        }

        public void Update()
        {
            mySprite.Update();
            velocity += acc;
            this.position = new Vector2(position.X + velocity.X, position.Y + velocity.Y);
            if (!ifBoom)
                this.rectangle = new Rectangle((int)position.X, (int)position.Y, mySprite.Width(), mySprite.Height());
        }

        public void Draw(SpriteBatch sb, int worldPositionX, int worldPositionY)
        {
            if (!ifBoom)
                mySprite.Draw(sb, new Vector2(position.X - worldPositionX, position.Y));

        }

        public void TouchDown()
        {
            this.acc = new Vector2(0.0f, 0.2f);
            this.velocity = new Vector2(velocity.X, -velocity.Y);
        }
        public void Attack(IPlayer mario)
        {
            mario.Freeze();
            Boom();
        }
        public void Attack(IEnemy enemy)
        {
            enemy.TakeDamage();
            Boom();
        }
        public void Attack(IBoss boss)
        {

        }
        public void Boom()
        {
            this.acc = new Vector2(0.0f, 0.0f);
            this.velocity = new Vector2(0.0f, 0.0f);
            this.rectangle = new Rectangle();
            ifBoom = true;
        }
    }
}
