using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
    public class PurplePulsePro : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 90;
            Projectile.height = 34;
            Projectile.hostile = true;
            Projectile.timeLeft = 300;  // Время жизни снаряда
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            this.Projectile.rotation = this.Projectile.velocity.ToRotation();

            if (this.Projectile.localAI[0] == 0f)
            {
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item91, this.Projectile.position);
            }

            this.Projectile.localAI[0] += 1f;

            if (this.Projectile.localAI[0] > 3f)
            {
                int dustID = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleTorch);
                Main.dust[dustID].noGravity = true;
            }

            // Когда время жизни снаряда заканчивается, создаем снаряд взрыва
            if (Projectile.timeLeft <= 1)
            {
                Explode();  // Вызов взрыва
            }
        }

        // Создание снаряда PurpleBoomPro (взрыв)
        private void Explode()
        {
            // Создаем снаряд PurpleBoomPro на месте текущего снаряда
            Projectile.NewProjectile(
                Projectile.GetSource_Death(),  // Источник смерти
                Projectile.Center.X,  // Координаты центра снаряда
                Projectile.Center.Y,
                0f, 0f,  // Начальная скорость (снаряд взрывается на месте)
                ModContent.ProjectileType<PurpleBoomPro>(),  // Тип снаряда (взрыв)
                Projectile.damage,  // Урон взрыва
                0f,  // Сила удара
                Projectile.owner  // Владелец снаряда
            );
        }
    }
}
