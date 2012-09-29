using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ASpace
{
    // Класс, описывающий свойства спрайта.
    public class SpriteBase
    {
        // Позиция спрайта.      
        public Vector2 SpriteLocation { get; set; }

        // Поворот спрайта в радианах.      
        public float SpriteRotation { get; set; }

        // Поворот спрайта в градусах.        
        public float SpriteRotationDeg
        {
            //Преобразуем градусы в радианы и наоборот.
            get
            { return SpriteRotation * 180 / MathHelper.Pi; }
            set
            { SpriteRotation = value * MathHelper.Pi / 180; }
        }

        // Масштаб спрайта.    
        public float SpriteScale
        {
            get { return spriteScale; }
            set
            {
                //Проверяем, положителен ли масштаб.
                if (value >= 0)
                { spriteScale = value; }
                else //Если отрицателен, то приравниваем его к нулю.
                { spriteScale = 0; }
            }
        }
        float spriteScale;

        // Положение начала координат спрайта.      
        public Vector2 SpriteOrigin { get; set; }

        // Цвет спрайта.  
        public Color SpriteColor { get; set; }

        // Прозрачность спрайта.
        // От 0 до 255.        
        public byte SpriteAlpha
        {
            get { return SpriteColor.A; }
            set { SpriteColor = new Color(SpriteColor.R, SpriteColor.G, SpriteColor.B, value); }
        }


        // Прозрачность спрайта.
        // От 0.0f до 1.0f.        
        public float SpriteAlphaF
        {
            //Преобразуем диапазон прозрачности из 0 - 255 в 0.0 - 1.0 и обратно.
            get
            { return (float)(SpriteColor.A) / 255.0f; }
            set
            { SpriteColor = new Color(SpriteColor.R, SpriteColor.G, SpriteColor.B, value); }
        }

        // Порядок отрисовки спрайта.
        // Необходимо устанавливать порядок сортировки BackToFront или FrontToBack.        
        public float LayerDepth { get; set; }

        //Отражение спрайта по горизонтали или вертикали.        
        public SpriteEffects SpriteEffects { get; set; }

        // Возвращает строку с описанием параметров спрайта.        
        // <returns>Параметры спрайта (несколько строк).</returns>
        public override string ToString()
        {
            return base.ToString() +
            "  Sprite:" +
            "    Location - " + SpriteLocation.ToString() +
            "    Origin - " + SpriteOrigin.ToString() +
            "    Rotation - " + SpriteRotation.ToString() +
            "    Scale - " + SpriteScale.ToString() +
            "    LayerDepth - " + LayerDepth.ToString() +
            "    Effects - " + SpriteEffects.ToString();
        }

        // Инициализация начальных параметров по умолчанию.        
        public virtual void Initialize()
        {
            SpriteColor = Color.White;
            SpriteEffects = SpriteEffects.None;
            SpriteLocation = Vector2.Zero;
            SpriteOrigin = Vector2.Zero;
            SpriteRotation = 0.0f;
            SpriteScale = 1.0f;
            LayerDepth = 0;
        }
    }
}
