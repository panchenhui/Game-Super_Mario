using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Sprites.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.BlockClass
{
    public class Level1_4Magma3Class : IBlock
    {
        public ISprite Sprite { get; set; }

        public SuperMario Mygame { get; set; }

        public Rectangle rectangle { get; set; }

        public Level1_4Magma3Class(SuperMario game, Vector2 position)
        {
            this.Mygame = game;
            this.Sprite = new Level1_4MagmaSprite3(Mygame.blocks);
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, 0, 0);
        }

        public void Used()
        {
        }
        public void Shake()
        {

        }
        public void Update()
        {
            this.Sprite.Update();
        }

        public void Draw(SpriteBatch sb, int worldPositionX, int worldPositionY)
        {

            Sprite.Draw(sb, new Vector2(rectangle.X - worldPositionX, rectangle.Y));
        }
    }
}
