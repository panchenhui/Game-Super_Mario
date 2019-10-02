using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Sprites.MarioFire;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.States
{
    public class FMRightCrouchState : IMarioState
    {
        private IPlayer mario { get; set; }

        public FMRightCrouchState(IPlayer mario)
        {
            this.mario = mario;
            mario.Sprite = new FMRightCrouchFireSprite(mario.Mygame.texture);
        }

        public void Up()
        {
           

        }

        public void Down()
        {
            mario.State = new FMRightCrouchState(mario);
        }

        public void Left()
        {
            mario.State = new FMLeftCrouchState(mario);
        }

        public void Right()
        {
            mario.State = new FMRightCrouchState(mario);
        }

        public void Dead()
        {
            mario.State = new FMDeadState(mario);
        }
        public void ToBig()
        {
            
        }

        public void ToSmall()
        {
            mario.State = new SMRightIdleState(mario);
        }

        public void ToFire()
        {

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
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y - 26);
            mario.State = new FMRightIdleState(mario);
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
