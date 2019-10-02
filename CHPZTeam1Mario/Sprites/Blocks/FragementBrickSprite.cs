using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CHPZTeam1Mario.Sprites.Blocks
{
    class FragementBrickSprite:ISprite
    {
        public Texture2D Texture { get; set; }
        public int startX { get; set; }
        public int startY { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        private Vector2 gravity = new Vector2(0, 0.6f);

        private Vector2 v1=new Vector2(0,0);
        private Vector2 acc =new Vector2(-1.4f,-6);

        private Vector2 v2 = new Vector2(0, 0);
        private Vector2 acc2 = new Vector2(1.4f, -6);

        private Vector2 v3 = new Vector2(0, 0);
        private Vector2 acc3 = new Vector2(-1.4f, -10);

        private Vector2 v4 = new Vector2(0, 0);
        private Vector2 acc4 = new Vector2(1.4f, -10);




        public FragementBrickSprite(Texture2D texture)
        {
            this.Texture = texture;
            startX = 373;
            startY =47;
            width = 8;
            height = 8;
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
            acc += gravity;
            v1 += acc;

            acc2 += gravity;
            v2 += acc2;

            acc3 += gravity;
            v3+= acc3;

            acc4 += gravity;
            v4 += acc4;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            int sourceLocX = startX;
            int sourceLocY = startY;
            Rectangle sourceRectangle = new Rectangle(sourceLocX, sourceLocY, width, height);
            Rectangle destinationRectangle1 = new Rectangle((int)(vector.X+v1.X), (int)(vector.Y+v1.Y), width * 2, height * 2);
            Rectangle destinationRectangle2 = new Rectangle((int)(vector.X + v2.X)+8, (int)(vector.Y + v2.Y), width * 2, height * 2);
            Rectangle destinationRectangle3= new Rectangle((int)(vector.X + v3.X), (int)(vector.Y + v3.Y)+8, width * 2, height * 2);
            Rectangle destinationRectangle4 = new Rectangle((int)(vector.X + v4.X)+8, (int)(vector.Y + v4.Y)+8, width * 2, height * 2);


            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle1, sourceRectangle, Color.White);
            spriteBatch.Draw(Texture, destinationRectangle2, sourceRectangle, Color.White);
            spriteBatch.Draw(Texture, destinationRectangle3, sourceRectangle, Color.White);
            spriteBatch.Draw(Texture, destinationRectangle4, sourceRectangle, Color.White);

            spriteBatch.End();
        }
    }
}
