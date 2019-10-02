using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.MarioClass;
using CHPZTeam1Mario.Sprites.EmptyScreen;
using CHPZTeam1Mario.Sprites.Items;
using CHPZTeam1Mario.Sprites.MarioFire;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.ItemClass
{
    public class FlowerClass : IItem
    {
        public ISprite Sprite { get; set; }

        public SuperMario Mygame { get; set; }
        public Rectangle rectangle { get; set; }

        private Vector2 velosity;

        private int timer;

        public FlowerClass(SuperMario game,Vector2 position)
        {
            this.Mygame = game;
            this.Sprite = new FlowerSprite(Mygame.items);
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, 17, 18);
            velosity = new Vector2(0, -1);
            timer = 36;
        }
        public void ChangeMovement(int i)
        {

        }
        public void ChangeDirection()
        {

        }
        public void Used()
        {
            Mygame.HUD.GetScore(1000);
            Mygame.HUD.ScoreDisplay(1000, new Vector2(rectangle.X, rectangle.Y));

            this.Sprite = new EmptyScreen(Mygame.items);
            if (!(Mygame.Mario.State is FMLeftJumpFireSprite)&&
            !(Mygame.Mario.State is FMLeftStandFireSprite)&&
             !(Mygame.Mario.State is FMLeftWalkFireSprite)&&
             !(Mygame.Mario.State is FMRightJumpFireSprite)&&
             !(Mygame.Mario.State is FMRightStandFireSprite)&&
            !(Mygame.Mario.State is FMRightWalkFireSprite))
            {
                Mygame.Mario = new FlowerEatMario(Mygame.Mario);
                this.rectangle = new Rectangle();
                Sound.Instance.PowerUp();
            }else
            {
                this.rectangle = new Rectangle();
            }
          

        }

        public void Update()
        {
            if (timer > 0)
            {
                this.rectangle = new Rectangle(rectangle.X + (int)velosity.X, rectangle.Y + (int)velosity.Y, 17, 18);
                timer--;
            }
            Sprite.Update();
        }

        public void Draw(SpriteBatch sb, int worldPositionX, int worldPositionY)
        {
           
            Sprite.Draw(sb, new Vector2(rectangle.X - worldPositionX, rectangle.Y));
        }
    }
}
