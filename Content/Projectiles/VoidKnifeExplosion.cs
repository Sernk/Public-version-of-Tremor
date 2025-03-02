using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class VoidKnifeExplosion : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.timeLeft = 420;
			Projectile.width = 52;
			Projectile.height = 52;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.friendly = true;
			Main.projFrames[Projectile.type] = 5;
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
			if (Projectile.frameCounter > 6)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
			}
			if (Projectile.frame >= 5)
			{
				Projectile.Kill();
			}
		}
	}
}