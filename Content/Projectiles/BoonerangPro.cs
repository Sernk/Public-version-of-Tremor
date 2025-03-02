using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class BoonerangPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(106);
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("BoonerangPro");
		}
	}
}