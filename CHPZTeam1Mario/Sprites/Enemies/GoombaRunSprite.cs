﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CHPZTeam1Mario.Sprites.Enemies
{
    class GoombaRunSprite:ISprite
    {
        public Texture2D Texture { get; set; }
        public int startX { get; set; }
        public int startY { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int currentFrame;
        public int counter;
     
        public int speed = 8;

        public GoombaRunSprite(Texture2D texture)
        {
            this.Texture = texture;
            currentFrame = 0;
            counter = 0;
            startX = 0;
            startY = 4;
            width = 16;
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
            counter++;
            if (counter % speed == 0)
            {
                currentFrame++;
                if (currentFrame == 2)
                {
                    currentFrame = 0;
                }
            }
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
