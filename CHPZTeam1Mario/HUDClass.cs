using CHPZTeam1Mario.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario
{
    public class HUDClass
    {
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private Vector2 pos;
        private Vector2 displayPos;
        private Vector2 displayVelocity;
        private SuperMario myGame;
        public string HUDdisplay;
        public string SecondLine;
        public string HUDdisplay2;
        public string SecondLine2;
        public string SecondLine3;
        public string firstToDisplay;
        public string secondTDisplay;
        public Color myColor;
        private string display;
        private int Score;
        private int Coin;
        private int Time;
        private ISprite coin;
        private int health = 0;
        private int counter;
        private int displayTime=0;
        private const int posX = 400;
        private const int poxY = 20;

        public HUDClass(SuperMario game,SpriteBatch sb, ContentManager content,Texture2D items)
        {
            myGame = game;
            spriteBatch = sb;
            font = content.Load<SpriteFont>("MarioFont");
            pos = new Vector2(posX,poxY);
            displayPos = new Vector2();
            displayVelocity = new Vector2(0, -2);
            HUDdisplay = "MARIO                                  WORLD             TIME";
           HUDdisplay2 = "MARIO                                  WORLD             Health";
            coin = new CoinSprite(items);
            myColor = Color.White;
            Score = 0;
            Coin = 0;
            Time = 400;
            SecondLine = FormatToString(Score, 6) + "             x" + FormatToString(Coin, 2) + "                   1-1                  " + FormatToString(Time, 3);
           SecondLine2 = FormatToString(Score, 6) + "             x" + FormatToString(Coin, 2) + "                   1-4                  " + FormatToString(Time, 3);
           SecondLine3 = FormatToString(Score, 6) + "             x" + FormatToString(Coin, 2) + "                   1-4                  " + FormatToString(health, 3);
            firstToDisplay = HUDdisplay;
            secondTDisplay = SecondLine;
        }

        public void Reset(int i)
        {
            Score = 0;
            Coin = 0;
            Time = 400;
            switch (i)
            {
                case 1:
                    firstToDisplay = HUDdisplay;
                    secondTDisplay = SecondLine;
                    myColor = Color.White;
                    break;
                case 4:
                    firstToDisplay = HUDdisplay;
                    secondTDisplay = SecondLine2;
                    myColor = Color.Yellow;
                    break;
                default:
                    break;
            }
        }

        public void Update()
        {
            counter++;
            if (counter == 60)
            {
                counter = 0;
                if (Time > 0)
                {
                    Time--;
                }
            }

            if (displayTime > 0)
            {
                displayTime--;
                displayPos += displayVelocity;
            }

            coin.Update();
            int updateStr = 1;
            if (secondTDisplay.Equals(SecondLine2))
            {
                updateStr = 2;
            }
            else if (secondTDisplay.Equals(SecondLine3))
            {
                updateStr = 3;
            }
            SecondLine = FormatToString(Score,6) + "             x" + FormatToString(Coin, 2) + "                   1-1                  " + FormatToString(Time, 3);
            if (myGame.Mario.health > 0)
            {
                health = myGame.Mario.health;
            }
            else
            {
                health = 0;
            }
            SecondLine2 = FormatToString(Score, 6) + "             x" + FormatToString(Coin, 2) + "                   1-4                  " + FormatToString(Time, 3);
            SecondLine3 = FormatToString(Score, 6) + "             x" + FormatToString(Coin, 2) + "                   1-4                  " + FormatToString(health, 3);
            switch (updateStr)
            {
                case 1:
                    secondTDisplay = SecondLine;
                    break;
                case 2:
                    secondTDisplay = SecondLine2;
                    break;
                case 3:
                    secondTDisplay = SecondLine3;
                    break;
                default:
                    break;
            }
        }

        public void TimeToScore()
        {
            Score = Score + Time * 50;
            Time = 0;
        }

        public void GetScore(int score)
        {
            Score += score;
        }

        public void ScoreDisplay(int score,Vector2 pos)
        {
            display = score.ToString();
            displayPos = pos;
            displayTime = 45;
        }

        public void GetCoin() {
            Coin += 1;
        }

        public string FormatToString(int Score,int digit) {
            string str = "";
            if (Score != 0)
            {
                for (int i = 0; i < digit; i++)
                {
                    if (Score >= (Math.Pow(10, i)))
                    {
                        str = "";
                        for (int j = digit - i - 1; j > 0; j--)
                        {
                            str += "0";
                        }
                        str += Score;
                    }
                }
            }
            else
            {
                for(int i = 0; i < digit; i++)
                {
                    str += "0";
                }
            }

            return str;
        }

        public void Draw(Vector2 camera)
        {
            Vector2 FontOrigin = font.MeasureString(HUDdisplay)/2;

            

            spriteBatch.Begin();
            spriteBatch.DrawString(font, firstToDisplay, pos,
                myColor, 0, FontOrigin, new Vector2(2, 2), SpriteEffects.None, 0.5f);
            if (displayTime > 0)
            {
                Vector2 displayOrigin = font.MeasureString(display)/2;
                spriteBatch.DrawString(font, display, displayPos-camera, Color.White, 0, displayOrigin, new Vector2(2, 2), SpriteEffects.None, 0.5f);
            }
            spriteBatch.DrawString(font, secondTDisplay, pos+(new Vector2(0,30)), myColor, 0, FontOrigin, new Vector2(2, 2), SpriteEffects.None, 0.5f);
            spriteBatch.End();
            coin.Draw(spriteBatch, new Vector2(260,30));
        }

        public void RecordScore()
        {

        }
    }
}
