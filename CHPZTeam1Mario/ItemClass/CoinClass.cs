using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Sprites.EmptyScreen;
using CHPZTeam1Mario.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.ItemClass
{
    public class CoinClass : IItem
    {
        public ISprite Sprite { get; set; }

        public SuperMario Mygame { get; set; }
        public Rectangle rectangle { get; set; }

        private Vector2 velosity;
        private Vector2 accelerate;

        private int timer;

        public CoinClass(SuperMario game,Vector2 position)
        {
            this.Mygame = game;
            this.Sprite = new CoinSprite(Mygame.items);
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, 10, 15);
            accelerate = new Vector2(0, 0.4f);
            velosity = new Vector2(0, -10);
            timer = 35;
            Used();
        }
        public void ChangeMovement(int i)
        {

        }
        public void ChangeDirection()
        {

        }
        public void Used()
        {            
            Mygame.HUD.GetScore(200);
            Mygame.HUD.GetCoin();
            Mygame.HUD.ScoreDisplay(200, new Vector2(rectangle.X, rectangle.Y));

        }

        public void Update()
        {
            if (timer > 0)
            {
                velosity += accelerate;
                this.rectangle = new Rectangle(rectangle.X + (int)velosity.X, rectangle.Y + (int)velosity.Y, 10, 15);
                timer--;
            }
            else {
                this.rectangle = new Rectangle(0, 0, 0, 0);
                this.Sprite = new EmptyScreen(Mygame.items);
            }
            Sprite.Update();
        }

        public void Draw(SpriteBatch sb,int worldPositionX, int worldPositionY)
        {
            
            Sprite.Draw(sb, new Vector2(rectangle.X - worldPositionX, rectangle.Y));
        }
    }
}
