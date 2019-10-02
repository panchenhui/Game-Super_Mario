using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Sprites.MarioFire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.States
{
    public class FMLeftWalkState : IMarioState
    {
        private IPlayer mario { get; set; }

        public FMLeftWalkState(IPlayer mario)
        {
            this.mario = mario;
            mario.Sprite = new LeftWalkFireMario(mario.Mygame.texture);
        }

        public void Up()
        {
            mario.State = new FMLeftJumpState(mario);

        }

        public void Down()
        {
            mario.State = new FMLeftCrouchState(mario);
        }

        public void Left()
        {

        }

        public void Right()
        {
            mario.State = new FMRightStandState(mario);
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
