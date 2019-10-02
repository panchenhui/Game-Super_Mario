using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.Sprites.EmptyScreen;
using CHPZTeam1Mario.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHPZTeam1Mario.ItemClass
{
    public class MagicNoteClueClass : IItem
    {
        public ISprite Sprite { get; set; }

        public SuperMario Mygame { get; set; }
        public Rectangle rectangle { get; set; }


        private bool ifUsed = false;
        private Subtitle mySubtitle;
        public MagicNoteClueClass(SuperMario game, Vector2 position)
        {
            this.Mygame = game;
            this.Sprite = new MagicNoteSprite(Mygame.note);
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, Sprite.Width(),Sprite.Height());
            mySubtitle = new Subtitle(game, game.spriteBatch, game.Content, "Content/Subtitle/MagicNote.txt", Color.White);


        }
        public void ChangeMovement(int i)
        {

        }
        public void ChangeDirection()
        {

        }
        public void Used()
        {
            Mygame.HUD.GetScore(200);
            Mygame.HUD.GetCoin();
            Mygame.HUD.ScoreDisplay(200, new Vector2(rectangle.X, rectangle.Y));
            ifUsed = true;
            this.rectangle = new Rectangle();
            Mygame.World.clue1Note = true;

        }

        public void Update()
        {
            if(ifUsed)
                mySubtitle.Update();
            if (!ifUsed)
                Sprite.Update();
        }

        public void Draw(SpriteBatch sb, int worldPositionX, int worldPositionY)
        {
            if (ifUsed)
                mySubtitle.Draw();
            if (!ifUsed)
                Sprite.Draw(sb, new Vector2(rectangle.X - worldPositionX, rectangle.Y));
        }
    }
}
