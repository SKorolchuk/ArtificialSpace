using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ASpace
{
    // Класс управления спрайтом.
    // Наследуем его от класса SpriteBase.  
    public class Sprite : SpriteBase
    {
        // Текстура спрайта.        
        public Texture2D SpriteTexture { get; set; }


        // Конструктор.
        // Положение в точке (0, 0).
        public Sprite(Texture2D texture)
        {
            Initialize();
            SpriteTexture = texture;
        }

        // Конструктор.
        // Положение в точке (0, 0).
        public Sprite(string textureName, ContentManager content)
        {
            Initialize();
            SpriteTexture = content.Load<Texture2D>(textureName);
        }

        // Конструктор.
        // Положение в точке location.
        public Sprite(Texture2D texture, Vector2 location)
        {
            Initialize();
            SpriteTexture = texture;
            SpriteLocation = location;
        }

        // Конструктор.
        // Положение в точке location.
        public Sprite(string textureName, ContentManager content, Vector2 location)
        {
            Initialize();
            SpriteTexture = content.Load<Texture2D>(textureName);
            SpriteLocation = location;
        }

        // Возвращает строку с описанием параметров текстуры и спрайта.
        public override string ToString()
        {
            return base.ToString() +
            "  Texture:" +
            "    Width - " + SpriteTexture.Width.ToString() +
            "    Height - " + SpriteTexture.Height.ToString() +
            "    Format - " + SpriteTexture.Format.ToString();
        }

        // Пренос начала координат спрайта в его центр.      
        public void OriginToCenter()
        {
            SpriteOrigin = new Vector2(SpriteTexture.Width / 2,
                                       SpriteTexture.Height / 2);
        }

        // Пренос начала координат спрайта в верхний левый угол.        
        public void OriginToZero()
        {
            SpriteOrigin = Vector2.Zero;
        }

        // Задаём положение спрайта.
        public void SetLocation(float x, float y)
        {
            SpriteLocation = new Vector2(x, y);
        }

        // Задаём положение спрайта.
        public void SetLocation(double x, double y)
        {
            SpriteLocation = new Vector2((float)x, (float)y);
        }

        // Линейное перемещение спрайта.
        public void LinearMotion(float dx, float dy)
        {
            SpriteLocation += new Vector2(dx, dy);
        }

        // Линейное перемещение спрайта.
        public void LinearMotion(double dx, double dy)
        {
            SpriteLocation += new Vector2((float)dx, (float)dy);
        }

        // Угловое перемещение спрайта.
        public void AngularMotion(float w)
        {
            SpriteRotation += w;
        }

        // Угловое перемещение спрайта.
        public void AngularMotion(double w)
        {
            SpriteRotation += (float)w;
        }

        // Отрисовка спрайта в новой сессии.
        public void DrawSpriteNew(SpriteBatch spriteBatch)
        {
            //Начинаем новую сессию отрисовки спрайтов.
            spriteBatch.Begin();

            //Рисуем спрайт.
            spriteBatch.Draw(
                SpriteTexture,
                SpriteLocation,
                new Rectangle(0, 0, SpriteTexture.Width, SpriteTexture.Height),
                SpriteColor,
                SpriteRotation,
                SpriteOrigin,
                SpriteScale,
                SpriteEffects,
                0);

            //Заканчиваем отрисовку.
            spriteBatch.End();
        }

        // Отрисовка спрайта в текущей сессии.
        public void DrawSprite(SpriteBatch spriteBatch)
        {
            //Рисуем спрайт.
            spriteBatch.Draw(
                SpriteTexture,
                SpriteLocation,
                new Rectangle(0, 0, SpriteTexture.Width, SpriteTexture.Height),
                SpriteColor,
                SpriteRotation,
                SpriteOrigin,
                SpriteScale,
                SpriteEffects,
                LayerDepth);
        }


        // Копирование текущего спрайта.
        public virtual Sprite CloneSprite()
        {
            //Создаём новый спрайт.
            Sprite sprite = new Sprite(SpriteTexture, SpriteLocation);
            //Копируем в него все параметры.
            sprite.SpriteColor = SpriteColor;
            sprite.SpriteEffects = SpriteEffects;
            sprite.SpriteOrigin = SpriteOrigin;
            sprite.SpriteRotation = SpriteRotation;
            sprite.SpriteScale = SpriteScale;
            return sprite;
        }
    }
}
