using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Projectile;
using CHPZTeam1Mario.Sprites.MarioFire;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.States
{
    public class FMLeftJumpState : IMarioState
    {
        private IPlayer mario { get; set; }
        private int timer = 15;

        public FMLeftJumpState(IPlayer mario)
        {
            this.mario = mario;
            mario.Sprite = new FMLeftJumpFireSprite(mario.Mygame.texture);
        }

        public void Up()
        {

            mario.State = new FMLeftJumpState(mario);
        }

        public void Down()
        {
            mario.State = new FMLeftIdleState(mario);
        }

        public void Left()
        {
            mario.State = new FMLeftJumpState(mario);
        }

        public void Right()
        {
            mario.State = new FMRightJumpState(mario);
        }

        public void Dead()
        {
            mario.State = new FMDeadState(mario);
        }

        public void ToBig()
        {
            mario.State = new BMLeftJumpState(mario);
        }

        public void ToSmall()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + 38);
            mario.State = new SMLeftJumpState(mario);
        }

        public void ToFire()
        {

        }

        public void Update()
        {
            if (timer > 0)
            {
                timer--;
            }
            else
            {
                timer = 15;
            }
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
            mario.State = new FMLeftIdleState(mario);
        }
        public void TakeDamage()
        {
            mario.State = new SMLeftJumpState(mario);
        }
        public void Fire()
        {
            if (timer == 15)
            {
                mario.Mygame.World.AddProjectile(new MarioFireBall(new Vector2(mario.Position.X - 10, mario.Position.Y + 5), mario.Mygame.enemies, -1));
            }
        }
    }
}
