using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.MarioClass;
using CHPZTeam1Mario.Sprites.MarioSmall;
using CHPZTeam1Mario.States;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.States
{
    public class SMRightCrouchState : IMarioState
    {
        private IPlayer mario { get; set; }

        public SMRightCrouchState(IPlayer mario)
        {
            this.mario = mario;
            mario.Sprite = new SMRightIdleSprite(mario.Mygame.texture);
        }

        public void Left()
        {
            mario.State = new SMLeftIdleState(mario);
        }

        public void Right()
        {

                mario.State = new SMRightRunState(mario);
            
        }

        public void Up()
        {
            mario.State = new SMRightJumpState(mario);
        }

        public void Down()
        {

        }
        public void ToBig()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 38);
            mario.State = new BMRightIdleState(mario);
        }

        public void ToSmall()
        {

        }

        public void ToFire()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 38);
            mario.State = new FMRightIdleState(mario);
        }

        public void Dead()
        {
            mario.State = new SMDeadState(mario);
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
            mario.State = new SMDeadState(mario);
        }
        public void Fire()
        {

        }
    }
}
