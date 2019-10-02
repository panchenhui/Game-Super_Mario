using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CHPZTeam1Mario.Sprites.Items
{
    class FlagMotionSprite:ISprite
    {
        public Texture2D Texture { get; set; }
        public int startX { get; set; }
        public int startY { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        private int currentFrame;
        private int counter = 0;
        private int speed = 16 ;

        public FlagMotionSprite(Texture2D texture)
        {
            this.Texture = texture;
            startX = 248;
            startY = 593;
            width = 26;
            height = 170;
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
                if (currentFrame >4)
                {
                    currentFrame = 4;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            int sourceLocX=0;
            int sourceLocY=593;
            switch (currentFrame)
            {
                case 0:
                    sourceLocX=248;
                    break;
                case 1:
                    sourceLocX = 215;
                    break;
                case 2:
                    sourceLocX = 181;
                    break;
                case 3:
                    sourceLocX = 148;
                    break;
                case 4:
                    sourceLocX = 115;
                    break;

            }

            Rectangle sourceRectangle = new Rectangle(sourceLocX, sourceLocY, width, height);
            Rectangle destinationRectangle = new Rectangle((int)vector.X, (int)vector.Y, width * 2, height * 2);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
