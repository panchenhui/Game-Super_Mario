using CHPZTeam1Mario.Commands;
using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Sprites.MarioSmall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.States
{
    public class BMDeadState : IMarioState
    {
        private IPlayer mario { get; set; }

        public BMDeadState(IPlayer mario)
        {
            this.mario = mario;
            mario.Sprite = new SMDeadSprite(mario.Mygame.texture);
        }

        public void Up()
        {           
        }

        public void Down()
        {
            
        }

        public void Left()
        {           
        }

        public void Right()
        {           
        }

       
        public void Dead()
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

        public void Update()
        {
            mario.Sprite.Update();
            ICommand reset = new CommandReset(mario.Mygame);
            reset.Execute();
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
