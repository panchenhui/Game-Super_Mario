using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Sprites.EmptyScreen;
using CHPZTeam1Mario.Sprites.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.EnemyClass
{
    public class GoombaClass : IEnemy
    {
        public ISprite Sprite { get; set; }

        public SuperMario Mygame { get; set; }

        private Vector2 velocity;

        private Vector2 acceleration;

        private Vector2 pos;
        private bool ifDead = false;

        private bool start = false;

        int DeadTimer = 15;
        public Rectangle rectangle { get; set; }


        public GoombaClass(SuperMario game,Vector2 position)
        {
            this.Mygame = game;
            this.Sprite = new GoombaRunSprite(Mygame.enemies);
            pos = position;
            velocity = new Vector2(0.0f, 0.0f);
            acceleration = new Vector2(0.0f, 0.0f);
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, 32, 32);

        }

        public void ChangeDirection()
        {
            velocity = new Vector2(-velocity.X, velocity.Y);
        }

        public void ChangeMovement(int i)
        {
            switch (i)
            {
                case (int)Enum.DisableMovementType.None:
 
                    this.acceleration = new Vector2(0.0f, 0.2f);
                    break;
                case (int)Enum.DisableMovementType.Up:

                    this.rectangle = new Rectangle(rectangle.X, rectangle.Y + 1, rectangle.Width, rectangle.Height);
                    break;
                case (int)Enum.DisableMovementType.Down:
                    this.rectangle = new Rectangle(rectangle.X, (int)(rectangle.Y - 0.5f), rectangle.Width, rectangle.Height);
                    this.acceleration = new Vector2(acceleration.X, 0.0f);
                    this.velocity = new Vector2(velocity.X, 0.0f);
                    break;
                case (int)Enum.DisableMovementType.Left:
                    acceleration = new Vector2(0.0f, acceleration.Y);
                    velocity = new Vector2(1.5f, velocity.Y);
                    break;
                case (int)Enum.DisableMovementType.Right:
                    acceleration = new Vector2(0.0f, acceleration.Y);
                    velocity = new Vector2(-1.5f, velocity.Y);
                    break;
                default:
                    break;
            }
        }

        public void TakeDamage()
        {
            if (!ifDead)
            {
                this.Sprite = new GoombaStompedSprite(Mygame.enemies);
                this.rectangle = new Rectangle((int)rectangle.X, (int)rectangle.Y + 16, 32, 16);
                velocity = new Vector2(0, 0);
                ifDead = true;
                Sound.Instance.Stomp();
                Mygame.HUD.GetScore(100);
                Mygame.HUD.ScoreDisplay(100,new Vector2(rectangle.X,rectangle.Y));
            }
        }

        public void Crashing(IEnemy enemy)
        {
        }

        public void Attack(IPlayer mario)
        {
            if(!ifDead)
                mario.TakeDamage();
        }
        public void Update()
        {
            if (!start && rectangle.X < Mygame.camera.cameraPositionX + 800)
            {
                velocity = new Vector2(-1.5f, 0);
                start = true;
            }
            if (ifDead)
            {
                DeadTimer--;
            }
            if (DeadTimer == 0){
                Sprite = new EmptyScreen(Mygame.items);
                rectangle = new Rectangle();
            }
            Sprite.Update();
            velocity += acceleration;
            rectangle = new Rectangle(rectangle.X + (int)velocity.X, rectangle.Y + (int)velocity.Y, rectangle.Width, rectangle.Height);
        }

        public void Draw(SpriteBatch sb,int worldPositionX,int worldPositionY)
        {
           
            Sprite.Draw(sb, new Vector2(rectangle.X - worldPositionX, rectangle.Y));
        }
    }
}
