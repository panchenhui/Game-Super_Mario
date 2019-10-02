using CHPZTeam1Mario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.States
{
    public class BMRightRunningState : IMarioState
    {
        private IPlayer mario { get; set; }

        public BMRightRunningState(IPlayer mario)
        {
            this.mario = mario;
            mario.Sprite = new SpriteBMRightRun(mario.Mygame.texture);
        }

        public void Up()
        {
            mario.State = new BMRightJumpState(mario);

        }

        public void Down()
        {
            mario.State = new BMRightCrouchState(mario);
        }

        public void Left()
        {
            mario.State = new BMLeftIdleState(mario);
        }

        public void Right()
        {
            
        }
        public void Dead()
        {
            mario.State = new BMDeadState(mario);
        }

        public void Update()
        {
            mario.Sprite.Update();
        }
    }
}
