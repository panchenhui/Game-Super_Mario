using CHPZTeam1Mario.Sprites.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Commands
{
    class CommandHitQuestionBrick:ICommand
    {
        private Game1 myGame;

        public CommandHitQuestionBrick(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.blockQuestion = new UsedBrickSprite(myGame);
        }
    }
}
