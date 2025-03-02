using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class RelayxDragonBig : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 45;
			Projectile.height = 80;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.tileCollide = false;
			Projectile.penetrate = 1;
			Projectile.extraUpdates = 1;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
			AIType = ProjectileID.Bullet;
			Main.projFrames[Projectile.type] = 4;
		}

		public override bool PreAI()
		{
			Projectile.spriteDirection = Projectile.direction;
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= 6)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
				if (Projectile.frame >= 4)
				{
					Projectile.frame = 0;
				}
			}
			return true;
		}

		public override void AI()
		{
			Projectile.spriteDirection = Projectile.direction;
			if (Main.rand.NextBool(3))
			{
				int dust2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 59, 0f, 0f, 100, default(Color), 1f);
				Main.dust[dust2].noGravity = true;
				Main.dust[dust2].velocity *= 0f;
			}

			float CenterX = Projectile.Center.X;
			float CenterY = Projectile.Center.Y;
			float Distanse = 400f;
			bool CheckDistanse = false;
			for (int MobCounts = 0; MobCounts < 200; MobCounts++)
			{
				if (Main.npc[MobCounts].CanBeChasedBy(Projectile, false) && Collision.CanHit(Projectile.Center, 1, 1, Main.npc[MobCounts].Center, 1, 1))
				{
					float Position1 = Main.npc[MobCounts].position.X + Main.npc[MobCounts].width / 2;
					float Position2 = Main.npc[MobCounts].position.Y + Main.npc[MobCounts].height / 2;
					float Position3 = Math.Abs(Projectile.position.X + Projectile.width / 2 - Position1) + Math.Abs(Projectile.position.Y + Projectile.height / 2 - Position2);
					if (Position3 < Distanse)
					{
						Distanse = Position3;
						CenterX = Position1;
						CenterY = Position2;
						CheckDistanse = true;
					}
				}
			}
			if (CheckDistanse)
			{
				float Speed = 8f;
				Vector2 FinalPos = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
				float NewPosX = CenterX - FinalPos.X;
				float NewPosY = CenterY - FinalPos.Y;
				float FinPos = (float)Math.Sqrt(NewPosX * NewPosX + NewPosY * NewPosY);
				FinPos = Speed / FinPos;
				NewPosX *= FinPos;
				NewPosY *= FinPos;
				Projectile.velocity.X = (Projectile.velocity.X * 20f + NewPosX) / 21f;
				Projectile.velocity.Y = (Projectile.velocity.Y * 20f + NewPosY) / 21f;
			}
		}

		public override void OnKill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 59, Projectile.oldVelocity.X * 0.7f, Projectile.oldVelocity.Y * 0.7f);
			}
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 59, Projectile.oldVelocity.X * 0.7f, Projectile.oldVelocity.Y * 0.7f);
			}
			Main.player[Projectile.owner].statLife += 10;
			Main.player[Projectile.owner].HealEffect(10);
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 59, Projectile.oldVelocity.X * 0.7f, Projectile.oldVelocity.Y * 0.7f);
				Projectile.Kill();
			}
			return true;
		}
	}
}