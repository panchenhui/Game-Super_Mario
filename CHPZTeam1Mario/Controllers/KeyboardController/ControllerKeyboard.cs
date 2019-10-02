using CHPZTeam1Mario.Commands;
using CHPZTeam1Mario.Controllers.KeyboardController;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario
{
    public class ControllerKeyboard : IController
    {
        private List<IKeyState> KeyboardList;

        private SuperMario myGame;

        private Keys[] isPressed;
        private Keys[] wasPressed;
        private Keys[] newPressed;
        private Keys[] keepPressing;
        private Keys[] released;
        public ControllerKeyboard(SuperMario game)
        {
            myGame = game;
            KeyboardList = new List<IKeyState>();
            isPressed =new Keys[0];
            wasPressed=new Keys[0]; 
            newPressed = new Keys[0];
            keepPressing = new Keys[0];
            released = new Keys[0];

        }

        public void Initialize()
        {
            KeyboardList.Add(new IsPressedKey(Keys.U, new CommandBecomeBig(myGame)));
            KeyboardList.Add(new IsPressedKey(Keys.O, new CommandBecomeDead(myGame)));
            KeyboardList.Add(new IsPressedKey(Keys.Y, new CommandBecomeSmall(myGame)));
            KeyboardList.Add(new IsPressedKey(Keys.I, new CommandBecomeFire(myGame)));
            KeyboardList.Add(new IsPressedKey(Keys.Z, new CommandQuestionToUsed(myGame)));
            KeyboardList.Add(new IsPressedKey(Keys.X, new CommandBrickToDisappear(myGame)));
            KeyboardList.Add(new IsPressedKey(Keys.C, new CommandHiddenToUsed(myGame)));
            KeyboardList.Add(new IsPressedKey(Keys.R, new CommandReset(myGame)));
            KeyboardList.Add(new IsPressedKey(Keys.Space, new CommandAccelerate(myGame)));

            KeyboardList.Add(new IsPressedKey(Keys.Right, new CommandRight(myGame)));
            KeyboardList.Add(new IsPressedKey(Keys.Left, new CommandLeft(myGame)));
            KeyboardList.Add(new IsPressedKey(Keys.Up, new CommandUp(myGame)));
            KeyboardList.Add(new IsPressedKey(Keys.Down, new CommandDown(myGame)));
            KeyboardList.Add(new IsPressedKey(Keys.A, new CommandLeft(myGame)));
            KeyboardList.Add(new IsPressedKey(Keys.W, new CommandUp(myGame)));
            KeyboardList.Add(new IsPressedKey(Keys.D, new CommandRight(myGame)));
            KeyboardList.Add(new IsPressedKey(Keys.S, new CommandDown(myGame)));
            

            KeyboardList.Add(new ReleasedKey(Keys.Right, new CommandReleaseRight(myGame)));
            KeyboardList.Add(new ReleasedKey(Keys.D, new CommandReleaseRight(myGame)));
            KeyboardList.Add(new ReleasedKey(Keys.Left, new CommandReleaseLeft(myGame)));
            KeyboardList.Add(new ReleasedKey(Keys.A, new CommandReleaseLeft(myGame)));
            KeyboardList.Add(new ReleasedKey(Keys.Down, new CommandReleaseDown(myGame)));
            KeyboardList.Add(new ReleasedKey(Keys.S, new CommandReleaseDown(myGame)));
            KeyboardList.Add(new ReleasedKey(Keys.Up, new CommandReleaseUp(myGame)));
            KeyboardList.Add(new ReleasedKey(Keys.W, new CommandReleaseUp(myGame)));
            KeyboardList.Add(new ReleasedKey(Keys.Space, new CommandRelsAccelerate(myGame)));
            KeyboardList.Add(new ReleasedKey(Keys.P, new CommandPause(myGame)));
            KeyboardList.Add(new ReleasedKey(Keys.N, new CommandGoToUnderground(myGame)));
            KeyboardList.Add(new ReleasedKey(Keys.M, new CommandBackToGround(myGame)));
            KeyboardList.Add(new ReleasedKey(Keys.L, new CommandGoToLevel1_4(myGame)));
            KeyboardList.Add(new ReleasedKey(Keys.B, new CommandToInfo(myGame)));
            KeyboardList.Add(new ReleasedKey(Keys.Q, new CommandCallDragon(myGame)));
            KeyboardList.Add(new ReleasedKey(Keys.K, new CommandSkipSubtitle(myGame)));

            KeyboardList.Add(new KeepPressingKey(Keys.Up, new CommandUp(myGame)));

        }

        private void UpdateKeyState()
        {
            wasPressed = isPressed;
            isPressed = Keyboard.GetState().GetPressedKeys();
            newPressed = isPressed.Except(wasPressed).ToArray();
            keepPressing = isPressed.Intersect(wasPressed).ToArray();
            released = wasPressed.Except(isPressed).ToArray();

        }
        public void Update()
        {

            UpdateKeyState();
            if (!myGame.ifPause)
            {
                foreach (Keys k in isPressed)
                {
                    foreach (IKeyState isP in KeyboardList)
                        if (isP.Type().Equals("IsPressedKey"))
                            if (isP.myKey.Equals(k))
                                isP.Execute();
                }
                foreach (Keys k in released)
                {
                    foreach (IKeyState isP in KeyboardList)
                        if (isP.Type().Equals("ReleasedKey"))
                            if (isP.myKey.Equals(k))
                                isP.Execute();
                }
                foreach (Keys k in keepPressing)
                {
                    foreach (IKeyState isP in KeyboardList)
                        if (isP.Type().Equals("KeepPressingKey"))
                            if (isP.myKey.Equals(k))
                                isP.Execute();
                }
                foreach (Keys k in newPressed)
                {
                    foreach (IKeyState isP in KeyboardList)
                        if (isP.Type().Equals("NewPressedKey"))
                            if (isP.myKey.Equals(k))
                                isP.Execute();
                }
            }
            else
            {
                foreach (Keys key in released)
                {
                    if (key.Equals(Keys.P)){
                        foreach (IKeyState isP in KeyboardList)
                        {
                            if (isP.Type().Equals("ReleasedKey"))
                                if (isP.myKey.Equals(key))
                                {
                                    isP.Execute();
                                    return;
                                }
                        }
                    }
                }
            }

        }
    }
}
