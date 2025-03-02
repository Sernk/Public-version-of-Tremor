using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class WallOfShadowsBoom : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 52;
			Projectile.height = 52;
			Projectile.penetrate = -1;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Main.projFrames[Projectile.type] = 5;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Wall Of Shadows Boom");

		}

		public override bool PreAI()
		{
			if (Projectile.ai[0] == 0f)
			{
				Projectile.Damage();
				Projectile.ai[0] = 1f;
			}
			Projectile.frameCounter++;
			if (Projectile.frameCounter > 10)
			{
				;
				Projectile.frameCounter = 0;
				Projectile.frame++;
				if (Projectile.frame > Main.projFrames[Projectile.type])
				{
					Projectile.Kill();
				}
			}
			return false;
		}

		public override void AI()
		{
			Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 173, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(153, 300);
		}
	}
}
