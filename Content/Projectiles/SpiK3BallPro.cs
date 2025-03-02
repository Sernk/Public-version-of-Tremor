using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class SpiK3BallPro : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.aiStyle = 14;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = 5;
			Projectile.timeLeft = 1500;
			Projectile.extraUpdates = 1;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("SpiK-3 Ball");

		}

		public override void OnKill(int timeLeft)
		{
			for (int k = 0; k < 40; k++)
			{
				int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 26, Projectile.oldVelocity.X * 0.7f, Projectile.oldVelocity.Y * 0.7f);
			}
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
		}
	}
}
