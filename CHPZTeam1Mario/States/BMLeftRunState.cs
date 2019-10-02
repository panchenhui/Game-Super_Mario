using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Sprites.MarioBig;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.States
{
    public class BMLeftRunState : IMarioState
    {
        private IPlayer mario { get; set; }

        public BMLeftRunState(IPlayer mario)
        {
            this.mario = mario;
            mario.Sprite = new BMLeftRunSprite(mario.Mygame.texture);
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

        public void ToBig()
        {

        }

        public void ToSmall()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + 38);
            mario.State = new SMLeftRunState(mario);
        }

        public void ToFire()
        {
            mario.State = new FMLeftRunState(mario);
        }

        public void Update()
        {
            mario.Sprite.Update();
        }
        public void RelsRight()
        {
            
        }
        public void RelsLeft()
        {
            mario.State = new BMLeftIdleState(mario);
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
            mario.State = new SMLeftRunState(mario);
        }
        public void Fire()
        {

        }
    }
}
