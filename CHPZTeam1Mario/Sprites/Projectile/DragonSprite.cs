using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Sprites.Projectile
{
    public class DragonSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int startX { get; set; }
        public int startY { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        private int timer = 6;
        private int currentFrame = 1;
        public DragonSprite(Texture2D texture)
        {
            this.Texture = texture;
            startX = 28;
            startY = 143;
            width = 252;
            height = 185;
        }
        public void Update()
        {
            timer--;
            if (timer <= 0)
            {
                switch (currentFrame)
                {
                    case 1:
                        startX = 28;
                        startY = 143;
                        width = 252;
                        height = 185;
                        currentFrame = 2;
                        break;
                    case 2:
                        startX = 322;
                        startY = 120;
                        width = 235;
                        height = 206;
                        currentFrame = 3;
                        break;
                    case 3:
                        startX = 616;
                        startY = 150;
                        width = 265;
                        height = 175;
                        currentFrame = 4;
                        break;
                    case 4:
                        startX = 883;
                        startY = 235;
                        width = 262;
                        height = 137;
                        currentFrame = 5;
                        break;
                    case 5:
                        startX = 1205;
                        startY = 262;
                        width = 209;
                        height = 169;
                        currentFrame = 6;
                        break;
                    case 6:
                        startX = 1499;
                        startY = 258;
                        width = 235;
                        height = 152;
                        currentFrame = 7;
                        break;
                    case 7:
                        startX = 1792;
                        startY = 225;
                        width = 257;
                        height = 131;
                        currentFrame = 8;
                        break;
                    case 8:
                        startX = 2083;
                        startY = 210;
                        width = 268;
                        height = 119;
                        currentFrame = 1;
                        break;
                    default:
                        break;
                }
                timer = 6;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            int sourceLocX = startX;
            int sourceLocY = startY;
            Rectangle sourceRectangle = new Rectangle(sourceLocX, sourceLocY, width, height);
            Rectangle destinationRectangle = new Rectangle((int)vector.X, (int)vector.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
        public int Width()
        {
            return width * 2;
        }

        public int Height()
        {
            return height * 2;
        }
    }
}
