using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Interfaces
{
    public interface IBoss : IObject
    {
        SuperMario myGame { get; set; }
        int health { get; set; }
        ISprite mySprite { get; set; }
        Vector2 acc { get; set; }
        Vector2 velocity { get; set; }
        bool ifDead { get; set; }
        void ChangeMovement(int i);


        void Attack(IPlayer mario);

        void TakeDamage();
        void Update();
        void Draw(SpriteBatch sb, Vector2 vector);
    }
}
