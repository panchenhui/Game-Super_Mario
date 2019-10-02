using CHPZTeam1Mario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.States
{
    public class BMLeftRunningState : IMarioState
    {
        private IPlayer mario { get; set; }

        public BMLeftRunningState(IPlayer mario)
        {
            this.mario = mario;
            mario.Sprite = new SpriteBMLeftRun(mario.Mygame.texture);
        }

        public void Up()
        {
            mario.State = new BMLeftJumpState(mario);

        }

        public void Down()
        {
            mario.State = new BMLeftCrouchState(mario);
        }

        public void Left()
        {
           
        }

        public void Right()
        {
            mario.State = new BMRightIdleState(mario);
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
