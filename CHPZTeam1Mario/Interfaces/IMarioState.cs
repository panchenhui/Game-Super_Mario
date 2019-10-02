using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Interfaces
{
    public interface IMarioState
    {
        void Left();

        void Right();

        void Up();

        void Down();

        void RelsRight();

        void RelsUp();

        void RelsDown();

        void RelsLeft();

        void ToBig();

        void ToSmall();

        void ToFire();

        void Dead();

        void Update();

        void TouchDown();

        void TakeDamage();

        void Fire();

    }
}
