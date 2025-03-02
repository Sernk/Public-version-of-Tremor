using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace TremorMod.Content.Projectiles
{
	public class AlphaKnifePro : ModProjectile
	{
		public override void SetDefaults()
		{ 
			Projectile.width = 14;
			Projectile.height = 32;
			Projectile.friendly = true;
			Projectile.aiStyle = 1;
			Projectile.timeLeft = 1200;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
		}	

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alpha Knife");

		}*/

		public override void OnKill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 1, Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f);
			}
            SoundEngine.PlaySound(SoundID.Item1, Projectile.position);
        }

		/*public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.75f;
		}*/
	}
}
