using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Commands
{
    public class CommandSkipSubtitle : ICommand
    {
        private SuperMario myGame;

        public CommandSkipSubtitle(SuperMario game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.World.Level.ifSkip = true;
            
        }
    }
}
