using CHPZTeam1Mario.Level;
using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Commands
{
    public class CommandGoToUnderground : ICommand
    {

            private SuperMario myGame;

            public CommandGoToUnderground(SuperMario game)
            {
                myGame = game;
            }
            public void Execute()
            {
            myGame.backgroundColor = Color.Black;
            myGame.World.Level =new UnderWorld(myGame,myGame.World.Level, "UndergroundWorld.xml");

            myGame.Mario.Position = new Microsoft.Xna.Framework.Vector2(50,50);
            myGame.camera.disableCamera = true;
            }
        
    }
}
