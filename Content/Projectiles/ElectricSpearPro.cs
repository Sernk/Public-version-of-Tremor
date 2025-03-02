using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class ElectricSpearPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(47);

			AIType = 47;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("ElectricSpearPro");

		}

		public override void AI()
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 226, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 136, default(Color), 0.9f);
			Main.dust[dust].noGravity = true;
		}
	}
}
