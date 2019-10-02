using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario
{
    public class Utility
    {
        public static int timer_mario_class = 0;
        public static int flasher_mario_class = 0;
        public static int reset_timer_mario_class = 0;
        public static int mario_width = 34;
        public static int mario_height = 32;

        public static int MarioFlashSpeed = 3;
        public static int BigMarioBecomgingSmallTimer = 100;
        public static float MarioLocationShifter = 0.1f;
        public static float MarioRunningAcc = 0.5f;
        public static float MarioFrictionAcc = 1.0f;

        public static float MarioStartingSpeed = 2.0f;


        public static float Physics_FallingAcc = 0.2f;
 
 
        public static float MarioMaxWalkSpeed = 5.0f;
        public static float MarioJumpingSpeed = 7.0f;
        public static float MarioMaxRunningSpeed = 7.0f;
        public static float MarioSlidingAcc = 5.0f;
        public static float MarioBounceSpeed = 5.0f;

        public static int timer_check_mario_class = 20;

        public static int position_limit_y = 480;
        public static int position_limit_x = 6534;

        public static int BossNormalAttackSpeed = 80;
        public static int BossNormalQuickAttackSpeed = 20;
        public static int BossMovementTimer = 200;
        public static float BossMoveSpeed = 5.0f;
        public static float PositionShifter = 0.5f;
        public static int JusticeCDTimer = 120;
        public static int FrozenFishCDTimer = 120;
    }
}
