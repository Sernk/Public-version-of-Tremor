using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class ObsidianSaberPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(595);

			Projectile.width = 96;
			Projectile.height = 48;
			AIType = 595;
			Main.projFrames[Projectile.type] = 28;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("ObsidianSaberPro");

		}

	}
}
