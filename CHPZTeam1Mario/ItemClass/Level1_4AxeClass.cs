using CHPZTeam1Mario.BlockClass;
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
    public class Level1_4AxeClass : IItem
    {
        public ISprite Sprite { get; set; }

        public SuperMario Mygame { get; set; }
        public Rectangle rectangle { get; set; }

        int sizeX = 32;
        int sizeY = 32;
        public Level1_4AxeClass(SuperMario game, Vector2 position)
        {
            this.Mygame = game;
            this.Sprite = new Level1_4AxeSprite(Mygame.blocks);
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, sizeX, sizeY);
            
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
            this.Sprite = new EmptyScreen(Mygame.items);
            this.rectangle = new Rectangle(0, 0, 0, 0);
            foreach (IBlock b in Mygame.World.Level.BlockList)
            {
                if (b is Level1_4Bridge1Class)
                {
                    b.Used();                    
                }
            }

            Sound.Instance.Coin();
        }

        public void Update()
        {

            this.rectangle = new Rectangle(rectangle.X, rectangle.Y, sizeX, sizeY);
            Sprite.Update();
        }

        public void Draw(SpriteBatch sb, int worldPositionX, int worldPositionY)
        {

            Sprite.Draw(sb, new Vector2(rectangle.X - worldPositionX, rectangle.Y));
        }
    }
}
