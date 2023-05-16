using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using WonkmyLibs;

namespace WonkmyGame
{
    public class CowBullishGame: Game
    {
        private GraphicsDeviceManager graphics;

        private List<Cow> cows;

        Texture2D bg;
        Cow cow;

        float cowMoveSpeed = 220.0f;
        public CowBullishGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Globals.content = Content;
            
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            SetWindowSize(720, 1280);
            Globals.SetFPS(60.0f);

            cows = new List<Cow>();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            Globals.content.RootDirectory = "Content";
            Globals.keyBoard = new McKeyboard();
            Globals.mouse = new MouseControl();

            bg =Globals.content.Load<Texture2D>("Sprites/Niuqi/bg");

            cow = new Cow();
            cow.SetMoveSpeed(cowMoveSpeed);
            cow.SetPostion(new Vector2(Globals.screenWidth / 2 - cow.cow_sprite.Width / 2, Globals.screenHeight - 500));

            cows.Add(cow);

            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected void SetWindowSize(int width,int height)
        {
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            Globals.screenWidth = width;
            Globals.screenHeight = height;
            graphics.ApplyChanges();
        }
        protected override void Update(GameTime gameTime)
        {
            SetWindowSize(720, 1280);
            Globals.keyBoard.Update();//键盘输入更新函数
            Globals.mouse.Update();
            Globals.keyBoard.UpdateOld();
            Globals.mouse.UpdateOld();

            cow.Update(gameTime);//牛脚本更新函数

            foreach (var cow in cows)
            {
                if(cow.cow_sprite.Bounds.Intersects(new Rectangle()))
                {
                    cows.Remove(cow);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);

            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            Globals.spriteBatch.Draw(bg, Vector2.Zero, new Rectangle(0, 0, bg.Width, bg.Height), Color.White);
            cow.Draw();
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }

        
    }
}
