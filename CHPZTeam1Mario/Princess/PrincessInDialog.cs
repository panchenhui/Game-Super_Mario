using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Level;
using CHPZTeam1Mario.MarioClass;
using CHPZTeam1Mario.Sprites.Princess;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Princess
{
    public class PrincessInDialog : IBoss
    {
        public SuperMario myGame { get; set; }
        public int health { get; set; }
        public Rectangle rectangle { get; set; }
        public ISprite mySprite { get; set; }
        public Vector2 acc { get; set; }
        public Vector2 velocity { get; set; }
        public bool ifDead { get; set; }

        private Subtitle myDialog;
        private bool GoodEnd;
        public PrincessInDialog(SuperMario game, Vector2 pos,bool ifGoodEnd)
        {
            myGame = game;
            mySprite = new BossPrincessSprite(myGame.princess);
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, mySprite.Width(), mySprite.Height());
            acc = new Vector2(0.0f, 0.2f);
            velocity = new Vector2(0.0f, 0.0f);
            health = 30;
            if (ifGoodEnd)
            {
                myDialog = new Subtitle(game, game.spriteBatch, game.Content, "Content/Subtitle/GoodEndDialog.txt",Color.White,true);
            }
            else
            {
                myDialog = new Subtitle(game, game.spriteBatch, game.Content, "Content/Subtitle/BadEndDialog.txt", Color.White,true);
            }
            ifDead = false;
            GoodEnd = ifGoodEnd;
        }
        public void ChangeMovement(int i)
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
                    this.acc = new Vector2(acc.X, 0.0f);
                    this.velocity = new Vector2(velocity.X, 0.0f);
                    break;
                case (int)Enum.DisableMovementType.Left:
                    acc = new Vector2(0.0f, acc.Y);
                    velocity = new Vector2(0.0f, velocity.Y);
                    break;
                case (int)Enum.DisableMovementType.Right:
                    acc = new Vector2(0.0f, acc.Y);
                    velocity = new Vector2(-0.0f, velocity.Y);
                    break;
                default:
                    break;
            }
        }

        public void Attack(IPlayer mario)
        {


        }



        public void TakeDamage()
        {
        }
        public void Update()
        {
            if (rectangle.X <= myGame.camera.cameraPositionX + 800)
            {
                myDialog.Update();
                Attack(myGame.Mario);
                velocity += acc;
                mySprite.Update();
                if (!ifDead)
                    rectangle = new Rectangle(rectangle.X + (int)velocity.X, rectangle.Y + (int)velocity.Y, rectangle.Width, rectangle.Height);
                if (myDialog.ifDisappear == true && GoodEnd)
                {
                    myGame.World.Level.BossPr = new BossPrincess(myGame, new Vector2(rectangle.X, rectangle.Y));
                    myGame.Mario.health = 30;
                    myGame.Mario = new FlowerEatMario(myGame.Mario);
                    myGame.HUD.firstToDisplay = myGame.HUD.HUDdisplay2;
                    myGame.HUD.secondTDisplay = myGame.HUD.SecondLine3;
                    myGame.HUD.myColor = Color.Yellow;
                }
                else if (myDialog.ifDisappear == true && !GoodEnd)
                {
                    myGame.World.Level = new InfoScreen(myGame, "Content/Subtitle/BadEnd.txt");
                }
            }
        }
        public void Draw(SpriteBatch sb, Vector2 vector)
        {
            if (rectangle.X <= myGame.camera.cameraPositionX + 800)
            {
                myDialog.Draw();
                if (!ifDead)
                {
                    mySprite.Draw(sb, new Vector2(rectangle.X - vector.X, rectangle.Y));
                }
            }
        }
    }
}
