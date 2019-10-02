using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Sprites.Items
{
    class FlagpoleSprite:ISprite
    {
        public Texture2D Texture;

        private int currentFrame;
        private int counter;
        private int startX = 249;
        private int startY = 595;
        private int width = 24;
        private int height = 167;

        private int speed = 8;
        public FlagpoleSprite(Texture2D texture)
        {
            this.Texture = texture;
            currentFrame = 0;
            counter = 0;
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            int sourceLocX = startX + 30 * currentFrame;
            int sourceLocY = startY;
            Rectangle sourceRectangle = new Rectangle(sourceLocX, sourceLocY, width, height);
            Rectangle destinationRectangle = new Rectangle((int)vector.X, (int)vector.Y, width * 2, height * 2);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
