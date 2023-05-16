using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WonkmyLibs;

namespace WonkmyGame
{
    public class CowBullishGame: Game
    {
        // Resources for drawing.
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        Texture2D bg;
        public CowBullishGame()
        {
            graphics = new GraphicsDeviceManager(this);

           
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            SetWindowSize(720, 1280);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            this.Content.RootDirectory = "Content";
            Globals.keyBoard = new McKeyboard();
            Globals.mouse = new MouseControl();

            bg = Content.Load<Texture2D>("Sprites/Niuqi/bg");
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected void SetWindowSize(int width,int height)
        {
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            graphics.ApplyChanges();
        }
        protected override void Update(GameTime gameTime)
        {
            //KeyboardState keyboardState = Keyboard.GetState();
            //if (keyboardState.IsKeyDown(Keys.Tab))
            //{

            //}
            
            SetWindowSize(720, 1280);
            Globals.keyBoard.Update();//键盘输入更新函数
            Globals.mouse.Update();

            Globals.keyBoard.UpdateOld();
            Globals.mouse.UpdateOld();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            spriteBatch.Draw(bg, Vector2.Zero, new Rectangle(0, 0, bg.Width, bg.Height), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
