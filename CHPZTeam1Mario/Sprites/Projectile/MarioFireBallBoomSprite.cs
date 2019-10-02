using CHPZTeam1Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Sprites.Projectile
{
    public class MarioFireBallBoomSprite : ISprite
    {
      
        public int currentFrame = 0;
        public int boomSpeed = 1;
        public int boomTimer = 0;
        public Texture2D Texture { get; set; }
        public int startX { get; set; }
        public int startY { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public MarioFireBallBoomSprite(Texture2D texture)
        {
            this.Texture = texture;
            startX = 363;
            startY = 187;
            width = 9;
            height = 9;
        }
        public void Update()
        {
            boomTimer++;
            if (boomTimer % boomSpeed == 0)
            {
                currentFrame++;
                switch (currentFrame)
                {
                    case 1:
                        this.startX = 363;
                        this.startY = 187;
                        this.width = 9;
                        this.height = 9;
                        this.boomSpeed = 1;
                        break;
                    case 2:
                        this.startX = 391;
                        this.startY = 184;
                        this.width = 13;
                        this.height = 15;
                        this.boomSpeed = 1;
                        break;
                    case 3:
                        this.startX = 420;
                        this.startY = 183;
                        this.width = 17;
                        this.height = 17;
                        this.boomSpeed = 6;
                        currentFrame = 0;
                        boomTimer = 0;
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
