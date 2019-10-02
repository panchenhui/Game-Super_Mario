using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.ItemClass;
using CHPZTeam1Mario.Projectile;
using CHPZTeam1Mario.Sprites.Blocks;
using CHPZTeam1Mario.Sprites.EmptyScreen;
using CHPZTeam1Mario.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Blocks
{
    public class BrickClass : IBlock
    {
        public ISprite Sprite { get; set; }

        public SuperMario Mygame { get; set; }

        public Rectangle rectangle { get; set; }

        public Vector2 position { get; set; }
     
        public Vector2 velosity { get; set; }

        public Vector2 acceleration { get; set; }

        private bool used = false;

        private int timer = 25;

        private bool shaked = false;

        private int shaker;

    

        public BrickClass(SuperMario game,Vector2 position)
        {
            this.position = position;
            this.Mygame = game;
            this.Sprite = new FloatingBrickSprite(Mygame.blocks);
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, Sprite.Width(), Sprite.Height());

            shaker = -1;
            velosity = new Vector2(0, -4);
            acceleration = new Vector2(0, 1);
        }

        public void Used()
        {
            if (!used)
            {
                Mygame.World.AddProjectile(new Dabaojian(this));
                this.Sprite = new FragementBrickSprite(Mygame.blocks);
                used = true;
                Sound.Instance.BreakBlock();
                Mygame.HUD.GetScore(50);
            }
             
        }

        public void Shake()
        {
            if (!shaked)
                {

                Mygame.World.AddProjectile(new Dabaojian(this));
                    shaker = 7;
                    shaked = true;
                }
            
        }

        public void Update()
        {
            if (used)
            {
                timer--;
            }
            if (timer == 0)
            {
                this.Sprite = new EmptyScreen(Mygame.blocks);
                rectangle = new Rectangle(0, 0, 0, 0);
            }
            if (shaker > 0)
            {
                velosity += acceleration;
                this.rectangle = new Rectangle(rectangle.X + (int)velosity.X, rectangle.Y + (int)velosity.Y, 32, 32);
                shaker--;
            }else if (shaker == 0)
            {
                velosity = new Vector2(0, -4);
                shaked = false;
                shaker = -1;
            }
           
            Sprite.Update();
        }

        public void Draw(SpriteBatch sb, int worldPositionX, int worldPositionY)
        {
            
            Sprite.Draw(sb, new Vector2(rectangle.X-worldPositionX, rectangle.Y));
        }
    }
}
