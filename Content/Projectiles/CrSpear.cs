using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace TremorMod.Content.Projectiles
{
	public class CrSpear : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(507);
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 99999;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.aiStyle = 1;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Spear");

		}*/

		public override void AI()
		{
			CreateDust();
		}

		
        public override void OnKill(int timeLeft)
		{
			for (int k = 0; k < 10; k++)
			{
				int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 16, Projectile.oldVelocity.X * 0.7f, Projectile.oldVelocity.Y * 0.7f);
			}
            SoundEngine.PlaySound(SoundID.Item20, Projectile.position);
        }

		public void CreateDust()
		{
			if (Main.rand.NextBool(2))
			{
				/* TODO: CrystalD does not exist
				int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType<Dusts.CrystalD>());
				Main.dust[dust].scale = 0.9f;
				*/
			}
		}
	}
}
