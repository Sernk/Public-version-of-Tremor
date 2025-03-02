using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class BicholmereSpearPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 3;
			Projectile.height = 11;
			Projectile.friendly = true;
			Projectile.aiStyle = 1;
			Projectile.timeLeft = 1200;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Bicholmere Spear");
		}

		public override void OnKill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 37, Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f);
			}
            SoundEngine.PlaySound(SoundID.Item1, Projectile.position);
        }

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			Projectile.ai[0] += 0.1f;
			Projectile.velocity *= 0.75f;
		}
	}
}
