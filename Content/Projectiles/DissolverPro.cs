using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class DissolverPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(553);
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("DissolverPro");

		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (Main.rand.NextBool(2))
			{
				target.AddBuff(BuffID.Ichor, 280, false);
			}
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
