using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace WonkmyLibs
{
    /// <summary>
    /// 2d精灵基类
    /// </summary>
    public class Basic2d
    {
        public float rot;
        public Vector2 pos, dims;
        public Texture2D mySprite;
        public Basic2d(string path,Vector2 _pos,Vector2 _dims)
        {
            pos = _pos;
            dims = _dims;
            mySprite = Globals.content.Load<Texture2D>(path);
        }

        public virtual void update()
        {

        }

        public virtual void Draw(Vector2 offset)
        {
            if (mySprite != null)
            {
                Globals.spriteBatch.Draw(mySprite, 
                    new Rectangle((int)(pos.X+offset.X), (int)(pos.Y+offset.Y), (int)(dims.X), (int)(dims.Y)), 
                    null,
                    Color.White, 
                    rot, 
                    new Vector2(mySprite.Bounds.Width / 2, mySprite.Bounds.Height / 2), 
                    new SpriteEffects(), 
                    0);
            }
        }
        public virtual void Draw(Vector2 offset,Vector2 origin)
        {
            if (mySprite != null)
            {
                Globals.spriteBatch.Draw(mySprite,
                    new Rectangle((int)(pos.X + offset.X), (int)(pos.Y + offset.Y), (int)(dims.X), (int)(dims.Y)),
                    null,
                    Color.White,
                    rot,
                    new Vector2(origin.X, origin.Y),
                    new SpriteEffects(),
                    0);
            }
        }
    }
}
