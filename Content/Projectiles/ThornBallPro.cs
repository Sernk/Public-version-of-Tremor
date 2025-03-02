using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class ThornBallPro : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.aiStyle = 14;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = 5;
			Projectile.timeLeft = 9000;
			Projectile.extraUpdates = 1;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Thorn Ball");

		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.velocity.Y = -oldVelocity.Y;
			}
			else
			{
				Projectile.ai[0] += 0.1f;
				if (Projectile.velocity.X != oldVelocity.X)
				{
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y)
				{
					Projectile.velocity.Y = -oldVelocity.Y;
				}
				Projectile.velocity *= 0.75f;
				SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
			}
			return false;
		}

		public override void OnKill(int timeLeft)
		{
			for (int k = 0; k < 30; k++)
			{
				int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 21, Projectile.oldVelocity.X * 0.7f, Projectile.oldVelocity.Y * 0.7f);
			}
			SoundEngine.PlaySound(SoundID.Grass, Projectile.position);
		}
	}
}
