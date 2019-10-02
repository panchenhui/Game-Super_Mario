using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Sprites.MarioBig;
using CHPZTeam1Mario.Sprites.MarioChangeSprite;
using CHPZTeam1Mario.Sprites.MarioChanging;
using CHPZTeam1Mario.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.MarioClass
{
    public class FlowerEatMario : IPlayer
    {

        public int health { get; set; }
        public IMarioState State { get; set; }
        public ISprite Sprite { get; set; }

        public SuperMario Mygame { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle rectangle { get; set; }
        public Vector2 velocity { get; set; }

        public Vector2 acc { get; set; }

        private IPlayer decoratedMario;

        private int timer = 46;
        public FlowerEatMario(IPlayer decoratedMario)
        {
            this.decoratedMario = decoratedMario;
            this.Mygame = decoratedMario.Mygame;
            this.State = decoratedMario.State;
            Sprite = decoratedMario.Sprite;

            if (this.State is BMRightIdleState)
            {
                this.Sprite = new BTFRightIdleSprite(this.Sprite.Texture);
            }
            else if (this.State is BMLeftIdleState)
            {
                this.Sprite = new BTFLeftIdleSprite(this.Sprite.Texture);
            }
            else if (this.State is BMRightJumpState)
            {
                this.Sprite = new BTFRightJumpSprite(this.Sprite.Texture);
            }
            else if (this.State is BMLeftJumpState)
            {
                this.Sprite = new BTFLeftJumpSprite(this.Sprite.Texture);
            }else if (this.State is BMLeftRunState)
            {
                this.Sprite = new BTFLeftIdleSprite(this.Sprite.Texture);
            }else if (this.State is BMRightRunState)
            {
                this.Sprite = new BTFRightIdleSprite(this.Sprite.Texture);
            }

            else if (this.State is SMLeftIdleState)
            {
                this.Sprite = new BTFLeftIdleSprite(this.Sprite.Texture);
            }
            else if (this.State is SMLeftJumpState)
            {
                this.Sprite = new BTFLeftIdleSprite(this.Sprite.Texture);
            }
            else if (this.State is SMRightIdleState)
            {
                this.Sprite = new BTFRightIdleSprite(this.Sprite.Texture);
            }
            else if (this.State is SMRightJumpState)
            {
                this.Sprite = new BTFRightIdleSprite(this.Sprite.Texture);
            }
            else if (this.State is SMRightRunState)
            {
                this.Sprite = new BTFRightIdleSprite(this.Sprite.Texture);
            }
            else if (this.State is SMLeftRunState)
            {
                this.Sprite = new BTFLeftIdleSprite(this.Sprite.Texture);
            }

            this.Position = decoratedMario.Position;
            this.rectangle = decoratedMario.rectangle;

            this.acc = decoratedMario.acc;
            this.velocity = decoratedMario.velocity;

        }
        public void Accelerate()
        {

        }
        public void RelsAccelerate()
        {

        }
        public void Left()
        {

        }

        public void Right()
        {

        }

        public void Up()
        {

        }

        public void Down()
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

        public void DisableMovement(int i)
        {

        }

        public void Draw(SpriteBatch sb, Vector2 vector)
        {

            Sprite.Draw(sb, new Vector2(Position.X - vector.X, Position.Y - vector.Y));

        }

        public void Update()
        {
            if (timer > 0)
            {
                timer--;
            }
            else
            {
                Mygame.Mario = decoratedMario;
                if (this.State is SMLeftJumpState)
                {
                    Mygame.Mario.ToFire();
                }
                else if (this.State is SMLeftIdleState)
                {
                    Mygame.Mario.ToFire();
                }
                else if (this.State is SMRightIdleState)
                {
                    Mygame.Mario.ToFire();
                }
                else if (this.State is SMRightJumpState)
                {
                    Mygame.Mario.ToFire();
                }
                else if (this.State is SMRightRunState)
                {
                    Mygame.Mario.ToFire();
                }
                else if (this.State is SMLeftRunState)
                {
                    Mygame.Mario.ToFire();
                }
                else
                {
                    Mygame.Mario.ToFire();
                }

            }
            this.Sprite.Update();
        }
        public void TakeDamage()
        {

        }

        public void Attack(IEnemy enemy)
        {

        }
        public void Freeze()
        {

        }
    }
}
