using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class TitaniumDiscPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(106);

			AIType = 106;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("TitaniumDiscPro");

		}

	}
}
