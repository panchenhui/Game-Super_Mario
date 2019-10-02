using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Level;
using CHPZTeam1Mario.Projectile;
using CHPZTeam1Mario.Sprites.Princess;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Princess
{
    public class BossPrincess : IBoss
    {
        public SuperMario myGame { get; set; }
        public int health { get; set; }
        public Rectangle rectangle { get; set; }
        public ISprite mySprite { get; set; }
        public Vector2 acc { get; set; }
        public Vector2 velocity { get; set; }
        public bool ifDead { get; set; }
        private int skillCD = 0;
        private int nomAttackSpeed = Utility.BossNormalAttackSpeed;
        private int moveTimer = 0;
        public BossPrincess(SuperMario game,Vector2 pos)
        {
            myGame = game;
            mySprite = new BossPrincessSprite(myGame.princess);
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, mySprite.Width(), mySprite.Height());
            acc = new Vector2(0.0f, Utility.Physics_FallingAcc);
            velocity = new Vector2(0.0f, 0.0f);
            health = 30;
            ifDead = false;                        
        }
        public void ChangeMovement(int i)
        {
            switch (i)
            {
                case (int)Enum.DisableMovementType.None:

                    this.acc = new Vector2(0.0f, Utility.Physics_FallingAcc);
                    break;
                case (int)Enum.DisableMovementType.Up:

                    break;
                case (int)Enum.DisableMovementType.Down:
                    this.rectangle = new Rectangle(rectangle.X, (int)(rectangle.Y - Utility.PositionShifter), rectangle.Width, rectangle.Height);
                    this.acc = new Vector2(acc.X, 0.0f);
                    this.velocity = new Vector2(velocity.X, 0.0f);
                    break;
                case (int)Enum.DisableMovementType.Left:
                    acc = new Vector2(0.0f, acc.Y);
                    velocity = new Vector2(0.0f, velocity.Y);
                    break;
                case (int)Enum.DisableMovementType.Right:
                    acc = new Vector2(0.0f, acc.Y);
                    velocity = new Vector2(-0.0f, velocity.Y);
                    break;
                default:
                    break;
            }
        }

        private void NormalAttack()
        {
            Vector2 pos = new Vector2(rectangle.X, rectangle.Y);
            int direction = 1;
            if (rectangle.X < myGame.Mario.rectangle.X)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }
            myGame.World.AddProjectile(new JusticeFireBall(pos, mySprite.Texture, new Vector2(direction * 5.196f, -3.0f)));
            myGame.World.AddProjectile(new JusticeFireBall(pos, mySprite.Texture, new Vector2(direction * 3.0f, -5.196f)));
            myGame.World.AddProjectile(new JusticeFireBall(pos, mySprite.Texture, new Vector2(direction * 6.0f, 0.0f)));
            myGame.World.AddProjectile(new JusticeFireBall(pos, mySprite.Texture, new Vector2(direction * 3.0f, 5.196f)));
            myGame.World.AddProjectile(new JusticeFireBall(pos, mySprite.Texture, new Vector2(direction * 5.196f, 3.0f)));
        }
        public void Attack(IPlayer mario)
        {

            int skillNum = RandomSkill();
            switch (skillNum)
            {
                case 1:
                if (skillCD <= 0)
                {
                    if (myGame.World.Level.BossPr is BossPrincess && acc.Y == 0.0f)
                    {
                        Justice();
                    }
                        skillCD = Utility.JusticeCDTimer;
                        if (nomAttackSpeed < Utility.BossNormalQuickAttackSpeed)
                        {
                            nomAttackSpeed = Utility.BossNormalQuickAttackSpeed;
                        }
                    }
                    break;
                case 2:
                if (skillCD <= 0)
                {
                        FishShoal();
                        skillCD = Utility.FrozenFishCDTimer;
                        if (nomAttackSpeed < Utility.BossNormalQuickAttackSpeed)
                        {
                            nomAttackSpeed = Utility.BossNormalQuickAttackSpeed;
                        }  
                }
                    break;
                default:
                    if (moveTimer <= 0&&(rectangle.X<=myGame.camera.cameraPositionX+800))
                    {
                        MoveTowardMario(mario);
                        moveTimer = Utility.BossMovementTimer;
                    }

                    break;
                
            }
        }
        private void MoveTowardMario(IPlayer mario)
        {
            float ratio = (float)Math.Abs(mario.Position.X - rectangle.X) / 800.0f;
            if (mario.Position.X < rectangle.X)
            {
                velocity = new Vector2(-ratio * Utility.BossMoveSpeed, -Utility.BossMoveSpeed);
            }
            else
            {
                velocity = new Vector2(ratio * Utility.BossMoveSpeed, -Utility.BossMoveSpeed);
            }
        }
        private int RandomSkill()
        {
            int result = 1;
            Random r = new Random();
            int random = r.Next(1, 101);
            if (random <= 30)
            {
                result = 1;
            }
            else if(random<=40){
                result = 2;
            }
            else
            {
                result = 3;
            }
            return result;
        }

        private void Justice()
        {
            myGame.World.Level.BossPr=new BossPrincessWithJusticeSkill(this);
        }

        private void FishShoal()
        {
            myGame.World.Level.BossPr = new BossPrincessWithFrozenFish(this);
        }
        public void TakeDamage()
        {
            health--;
            if (health <= 0)
            {
                ifDead = true;
                rectangle = new Rectangle();
                myGame.World.Level = new InfoScreen(myGame,"Content/Subtitle/GoodEnd.txt");
            }
        }
        public void Update()
        {
            skillCD--;
            nomAttackSpeed--;
            moveTimer--;
            
            Attack(myGame.Mario);
            if (nomAttackSpeed == 0)
            {
                NormalAttack();
                nomAttackSpeed = Utility.BossNormalAttackSpeed;
            }

            velocity += acc;
            mySprite.Update();
            if(!ifDead)
                rectangle = new Rectangle(rectangle.X + (int)velocity.X, rectangle.Y + (int)velocity.Y, rectangle.Width, rectangle.Height);
        }
        public void Draw(SpriteBatch sb, Vector2 vector)
        {
            if(!ifDead)
            mySprite.Draw(sb,new Vector2(rectangle.X-vector.X,rectangle.Y));
        }
    }
}
