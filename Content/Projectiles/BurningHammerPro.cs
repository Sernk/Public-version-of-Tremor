using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class BurningHammerPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(3);

			Projectile.width = 26;
			Projectile.height = 36;
			AIType = 3;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("BurningHammerPro");

		}

		public override bool CanHitPlayer(Player target)
		{
			return false;
		}

		public override bool? CanHitNPC(NPC target)
		{
			return (target.friendly) ? false : true;
		}

		public override void AI()
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 136, default(Color), 2.9f);
			Main.dust[dust].noGravity = true;
		}

		public override void OnKill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 6, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 2f, 100, default(Color), 2f);
			}
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
		}

	}
}
