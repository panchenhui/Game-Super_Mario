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
    public class SMRightRunState : IMarioState
    {
        private IPlayer mario { get; set; }        

        public SMRightRunState(IPlayer mario)
        {
            this.mario = mario;
            mario.Sprite = new SMRightRunSprite(mario.Mygame.texture);
        }

        public void Left()
        {
            mario.State = new SMLeftIdleState(mario);

        }

        public void Right()
        {

        }

        public void Up()
        {
            mario.State = new SMRightJumpState(mario);
        }

        public void Down()
        {
            mario.State = new SMRightIdleState(mario);
        }

        public void ToBig()
        {
            mario.State = new BMRightRunState(mario);
        }

        public void ToSmall()
        {
           
        }

        public void ToFire()
        {
            mario.State = new FMRightRunState(mario);
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
