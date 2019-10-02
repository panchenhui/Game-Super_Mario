using CHPZTeam1Mario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.States
{
    public class BMRightJumpState : IMarioState
    {
        private IPlayer mario { get; set; }

        public BMRightJumpState(IPlayer mario)
        {
            this.mario = mario;
            mario.Sprite = new SpriteBMRightJump(mario.Mygame.texture);
        }

        public void Up()
        {
            mario.State = new BMRightJumpState(mario);

        }

        public void Down()
        {
            mario.State = new BMRightIdleState(mario);
        }

        public void Left()
        {
            mario.State = new BMLeftIdleState(mario);
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
