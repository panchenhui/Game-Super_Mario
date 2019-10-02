using CHPZTeam1Mario.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using CHPZTeam1Mario.Sprites.Items;
using CHPZTeam1Mario.MarioClass;

namespace CHPZTeam1Mario.BlockClass
{
    public class FlagpoleClass : IBlock
    {
        public ISprite Sprite { get; set; }

        public SuperMario Mygame { get; set; }

        public Rectangle rectangle { get; set; }

        private Rectangle drawRectangle;

        private bool used = false;

        public FlagpoleClass(SuperMario game, Vector2 position)
        {
            this.Mygame = game;
            this.Sprite = new FlagSprite(Mygame.pipes);
            this.rectangle = new Rectangle((int)position.X + 32, (int)position.Y, 4, 400);
            drawRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
        }
        public void Shake()
        {

        }
        public void Used()
        {
            if (!used)
            {
                Sprite = new FlagMotionSprite(Mygame.pipes);
                used = true;
                Mygame.Mario = new FinishMario(Mygame.Mario);
                int height = Mygame.Mario.rectangle.Y;
                if(height < 78)
                {
                    Mygame.HUD.GetScore(5000);
                    Mygame.HUD.ScoreDisplay(5000, new Vector2(drawRectangle.X, 200));
                }else if (height >= 78 && height < 218)
                {
                    Mygame.HUD.GetScore(2000);
                    Mygame.HUD.ScoreDisplay(2000, new Vector2(drawRectangle.X, 200));
                }else if (height >= 218 && height < 368)
                {
                    Mygame.HUD.GetScore(500);
                    Mygame.HUD.ScoreDisplay(500, new Vector2(drawRectangle.X, 200));
                }
                else
                {
                    Mygame.HUD.GetScore(100);
                    Mygame.HUD.ScoreDisplay(100, new Vector2(drawRectangle.X, 200));
                }
                Mygame.HUD.TimeToScore();
            }
        }

        public void Update()
        {
            this.Sprite.Update();
        }

        public void Draw(SpriteBatch sb, int worldPositionX, int worldPositionY)
        {

            Sprite.Draw(sb, new Vector2(drawRectangle.X - worldPositionX, drawRectangle.Y));
        }
    }
}
