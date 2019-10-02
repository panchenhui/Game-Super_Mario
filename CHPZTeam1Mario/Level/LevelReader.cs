using CHPZTeam1Mario.Blocks;
using CHPZTeam1Mario.EnemyClass;
using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.ItemClass;
using CHPZTeam1Mario.MarioClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace CHPZTeam1Mario.Level
{
    class LevelReader
    {
        static public GameLevel LoadLevelFromFile(String filename)
        {
            GameLevel level = null;
            filename = String.Concat("Content/", filename);
            using (StreamReader stream = new StreamReader(filename))
            {
                stream.ReadLine();
            }
            return level;
        }

        public void LoadLevel(StreamReader stream,SuperMario game)
        {
            List<IEnemy> enemies = new List<IEnemy>();
            List<IBlock> blocks = new List<IBlock>();
            List<IItem> items = new List<IItem>();
            Mario mario = null;


            String tag;

            stream.ReadLine(); //should be <level>
            while ((tag = stream.ReadLine()) != null && !tag.Equals("</level>"))
            {
                string[] words = tag.Split(' ');
                int? xpos = null;
                int? ypos = null;

                String type = "";
                for (int wordsCount = 1; wordsCount < words.Length; wordsCount++)
                {
                    if (words[wordsCount].Length >= 6)
                    {
                        if (words[wordsCount].Substring(0, 5).Equals("type="))
                        {
                            type = words[wordsCount].Substring(5).Trim('"').ToLower();
                        }
                        else if (words[wordsCount].Substring(0, 5).Equals("xpos="))
                        {
                            xpos = Int32.Parse(words[wordsCount].Substring(5).Trim('"'));
                        }
                        else if (words[wordsCount].Substring(0, 5).Equals("ypos="))
                        {
                            ypos = Int32.Parse(words[wordsCount].Substring(5).Trim('"'));
                        }
                    }
                }
                switch (type.Trim('"'))
                {
                    case "Goomba":
                        enemies.Add(new GoombaClass(game));
                        break;
                    case "Koopa":
                        enemies.Add(new KoopaClass(game));
                        break;
                    case "Brick":
                        //blocks.Add(new BrickClass(game));
                        break;
                    case "Coin":
                        items.Add(new CoinClass(game));
                        break;
                    case "Flower":
                        items.Add(new FlowerClass(game));
                        break;
                    case "GreenMushroom":
                        items.Add(new GreenMushroomClass(game));
                        break;
                    case "RedMushroom":
                        items.Add(new RedMushroomClass(game));
                        break;
                    case "Star":
                        items.Add(new StarClass(game));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}


