using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Controllers.KeyboardController
{
    public class IsPressedKey : IKeyState
    {
        public Keys myKey { get; set; }
        public ICommand myComd { get; set; }
        public IsPressedKey(Keys key, ICommand comd)
        {
            myKey = key;
            myComd = comd;
        }

        public void Execute()
        {
            myComd.Execute();
        }
        public string Type()
        {
            return "IsPressedKey";
        }
    }
}
