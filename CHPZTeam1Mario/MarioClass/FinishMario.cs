using CHPZTeam1Mario.Commands;
using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Sprites.EmptyScreen;
using CHPZTeam1Mario.Sprites.MarioBig;
using CHPZTeam1Mario.Sprites.MarioFire;
using CHPZTeam1Mario.Sprites.MarioSmall;
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
    public class FinishMario : IPlayer
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

        private int time = 600;
        private bool position_check_01 = false;
        private bool position_check_02 = false;
        private bool position_check_03 = false;
        private int flagX = 6342;
        private int mario_falling_velocity = 2;
        private int FBMGroundY = 325;
        private int SMGroundY = 355;

        private int endTimer=181;
        public FinishMario(IPlayer decoratedMario)
        {
            this.Mygame = decoratedMario.Mygame;
            this.Sprite = decoratedMario.Sprite;
            this.State = decoratedMario.State;

            if (this.State is BMRightJumpState)
            {
                this.Sprite = new BMRightOnFlagSprite(this.Sprite.Texture);
            }
            if (this.State is FMRightJumpState)
            {
                this.Sprite = new FMRightOnFlagSprite(this.Sprite.Texture);
            }
            if (this.State is SMRightJumpState)
            {
                this.Sprite = new SMRightOnFlagSprite(this.Sprite.Texture);
            }
            this.Position = decoratedMario.Position;
            this.rectangle = decoratedMario.rectangle;
            this.decoratedMario = decoratedMario;
            this.acc = decoratedMario.acc;
            this.velocity = new Vector2(0, 0);
            Sound.Instance.StopTheme();
            Sound.Instance.WorldClear();
            Sound.Instance.Flagpole();
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
        public void Update()
        {
            if (this.State is BMRightJumpState)
            {
                if (time > 0)
                {
                    time--;
                    if (this.Position.Y < FBMGroundY)
                    {
                        this.Position = new Vector2(this.Position.X, this.Position.Y + mario_falling_velocity);
                    }
                    else {
                        this.Sprite = new BMLeftOnFlagSprite(this.Sprite.Texture);
                        if (!position_check_01)
                        {
                            position_check_01 = true;
                            this.Position = new Vector2(this.Position.X+35, this.Position.Y);
                        }
                        time -= 100;
                    }
                }else
                {

                    if (!position_check_02)
                    {
                        this.Sprite = new BMRightRunSprite(this.Mygame.texture);
                        position_check_02 = true;
                        this.Position = new Vector2(this.Position.X + 10, this.Position.Y + 25);
                    }
                    this.velocity = new Vector2(1, 0);
                    this.Position = new Vector2((int)(Position.X + this.velocity.X), (int)(Position.Y + this.velocity.Y));
                }
           }else if (this.State is FMRightJumpState)
            {
                if (time > 0)
                {
                    time--;
                    if (this.Position.Y < FBMGroundY)
                    {
                        if (!position_check_03)
                        {
                            this.Position = new Vector2(this.Position.X+2, this.Position.Y);
                            position_check_03 = true;
                        }     
                        this.Position = new Vector2(this.Position.X, this.Position.Y + mario_falling_velocity);
                    }
                    else
                    {
                        this.Sprite = new FMLeftOnFlagSprite(this.Sprite.Texture);
                        if (!position_check_01)
                        {
                            position_check_01 = true;
                            this.Position = new Vector2(this.Position.X + 24, this.Position.Y);
                        }
                        time -= 100;
                    }
                }
                else
                {

                    if (!position_check_02)
                    {
                        this.Sprite = new FMRightWalkFireSprite(this.Mygame.texture);
                        position_check_02 = true;
                        this.Position = new Vector2(this.Position.X + 10, this.Position.Y + 25);
                    }
                    this.velocity = new Vector2(1, 0);
                    this.Position = new Vector2((int)(Position.X + this.velocity.X), (int)(Position.Y + this.velocity.Y));
                }
            }else if (this.State is SMRightJumpState)
            {
                if (time > 0)
                {
                    time--;
                    if (this.Position.Y < SMGroundY)
                    {
                        
                        this.Position = new Vector2(flagX, this.Position.Y +mario_falling_velocity);
                        position_check_03 = true;
                                                
                    }
                    else {
                        this.Sprite = new SMLeftOnFlagSprite(this.Sprite.Texture);
                        if (!position_check_01)
                        {
                            position_check_01 = true;
                            this.Position = new Vector2(this.Position.X + 30, this.Position.Y);
                        }
                        time -=100;
                    }
                }
                else
                {

                    if (!position_check_02)
                    {
                        this.Sprite = new SMRightRunSprite(this.Mygame.texture);
                        position_check_02 = true;
                        this.Position = new Vector2(this.Position.X + 10, this.Position.Y + 32);
                    }
                    this.velocity = new Vector2(1, 0);
                    this.Position = new Vector2((int)(Position.X + this.velocity.X), (int)(Position.Y + this.velocity.Y));
                }
            }
            
            this.Sprite.Update();



        }
        public void Draw(SpriteBatch sb, Vector2 vector)
        {
            if (this.Position.X <= 6500.0f)
            {
                this.Sprite.Draw(sb, new Vector2(this.Position.X - vector.X, this.Position.Y - vector.Y));
            }
            else
            {
                endTimer--;
                
                if (endTimer == 0)
                {
                    ICommand gotoLevel1_4 = new CommandGoToLevel1_4(Mygame);
                    gotoLevel1_4.Execute();
                    Mygame.Mario = decoratedMario;
                    Mygame.Mario.Position = new Vector2(50,150);
                    Mygame.Mario.velocity = new Vector2();
                    this.State.Right();

                }
            }
        }


        public void TakeDamage()
        {

        }

        public void Attack(IEnemy enemy)
        {
        }

        void RemoveStar()
        {
        }
        public void Freeze()
        {

        }
    }
}
