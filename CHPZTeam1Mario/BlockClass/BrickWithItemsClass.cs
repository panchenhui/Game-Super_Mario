using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.ItemClass;
using CHPZTeam1Mario.Projectile;
using CHPZTeam1Mario.Sprites.Blocks;
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
    public class BrickWithItemsClass : IBlock
    {
        public ISprite Sprite { get; set; }

        public SuperMario Mygame { get; set; }

        public Rectangle rectangle { get; set; }

        private Enum.Itemtype Itemtype;

        private Vector2 velosity;
        private Vector2 acceleration;

        private int ItemNumber;

        private bool used;

        private int timer;

        private int counting = 0;

        public BrickWithItemsClass(SuperMario game,Vector2 position,Enum.Itemtype type)
        {
            this.Mygame = game;
            this.Sprite = new FloatingBrickSprite(Mygame.blocks);
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, 32, 32);

            Itemtype = type;
            if (Itemtype.Equals(Enum.Itemtype.Star)){
                ItemNumber = 1;
            }
            else if (Itemtype.Equals(Enum.Itemtype.Coin)) {
                ItemNumber = 6;
            }
            used = false;
            timer = 0;
            velosity = new Vector2(0, -4);
            acceleration = new Vector2(0, 1);
        }

        public void Used()
        {
            if (counting % 2 == 0)
            {
                if (!used)
                {
                    Mygame.World.AddProjectile(new Dabaojian(this));
                    if (ItemNumber > 0)
                    {
                        Generate(Itemtype);
                        if (Itemtype.Equals(Enum.Itemtype.Coin))
                            {
                            Sound.Instance.Coin();
                        }
                    }
                    if (ItemNumber == 0)
                    {
                        used = true;
                        this.Sprite = new UsedBrickSprite(Mygame.blocks);
                    }
                    timer = 7;
                }
            }
        }

        public void Generate(Enum.Itemtype item)
        {
            switch (item)
            {
                case Enum.Itemtype.Star:
                    IItem star = new StarClass(Mygame, new Vector2(rectangle.X, rectangle.Y));
                    Mygame.World.AddItem(star);
                    break;
                case Enum.Itemtype.GreenMushroom:
                    IItem GreenMushroom = new GreenMushroomClass(Mygame, new Vector2(rectangle.X, rectangle.Y));
                    Mygame.World.AddItem(GreenMushroom);
                    break;
                case Enum.Itemtype.RedMushroom:
                    IItem RedMushroom = new RedMushroomClass(Mygame, new Vector2(rectangle.X, rectangle.Y));
                    Mygame.World.AddItem(RedMushroom);
                    break;
                case Enum.Itemtype.Coin:
                    IItem Coin = new CoinClass(Mygame, new Vector2(rectangle.X, rectangle.Y));
                    Mygame.World.AddItem(Coin);
                    break;
                case Enum.Itemtype.Flower:
                    IItem Flower = new FlowerClass(Mygame, new Vector2(rectangle.X, rectangle.Y));
                    Mygame.World.AddItem(Flower);
                    break;
            }
            this.ItemNumber--;

        }
        public void Shake()
        {

        }
        public void Update()
        {
            if (timer > 0)
            {
                velosity += acceleration;
                this.rectangle = new Rectangle(rectangle.X + (int)velosity.X, rectangle.Y + (int)velosity.Y, 32, 32);
                timer--;
            }else{
                velosity = new Vector2(0, -4);
            }         
               
            if (counting > 100)
            {
                counting = 0;
            }
            counting++;

            this.Sprite.Update();
        }

        public void Draw(SpriteBatch sb, int worldPositionX, int worldPositionY)
        {
            
            Sprite.Draw(sb, new Vector2(rectangle.X-worldPositionX, rectangle.Y));
        }
    }
}
