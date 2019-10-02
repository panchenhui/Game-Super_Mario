using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Interfaces
{
    public interface IProjectile : IObject
    {

        Vector2 position { get; set; }

        Vector2 acc { get; set; }

        Vector2 velocity { get; set; }

        ISprite mySprite { get; set; }

        void Update();

        void Draw(SpriteBatch sb, int worldPositionX, int worldPositionY);

        void TouchDown();

        void Boom();
        void Attack(IEnemy enemy);
        void Attack(IPlayer enemy);
        void Attack(IBoss boss);

    }
}
