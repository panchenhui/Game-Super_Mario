using CHPZTeam1Mario.Collision;
using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Princess;
using CHPZTeam1Mario.Projectile;
using CHPZTeam1Mario.Sprites.Projectile;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Level
{
    public class Level1_4 : ILevel
    {
        public SuperMario Mygame { get; set; }
        public List<IItem> ItemList { get; set; }
        public List<IEnemy> EnemyList { get; set; }
        public List<IBlock> BlockList { get; set; }
        public List<IFire> FireList { get; set; }
        public List<IBackground> BackgroundList { get; set; }
        public Queue<IProjectile> ProjectileQueue { get; set; }
        public LevelLoader loader;
        private int count = 0;
        public bool ifSkip { get; set; }
        private string myFileName;
        public IBoss BossPr { get; set; }
        public Level1_4(SuperMario game, ILevel level, string fileName)
        {
            this.Mygame = game;
            ProjectileQueue = new Queue<IProjectile>();
            ItemList = new List<IItem>();
            EnemyList = new List<IEnemy>();
            BlockList = new List<IBlock>();
            FireList = new List<IFire>();
            BackgroundList = new List<IBackground>();
            bool ifGoodEnd = game.World.clue1Note && game.World.clue2Flower;

            BossPr = new PrincessInDialog(game, new Vector2(4900, 254),ifGoodEnd);
           
            this.loader = new LevelLoader(this, game);
            myFileName = fileName;
            ifSkip = false;
            Mygame.camera.SetPositionZero();
            Load();
            Sound.Instance.StopTheme();
            Sound.Instance.StartTheme();
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
            foreach (IFire item in FireList)
            {
                item.Update();

            }
            count++;
            Queue<IProjectile> tempQueue = new Queue<IProjectile>();
            while (ProjectileQueue.Count > 0)
            {
                IProjectile temp = ProjectileQueue.Dequeue();
                bool checkIfOut = (temp.position.X < Mygame.camera.cameraPositionX ||
                    temp.position.X > Mygame.camera.cameraPositionX + 800 || temp.position.Y < 0 || temp.position.Y > 480);
                if ((temp.rectangle.Height == 0 && count == 10)|| checkIfOut)
                {
                }
                else
                {
                    temp.Update();
                    tempQueue.Enqueue(temp);
                }

            }
            if (count == 10)
                count = 0;
            ProjectileQueue = tempQueue;

            foreach (IBackground background in BackgroundList)
            {
                background.Update();

            }
            BossPr.Update();
            CollisionDetector.Update(this);
            ECollisionDetector.Update(this);
            FBCollisionDetector.Update(this);
            ICollisionDetector.Update(this);
            BossPrincessCollisionDetector.Update(this);
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
            
            foreach (IFire fire in FireList)
            {
                fire.Draw(Mygame.spriteBatch, worldPositionX, worldPositionX);
            }
            BossPr.Draw(Mygame.spriteBatch, new Vector2(worldPositionX, worldPositionX));
        }
        public void ReturnGround()
        {

        }
    }
}
