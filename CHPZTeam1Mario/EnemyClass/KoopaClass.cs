using CHPZTeam1Mario.Interfaces;
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
    public class KoopaClass : IEnemy
    {
        public ISprite Sprite { get; set; }

        public SuperMario Mygame { get; set; }

        public Rectangle rectangle { get; set; }

        private Vector2 velocity;

        private Vector2 acceleration;

        private Vector2 pos;

        private bool ifDead = false;

        private bool ifStomped = false;

        private bool StompedAgain = false;

        private bool start = false;

        public KoopaClass(SuperMario game,Vector2 position)
        {
            this.Mygame = game;
            this.Sprite = new KoopaLeftSprite(Mygame.enemies);
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, 32, 48);
            pos=position;
            velocity = new Vector2(0, 0);
            acceleration = new Vector2(0, 0);
        }

        public void ChangeDirection()
        {
            if(Sprite is KoopaLeftSprite)
            {
                Sprite = new KoopaRightSprite(Mygame.enemies);
                velocity = new Vector2(1.5f, velocity.Y);
            }
            else if (Sprite is KoopaRightSprite)
            {
                Sprite = new KoopaLeftSprite(Mygame.enemies);
                velocity = new Vector2(-1.5f, velocity.Y);
            }
            else
            {
                velocity = new Vector2(-velocity.X, velocity.Y);
            }
        }

        public void ChangeMovement(int i)
        {
            if (!ifDead)
            {
                switch (i)
                {
                    case (int)Enum.DisableMovementType.None:

                        this.acceleration = new Vector2(0.0f, 0.2f);
                        break;
                    case (int)Enum.DisableMovementType.Up:

                        this.pos = new Vector2(this.pos.X, this.pos.Y + 0.5f);
                        break;
                    case (int)Enum.DisableMovementType.Down:
                        this.pos = new Vector2(this.pos.X, this.pos.Y - 1.0f);
                        this.acceleration = new Vector2(acceleration.X, 0.0f);
                        this.velocity = new Vector2(velocity.X, 0.0f);
                        break;
                    case (int)Enum.DisableMovementType.Left:
                        acceleration = new Vector2(0.0f, acceleration.Y);
                        this.ChangeDirection();
                        break;
                    case (int)Enum.DisableMovementType.Right:
                        acceleration = new Vector2(0.0f, acceleration.Y);
                        this.ChangeDirection();
                        break;
                    default:
                        break;
                }
            }
        }

        public void Crashing(IEnemy enemy)
        {
            if (StompedAgain)
            {
                enemy.TakeDamage();
            }
        }

        public void TakeDamage()
        {
            if(!ifDead&&!ifStomped&&!StompedAgain){
                this.Sprite = new KoopaStompedSprite(Mygame.enemies);
                this.rectangle = new Rectangle((int)rectangle.X, (int)rectangle.Y + 20, 32, 28);
                velocity = new Vector2(0, 0);
                ifStomped = true;
                Sound.Instance.Stomp();
                Mygame.HUD.GetScore(100);
                Mygame.HUD.ScoreDisplay(100, new Vector2(rectangle.X, rectangle.Y));
            }
            else if(ifStomped)
            {
                velocity = new Vector2(4,0);
                Mygame.HUD.GetScore(500);
                Mygame.HUD.ScoreDisplay(500, new Vector2(rectangle.X, rectangle.Y));
                ifStomped = false;
                StompedAgain = true;
            }
            else if(StompedAgain)
            {
                ifDead = true;
                velocity = new Vector2(0, -1);
                acceleration = new Vector2(0,0.4f);           
            }
        }
        public void Attack(IPlayer mario)
        {
            if (!ifDead)
                mario.TakeDamage();

        }
        public void Update()
        {
            if (!start&&rectangle.X<Mygame.camera.cameraPositionX+800)
            {
                velocity = new Vector2(-1.5f, 0);
                start = true;
            }
            Sprite.Update();
            velocity += acceleration;
            rectangle = new Rectangle(rectangle.X + (int)velocity.X, rectangle.Y + (int)velocity.Y, rectangle.Width, rectangle.Height);
        }

        public void Draw(SpriteBatch sb, int worldPositionX, int worldPositionY)
        {
            
            Sprite.Draw(sb, new Vector2(rectangle.X - worldPositionX, rectangle.Y));
        }
    }
}
