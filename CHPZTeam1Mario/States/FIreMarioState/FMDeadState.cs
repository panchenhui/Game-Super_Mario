using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Sprites.MarioSmall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// //
/// </summary>
namespace CHPZTeam1Mario.States
{
    public class FMDeadState : IMarioState
    {
        private IPlayer mario { get; set; }

        public FMDeadState(IPlayer mario)
        {
            this.mario = mario;
            mario.Sprite = new SpriteSMDead(mario.Mygame.texture);
        }

        public void Up()
        {

        }

        public void Down()
        {

        }

        public void Left()
        {

        }

        public void Right()
        {

        }


        public void Dead()
        {
        }

        public void Update()
        {
            mario.Sprite.Update();
        }
    }
}
