using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class ScarredReaperPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(106);
			Projectile.width = 48;
			Projectile.height = 48;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("ScarredReaperPro");
		}
	}
}