using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ASpace
{
    // Класс для вывода текста на экран, наследуем от класса SpriteBase.    
    public class SpriteText : SpriteBase
    {
        // Текстура шрифта.        
        public SpriteFont SpriteFont { get; set; }

        // Выводимый текст.              
        public String Text { get; set; }

        // Конструктор.
        // Загружаем шрифт.        
        public SpriteText(string fontName, ContentManager content)
        {
            Initialize();
            SpriteFont = content.Load<SpriteFont>(fontName);
        }

        // Конструктор.
        // Указываем уже загруженный шрифт.        
        public SpriteText(SpriteFont font)
        {
            Initialize();
            SpriteFont = font;
        }

        // Конструктор.
        // Загружаем шрифт и указываем положение текста.
        public SpriteText(string fontName, ContentManager content, Vector2 location)
        {
            Initialize();
            SpriteFont = content.Load<SpriteFont>(fontName);
            SpriteLocation = location;
        }

        // Конструктор.
        // Указываем уже загруженный шрифт и положение текста..
        public SpriteText(SpriteFont font, Vector2 location)
        {
            Initialize();
            SpriteFont = font;
            SpriteLocation = location;
        }

        // Возвращает строку с описанием параметров шрифта и спрайта с текстом.
        public override string ToString()
        {
            return base.ToString() +
            "  Font: " + SpriteFont.ToString();
        }

        // Отрисовка текста в новой сессии.
        public void DrawTextNew(SpriteBatch spriteBatch)
        {
            //Начинаем новую сессию отрисовки спрайтов.
            spriteBatch.Begin();

            //Проверяем есть ли шрифт.
            if (SpriteFont != null)
            {
                //Рисуем текст.
                spriteBatch.DrawString(
                    SpriteFont,     //Шрифт.
                    Text,           //Строка с текстом.
                    SpriteLocation, //Положиение строки.
                    SpriteColor,    //Цвет.
                    SpriteRotation, //Поворот..
                    SpriteOrigin,   //Положение начала координат.
                    SpriteScale,    //Масштаб.
                    SpriteEffects,  //Эффекты.
                    0);             //Глубина.
            }

            //Заканчиваем отрисовку.
            spriteBatch.End();
        }

        // Отрисовка текста в текущей сессии.
        public void DrawText(SpriteBatch spriteBatch)
        {
            //Проверяем есть ли шрифт.
            if (SpriteFont != null)
            {
                //Рисуем спрайт.
                spriteBatch.DrawString(
                    SpriteFont,     //Шрифт.
                    Text,           //Строка с текстом.
                    SpriteLocation, //Положиение строки.
                    SpriteColor,    //Цвет.
                    SpriteRotation, //Поворот..
                    SpriteOrigin,   //Положение начала координат.
                    SpriteScale,    //Масштаб.
                    SpriteEffects,  //Эффекты.
                    LayerDepth);    //Глубина.
            }
        }
    }
}
