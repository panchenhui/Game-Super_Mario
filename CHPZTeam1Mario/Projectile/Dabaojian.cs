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
    public class Dabaojian : IProjectile
    {
        public Rectangle rectangle { get; set; }

        public Vector2 position { get; set; }

        public Vector2 acc { get; set; }

        public Vector2 velocity { get; set; }

        public ISprite mySprite { get; set; }

        private IBlock dabaojian;

        int timer = 30;

        public Dabaojian(IBlock block)
        {
            dabaojian = block;
            this.rectangle = block.rectangle;            
        }

        public void Update()
        {
            if (timer > 0)
            {
                timer--;
                this.rectangle = dabaojian.rectangle;
            }
            else
            {
                this.rectangle = new Rectangle();
            }
        }

        public void Draw(SpriteBatch sb,int worldPositionX,int worldPositionY)
        {
           
        }

        public void TouchDown()
        {
           
        }
        public void Attack(IEnemy enemy)
        {
            enemy.TakeDamage();
        }

        public void Attack(IPlayer mario)
        {
        }
        public void Attack(IBoss boss)
        {
        }
        public void Boom()
        {
            
        }
    }
}
