using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.MarioClass;
using CHPZTeam1Mario.Sprites.MarioSmall;
using CHPZTeam1Mario.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.States
{
    public class SMLeftIdleState : IMarioState
    {
        private IPlayer mario { get; set; }        

        public SMLeftIdleState(IPlayer mario)
        {
            this.mario = mario;
            mario.Sprite = new SpriteSMLeftIdle(mario.Mygame.texture);
        }

        public void Left()
        {
            mario.State = new SMLeftRunningState(mario);
        }

        public void Right()
        {
            mario.State = new SMRightIdleState(mario);
        }

        public void Up()
        {
            mario.State = new SMLeftJumpState(mario);
        }

        public void Down()
        {
            mario.State = new SMLeftIdleState(mario);
        }

        public void Dead()
        {
            mario.State = new SMDeadState(mario);
        }

        public void Update()
        {
            mario.Sprite.Update();
        }
    }
}
