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
    public class BMRightIdleState :IMarioState
    {
        private IPlayer mario { get; set; }



        public BMRightIdleState(IPlayer mario)
        {
            this.mario = mario;
            mario.Sprite = new BMRightIdleSprite(mario.Mygame.texture);
        }

        public void Up()
        {
            mario.State = new BMRightJumpState(mario);

        }

        public void Down()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + 26);
            mario.State = new BMRightCrouchState(mario);
        }

        public void Left()
        {
            mario.State = new BMLeftIdleState(mario);
        }

        public void Right()
        {

                mario.State = new BMRightRunState(mario);
            
            
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
            mario.State = new SMRightIdleState(mario);
        }

        public void ToFire()
        {
            mario.State = new FMRightIdleState(mario);
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
            mario.State = new SMRightIdleState(mario);
        }
        public void Fire()
        {

        }
    }
}
