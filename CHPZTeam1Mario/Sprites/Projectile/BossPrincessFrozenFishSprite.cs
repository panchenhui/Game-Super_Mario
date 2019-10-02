using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Sprites.Projectile
{
    public class BossPrincessFrozenFishSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int startX { get; set; }
        public int startY { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        private int currentFrame = 1;
        public BossPrincessFrozenFishSprite(Texture2D texture)
        {
            this.Texture = texture;
            startX = 53;
            startY = 267;
            width = 16;
            height = 17;
        }
        public void Update()
        {
            switch (currentFrame)
            {
                case 1:
                    startX = 53;
                    startY = 267;
                    width = 16;
                    height = 17;
                    currentFrame = 2;
                    break;
                case 2:
                    startX = 71;
                    startY = 267;
                    width = 17;
                    height = 17;
                    currentFrame = 1;
                    break;
                default:
                    break;
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
