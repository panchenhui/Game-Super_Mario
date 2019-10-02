using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Sprites.MarioFire
{
    class FMRightWalkFireSprite : ISprite
    {
        public Texture2D Texture { get; set; }

        public int startX { get; set; }
        public int startY { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public int currentFrames;


        public int counter;
        public int speed = 8;

        public FMRightWalkFireSprite(Texture2D Mario_Sprite_Sheet)
        {
            Texture = Mario_Sprite_Sheet;
            currentFrames = 0;
            counter = 0;

            startX = 285;
            startY = 120;

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
                currentFrames++;
                if (currentFrames == 3)
                {
                    currentFrames = 0;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {

            Rectangle sourceRectangle = new Rectangle(startX-currentFrames*25, startY, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * 2, height * 2);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
