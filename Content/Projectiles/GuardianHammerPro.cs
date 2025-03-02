using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class GuardianHammerPro : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.CloneDefaults(301);
			Projectile.width = 32;
			Projectile.height = 32;
			AIType = 301;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("GarnetGlovePro");

		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override bool CanHitPlayer(Player target)
		{
			return false;
		}

		public override bool? CanHitNPC(NPC target)
		{
			return (target.friendly) ? false : true;
		}

		public override void AI()
		{
			Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
			if (Main.rand.NextBool())
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 62, Projectile.velocity.X * 0.9f, Projectile.velocity.Y * 0.9f);
			}
		}

	}
}
