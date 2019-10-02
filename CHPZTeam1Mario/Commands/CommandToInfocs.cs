using CHPZTeam1Mario.Level;
using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Commands
{
    public class CommandToInfo : ICommand
    {

        private SuperMario myGame;

        public CommandToInfo(SuperMario game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.backgroundColor = Color.Black;
            myGame.World.Level = new Level1_4(myGame, myGame.World.Level, "Info.xml");
            myGame.World.Load();
            myGame.camera.disableCamera = false;
        }

    }
}
