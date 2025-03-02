using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TremorMod.Content.Projectiles
{
	public class DemonEyePro : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 16;
			Projectile.height = 28;
			Projectile.friendly = true;
			Projectile.aiStyle = 1;
			Main.projFrames[Projectile.type] = 2;
			Projectile.timeLeft = 1200;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("DemonEyePro");

		}

		public override void OnKill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 1, Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f);
			}
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            if (Main.netMode != NetmodeID.Server) // Метод для Gore
            {
                Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.position,
                new Vector2(Projectile.velocity.X, Projectile.velocity.Y),
                1, 1f);

                Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.position,
                new Vector2(Projectile.velocity.X, Projectile.velocity.Y),
                2, 1f);
            }
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			Projectile.ai[0] += 0.1f;
			Projectile.velocity *= 0.75f;
		}
	}
}
