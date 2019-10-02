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
    public class Dragon : IProjectile
    {
        public Rectangle rectangle { get; set; }

        public Vector2 position { get; set; }

        public Vector2 acc { get; set; }

        public Vector2 velocity { get; set; }

        public ISprite mySprite { get; set; }
        private Texture2D myTexture;
        private bool ifBoom = false;
        public Dragon(Vector2 pos, Texture2D texture)
        {
            this.position = pos;
            this.mySprite = new DragonSprite(texture);
            myTexture = texture;
            this.rectangle = new Rectangle((int)pos.X, (int)pos.Y, mySprite.Height()/2, mySprite.Height()/2);

            this.velocity = new Vector2(5.0f,0.0f);
            Sound.Instance.Dragon();
            Sound.Instance.Dragon();
            Sound.Instance.Dragon();
            Sound.Instance.Dragon();
            Sound.Instance.Dragon();
        }

        public void Update()
        {
            mySprite.Update();

            this.position = new Vector2(position.X + velocity.X, position.Y + velocity.Y);
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, mySprite.Width()/2, mySprite.Height()/2);
        }

        public void Draw(SpriteBatch sb, int worldPositionX, int worldPositionY)
        {
                mySprite.Draw(sb, new Vector2(position.X - worldPositionX, position.Y));

        }

        public void TouchDown()
        {
           
        }
        public void Attack(IPlayer mario)
        {

        }
        public void Attack(IEnemy enemy)
        {
            enemy.TakeDamage();

        }
        public void Attack(IBoss boss)
        {
            boss.TakeDamage();
        }
        public void Boom()
        {
        }
    }
}
