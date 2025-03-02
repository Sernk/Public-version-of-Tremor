using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class TheSpikePro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(541);

			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.timeLeft = 480;
			Projectile.friendly = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("The Spike");

		}

	}
}
