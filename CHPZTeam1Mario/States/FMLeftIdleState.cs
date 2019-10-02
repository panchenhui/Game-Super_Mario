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
    public class FMLeftIdleState : IMarioState
    {
        private IPlayer mario { get; set; }

        private int timer = 15;

        public FMLeftIdleState(IPlayer mario)
        {
            this.mario = mario;
            mario.Sprite = new FMLeftStandFireSprite(mario.Mygame.texture);
        }

        public void Up()
        {
            mario.State = new FMLeftJumpState(mario);

        }

        public void Down()
        {
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + 26);
            mario.State = new FMLeftCrouchState(mario);
        }

        public void Left()
        {

                mario.State = new FMLeftRunState(mario);
            
        }

        public void Right()
        {
            mario.State = new FMRightIdleState(mario);
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
            mario.Position = new Vector2(mario.Position.X, mario.Position.Y + 38);
            mario.State = new SMLeftIdleState(mario);
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
            mario.Sprite = new FMLeftStandFireSprite(mario.Mygame.texture);
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
            mario.State = new SMLeftIdleState(mario);
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
