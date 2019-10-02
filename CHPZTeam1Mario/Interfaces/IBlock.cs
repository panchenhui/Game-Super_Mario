using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Interfaces
{
    public interface IBlock : IObject
    {
        ISprite Sprite { get; set; }

        SuperMario Mygame { get; set; }

        void Used();

        void Update();

        void Shake();

        void Draw(SpriteBatch sb,int worldPositionX, int worldPositionY);
    }
}
