using CHPZTeam1Mario.Blocks;
using CHPZTeam1Mario.EnemyClass;
using CHPZTeam1Mario.ItemClass;
using CHPZTeam1Mario.MarioClass;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHPZTeam1Mario.Levels;
using CHPZTeam1Mario.Level;

namespace CHPZTeam1Mario.Commands
{
    public class CommandReset :ICommand
    {
        private SuperMario myGame;
        public CommandReset(SuperMario game)
        {
            myGame = game;
        }
        public void Execute()
        {
            if (myGame.World.Level is LevelClass)
            {
                myGame.Mario = new Mario(myGame, new Microsoft.Xna.Framework.Vector2(50, 150));
                myGame.World.Level = new LevelClass(myGame,"Level.xml");
                myGame.camera.cameraPositionX = 0;
                myGame.HUD.Reset(1);
                Sound.Instance.StartTheme();
                myGame.backgroundColor = Color.CornflowerBlue;
                myGame.camera.disableCamera = false;
            }
            else if (myGame.World.Level is Level1_4)
            {
                myGame.backgroundColor = Color.Black;
                myGame.World.Level = new Level1_4(myGame, myGame.World.Level, "Level1-4.xml");
                myGame.Mario = new Mario(myGame, new Microsoft.Xna.Framework.Vector2(50, 150));
                myGame.camera.disableCamera = false;
                myGame.camera.cameraPositionX = 0;
                Sound.Instance.StartTheme();
                myGame.HUD.Reset(4);
            }
        }
    }
}
