using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class CrystalBlast : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 10;
		}

		public override void SetDefaults()
		{
			Projectile.timeLeft = 420;
			Projectile.width = 60;
			Projectile.height = 60;
			Projectile.friendly = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void AI()
		{
			Projectile.frameCounter++;
			if (Projectile.frameCounter > 2)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
			}
			if (Projectile.frame >= 10)
			{ Projectile.Kill(); }
		}
	}
}