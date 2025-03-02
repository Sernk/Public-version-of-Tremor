using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace TremorMod.Content.Projectiles
{
	public class ZootalooRodPro : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 600;
			Projectile.DamageType = DamageClass.Magic;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Zootaloo Rod Pro");

		}

		public override void AI()
		{
			Lighting.AddLight(Projectile.Center, ((255 - Projectile.alpha) * 0.25f) / 255f, ((255 - Projectile.alpha) * 0.2f) / 255f, ((255 - Projectile.alpha) * 0.01f) / 255f);
			if (Projectile.wet && !Projectile.lavaWet)
			{
				Projectile.Kill();
			}
			if (Projectile.localAI[0] == 0f)
			{
				SoundEngine.PlaySound(SoundID.Item20, Projectile.position);
				Projectile.localAI[0] += 1f;
			}
			for (int num457 = 0; num457 < 10; num457++)
			{
				int num458 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 44, 0f, 0f, 100, default(Color), 1.2f);
				Main.dust[num458].noGravity = true;
				Main.dust[num458].velocity *= 0.5f;
				Main.dust[num458].velocity += Projectile.velocity * 0.1f;
			}
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
			}
			return false;
		}

        public override void OnKill(int timeLeft)
        {
            IEntitySource source = Projectile.GetSource_FromThis();
            Vector2 position = Projectile.Center;
            Vector2 velocity = Vector2.Zero; // т.к. у вас (0f, 0f)

            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<SporeExplosion>(),
            Projectile.damage, Projectile.knockBack, Projectile.owner);
        }
    }
}
