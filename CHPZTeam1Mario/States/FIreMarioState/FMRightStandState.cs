using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Sprites.MarioFire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.States
{
    public class FMRightStandState : IMarioState
    {
        private IPlayer mario { get; set; }

        public FMRightStandState(IPlayer mario)
        {
            this.mario = mario;
            mario.Sprite = new RightStandFireMario(mario.Mygame.texture);
        }

        public void Up()
        {
            mario.State = new FMRightJumpState(mario);

        }

        public void Down()
        {
            mario.State = new FMRightCrouchState(mario);
        }

        public void Left()
        {
            mario.State = new FMLeftStandState(mario);
        }

        public void Right()
        {
            mario.State = new FMRightWalkState(mario);
        }

        public void Dead()
        {
            mario.State = new FMDeadState(mario);
        }

        public void Update()
        {
            mario.Sprite.Update();
        }
    }
}
