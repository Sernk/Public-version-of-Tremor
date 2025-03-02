using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class AncientSolarWindPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(66);

			AIType = 66;
			Projectile.tileCollide = false;
			Projectile.light = 0.8f;
			Projectile.penetrate = -1;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ancient Solar Wind");

		}

		public override void AI()
		{
			Projectile.light = 0.9f;
			int DustID = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 2f), Projectile.width, Projectile.height, 6, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 0.5f);
			Main.player[Projectile.owner].direction = Projectile.direction;
			Main.player[Projectile.owner].heldProj = Projectile.whoAmI;
			Main.player[Projectile.owner].itemTime = Main.player[Projectile.owner].itemAnimation;
			Projectile.position.X = Main.player[Projectile.owner].position.X + Main.player[Projectile.owner].width / 2 - Projectile.width / 2;
			Projectile.position.Y = Main.player[Projectile.owner].position.Y + Main.player[Projectile.owner].height / 2 - Projectile.height / 2;
			Projectile.position += Projectile.velocity * Projectile.ai[0];
			if (Projectile.ai[0] == 0f)
			{
				Projectile.ai[0] = 3f;
				Projectile.netUpdate = true;
			}
			if (Main.player[Projectile.owner].itemAnimation < Main.player[Projectile.owner].itemAnimationMax / 3)
			{
				Projectile.ai[0] -= 1.0f; //How far back it goes
				if (Projectile.localAI[0] == 0f && Main.myPlayer == Projectile.owner)
				{
					Projectile.localAI[0] = 1f;
					if (Collision.CanHit(Main.player[Projectile.owner].position, Main.player[Projectile.owner].width, Main.player[Projectile.owner].height, new Vector2(Projectile.Center.X + Projectile.velocity.X * Projectile.ai[0], Projectile.Center.Y + Projectile.velocity.Y * Projectile.ai[0]), Projectile.width, Projectile.height))
					{
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X + Projectile.velocity.X, Projectile.Center.Y + Projectile.velocity.Y, Projectile.velocity.X * 1.5f, Projectile.velocity.Y * 1.5f, 85, Projectile.damage, Projectile.knockBack * 0.85f, Projectile.owner, 0f, 0f);
					}
				}
			}
			else
			{
				Projectile.ai[0] += 0.65f; //How far it goes
			}

			//Kills projectile once item is done animating
			if (Main.player[Projectile.owner].itemAnimation == 0)
			{
				Projectile.Kill();
			}

			//Rotate spear
			Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 2.355f;
			if (Projectile.spriteDirection == -1)
			{
				Projectile.rotation -= 1.57f;
			}
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (Main.rand.NextBool(2))
			{
				target.AddBuff(24, 180, false);
			}
		}
	}
}
