using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.ChangeState
{
    class SMarioTobig
    {
        public IMarioState State { get; set; }
        public ISprite Sprite { get; set; }

        public SuperMario Mygame { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle rectangle { get; set; }
        public Vector2 velocity { get; set; }

        public Vector2 acc { get; set; }

        public IPlayer decoratedMario;

        public int timer = 480;
        private int flashTimer = 2;
        public StarMario(IPlayer decoratedMario)
        {
            this.Mygame = decoratedMario.Mygame;
            this.Sprite = decoratedMario.Sprite;
            this.State = decoratedMario.State;
            this.Position = decoratedMario.Position;
            this.rectangle = decoratedMario.rectangle;
            this.decoratedMario = decoratedMario;
            this.acc = decoratedMario.acc;
            this.velocity = decoratedMario.velocity;

        }
        public void Accelerate()
        {
            decoratedMario.Accelerate();

        }
        public void RelsAccelerate()
        {
            decoratedMario.RelsAccelerate();
        }
        public void Left()
        {
            decoratedMario.Left();

        }

        public void Right()
        {
            decoratedMario.Right();
        }

        public void Up()
        {
            decoratedMario.Up();
        }

        public void Down()
        {
            decoratedMario.Down();
        }

        public void Dead()
        {
            decoratedMario.Dead();
        }

        public void ToBig()
        {
            decoratedMario.ToBig();
        }

        public void ToSmall()
        {
            decoratedMario.ToSmall();
        }
        public void ToFire()
        {
            decoratedMario.ToFire();
        }
        public void RelsRight()
        {
            decoratedMario.RelsRight();
        }
        public void RelsLeft()
        {
            decoratedMario.RelsLeft();
        }
        public void RelsDown()
        {
            decoratedMario.RelsDown();
        }
        public void RelsUp()
        {
            decoratedMario.RelsUp();
        }

        public void DisableMovement(int i)
        {
            decoratedMario.DisableMovement(i);
        }
        public void Draw(SpriteBatch sb, Vector2 vector)
        {
            flashTimer++;
            if (flashTimer % 3 == 0)
                decoratedMario.Draw(sb, vector);
        }

        public void Update()
        {
            timer--;
            if (timer == 0)
            {
                RemoveStar();
                return;
            }
            decoratedMario.Update();
            this.Position = decoratedMario.Position;
            this.rectangle = decoratedMario.rectangle;
        }
        public void TakeDamage()
        {

        }

        public void Attack(IEnemy enemy)
        {
            enemy.TakeDamage();
        }

        void RemoveStar()
        {
            Mygame.Mario = decoratedMario;
        }
    }
}
