using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class BigPlague : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(566);

			AIType = 566;
			Projectile.tileCollide = false;
			Main.projFrames[Projectile.type] = 4;
			Projectile.width = 40;
			Projectile.height = 32;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("BigPlague");

		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void OnKill(int timeLeft)
		{
			int ses = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0, 0, ModContent.ProjectileType<PlagueBlast>(), Projectile.damage * 2, 0.7f, Projectile.owner);
			Main.projectile[ses].scale = Projectile.scale;
		}
		public override void AI()
		{
			Projectile.frameCounter++;
			if (Projectile.frameCounter > 2)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
			}
			if (Projectile.frame >= 4)
			{ Projectile.frame = 0; }

		}
	}
}
