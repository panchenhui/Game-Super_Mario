using CHPZTeam1Mario.Princess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.Interfaces
{
    public interface ILevel
    {
        SuperMario Mygame { get; set; }
        List<IItem> ItemList { get; set; }
        List<IEnemy> EnemyList { get; set; }
        List<IBlock> BlockList { get; set; }
        List<IFire> FireList { get; set; }
        List<IBackground> BackgroundList { get; set; }
        Queue<IProjectile> ProjectileQueue { get; set; }
        bool ifSkip { get; set; }
        IBoss BossPr { get; set; }
        void Load();

        void Update();
        void Draw(int worldPositionX, int WorldPositionY);

        void ReturnGround();

    }
}
