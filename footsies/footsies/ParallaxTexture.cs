using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace footsies
{
    class ParallaxTexture
    {
        private Texture2D texture;
        private int positionY;

        public float offsetX { get; set; }

        public ParallaxTexture(Texture2D _texture, int _positionY)
        {
            texture = _texture;
            positionY = _positionY;
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            int width = _spriteBatch.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            int texureStartX = (int)(offsetX % texture.Width);
            int textureWidth = texture.Width - texureStartX;
            int startX = 0;

            while(startX < width)
            {
                _spriteBatch.Draw(texture, new Vector2(startX, positionY),
                    new Rectangle(texureStartX, 0, textureWidth, texture.Height), Color.White);
                startX += textureWidth;

                texureStartX = 0;
                textureWidth = texture.Width;
            }
        }
    }
}//lol
