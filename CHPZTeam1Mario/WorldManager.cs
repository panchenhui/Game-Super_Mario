using CHPZTeam1Mario.BackgroundClass;
using CHPZTeam1Mario.BlockClass;
using CHPZTeam1Mario.Blocks;
using CHPZTeam1Mario.Collision;
using CHPZTeam1Mario.EnemyClass;
using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.ItemClass;
using CHPZTeam1Mario.Level;
using CHPZTeam1Mario.Levels;
using CHPZTeam1Mario.Sprites;
using CHPZTeam1Mario.Sprites.Blocks;
using CHPZTeam1Mario.Sprites.Enemies;
using CHPZTeam1Mario.Sprites.Items;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario
{
    public class WorldManager
    {       
        public SuperMario Mygame;

        public ILevel Level;
        public bool clue1Note { get; set; }
        public bool clue2Flower { get; set; }
        public bool clue3 { get; set; }
        public WorldManager(SuperMario game)
        {
            Mygame = game;
            clue1Note=false;
            clue2Flower=false;
            clue3 = false;
            //Level = new LevelClass(Mygame, "Level.xml");
            Level = new InfoScreen(Mygame, "Content/Subtitle/introduction.txt","Level.xml");
        }
        public void Load()
        {
            Level.Load();
        }

        public void AddItem(IItem item)
        {
            Level.ItemList.Add(item);
        }

        public void AddProjectile(IProjectile projectile)
        {
            Level.ProjectileQueue.Enqueue(projectile);
        }

        public void Update()
        {
            Level.Update();

        }

        public void Draw(int worldPositionX, int worldPositionY)
        {
            Level.Draw(worldPositionX, worldPositionY);
        } 
    }
}
