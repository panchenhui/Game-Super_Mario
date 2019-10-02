﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Sprites.MarioSmall
{
    class SMLeftOnFlagSprite : ISprite
    {
        public Texture2D Texture { get; set; }

        public int startX { get; set; }
        public int startY { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public SMLeftOnFlagSprite(Texture2D texture)
        {
            this.Texture = texture;
            startX = 60;
            startY = 30;
            width = 17;
            height = 16;
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
    }
}
