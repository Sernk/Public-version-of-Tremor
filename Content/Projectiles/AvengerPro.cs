using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class AvengerPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(542);
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.timeLeft = 220;
			Projectile.friendly = true;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Avenger Pro");
		}*/

	}
}
