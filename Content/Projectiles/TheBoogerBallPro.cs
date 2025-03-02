using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class TheBoogerBallPro : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.timeLeft = 150;
			Projectile.width = 34;
			Projectile.height = 34;
			Projectile.light = 0.8f;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("TheBoogerBallPro");

		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void AI()
		{
			Lighting.AddLight(Projectile.Center, new Vector3(0.075f, 0.3f, 0.15f));
			Projectile.velocity *= 0.985f;
			Projectile.rotation += Projectile.velocity.X * 0.2f;
			if (Projectile.velocity.X > 0f)
			{
				Projectile.rotation += 0.08f;
			}
			else
			{
				Projectile.rotation -= 0.08f;
			}
			Projectile.ai[1] += 1f;
			if (Projectile.ai[1] > 30f)
			{
				Projectile.alpha += 10;
				if (Projectile.alpha >= 255)
				{
					Projectile.alpha = 255;
					Projectile.Kill();
				}
			}

		}

	}
}
