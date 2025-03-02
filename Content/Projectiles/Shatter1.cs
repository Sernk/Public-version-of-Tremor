using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class Shatter1 : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Grenade);
			Projectile.penetrate = 1;
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.alpha = 80;
			AIType = ProjectileID.Grenade;
			Projectile.light = 0.5f;
		}

        public void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			int newLife = 1;
			Main.player[Projectile.owner].statLife += newLife;
			Main.player[Projectile.owner].HealEffect(newLife);
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
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
				//Main.PlaySound(2, (int)Projectile.position.X, (int)Projectile.position.Y, 27);
                SoundEngine.PlaySound(SoundID.Item12, Projectile.position);
            }
			return false;
		}
	}
}