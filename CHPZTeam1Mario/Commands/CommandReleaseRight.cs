using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Commands
{
    public class CommandReleaseRight : ICommand
    {
        private SuperMario myGame;

        public CommandReleaseRight(SuperMario game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.Mario.RelsRight();
        }
    }
}
