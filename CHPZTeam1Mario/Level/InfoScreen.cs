using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Levels;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Level
{
    public class InfoScreen : ILevel
    {
        public SuperMario Mygame { get; set; }
        public List<IItem> ItemList { get; set; }
        public List<IEnemy> EnemyList { get; set; }
        public List<IBlock> BlockList { get; set; }
        public List<IFire> FireList { get; set; }
        public List<IBackground> BackgroundList { get; set; }

        public Queue<IProjectile> ProjectileQueue { get; set; }
        public IBoss BossPr { get; set; }
        public bool ifSkip { get; set; }
        public LevelLoader loader;
        private Subtitle mySubtitle;
        private string nextLevel;
        private int endTimer = 0;
        public InfoScreen(SuperMario game, string path,string next)
        {
            
            this.Mygame = game;
            game.backgroundColor = Color.Black;
            mySubtitle = new Subtitle(game,game.spriteBatch,game.Content,path,Color.White);
            nextLevel = next;
            ifSkip = false;
        }
        public InfoScreen(SuperMario game, string path)
        {
            
            this.Mygame = game;
            game.backgroundColor = Color.Black;
            mySubtitle = new Subtitle(game, game.spriteBatch, game.Content, path, Color.White);
            nextLevel = "";
        }
        public void Load()
        {
            
        }

        public void Update()
        {
            
            Mygame.infoScreen = true;
            mySubtitle.Update();
            if (mySubtitle.ifDisappear == true||ifSkip)
            {
                if (!nextLevel.Equals(""))
                {
                    Mygame.World.Level = new LevelClass(Mygame, nextLevel);
                }
                else
                {
                    endTimer++;
                    if (endTimer == 100)
                    {
                        Mygame.Exit();
                    }
                }
            }
        }
        public void Draw(int worldPositionX, int WorldPositionY)
        {

            mySubtitle.Draw();
            
        }

        public void ReturnGround()
        {

        }
    }
}
