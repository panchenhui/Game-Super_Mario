using CHPZTeam1Mario.BackgroundClass;
using CHPZTeam1Mario.BlockClass;
using CHPZTeam1Mario.Blocks;
using CHPZTeam1Mario.EnemyClass;
using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.ItemClass;
using CHPZTeam1Mario.Levels;
using CHPZTeam1Mario.MarioClass;
using CHPZTeam1Mario.Projectile;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CHPZTeam1Mario.Level
{
    public class LevelLoader
    {
        SuperMario game;
        public Vector2 position;
        public Enum.Itemtype type;


        public ILevel level;

        public LevelLoader(ILevel level, SuperMario game)
        {
            this.level = level;
            this.game = game;
        }

        public void Loader(string fileName)
        {

            XmlReader reader = XmlReader.Create(fileName);

            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "floorBlock"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new FloorBrickClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "stairBlock"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new StairBlockClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "questionBlock"))
                {

                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        string itemType = reader.GetAttribute("item");
                        if (itemType == "coin")
                        {
                            type = Enum.Itemtype.Coin;
                        }
                        else if (itemType == "flower")
                        {
                            type = Enum.Itemtype.Flower;
                        }
                        else if (itemType == "redMushroom")
                        {
                            type = Enum.Itemtype.RedMushroom;
                        }
                        else if (itemType == "greenMushroom")
                        {
                            type = Enum.Itemtype.GreenMushroom;
                        }
                        else if (itemType == "star") {
                            type = Enum.Itemtype.Star;
                        }
                    }
                    level.BlockList.Add(new QuestionBlockClass(game, position, type));


                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "brickWithItem"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        string itemType = reader.GetAttribute("item");
                        if (itemType == "coin")
                        {
                            type = Enum.Itemtype.Coin;
                        }
                        else if (itemType == "flower")
                        {
                            type = Enum.Itemtype.Flower;
                        }
                        else if (itemType == "redMushroom")
                        {
                            type = Enum.Itemtype.RedMushroom;
                        }
                        else if (itemType == "greenMushroom")
                        {
                            type = Enum.Itemtype.GreenMushroom;
                        }
                        else if (itemType == "star")
                        {
                            type = Enum.Itemtype.Star;
                        }
                        level.BlockList.Add(new BrickWithItemsClass(game, position,type));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "brick"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new BrickClass(game, position));
                    }
                }

                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "hiddenBlock"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new HiddenBlockClass(game, position));
                    }
                }

                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "usedBlock"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new UsedBrickClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "pipe"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new PipeClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "mediumPipe"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new MediumPipeClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "highPipe"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new HighPipeClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "penetrablePipe"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new PenetrablePipeClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "flagpole"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new FlagpoleClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "castle"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new CastleClass(game, position));
                    }
                }

                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "goomba"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.EnemyList.Add(new GoombaClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "koopa"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.EnemyList.Add(new KoopaClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "flower"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.ItemList.Add(new FlowerClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "coin"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.ItemList.Add(new CoinClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "redMushroom"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.ItemList.Add(new RedMushroomClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "greenMushroom"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.ItemList.Add(new GreenMushroomClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "star"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.ItemList.Add(new StarClass(game, position));
                    }

                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "cloud"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BackgroundList.Add(new CloudClass(game, position));
                    }

                }

                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "tripleCloud"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BackgroundList.Add(new TripleCloudsClass(game, position));
                    }

                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "bush"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BackgroundList.Add(new BushClass(game, position));
                    }

                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "smallBush"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BackgroundList.Add(new SmallBushClass(game, position));
                    }

                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "smallMountain"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BackgroundList.Add(new SmallMountainClass(game, position));
                    }

                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "bigMountain"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BackgroundList.Add(new BigMountainClass(game, position));
                    }

                }

                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "undergroundFloor"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new UndergroundFloorClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "undergroundBrick"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new UndergroundBrickClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "undergroundPipe"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new UndergroundPipeClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "undergroundPipe2"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new UndergroundPipe2Class(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "staticCoin"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.ItemList.Add(new StaticCoinClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "whiteBlock"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new Level1_4BlockClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "magma1"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new Level1_4MagmaClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "magma2"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new Level1_4Magma2Class(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "magma3"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new Level1_4Magma3Class(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "magma4"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new Level1_4Magma4Class(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "bridge"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new Level1_4Bridge1Class(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "bridge2"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new Level1_4Bridge2Class(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "slope"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new Level1_4SlopeClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "whiteUsedBlock"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new Level1_4UsedBlockClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "floatingBoard"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new Level1_4FloatingBoardClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "fireball"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.FireList.Add(new Level1_4FireballClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "upFire"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.FireList.Add(new Level1_4UpFireClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "fire"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.FireList.Add(new Level1_4FireClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "axe"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.ItemList.Add(new Level1_4AxeClass(game, position));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "bowser"))
                {
                    if (reader.HasAttributes)
                    {
                        position.X = Int32.Parse(reader.GetAttribute("x"));
                        position.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.EnemyList.Add(new BowserClass(game, position));
                    }
                }
            }
        }
    }
}