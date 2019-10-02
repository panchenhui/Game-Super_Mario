using CHPZTeam1Mario.Levels;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Commands
{
    public class CommandBackToGround : ICommand
    {
        private SuperMario myGame;

        public CommandBackToGround(SuperMario game)
        {
            myGame = game;
        }
        public void Execute()
        {

            myGame.backgroundColor = Color.CornflowerBlue;
            myGame.World.Level.ReturnGround();
            myGame.Mario.Position = new Microsoft.Xna.Framework.Vector2(5216, 250);
            myGame.camera.UpdateX((int)myGame.Mario.Position.X);
            myGame.camera.disableCamera = false;
        }
    }
}
