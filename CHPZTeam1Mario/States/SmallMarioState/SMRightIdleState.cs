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
    public class SMRightIdleState : IMarioState
    {
        private IPlayer mario { get; set; }        

        public SMRightIdleState(IPlayer mario)
        {
            this.mario = mario;
            mario.Sprite = new SpriteSMRightIdle(mario.Mygame.texture);
        }

        public void Left()
        {
            mario.State = new SMLeftIdleState(mario);
        }

        public void Right()
        {
            mario.State = new SMRightRunningState(mario);
        }

        public void Up()
        {
            mario.State = new SMRightJumpState(mario);
        }

        public void Down()
        {

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
