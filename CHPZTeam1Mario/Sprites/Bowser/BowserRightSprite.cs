using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Sprites.Bowser
{
    public class BowserRightSprite : ISprite
    {
        public Texture2D Texture { get; set; }

        public int startX { get; set; }
        public int startY { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        private int currentFrame = 0;
        private int timer = 0;
        private int updateSpeed = 10;
        public BowserRightSprite(Texture2D texture)
        {
            this.Texture = texture;
            startX = 256;
            startY = 367;
            width = 33;
            height = 33;
        }
        public void Update()
        {
            timer++;
            if (timer == updateSpeed)
            {
                currentFrame++;
                switch (currentFrame)
                {
                    case 1:
                        startX = 256;
                        break;
                    case 2:
                        startX = 291;
                        break;
                    case 3:
                        startX = 326;
                        break;
                    case 4:
                        startX = 361;
                        break;
                    default:
                        currentFrame = 0;
                        break;
                }
                timer = 0;
            }
        }
        public int Width()
        {
            return width * 2;
        }

        public int Height()
        {
            return height * 2;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            int sourceLocX = startX;
            int sourceLocY = startY;
            Rectangle sourceRectangle = new Rectangle(sourceLocX, sourceLocY, width, height);
            Rectangle destinationRectangle = new Rectangle((int)vector.X, (int)vector.Y, width * 2, height * 2);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
