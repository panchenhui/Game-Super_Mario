using CHPZTeam1Mario.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHPZTeam1Mario.Sprites.MarioSmall;
using CHPZTeam1Mario.Sprites.MarioBig;

namespace CHPZTeam1Mario.States
{
    public class BMRightJumpState : IMarioState
    {
        private IPlayer mario { get; set; }

        public BMRightJumpState(IPlayer mario)
        {
            this.mario = mario;
            mario.Sprite = new BMRightJumpSprite(mario.Mygame.texture);
        }

        public void Up()
        {

            mario.Sprite = new BMRightJumpSprite(mario.Mygame.texture);
        }

        public void Down()
        {
            mario.State = new BMRightIdleState(mario);
        }

        public void Left()
        {
            mario.State = new BMLeftJumpState(mario);
        }

        public void Right()
        {
            mario.State = new BMRightJumpState(mario);
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
            mario.State = new SMRightJumpState(mario);
        }

        public void ToFire()
        {
            mario.State = new FMRightJumpState(mario);
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
            mario.State = new BMRightIdleState(mario);
        }
        public void TakeDamage()
        {
            mario.State = new SMRightJumpState(mario);
        }
        public void Fire()
        {

        }

    }
}
