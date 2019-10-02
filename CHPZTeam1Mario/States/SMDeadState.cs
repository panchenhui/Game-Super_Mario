using CHPZTeam1Mario.Commands;
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
        private int timer = 180;
        public SMDeadState(IPlayer mario)
        {
            this.mario = mario;
            mario.Sprite = new SMDeadSprite(mario.Mygame.texture);
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
        public void ToBig()
        {
           
        }

        public void ToSmall()
        {

        }

        public void ToFire()
        {
            
        }
        public void Dead()
        {
        }

        public void Update()
        {
            timer--;
            mario.Sprite.Update();
            Sound.Instance.StopTheme();
            if (timer == 0)
            {
                ICommand reset = new CommandReset(mario.Mygame);
                reset.Execute();
            }
        }
        public void RelsRight()
        {

        }
        public void RelsLeft()
        {

        }
        public void RelsDown()
        {

        }
        public void RelsUp()
        {

        }
        public void TouchDown()
        {

        }
        public void TakeDamage()
        {
            
        }
        public void Fire()
        {

        }

    }
}
