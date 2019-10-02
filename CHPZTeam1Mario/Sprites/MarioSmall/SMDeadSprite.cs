using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Sprites.MarioSmall
{
    public class SMDeadSprite : ISprite
    {
        public Texture2D Texture { get; set; }

        public int startX { get; set; }
        public int startY { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        private Vector2 gravity = new Vector2(0, 0.3f);
        private Vector2 velocity = new Vector2(0, 0);
        private Vector2 acc = new Vector2(0, -10);

        public SMDeadSprite(Texture2D texture)
        {
            this.Texture = texture;
            startX = 0;
            startY = 16;
            width = 16;
            height = 15;

        }
        public void Update()
        {
            acc += gravity;
            velocity += acc;

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            int sourceLocX = startX;
            int sourceLocY = startY;
            Rectangle sourceRectangle = new Rectangle(sourceLocX, sourceLocY, width, height);
            Rectangle destinationRectangle = new Rectangle((int)(vector.X+velocity.X), (int)(vector.Y+velocity.Y), width*2,height*2);

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
