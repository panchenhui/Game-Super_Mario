using CHPZTeam1Mario.Level;
using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Commands
{
    public class CommandGoToLevel1_4 : ICommand
    {

            private SuperMario myGame;

            public CommandGoToLevel1_4(SuperMario game)
            {
                myGame = game;
            }
            public void Execute()
            {
            myGame.backgroundColor = Color.Black;
            myGame.World.Level =new Level1_4(myGame,myGame.World.Level, "Level1-4.xml");
            myGame.Mario.Position = new Microsoft.Xna.Framework.Vector2(50,150);
            myGame.camera.disableCamera = false;
            myGame.HUD.Reset(4);
            
            }
        
    }
}
