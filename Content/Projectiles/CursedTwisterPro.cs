using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class CursedTwisterPro : ModProjectile
	{

		public override void OnKill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 74, Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f);
			}
		}
		public override void SetDefaults()
		{

			Projectile.width = 6;
			Projectile.height = 6;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.extraUpdates = 2;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("CursedTwisterPro");

		}

		public override void AI()
		{
			int dustType = 74;
			if (Projectile.timeLeft > 133)
			{
				Projectile.timeLeft = 133;
			}
			if (Projectile.ai[0] > 7f)
			{
				float dustScale = 1f;
				if (Projectile.ai[0] == 8f)
				{
					dustScale = 1f;
				}
				else if (Projectile.ai[0] == 9f)
				{
					dustScale = 1f;
				}
				else if (Projectile.ai[0] == 10f)
				{
					dustScale = 1f;
				}
				else if (Projectile.ai[0] == 11f)
				{
					dustScale = 1f;
				}
				Projectile.ai[0] += 1f;
				for (int i = 0; i < 1; i++)
				{
					int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, dustType, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
					Dust dust = Main.dust[dustIndex];
					dust.noGravity = true;
					dust.scale *= 1f;
					dust.velocity.X = dust.velocity.X * 2f;
					dust.velocity.Y = dust.velocity.Y * 2f;
					dust.scale *= dustScale;
				}
			}
			else
			{
				Projectile.ai[0] += 1f;
			}
			Projectile.rotation += 0.3f * Projectile.direction;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (Main.rand.Next(10) == 0)
			{
				target.AddBuff(39, 500, false);
			}
		}
	}
}
