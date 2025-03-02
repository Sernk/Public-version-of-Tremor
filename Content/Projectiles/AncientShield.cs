using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace TremorMod.Content.Projectiles
{
	public class AncientShield : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 28;
			Projectile.height = 36;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 2;
			Projectile.tileCollide = false;
			Projectile.timeLeft = 660;
			Projectile.light = 0;
			Projectile.extraUpdates = 1;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 9;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
			Main.projFrames[Projectile.type] = 3;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("AncientShield");

		}

        public override bool PreAI()
        {
			//float Num = 4f;
			//float Num2 = 1.1f;
			int Num3 = 1;
			if (Projectile.position.X + Projectile.width / 2 < Main.player[Projectile.owner].position.X + Main.player[Projectile.owner].width)
			{
				Num3 = -1;
			}
			Vector2 Vector1 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
			float Num4 = Main.player[Projectile.owner].position.X + Main.player[Projectile.owner].width / 2 + Num3 * 180 - Vector1.X;
			float Num5 = Main.player[Projectile.owner].position.Y + Main.player[Projectile.owner].height / 2 - Vector1.Y;
			float Num6 = (float)Math.Sqrt(Num4 * Num4 + Num5 * Num5);
			float Num7 = Projectile.position.X + Projectile.width / 2 - Main.player[Projectile.owner].position.X - Main.player[Projectile.owner].width / 2;
			float Num8 = Projectile.position.Y + Projectile.height - 59f - Main.player[Projectile.owner].position.Y - Main.player[Projectile.owner].height / 2;
			float Num9 = (float)Math.Atan2(Num8, Num7) + 1.57f;
			if (Num9 < 0f)
			{
				Num9 += 6.283f;
			}
			else if (Num9 > 6.283)
			{
				Num9 -= 6.283f;
			}
			float Num10 = 0.15f;
			if (Projectile.rotation < Num9)
			{
				if (Num9 - Projectile.rotation > 3.1415)
				{
					Projectile.rotation -= Num10;
				}
				else
				{
					Projectile.rotation += Num10;
				}
			}
			else if (Projectile.rotation > Num9)
			{
				if (Projectile.rotation - Num9 > 3.1415)
				{
					Projectile.rotation += Num10;
				}
				else
				{
					Projectile.rotation -= Num10;
				}
			}
			if (Projectile.rotation > Num9 - Num10 && Projectile.rotation < Num9 + Num10)
			{
				Projectile.rotation = Num9;
			}
			if (Projectile.rotation < 0f)
			{
				Projectile.rotation += 6.283f;
			}
			else if (Projectile.rotation > 6.283)
			{
				Projectile.rotation -= 6.283f;
			}
			if (Projectile.rotation > Num9 - Num10 && Projectile.rotation < Num9 + Num10)
			{
				Projectile.rotation = Num9;
			}
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= 16)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
				if (Projectile.frame >= 3)
				{
					Projectile.frame = 0;
				}
			}
			Vector2 direction = Main.player[Projectile.owner].Center - Projectile.Center;
			direction.Normalize();
			direction *= 9f;
			Player player = Main.player[Projectile.owner];
			double deg = (double)Projectile.ai[1] / 2;
			double rad = deg * (Math.PI / 180);
			double dist = 100;
			Projectile.position.X = player.Center.X - (int)(Math.Cos(rad) * dist) - Projectile.width / 2;
			Projectile.position.Y = player.Center.Y - (int)(Math.Sin(rad) * dist) - Projectile.height / 2;
			Projectile.ai[1] += 2f;
			return false;
		}
	}
}
