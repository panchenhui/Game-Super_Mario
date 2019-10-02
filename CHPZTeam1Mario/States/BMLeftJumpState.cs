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
    public class BMLeftJumpState : IMarioState
    {
        private IPlayer mario { get; set; }

        public BMLeftJumpState(IPlayer mario)
        {
            this.mario = mario;
            mario.Sprite = new BMLeftJumpSprite(mario.Mygame.texture);
        }

        public void Up()
        {
            mario.Sprite = new BMLeftJumpSprite(mario.Mygame.texture);

        }

        public void Down()
        {
            mario.State = new BMLeftIdleState(mario);
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
            mario.State = new SMLeftJumpState(mario);
        }

        public void ToFire()
        {
            mario.State = new FMLeftJumpState(mario);
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
            mario.State = new BMLeftIdleState(mario);
        }
        public void TakeDamage()
        {
            mario.State = new SMLeftJumpState(mario);
        }
        public void Fire()
        {

        }
    }
}
