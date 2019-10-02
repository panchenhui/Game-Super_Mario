using CHPZTeam1Mario.Collision;
using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.ItemClass;
using CHPZTeam1Mario.Princess;
using CHPZTeam1Mario.Sprites.Projectile;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Level
{
    public class UnderWorld : ILevel
    {
        public SuperMario Mygame { get; set; }
        public List<IItem> ItemList { get; set; }
        public List<IEnemy> EnemyList { get; set; }
        public List<IBlock> BlockList { get; set; }
        public List<IBackground> BackgroundList { get; set; }
        public List<IFire> FireList { get; set; }
        public Queue<IProjectile> ProjectileQueue { get; set; }
        public LevelLoader loader;
        private int count = 0;
        private ILevel decoratedLevel;
        private string myFileName;
        public bool ifSkip { get; set; }
        public IBoss BossPr { get; set; }
        public UnderWorld(SuperMario game, ILevel level, string fileName)
        {
            this.Mygame = game;
            ProjectileQueue = new Queue<IProjectile>();
            ItemList = new List<IItem>();
            ItemList.Add(new MagicNoteClueClass(game,new Vector2(680,350-48)));
            EnemyList = new List<IEnemy>();
            BlockList = new List<IBlock>();
            FireList = new List<IFire>();
            BackgroundList = new List<IBackground>();
            this.loader = new LevelLoader(this, game);
            myFileName = fileName;
            decoratedLevel = level;
            Mygame.camera.SetPositionZero();
            Load();
            ifSkip = false;
        }
        public void Load()
        {
            this.loader.Loader(myFileName);
        }

        public void Update()
        {
            foreach (IEnemy enemy in EnemyList)
            {
                enemy.Update();
            }
            foreach (IBlock block in BlockList)
            {
                block.Update();
            }
            foreach (IItem item in ItemList)
            {
                item.Update();
            }
            foreach (IFire fire in FireList)
            {
                fire.Update();
            }
            count++;
            Queue<IProjectile> tempQueue = new Queue<IProjectile>();
            while (ProjectileQueue.Count > 0)
            {
                IProjectile temp = ProjectileQueue.Dequeue();
                if (temp.mySprite is MarioFireBallBoomSprite && count == 50)
                {
                }
                else
                {
                    temp.Update();
                    tempQueue.Enqueue(temp);
                }

            }
            if (count == 50)
                count = 0;
            ProjectileQueue = tempQueue;

            foreach (IBackground background in BackgroundList)
            {
                background.Update();

            }
            CollisionDetector.Update(this);
            ECollisionDetector.Update(this);
            FBCollisionDetector.Update(this);
            ICollisionDetector.Update(this);
        }
        public void Draw(int worldPositionX, int WorldPositionY)
        {
            foreach (IBackground background in BackgroundList)
            {
                background.Draw(Mygame.spriteBatch, worldPositionX, worldPositionX);
            }
            foreach (IItem item in ItemList)
            {
                item.Draw(Mygame.spriteBatch, worldPositionX, worldPositionX);
            }
            foreach (IBlock block in BlockList)
            {
                block.Draw(Mygame.spriteBatch, worldPositionX, worldPositionX);
            }
            foreach (IProjectile projectile in ProjectileQueue)
            {
                projectile.Draw(Mygame.spriteBatch, worldPositionX, worldPositionX);

            }
            foreach (IEnemy enemy in EnemyList)
            {
                enemy.Draw(Mygame.spriteBatch, worldPositionX, worldPositionX);
            }
        }

        public void ReturnGround()
        {
            Mygame.World.Level = decoratedLevel;
        }
    }
}
