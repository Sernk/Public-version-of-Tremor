using System;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class StarNestPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(566);

			AIType = 566;
			Projectile.tileCollide = false;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("StarNest");

		}

		public override void AI()
		{
			Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
			if (Main.rand.NextBool())
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 57, Projectile.velocity.X * 0.9f, Projectile.velocity.Y * 0.9f);
			}
		}
	}
}
