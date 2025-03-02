using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;

namespace TremorMod.Content.NPCs.Bosses.NovaPillar
{
    public class NovaSky : CustomSky
    {
        private bool isActive;
        private float opacity;
        private List<Star> stars;

        public override void OnLoad()
        {
            stars = new List<Star>();
            GenerateStars();
        }

        public override void Update(GameTime gameTime)
        {
            if (isActive)
            {
                opacity = Math.Min(opacity + 0.01f, 1f);
            }
            else
            {
                opacity = Math.Max(opacity - 0.01f, 0f);
            }

            foreach (var star in stars)
            {
                star.Update(gameTime, isActive);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
        {
            if (maxDepth >= 0 && minDepth < 0)
            {

                // Рисуем статичную планету выше врага
                Texture2D planetTexture = ModContent.Request<Texture2D>("TremorMod/Content/NPCs/Bosses/NovaPillar/NovaPlanet").Value;
                int planetSize = 600; // Увеличенный размер планеты
                Vector2 position = new Vector2(Main.screenWidth / 2 - planetSize / 2, Main.screenHeight / 6 - planetSize / 2); // Позиция выше по вертикали

                spriteBatch.Draw(planetTexture, new Rectangle((int)position.X, (int)position.Y, planetSize, planetSize), Color.White * opacity);

                // Рисуем звезды
                foreach (var star in stars)
                {
                    star.Draw(spriteBatch, opacity);
                }
            }
        }

        public override bool IsActive()
        {
            return isActive || opacity > 0f;
        }

        public override void Reset()
        {
            isActive = false;
        }

        public override void Activate(Vector2 position, params object[] args)
        {
            isActive = true;
        }

        public override void Deactivate(params object[] args)
        {
            isActive = false;
        }

        private void GenerateStars()
        {
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                stars.Add(new Star(
                    new Vector2(rand.Next(Main.screenWidth), rand.Next(Main.screenHeight)),
                    rand.Next(1, 4), // Тип звезды: 1, 2 или 3
                    new Vector2((float)(rand.NextDouble() * 2 - 1), (float)(rand.NextDouble() * 2 - 1))
                ));
            }
        }
    }

    public class Star
    {
        private Vector2 position;
        private int starType;
        private Vector2 velocity;
        private float scale;
        private float fadeSpeed;
        private float alpha;

        public Star(Vector2 position, int starType, Vector2 velocity)
        {
            this.position = position;
            this.starType = starType;
            this.velocity = velocity;
            this.scale = 0.5f + (float)new Random().NextDouble(); // Размер звезды
            this.fadeSpeed = 0.01f; // Скорость исчезновения
            this.alpha = 1f; // Начальная непрозрачность
        }

        public void Update(GameTime gameTime, bool isActive)
        {
            position += velocity;

            if (position.X < 0 || position.X > Main.screenWidth || position.Y < 0 || position.Y > Main.screenHeight)
            {
                position.X = (position.X + Main.screenWidth) % Main.screenWidth;
                position.Y = (position.Y + Main.screenHeight) % Main.screenHeight;
            }

            if (!isActive)
            {
                alpha -= fadeSpeed;
                scale -= fadeSpeed * 0.5f;
            }
            else
            {
                alpha = Math.Min(alpha + fadeSpeed, 1f); // Восстанавливаем прозрачность
                scale = Math.Min(scale + fadeSpeed * 0.5f, 1f); // Восстанавливаем размер
            }
        }


        public void Draw(SpriteBatch spriteBatch, float opacity)
        {
            if (alpha > 0)
            {
                Texture2D starTexture = ModContent.Request<Texture2D>($"TremorMod/Content/NPCs/Bosses/NovaPillar/NovaSoul {starType}").Value;
                spriteBatch.Draw(starTexture, position, null, Color.White * opacity * alpha, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            }
        }

        public bool IsFadedOut()
        {
            return alpha <= 0;
        }
    }
}