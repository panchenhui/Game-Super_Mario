﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Sprites.Projectile
{
    public class BossPrincessJusticeFireBallSprite : ISprite
    {

        public Texture2D Texture { get; set; }
        public int startX { get; set; }
        public int startY { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public BossPrincessJusticeFireBallSprite(Texture2D texture)
        {
            this.Texture = texture;
            startX = 126;
            startY = 241;
            width = 15;
            height = 17;
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
