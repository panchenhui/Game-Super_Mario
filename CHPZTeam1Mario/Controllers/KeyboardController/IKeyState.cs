using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Controllers.KeyboardController
{
    public interface IKeyState
    {
        Keys myKey { get; set; }
        ICommand myComd { get; set; }
        void Execute();

        string Type();

    }
}
