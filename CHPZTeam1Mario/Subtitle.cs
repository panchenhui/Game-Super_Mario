using CHPZTeam1Mario.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario
{
    public class Subtitle
    {
        private int printSpeed = 5;
        private string wholeStr = "";
        private string strToPrint = "";
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private Color strColor;
        private int counter = 0;
        private int timer = 0;
        private SuperMario myGame;
        private ISprite myFrame;
        public bool ifDisappear { get; set; }
        private int disappearTimer = 0;

        private int dialogTimer = 0;
        private int dialogSpeed = 30;
        private bool dialogMode = false;
        public Subtitle(SuperMario game,SpriteBatch sb, ContentManager content,string path,Color color)
        {
            myGame = game;
            spriteBatch = sb;
            font= content.Load<SpriteFont>("MarioFont");
            strColor = color;
            StreamReader sr = new StreamReader(path, Encoding.Default);
            string line;
            myFrame = new DialogFrameSprite(game.dialogFrame);
            while ((line = sr.ReadLine()) != null)
            {
                wholeStr += line+"\n";
            }
            ifDisappear = false;
        }
        public Subtitle(SuperMario game, SpriteBatch sb, ContentManager content, string path, Color color,bool mode)
        {
            myGame = game;
            spriteBatch = sb;
            font = content.Load<SpriteFont>("MarioFont");
            strColor = color;
            StreamReader sr = new StreamReader(path, Encoding.Default);
            string line;
            myFrame = new DialogFrameSprite(game.dialogFrame);
            while ((line = sr.ReadLine()) != null)
            {
                wholeStr += line + "\n";
            }
            ifDisappear = false;
            dialogMode = mode;
        }
        public void Update()
        {

            timer++;
            if (timer > printSpeed)
            {
                timer = 0;
            }
            else if (timer == printSpeed)
            {
                if (!dialogMode)
                {
                    counter++;
                    if (counter >= wholeStr.Length)
                    {
                        counter = wholeStr.Length;
                    }
                    strToPrint = wholeStr.Substring(0, counter);
                }
                else
                {
                    counter = 1;
                    int index = wholeStr.IndexOf('\n');
                    dialogTimer++;
                    if (dialogTimer==1||dialogTimer % dialogSpeed == 0)
                    {
                        if (index > 0)
                            strToPrint = wholeStr.Substring(0, index);
                        wholeStr = wholeStr.Substring(index + 1);
                    }
                }
            }
            if (counter >= wholeStr.Length)
            {
                disappearTimer++;
                if (disappearTimer >= 80)
                {
                    ifDisappear = true;
                }
            }
        }

        public void Draw()
        {
            if (!ifDisappear)
            {
                myFrame.Draw(spriteBatch, new Vector2(100, 100));
                spriteBatch.Begin();
                spriteBatch.DrawString(font, strToPrint, new Vector2(120, 120), strColor);
                spriteBatch.End();
            }
        }

        public void Clear()
        {
            wholeStr = "";
            strToPrint = "";
        }
    }
}
