using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Dusts;

namespace TremorMod.Content.Projectiles
{
	public class CyberLaserBat : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Cyber Laser");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(38);
			AIType = 38;
			Projectile.width = 20;
			Projectile.height = 38;
			Projectile.scale = 1f;
		}

		public override void PostAI()
		{
			Vector2 center = Projectile.Center;
			Vector2 lookTarget = Projectile.Center + Projectile.velocity;
			float rotX = lookTarget.X - center.X;
			float rotY = lookTarget.Y - center.Y;
			Projectile.rotation = -((float)Math.Atan2(rotX, rotY)) - 1.57f;
			if (Main.netMode != 2)
			{
				int dustID = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<CyberDust>(), Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, Color.White, 0.6f);
				int dustID2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<CyberDust>(), Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, Color.White, 0.8f);
			}
		}
	}
}