using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class ManaSkull : ModProjectile
    {

		public override void SetDefaults()
		{
			Projectile.width = 52;
			Projectile.height = 52;
			Projectile.friendly = true;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.penetrate = -1;
			Projectile.alpha = 255;
			Projectile.timeLeft = 420;
			Main.projFrames[Projectile.type] = 15;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			int newLife = Main.rand.Next(hit.Damage / 2) + 3;
			Main.player[Projectile.owner].statMana += newLife;
			Main.player[Projectile.owner].ManaEffect(newLife);
		}

		public override void AI()
		{

			//int num613 = 10;
			//int num614 = 15;
			//float num615 = 1f;
			//int num616 = 150;
			//int num617 = 42;
			if (Projectile.velocity.X != 0f)
			{
				Projectile.direction = (Projectile.spriteDirection = -Math.Sign(Projectile.velocity.X));
			}
			Projectile.frameCounter++;
			if (Projectile.frameCounter > 2)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
			}
			if (Projectile.frame >= 10)
			{ Projectile.velocity.X = 0f; Projectile.velocity.Y = 0f; }
			if (Projectile.frame >= 15)
			{ Projectile.Kill(); }
			if (!Collision.SolidCollision(Projectile.position, Projectile.width, Projectile.height))
			{
				Projectile.alpha -= 30;
				if (Projectile.alpha < 60)
				{
					Projectile.alpha = 60;
				}
			}
			else
			{
				Projectile.alpha += 30;
				if (Projectile.alpha > 150)
				{
					Projectile.alpha = 150;
				}
			}

		}
	}
}