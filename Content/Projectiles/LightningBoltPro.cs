using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class LightningBoltPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(443);

			AIType = 443;
			Projectile.DamageType = DamageClass.Magic;

			Projectile.timeLeft = 500;
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("LightningBoltPro");

		}

	}
}
