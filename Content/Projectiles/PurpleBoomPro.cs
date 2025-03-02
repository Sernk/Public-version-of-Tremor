using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
    public class PurpleBoomPro : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 90;  // Размер взрыва
            Projectile.height = 34;
            Projectile.hostile = true;  // Враждебный
            Projectile.timeLeft = 7;  // Увеличиваем время жизни (например, 60 кадров = 1 секунда)
            Projectile.penetrate = -1;  // Бесконечное проникновение
            Projectile.light = 1f;  // Яркое освещение
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;  // Не взаимодействует с блоками
        }

        public override void AI()
        {
            // Создание эффектов
            for (int i = 0; i < 30; i++)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleCrystalShard, Main.rand.Next(-5, 6), Main.rand.Next(-5, 6), 150, default, 1.8f);
                Main.dust[dust].noGravity = true;  // Пыль без гравитации
            }

            Terraria.Audio.SoundEngine.PlaySound(SoundID.Item14, Projectile.position);  // Звук взрыва

            // Уменьшаем время жизни снаряда, если необходимо
            if (Projectile.timeLeft <= 1)
            {
                // Снаряд исчезнет после всех эффектов
                Projectile.Kill();
            }
        }
    }
}