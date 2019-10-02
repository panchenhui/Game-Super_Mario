using CHPZTeam1Mario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CHPZTeam1Mario.States;
using CHPZTeam1Mario.Sprites.MarioSmall;
using CHPZTeam1Mario.Commands;
using CHPZTeam1Mario.Level;

namespace CHPZTeam1Mario.MarioClass
{
    public class Mario : IPlayer
    {
        public IMarioState State { get; set; }
        public ISprite Sprite { get; set; }

        public SuperMario Mygame { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle rectangle { get; set; }

        public Vector2 velocity { get; set; }

        public Vector2 acc { get; set; }
        public int health { get; set; }
        private bool above,below,left,right;

        private int timer  = Utility.timer_mario_class;
        private int flasher = Utility.flasher_mario_class;
        private int frozenTimer = 0;
        Boolean dead = false;
        private bool ifDisappear = false;
            
        private int resetTimer = Utility.reset_timer_mario_class;

        private bool ifFrozen = false;
        public Mario(SuperMario game,Vector2 startPosition)
        {
            this.Mygame = game;
            this.Sprite = new SMRightIdleSprite(Mygame.texture);         
            this.State = new SMRightIdleState(this);
            this.Position = new Vector2((float)startPosition.X, (float)startPosition.Y);
            this.rectangle = new Rectangle((int)startPosition.X,(int)startPosition.Y, Utility.mario_width, Utility.mario_height);
            this.acc = new Vector2(0.0f, Utility.Physics_FallingAcc);
            this.velocity = new Vector2(0.0f, 0.0f);
            above = true;
            below = true;
            left = true;
            right = true;
            health = -1;
        }

        public void Accelerate()
        {
            if (!below && !ifFrozen)
            {
                if (this.velocity.X > 0.0f && this.velocity.X <= Utility.MarioMaxRunningSpeed)
                {
                    this.acc = new Vector2(Utility.MarioRunningAcc, acc.Y);
                }
                else if (this.velocity.X < 0.0f && this.velocity.X >= -Utility.MarioMaxWalkSpeed)
                {
                    this.acc = new Vector2(-Utility.MarioRunningAcc, acc.Y);
                }
                else if(this.velocity.X > Utility.MarioMaxRunningSpeed)
                {
                    this.velocity = new Vector2(Utility.MarioMaxRunningSpeed, velocity.Y);
                }
                else if(this.velocity.X < -Utility.MarioMaxRunningSpeed)
                {
                    this.velocity = new Vector2(-Utility.MarioMaxRunningSpeed, velocity.Y);
                }
                else
                {
                    this.acc = new Vector2(0.0f, acc.Y);
                }
            }
            if (!ifFrozen)
            {
                State.Fire();
            }

        }
        public void RelsAccelerate()
        {

            if (!below&&!ifFrozen)
            {
                if (this.velocity.X > 0.0f && this.velocity.X <= Utility.MarioMaxRunningSpeed)
                {
                    this.acc = new Vector2(-Utility.MarioFrictionAcc, acc.Y);
                }
                else if (this.velocity.X < 0.0f && this.velocity.X >= -Utility.MarioMaxRunningSpeed)
                {
                    this.acc = new Vector2(Utility.MarioFrictionAcc, acc.Y);
                }
                else
                {
                    this.acc = new Vector2(0.0f, acc.Y);
                }
            }
            if (!ifFrozen)
            {
                State.Fire();
            }
        }
        public void Left()
        {
            if (!ifFrozen)
            {
                State.Left();
                if (left && velocity.X >= 0.0f && !dead)
                    this.velocity = new Vector2(-Utility.MarioStartingSpeed, velocity.Y);
            }
            
        }

        public void Right()
        {
            if (!ifFrozen)
            {
                State.Right();
                if (right && velocity.X <= 0.0f && !dead)
                    this.velocity = new Vector2(Utility.MarioStartingSpeed, velocity.Y);
            }
           
        }

        public void Up()
        {
            if (!ifFrozen)
            {
                bool ifCrouch = ((this.State is FMLeftCrouchState) || (this.State is FMRightCrouchState) || (this.State is BMLeftCrouchState) || (this.State is BMRightCrouchState));
                if (!below && !ifCrouch && !dead)
                {
                    this.velocity = new Vector2(velocity.X, -Utility.MarioJumpingSpeed);
                    Sound.Instance.Jump();

                }

                State.Up();
            }
        }

        public void Down()
        {
            if (!ifFrozen)
            {
                if ((this.State is FMLeftCrouchState) || (this.State is FMRightCrouchState) || (this.State is BMLeftCrouchState) || (this.State is BMRightCrouchState))
                    this.velocity = new Vector2(0.0f, velocity.Y);
                State.Down();
            }
        }

        public void Dead()
        {
            rectangle = new Rectangle();
            State.Dead();
            dead = true;
            Sound.Instance.Dead();            
        }

        public void ToBig()
        {
            
            State.ToBig();
        }

        public void ToSmall()
        {
            State.ToSmall();
        }
        public void ToFire()
        {
            State.ToFire();
        }
        public void RelsRight()
        {
            if (!ifFrozen)
            {
                State.RelsRight();
                velocity = new Vector2(0.0f, velocity.Y);
                if (velocity.X > 0.0f)
                    this.acc = new Vector2(-Utility.MarioSlidingAcc, acc.Y);
            }
        }
        public void RelsLeft()
        {
            if (!ifFrozen)
            {
                State.RelsLeft();
                velocity = new Vector2(0.0f, velocity.Y);
                if (velocity.X < 0.0f)
                    this.acc = new Vector2(Utility.MarioSlidingAcc, acc.Y);
            }
        }
        public void RelsDown()
        {
            
                State.RelsDown();
        }
        public void RelsUp()
        {
            if (!ifFrozen)
                State.RelsUp();
        }

        public void DisableMovement(int i)
        {
            switch (i)
            {
                case (int)Enum.DisableMovementType.None:
                    above = true;
                    below = true;
                    left = true;
                    right = true;
                    this.acc = new Vector2(0.0f, Utility.Physics_FallingAcc);
                    break;
                case (int)Enum.DisableMovementType.Up:
                    above = false;
                    this.Position = new Vector2(this.Position.X, this.Position.Y + Utility.MarioRunningAcc);
                    if (velocity.Y < 0.0f)
                    {
                        this.velocity = new Vector2(velocity.X, Utility.MarioLocationShifter);
                    }
                    break;
                case (int)Enum.DisableMovementType.Down:
                    below = false;
                    this.Position = new Vector2(this.Position.X, this.Position.Y - Utility.MarioLocationShifter);
                    this.acc = new Vector2(acc.X, 0.0f);
                    this.velocity = new Vector2(velocity.X, 0.0f);
                    State.TouchDown();                    
                    break;
                case (int)Enum.DisableMovementType.Left:
                    left = false;
                        acc = new Vector2(0.0f, acc.Y);
                        velocity = new Vector2(0.0f, velocity.Y);                    
                    break;
                case (int)Enum.DisableMovementType.Right:
                    right = false;
                        acc = new Vector2(0.0f, acc.Y);
                        velocity = new Vector2(0.0f, velocity.Y);                    
                    break;
                default:
                    above = true;
                    below = true;
                    left = true;
                    right = true;
                    break;
            }
        }
        public void Draw(SpriteBatch sb, Vector2 vector)
        {
            if (!ifDisappear)
            {
                if (timer <= 0|| dead)
                {
                    Sprite.Draw(sb, new Vector2(Position.X - vector.X, Position.Y - vector.Y));
                }
                else
                {
                    if (flasher % Utility.MarioFlashSpeed == 0)
                    {
                        Sprite.Draw(sb, new Vector2(Position.X - vector.X, Position.Y - vector.Y));
                    }
                }
            }
            else
            {
                resetTimer++;
                if (resetTimer++ == Utility.timer_check_mario_class)
                {
                    ICommand reset = new CommandReset(Mygame);
                    reset.Execute();
                }
            }
        }

        public void Update()
        {
            if (!dead)
            {
                if (this.Position.Y <= Utility.position_limit_y && this.Position.X <= Utility.position_limit_x)
                {
                    flasher++;
                    timer--;
                    if (above)
                        State.RelsUp();
                    if (!ifFrozen)
                    {
                        if (velocity.X > 0.0f && velocity.X + acc.X < 0.0f)
                        {
                            this.velocity = new Vector2(0.0f, velocity.Y + acc.Y);
                        }
                        else if (velocity.X < 0.0f && velocity.X + acc.X > 0.0f)
                        {
                            this.velocity = new Vector2(0.0f, velocity.Y + acc.Y);
                        }
                        else
                        {
                            this.velocity = new Vector2(velocity.X + acc.X, velocity.Y + acc.Y);
                        }
                    }
                    else
                    {
                        frozenTimer++;
                        this.velocity = new Vector2(0.0f, velocity.Y + acc.Y);
                        if (frozenTimer == 100)
                        {

                            frozenTimer = 0;
                            ifFrozen = false;
                            acc = new Vector2(0.0f,0.2f);
                        }
                    }
                    this.Position = new Vector2((int)(Position.X + velocity.X), (int)(Position.Y + velocity.Y));
                    if (!dead)
                        this.rectangle = new Rectangle((int)(Position.X), (int)(Position.Y), Sprite.Width(), Sprite.Height());
                    if(!ifFrozen)
                        State.Update();
                }
                else if (this.Position.Y > Utility.position_limit_y)
                {
                    this.Dead();
                }
                else if (this.Position.X > Utility.position_limit_x)
                {
                    ifDisappear = true;
                }
            }
            else
            {
                State.Update();
            }
        }
        public void TakeDamage()
        {
            if (timer < 0)
            {
                if (health < 0)
                {
                    if (Mygame.Mario.rectangle.Height<44)
                    {
                        Dead();
                    }
                    else
                    {
                        Mygame.Mario = new BFTakeDamageMario(Mygame.Mario);
                        Sound.Instance.TakeDamage();
                        timer = Utility.BigMarioBecomgingSmallTimer;
                    }
                }
                health--;
                if (health == 0)
                {
                    Dead();
                    Mygame.World.Level= new InfoScreen(Mygame, "Content/Subtitle/BadEnd.txt");
                }
            }              
        }

        public void Attack(IEnemy enemy)
        {
            if (this.below == false)
            {
                this.velocity = new Vector2(velocity.X, -Utility.MarioBounceSpeed);
                enemy.TakeDamage();              
            }
        }
        public void Freeze()
        {
            ifFrozen = true;
            velocity = new Vector2();
            acc = new Vector2(0.0f,0.2f);
        }
    }
}
