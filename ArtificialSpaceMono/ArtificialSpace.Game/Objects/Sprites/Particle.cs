using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ASpace
{
    //  Класс, описывающий частицу. Наследуем от класса спрайта.
    public class Particle : Sprite
    {
        //  Время жизни частицы, сек.
        public float LifeSpan { get; set; }
        //  Таймер времени жизни.  
        double Counter { get; set; }
        //  Скорость частицы, px/сек.  
        public Vector2 Velocity { get; set; }
        //  Ускорение частицы. px/сек^2.  
        public Vector2 Acceleration { get; set; }
        //  Угловая скорость частицы, рад/сек.  
        public float AngularVelocity { get; set; }
        //  Начальный масштаб частицы, 0..1  
        public float ScaleStart { get; set; }
        //  Конечный масштаб частицы, 0..1  
        public float ScaleEnd { get; set; }
        //  Изменение масштаба за один такт. Только чтение.  
        float ScaleDelta { get { return (ScaleEnd - ScaleStart) / LifeSpan; } }
        //  Начальная прозрачность частицы, 0..1  
        public float TransparencyStart { get; set; }
        //  Конечная прозначность частицы, 0..1  
        public float TransparencyEnd { get; set; }
        //  Изменение прозрачности за один такт. Только чтение.  
        float TransparencyDelta { get { return (TransparencyEnd - TransparencyStart) / LifeSpan; } }
        //  Начальный цвет частицы.  
        public Color ColorStart { get; set; }
        //  Конечный цвет частицы.  
        public Color ColorEnd { get; set; }
        //  Вектор изменения цвета за один такт. Только чтение.  
        Vector3 ColorDelta
        {
            get
            {
                return new Vector3(
                  (ColorEnd.R - ColorStart.R) / LifeSpan,
                  (ColorEnd.G - ColorStart.G) / LifeSpan,
                  (ColorEnd.B - ColorStart.B) / LifeSpan) / 255;
            }
        }
        //  Инициализация начальных параметров частицы.  
        public override void Initialize()
        {
            base.Initialize();
            LifeSpan = 0;
            Velocity = Vector2.Zero;
            AngularVelocity = 0;
            ScaleStart = 1;
            ScaleEnd = 1;
            TransparencyStart = 1;
            TransparencyEnd = 1;
            Acceleration = Vector2.Zero;
            ColorStart = Color.White;
            ColorEnd = Color.White;
        }
        //  Конструктор.  
        //  texture - Текстура частицы.
        public Particle(Texture2D texture)
            : base(texture)
        {
            Initialize();
        }
        //  Обновление счётчика жизни частицы и проверка на окончание срока жизни.  
        //  Возвращает true, если срок жизни частицы истёк.
        bool UpdateCounter(GameTime Time)
        {
            // Проверяем, не истёк ли срок жизни частцы.
            if (Counter > LifeSpan)
            {
                // Если истёк - обнуляем текстуру и возвращаем true.
                SpriteTexture = null;
                return true;
            }
            else
            {
                // Если нет - прибавляем прошедшее время к счётчику и возвращаем false.
                Counter += Time.ElapsedGameTime.TotalSeconds;
                return false;
            }
        }

        //  Время, прошедшее с прошлого обновления параметров частицы.  
        float elapsedGameTime;

        //  Обновление всех параметров на основе исходных данных.  
        //  Возвращает true, если срок жизни частицы истёк.
        public bool Update(GameTime Time)
        {
            // Получаем время, прошедшее с прошлого обновления.
            elapsedGameTime = (float)Time.ElapsedGameTime.TotalSeconds;

            // Обновление цвета и прозрачности на основе исходных данных.
            //SpriteColor = new Color(
            //  new Color(ColorStart.ToVector3() + ColorDelta * (float)Counter), (TransparencyStart + TransparencyDelta * (float)Counter));
            //// Обновление масштаба на основе исходных данных.
            SpriteScale = (float)(ScaleStart + ScaleDelta * Counter);
            // Обновление положения и угла поворота.
            // Приращение угла поворота.
            SpriteRotation += AngularVelocity * elapsedGameTime;
            // Приращение скорости.
            Velocity += Acceleration * elapsedGameTime;
            // Приращение координаты.    
            SpriteLocation += Velocity * elapsedGameTime;

            // Обновляем счётчик и возвращаем true, если срок жизни чистцы истёк.
            return UpdateCounter(Time);
        }

        //  Возвращает копию данной частицы.  
        public Particle CloneParticle()
        {
            // Создаём новую частицу.
            Particle particle = new Particle(SpriteTexture);
            // Копируем в неё все параметры.
            particle.SpriteColor = SpriteColor;
            particle.SpriteEffects = SpriteEffects;
            particle.SpriteLocation = SpriteLocation;
            particle.SpriteOrigin = SpriteOrigin;
            particle.SpriteRotation = SpriteRotation;
            particle.SpriteScale = SpriteScale;
            particle.Acceleration = Acceleration;
            particle.AngularVelocity = AngularVelocity;
            particle.Counter = Counter;
            particle.LifeSpan = LifeSpan;
            particle.Velocity = Velocity;
            particle.ScaleEnd = ScaleEnd;
            particle.ScaleStart = ScaleStart;
            particle.ColorEnd = ColorEnd;
            particle.ColorStart = ColorStart;
            particle.TransparencyEnd = TransparencyEnd;
            particle.TransparencyStart = TransparencyStart;
            return particle;
        }
    }
}
