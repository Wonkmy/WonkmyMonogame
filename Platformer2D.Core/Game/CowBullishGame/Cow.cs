using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WonkmyLibs;

namespace WonkmyGame
{
    class Cow
    {
        public Texture2D cow_sprite { get; set; }
        public Vector2 cowPos { get; set; }

        public bool CanMove { get; set; }
        public float cowMoveSpeed { get; set; }
        public Cow()
        {
            cow_sprite = Globals.content.Load<Texture2D>("Sprites/Niuqi/niu");
        }

        public void SetPostion(Vector2 pos)
        {
            cowPos = pos;
        }
        public void SetMoveSpeed(float speed)
        {
            cowMoveSpeed = speed;
        }
        public void SetCanMove(bool canMove)
        {
            CanMove = canMove;
        }
        public void Update(GameTime gameTime)
        {
            if (Globals.mouse.LeftClick())
            {
                CanMove = true;
            }
            if (CanMove)
            {
                SetPostion(cowPos - new Vector2(0, cowMoveSpeed * Globals.deltaTime));
            }
        }

        public void Draw()
        {
            Globals.spriteBatch.Draw(cow_sprite, cowPos - new Vector2(-23,-125), new Rectangle(47, 35, 23, 33), Color.White);
            Globals.spriteBatch.Draw(cow_sprite, cowPos - new Vector2(-53,-125), new Rectangle(76, 35, 30, 33), Color.White);
            Globals.spriteBatch.Draw(cow_sprite, cowPos, new Rectangle(0, 87, cow_sprite.Width, 160), Color.White);
        }

        public void Dispose()
        {
            Globals.content.Unload();
        }
    }
}
