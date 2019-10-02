using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Sprites.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.BlockClass
{
    public class Level1_4FloatingBoardClass : IBlock
    {
        public ISprite Sprite { get; set; }
        public SuperMario Mygame { get; set; }
        public Rectangle rectangle { get; set; }
        public Vector2 velocity { get; set; }
        int sizeX = 64;
        int sizeY = 16;
        int velocityX = 1 ;
        int time = 200;

        public Level1_4FloatingBoardClass(SuperMario game, Vector2 position)
        {
            this.Mygame = game;
            this.Sprite = new Level1_4FloatingBoardSprite(Mygame.items);
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, sizeX, sizeY);
            velocity = new Vector2(velocityX, 0);
        }

        public void Used()
        {
        }
        public void Shake()
        {

        }
        public void Update()
        {
            
            if (time <0) {
                velocityX = -velocityX;
                time = 200;
            }
            time--;
            this.Sprite.Update();
            rectangle = new Rectangle(rectangle.X +velocityX, rectangle.Y, rectangle.Width, rectangle.Height);
        }

        public void Draw(SpriteBatch sb, int worldPositionX, int worldPositionY)
        {

            Sprite.Draw(sb, new Vector2(rectangle.X - worldPositionX, rectangle.Y));
        }
    }
}
