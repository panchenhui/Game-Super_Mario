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
    public class BMRightCrouchState : IMarioState
    {
        private IPlayer mario { get; set; }

        public BMRightCrouchState(IPlayer mario)
        {
            this.mario = mario;
            mario.Sprite = new BMRightCrouchSprite(mario.Mygame.texture);
        }

        public void Up()
        {
           

        }

        public void Down()
        {
            
        }

        public void Left()
        {
            mario.State = new BMLeftCrouchState(mario);
        }

        public void Right()
        {
            mario.State = new BMRightCrouchState(mario);
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
            mario.State = new SMRightIdleState(mario);
        }

        public void ToFire()
        {
            mario.State = new FMRightCrouchState(mario);
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
            mario.State = new BMRightIdleState(mario);
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
