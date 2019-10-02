using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;

namespace CHPZTeam1Mario
{
    public class Sound
    {
        private Song theme;
        private Song worldClear;
        private SoundEffect starMario;
        private SoundEffectInstance starMarioInstance;
        private SoundEffect oneUp;
        private SoundEffect breakBlock;
        private SoundEffect coin;
        private SoundEffect fireBall;
        private SoundEffect fireWorks;
        private SoundEffect flagpole;
        private SoundEffect gameOver;
        private SoundEffect jump;
        private SoundEffect kick;
        private SoundEffect marioDie;
        private SoundEffect pause;
        private SoundEffect powerUp;
        private SoundEffect powerUpAppears;
        private SoundEffect stomp;
        private SoundEffect warning;
        private SoundEffect takeDamage;
        private SoundEffect dead;
        private SoundEffect justice;
        private SoundEffect freeze;
        private SoundEffect bowserFireball;
        private SoundEffect dragon;
        private static Sound instance = new Sound();
        public static Sound Instance
        {
            get
            {
                return instance;
            }
        }

        private Sound()
        {
        }

        public void LoadSounds(ContentManager Content)
        {
            worldClear = Content.Load<Song>("Sounds/WorldClear");
            theme = Content.Load<Song>("Sounds/NarutoMainTheme");           
            starMario = Content.Load <SoundEffect>("Sounds/starman");
            starMarioInstance = starMario.CreateInstance();
            oneUp = Content.Load<SoundEffect>("Sounds/smb_1-up");
            breakBlock = Content.Load<SoundEffect>("Sounds/smb_breakblock");
            coin = Content.Load<SoundEffect>("Sounds/smb_coin");
            fireBall = Content.Load<SoundEffect>("Sounds/smb_fireball");
            fireWorks = Content.Load<SoundEffect>("Sounds/smb_fireworks");
            flagpole = Content.Load<SoundEffect>("Sounds/smb_flagpole");
            gameOver = Content.Load<SoundEffect>("Sounds/smb_gameover");
            jump = Content.Load<SoundEffect>("Sounds/smb_jump-small");
            kick = Content.Load<SoundEffect>("Sounds/smb_kick");
            marioDie = Content.Load<SoundEffect>("Sounds/smb_mariodie");
            pause = Content.Load<SoundEffect>("Sounds/smb_pause");
            powerUp = Content.Load<SoundEffect>("Sounds/smb_powerup");
            stomp = Content.Load<SoundEffect>("Sounds/smb_stomp");
            warning = Content.Load<SoundEffect>("Sounds/smb_warning");
            powerUpAppears = Content.Load<SoundEffect>("Sounds/smb_powerup_appears");
            takeDamage = Content.Load<SoundEffect>("Sounds/smb_vine");
            dead = Content.Load<SoundEffect>("Sounds/smb_mariodie");
            justice= Content.Load<SoundEffect>("Sounds/justice");
            freeze= Content.Load<SoundEffect>("Sounds/freeze");
            bowserFireball = Content.Load<SoundEffect>("Sounds/smb_bowserfire");
            dragon= Content.Load<SoundEffect>("Sounds/jap");
        }

        public void Dragon()
        {
            dragon.Play();

        }
        public void Freeze()
        {
            freeze.Play();
        }
        public void Justice()
        {
            justice.Play();

        }
        public void StartTheme()
        {
            MediaPlayer.Play(theme);
            MediaPlayer.IsRepeating = true;

        }
        public void WorldClear()
        {
            MediaPlayer.Play(worldClear);
            MediaPlayer.IsRepeating = false;
        }
        public void StopTheme()
        {
            MediaPlayer.Stop();
        }

        public void PauseTheme()
        {
            MediaPlayer.Pause();
        }

        public void ResumeTheme()
        {
            if(MediaPlayer.State==MediaState.Paused)
                MediaPlayer.Resume();
        }
        public void StarMario()
        {
            starMarioInstance.IsLooped = true;
            starMarioInstance.Play();
            MediaPlayer.Pause();
        }

        public void EndStarMario()
        {
            starMarioInstance.Stop();
            MediaPlayer.Resume();
        }


        public void OneUp()
        {
            oneUp.Play();
        }
        public void BreakBlock()
        {
            breakBlock.Play();
        }
        public void Coin()
        {
            coin.Play();
        }
        public void FireBall()
        {
            fireBall.Play();
        }
        public void FireWorks()
        {
            fireWorks.Play();
        }
        public void GameOver()
        {
            gameOver.Play();
        }
        public void Jump()
        {
            jump.Play();
        }
        public void Kick()
        {
            kick.Play();
        }
        public void MarioDie()
        {
            marioDie.Play();
        }
        public void Pause()
        {
            pause.Play();
        }
        public void PowerUp()
        {
            powerUp.Play();
        }
        public void Stomp()
        {
            stomp.Play();
        }
        public void Warning()
        {
            warning.Play();
        }
        public void PowerupAppears()
        {
            powerUpAppears.Play();
        }
        public void Flagpole()
        {
            flagpole.Play();
        }
        public void TakeDamage()
        {
            takeDamage.Play();
        }
        public void Dead()
        {
            dead.Play();
        }
        public void BowserFire()
        {
            bowserFireball.Play();
        }


    }
}
