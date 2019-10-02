using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Interfaces
{
    public interface IFire : IObject
    {
        ISprite Sprite { get; set; }

        SuperMario Mygame { get; set; }
        void TakeDamage();

        void Attack(IPlayer mario);

        void ChangeMovement(int i);

        void Crashing(IFire fire);

        void ChangeDirection();

        void Update();

        void Draw(SpriteBatch sb,int worldPositionX,int worldPositionY);
    }
}
