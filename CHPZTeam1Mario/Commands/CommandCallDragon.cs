using CHPZTeam1Mario.Projectile;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Commands
{
    public class CommandCallDragon : ICommand
    {
        private SuperMario myGame;

        public CommandCallDragon(SuperMario game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.World.AddProjectile(new Dragon(new Vector2(myGame.Mario.Position.X, myGame.Mario.Position.Y-150),myGame.dragon));
        }
    }
}
