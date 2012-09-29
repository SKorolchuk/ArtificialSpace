using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ASpace
{
    public interface IGamable
    {
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}