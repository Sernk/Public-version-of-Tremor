using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class DungeonGuardianPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(555);
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.timeLeft = 420;
			Projectile.friendly = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("DungeonGuardianPro
		}
	}
}