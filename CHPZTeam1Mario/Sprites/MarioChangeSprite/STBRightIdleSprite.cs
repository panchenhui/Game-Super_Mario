using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Sprites.MarioChanging
{
    class STBRightIdleSprite : ISprite
    {

        public int currentFrame;
        public int counter;
        public Texture2D Texture { get; set; }
        public int startX { get; set; }
        public int startY { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public int speed = 3;

        public STBRightIdleSprite(Texture2D texture)
        {
            this.Texture = texture;
            currentFrame = 0;
            counter = 0;
            startX = 209;
            startY = 0;
            width = 18;
            height = 35;

        }
        public int Width()
        {
            return width * 2;
        }

        public int Height()
        {
            return height * 2;
        }
        public void Update()
        {
            counter++;
            if (counter % speed == 0)
            {
                currentFrame++;
                if (currentFrame > 1)
                {
                    currentFrame = 0;
                }

            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            int sourceLocX = startX;
            int sourceLocY = startY;

            if (currentFrame == 0)
            {
                sourceLocX = startX;
                sourceLocY = startY;
                width = 18;
                height = 16;
            }
            else if (currentFrame == 1)
            {
                sourceLocX = startX;
                sourceLocY = 51;
                width = 18;
                height = 36;
            }


            Rectangle sourceRectangle = new Rectangle(sourceLocX, sourceLocY, width, height);
            Rectangle destinationRectangle = new Rectangle((int)vector.X, (int)vector.Y-30, width * 2, height * 2);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
