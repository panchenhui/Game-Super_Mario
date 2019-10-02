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
    public class SMDeadState : IMarioState
    {
        private IPlayer mario { get; set; }        

        public SMDeadState(IPlayer mario)
        {
            this.mario = mario;
            mario.Sprite = new SpriteSMDead(mario.Mygame.texture);
        }     
        public void Left()
        {
            
        }

        public void Right()
        {
           
        }

        public void Up()
        {
            
        }

        public void Down()
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
