using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Sprites.Projectile
{
    public class MarioFireBallSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int startX { get; set; }
        public int startY { get; set; }
        public int width { get; set; }
        public int height { get; set; }
   
        public int currentFrame { get; set; }
        public int rollSpeed = 6;
        public int rollTimer = 0;
        public int countToDisappear { get; set; }
        public MarioFireBallSprite(Texture2D texture)
        {
            this.Texture = texture;
            currentFrame = 0;
            countToDisappear = 0;
            startX = 25;
            startY = 149;
            width = 9;
            height = 9;
        }
        public void Update()
        {
            rollTimer++;
            if (rollTimer % rollSpeed == 0)
            {
                currentFrame++;
                switch (currentFrame)
                {
                    case 1:
                        this.startX = 25;
                        this.startY = 149;
                        break;
                    case 2:
                        this.startX = 40;
                        this.startY = 149;
                        break;
                    case 3:
                        this.startX = 25;
                        this.startY = 164;
                        break;
                    case 4:
                        this.startX = 40;
                        this.startY = 164;
                        currentFrame = 0;
                        rollTimer = 0;
                        break;

                }
            }
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
