using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class BasicSkullburst : ModProjectile
    {
		public override void SetDefaults()
		{
			Projectile.timeLeft = 420;
			Projectile.width = 52;
			Projectile.height = 52;
			Projectile.friendly = true;
			Main.projFrames[Projectile.type] = 12;
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
			if (Projectile.frame >= 7)
			{ Projectile.velocity.X = 0f; Projectile.velocity.Y = 0f; }
			if (Projectile.frame >= 12)
			{ Projectile.Kill(); }
		}

	}
}