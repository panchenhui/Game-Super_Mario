using CHPZTeam1Mario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario
{
    public interface ISprite
    {
        Texture2D Texture { get; set; }
        int startX { get; set; }
        int startY { get; set; }
        int width { get; set; }
        int height { get; set; }

        void Update();

        void Draw(SpriteBatch spriteBatch,Vector2 vector);

        int Width();

        int Height();
       
    }
}
