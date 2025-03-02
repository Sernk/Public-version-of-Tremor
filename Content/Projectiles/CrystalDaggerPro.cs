using System;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
    public class CrystalDaggerPro : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.friendly = true;
            Projectile.aiStyle = 1;
            Projectile.timeLeft = 1200;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        /*public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Dagger");
        }*/

        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 73, Projectile.oldVelocity.X * 0.7f, Projectile.oldVelocity.Y * 0.7f);
            }
            SoundEngine.PlaySound(SoundID.Item20, Projectile.position);
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            // Увеличивает AI параметр при попадании
            Projectile.ai[0] += 0.1f;

            // Уменьшает скорость снаряда
            Projectile.velocity *= 0.75f;
        }
    }
}
