using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Sprites.Bowser;
using CHPZTeam1Mario.Sprites.EmptyScreen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.EnemyClass
{
    public class BowserClass : IEnemy
    {
        public ISprite Sprite { get; set; }

        public SuperMario Mygame { get; set; }

        private Vector2 velocity;

        private Vector2 acceleration;

        private Vector2 pos;
        private bool ifDead = false;

        private bool start = false;

        int DeadTimer = 15;

        private int MoveTimer = 400;
        public Rectangle rectangle { get; set; }

        private int health;

        public BowserClass(SuperMario game, Vector2 position)
        {
            this.Mygame = game;
            this.Sprite = new BowserLeftSprite(Mygame.princess);
            pos = position;
            velocity = new Vector2(0.0f, 0.0f);
            acceleration = new Vector2(0.0f, 0.0f);
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, Sprite.Width(), Sprite.Height());
            health = 16;
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
                    if (!ifDead)
                    {
                        this.rectangle = new Rectangle(rectangle.X, (int)(rectangle.Y - 0.1f), rectangle.Width, rectangle.Height);
                        this.acceleration = new Vector2(acceleration.X, 0.0f);
                        this.velocity = new Vector2(velocity.X, 0.0f);
                    }
                    break;
                case (int)Enum.DisableMovementType.Left:

                    break;
                case (int)Enum.DisableMovementType.Right:

                    break;
                default:
                    break;
            }
        }

        public void TakeDamage()
        {
            health -= 2;
            if (health <= 0)
            {
                ifDead = true;
                Sprite = new EmptyScreen(Mygame.items);
                rectangle = new Rectangle();
            }
        }

        public void Crashing(IEnemy enemy)
        {
        }

        public void Attack(IPlayer mario)
        {
            
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
            if (DeadTimer == 0)
            {
                Sprite = new EmptyScreen(Mygame.items);
                rectangle = new Rectangle();
            }
            if (start&&MoveTimer > 0)
            {
                MoveTimer--;
            }
            else if(start&& MoveTimer<=0)
            {
                this.ChangeDirection();
                MoveTimer = 400;
            }
            Sprite.Update();
            velocity += acceleration;
            rectangle = new Rectangle(rectangle.X + (int)velocity.X, rectangle.Y + (int)velocity.Y, rectangle.Width, rectangle.Height);

        }

        public void Draw(SpriteBatch sb, int worldPositionX, int worldPositionY)
        {
            if(!ifDead)
            Sprite.Draw(sb, new Vector2(rectangle.X - worldPositionX, rectangle.Y));
        }
    }
}
