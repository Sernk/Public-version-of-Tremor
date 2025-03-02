using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class BonecrusherPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(182);

			Projectile.width = 29;
			Projectile.height = 29;
			AIType = 182;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("BonecrusherPro");

		}

	}
}
