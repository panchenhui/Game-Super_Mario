﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Sprites.MarioChangeSprite
{
    class BTFLeftIdleSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int startX { get; set; }
        public int startY { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int currentFrame;
        public int counter;
      
        public int speed = 8;

        public BTFLeftIdleSprite(Texture2D texture)
        {
            this.Texture = texture;
            currentFrame = 0;
            counter = 0;
            startX = 178;
            startY = 50;

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
                currentFrame++;
                if (currentFrame > 1)
                {
                    currentFrame = 0;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            int sourceLocX = startX;
            int sourceLocY = startY;

            if (currentFrame == 0)
            {
                sourceLocX = startX;
                sourceLocY = startY;
                width = 18;
                height = 35;
            }
            else if (currentFrame == 1)
            {
                sourceLocX = startX;
                sourceLocY = 122;
                width = 18;
                height = 36;
            }


            Rectangle sourceRectangle = new Rectangle(sourceLocX, sourceLocY, width, height);
            Rectangle destinationRectangle = new Rectangle((int)vector.X, (int)vector.Y, width * 2, height * 2);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
