using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHPZTeam1Mario.MarioClass;

namespace CHPZTeam1Mario.Commands
{
    public class CommandBrickToDisappear : ICommand
    {
        private SuperMario myGame;

        public CommandBrickToDisappear(SuperMario game)
        {
            myGame = game;
        }
        public void Execute()
        {
        }
    }
}
