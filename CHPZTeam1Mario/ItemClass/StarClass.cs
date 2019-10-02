using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.MarioClass;
using CHPZTeam1Mario.Sprites.EmptyScreen;
using CHPZTeam1Mario.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.ItemClass
{
    public class StarClass : IItem
    {
        public ISprite Sprite { get; set; }

        public SuperMario Mygame { get; set; }

        public Rectangle rectangle { get; set; }
        private Vector2 velocity;
        private Vector2 acc;
        private int timer;

        public StarClass(SuperMario game,Vector2 position)
        {
            this.Mygame = game;
            this.Sprite = new StarSprite(Mygame.items);
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, 16, 16);
            acc = new Vector2(0.0f,0.2f);
            velocity = new Vector2(1.5f, -6.0f);
            timer = 0;
        }
        public void ChangeMovement(int i)
        {
            if (timer >= 36)
            {
                switch (i)
                {
                    case (int)Enum.DisableMovementType.None:

                        this.acc = new Vector2(0.0f, 0.2f);
                        break;
                    case (int)Enum.DisableMovementType.Up:

                        this.rectangle = new Rectangle(rectangle.X, rectangle.Y + 1, rectangle.Width, rectangle.Height);
                        break;
                    case (int)Enum.DisableMovementType.Down:
                        this.rectangle = new Rectangle(rectangle.X, (int)(rectangle.Y - 0.5f), rectangle.Width, rectangle.Height);
                        this.velocity = new Vector2(velocity.X, -5.0f);
                        break;
                    case (int)Enum.DisableMovementType.Left:
                        acc = new Vector2(0.0f, acc.Y);
                        this.ChangeDirection();
                        break;
                    case (int)Enum.DisableMovementType.Right:
                        acc = new Vector2(0.0f, acc.Y);
                        this.ChangeDirection();
                        break;
                    default:
                        break;
                }
            }
        }
        public void ChangeDirection()
        {
            if (velocity.X > 0.0)
            {
                velocity = new Vector2(-3.0f, velocity.Y);
            }
            else if (velocity.X < 0.0)
            {
                velocity = new Vector2(3.0f, velocity.Y);
            }
            else
            {
                velocity = new Vector2(0.0f, velocity.Y);
            }
        }
        public void Used()
        {
            Mygame.HUD.GetScore(1000);
            Mygame.HUD.ScoreDisplay(1000, new Vector2(rectangle.X, rectangle.Y));

            this.Sprite = new EmptyScreen(Mygame.items);
            Mygame.Mario = new StarMario(Mygame.Mario);
            this.rectangle = new Rectangle();
           
        }

        public void Update()
        {
            if (timer <36)
            {
                this.rectangle = new Rectangle(rectangle.X , rectangle.Y - 1, 16, 16);
                timer++;
            }
            else
            {
                velocity += acc;
                this.rectangle = new Rectangle(rectangle.X + (int)velocity.X, rectangle.Y + (int)velocity.Y, 32, 32);
            }
            Sprite.Update();
        }

        public void Draw(SpriteBatch sb, int worldPositionX, int worldPositionY)
        {
           
            Sprite.Draw(sb, new Vector2(rectangle.X - worldPositionX, rectangle.Y));
        }
    }
}
