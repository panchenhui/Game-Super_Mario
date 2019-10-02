using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Sprites.MarioChangingState
{
    class STBLeftIdle : ISprite
    {
        public Texture2D texture { get; set; }

        public int startX = 179;
        public int startY = 0;
        public int width = 18;
        public int height = 35;

        public int currentFrame = 0;
        public int speed = 8;
        public int counter = 0;

            public STBLeftIdle(Texture2D Mario_Sprite_Sheet)
            {
                texture = Mario_Sprite_Sheet;
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
                    if (currentFrame == 3)
                    {
                        currentFrame = 0;
                    }
                }
             }
            public void Draw(SpriteBatch spriteBatch, Vector2 location)
            {

                Rectangle sourceRectangle = new Rectangle(startX + currentFrames * 25, startY, width, height);
                Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * 2, height * 2);

                spriteBatch.Begin();
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }   
    }
}
