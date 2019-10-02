using CHPZTeam1Mario.Blocks;
using CHPZTeam1Mario.Commands;
using CHPZTeam1Mario.Interfaces;
using CHPZTeam1Mario.MarioClass;
using CHPZTeam1Mario.Controllers.KeyboardController;
using CHPZTeam1Mario.Sprites.Blocks;
using CHPZTeam1Mario.Sprites.Enemies;
using CHPZTeam1Mario.Sprites.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CHPZTeam1Mario.Levels;
using CHPZTeam1Mario.States;
using CHPZTeam1Mario.Sprites.Princess;
using CHPZTeam1Mario.Sprites.Projectile;
using CHPZTeam1Mario.Projectile;

namespace CHPZTeam1Mario
{
    public class SuperMario : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public Texture2D texture;
        public Texture2D enemies;
        public Texture2D items;
        public Texture2D blocks;
        public Texture2D pipes;
        public Texture2D fragementBrick;
        public Texture2D princess;
        public Texture2D note;
        public Texture2D dialogFrame;
        public Texture2D dragon;

        public Camera camera;
        public IPlayer Mario;
        public WorldManager World;

        public HUDClass HUD;
        public bool ifPause = false;
        public bool infoScreen { get; set; }
        public Color backgroundColor = Color.CornflowerBlue;

        private IController keyboardController;
        public SuperMario()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            infoScreen = false;           
        }

        protected override void Initialize()
        {
            keyboardController = new ControllerKeyboard(this);
            keyboardController.Initialize();          
            camera = new Camera();
            base.Initialize();           
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("mario1");
            enemies = Content.Load<Texture2D>("enemies");            
            items = Content.Load<Texture2D>("items");
            blocks = Content.Load<Texture2D>("smbSprites");
            pipes = Content.Load<Texture2D>("smb1_scenery_sprites");
            fragementBrick = Content.Load<Texture2D>("tiles");
            princess = Content.Load<Texture2D>("Mario2");
            note = Content.Load<Texture2D>("note");
            dialogFrame=Content.Load<Texture2D>("frame"); 
            dragon= Content.Load<Texture2D>("dragon");
            HUD = new HUDClass(this,spriteBatch, Content,items);

            Sound.Instance.LoadSounds(Content);
            Sound.Instance.StartTheme();
            Mario = new Mario(this, new Vector2(50, 150));
            World = new WorldManager(this);

        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.K))
            {
                ICommand skip = new CommandSkipSubtitle(this);
                skip.Execute();
            }
                
            if (!infoScreen)
            {
                keyboardController.Update();
                if (!ifPause)
                {
                    Sound.Instance.ResumeTheme();

                    Mario.Update();
                    camera.UpdateX((int)Mario.Position.X);
                    World.Update();
                    HUD.Update();

                    
                }
                else
                {
                    Sound.Instance.PauseTheme();
                }
                if (Mario.State is SMDeadState)
                {
                    camera.disableCamera = true;
                }
            }
            else
            {
                World.Update();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColor);

            

            World.Draw(camera.cameraPositionX,camera.cameraPositionY);
            Mario.Draw(spriteBatch,new Vector2(camera.cameraPositionX,camera.cameraPositionY));
            HUD.Draw(new Vector2(camera.cameraPositionX, camera.cameraPositionY));
            base.Draw(gameTime);
        }
    }
}
