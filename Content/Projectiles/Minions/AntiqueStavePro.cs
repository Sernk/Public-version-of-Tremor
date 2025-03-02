using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles.Minions
{
    public class AntiqueStavePro : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // Установите количество кадров анимации для снаряда
            Main.projFrames[Projectile.type] = 1;

            // Название снаряда (опционально, если требуется)
            // DisplayName.SetDefault("Antique Soul");
        }

        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.hostile = false;
            Projectile.friendly = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 900;
            Projectile.penetrate = -1;
            Projectile.tileCollide = true;
            Projectile.sentry = true;

            // Включение функции прицеливания миньонов
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
        }

        public override void AI()
        {
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];

                float shootToX = target.position.X + target.width * 0.5f - Projectile.Center.X;
                float shootToY = target.position.Y + target.height * 0.5f - Projectile.Center.Y;
                float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

                if (distance < 520f && !target.friendly && target.active)
                {
                    if (Projectile.ai[0] > 35f) // Задержка в 35 кадров (примерно 0.58 секунды)
                    {
                        distance = 1.6f / distance;
                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
                        int damage = 30;

                        // Используем корректный источник
                        Projectile.NewProjectile(
                            Projectile.GetSource_FromAI(),
                            Projectile.Center.X,
                            Projectile.Center.Y,
                            shootToX,
                            shootToY,
                            122, // Тип снаряда
                            damage,
                            0,
                            Main.myPlayer
                        );

                        Projectile.ai[0] = 0f;
                    }
                    Projectile.ai[0] += 1f;
                }
            }
        }
    }
}
