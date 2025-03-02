using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class GloomSphere : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.aiStyle = 91;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = 6;
			Projectile.timeLeft = 600;
			Projectile.light = 0.5f;
			Projectile.extraUpdates = 1;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Gloom Sphere");

		}

		public override void AI()
		{
			Projectile.velocity.Y += Projectile.ai[0];
			if (Main.rand.NextBool(2))
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 27, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
			}
		}
	}
}
