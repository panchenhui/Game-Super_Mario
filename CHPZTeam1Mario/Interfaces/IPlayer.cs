using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Interfaces
{
    public interface IPlayer : IObject
    {
        IMarioState State { get; set; }
        ISprite Sprite { get; set; }
        SuperMario Mygame { get; set; }
        Vector2 Position { get; set; }
        
        Vector2 acc { get; set; }

        Vector2 velocity { get; set; }
         int health { get; set; }
        void Accelerate();

        void RelsAccelerate();
        void Left();

        void Right();

        void Up();

        void Down();

        void Dead();

        void ToBig();

        void ToSmall();

        void ToFire();

        void Update();

        void RelsUp();

        void RelsDown();

        void RelsLeft();

        void RelsRight();

        void TakeDamage();

        void DisableMovement(int i);

        void Attack(IEnemy enemy);

        void Freeze();
        void Draw(SpriteBatch sb,Vector2 vector);

      
    }
}
