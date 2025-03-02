using Terraria;
using System;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Graphics.Shaders;
using Microsoft.Xna.Framework.Graphics;


namespace TremorMod.Content.Projectiles
{
    public class LightningOrb : ModProjectile
    {
        private const int NormalFrameCount = 4;
        private int hitCount = 0; // Счетчик ударов

        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 180; // Исчезает через 3 секунды (60 кадров = 1 секунда)
            Projectile.light = 1f;
            Projectile.aiStyle = -1; // Пользовательская логика AI
        }

        public override void AI()
        {
            // Обновление анимации снаряда
            int totalFrames = 4; // Количество кадров
            //int frameHeight = 99; // Высота одного кадра
            //int frameWidth = 99; // Ширина одного кадра

            // Счётчик кадров
            Projectile.frameCounter++;

            // Сменить кадр после определённого времени
            if (Projectile.frameCounter >= 6) // Скорость анимации, чем больше число, тем медленнее
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;

                if (Projectile.frame >= totalFrames) // Переход к первому кадру после последнего
                {
                    Projectile.frame = 0;
                }
            }
            // Нацеливание на ближайшего игрока
            Player targetPlayer = Main.player[Player.FindClosest(Projectile.Center, 0, 0)];
            if (targetPlayer != null && !targetPlayer.dead)
            {
                Vector2 direction = Vector2.Normalize(targetPlayer.Center - Projectile.Center);
                Projectile.velocity = direction * 10f; // Скорость молнии

                // Создание визуальных эффектов
                if (Main.rand.NextBool(3))
                {
                    int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Electric, 0f, 0f, 100, default, 1.5f);
                    Main.dust[dust].noGravity = true;
                }
            }

            // Проверяем, сколько раз снаряд нанес удар
            if (hitCount >= 5)
            {
                Projectile.Kill(); // Снаряд исчезает после 5 ударов
            }
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            hitCount++; // Увеличиваем счетчик при ударе по игроку
        }
        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Electric, 0f, 0f, 100, default, 1.5f);
                Main.dust[dust].noGravity = true;
            }
        }


        public override bool PreDraw(ref Color lightColor)
        {
            // Получаем текстуру снаряда
            Texture2D texture = ModContent.Request<Texture2D>("TremorMod/Content/Projectiles/LightningOrb").Value;
            // Рисуем снаряд с анимацией
            Rectangle frameRectangle = new Rectangle(0, Projectile.frame * 99, 99, 99);
            Vector2 position = Projectile.Center - Main.screenPosition;

            Main.spriteBatch.Draw(texture, position, frameRectangle, lightColor);

            return false; // Возвращаем false, чтобы стандартный метод рисования не вызывался
        }
    }
}