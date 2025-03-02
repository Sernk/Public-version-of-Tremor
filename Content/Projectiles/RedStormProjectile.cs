using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace TremorMod.Content.Projectiles
{
    public class RedStormProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 300;
            AIType = ProjectileID.WoodenArrowFriendly; // Поведение стрелы
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            // При попадании создаем лазеры с неба
            int laserCount = 5; // Количество лазеров
            for (int i = 0; i < laserCount; i++)
            {
                // Позиция лазера над врагом
                Vector2 laserPosition = new Vector2(
                    target.Center.X + Main.rand.Next(-100, 100), // Случайное смещение по горизонтали
                    target.Center.Y - 600f                       // Высота появления
                );

                Vector2 laserVelocity = new Vector2(0, 10f); // Лазер движется вниз

                // Создаем снаряд лазера
                Projectile.NewProjectile(
                    Projectile.GetSource_OnHit(target),
                    laserPosition,
                    laserVelocity,
                    ModContent.ProjectileType<RedStormLaser>(), // Тип снаряда для лазера
                    Projectile.damage / 2,  // Урон лазера (половина от исходного)
                    0f,                     // Нет отдачи
                    Projectile.owner        // Владелец
                );
            }
        }
    }
}
