using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Commands
{
    public class CommandReleaseUp : ICommand
    {
        private SuperMario myGame;

        public CommandReleaseUp(SuperMario game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.Mario.RelsUp();
        }
    }
}
