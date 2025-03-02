using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace TremorMod.Content.Projectiles
{
	public class CyberCutterPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 38;
			Projectile.height = 38;
			Projectile.scale = 1.1f;
            Projectile.aiStyle = 0;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.tileCollide = true;
			Projectile.ignoreWater = true;
			Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 50;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("CyberCutterPro");

		}*/

		public override void AI()
		{
			Projectile.light = 0.9f;
			int DustID1 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 60, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 120, default(Color), 1.75f);
			int DustID2 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 60, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 120, default(Color), 1.75f);
			int DustID3 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 60, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 120, default(Color), 1.75f);
			Main.dust[DustID1].noGravity = true;
			Main.dust[DustID2].noGravity = true;
			Main.dust[DustID3].noGravity = true;
			Projectile.rotation += Projectile.direction * 0.8f;
			if (Main.myPlayer == Projectile.owner && Projectile.ai[0] == 0f)
			{
				Projectile.rotation += Projectile.direction * 0.8f;
				if (Main.player[Projectile.owner].channel)
				{
					Projectile.rotation += Projectile.direction * 0.8f;
					float num146 = 12f;
					Vector2 vector10 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
					Projectile.rotation += Projectile.direction * 0.8f;
					float num147 = Main.mouseX + Main.screenPosition.X - vector10.X;
					Projectile.rotation += Projectile.direction * 0.8f;
					float num148 = Main.mouseY + Main.screenPosition.Y - vector10.Y;
					Projectile.rotation += Projectile.direction * 0.8f;
					if (Main.player[Projectile.owner].gravDir == -1f)
					{
						num148 = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - vector10.Y;
						Projectile.rotation += Projectile.direction * 0.8f;
					}
					float num149 = (float)Math.Sqrt(num147 * num147 + num148 * num148);
					num149 = (float)Math.Sqrt(num147 * num147 + num148 * num148);
					if (num149 > num146)
					{
						Projectile.rotation += Projectile.direction * 0.8f;
						num149 = num146 / num149;
						num147 *= num149;
						num148 *= num149;
						int num150 = (int)(num147 * 1000f);
						int num151 = (int)(Projectile.velocity.X * 1000f);
						Projectile.rotation += Projectile.direction * 0.8f;
						int num152 = (int)(num148 * 1000f);
						int num153 = (int)(Projectile.velocity.Y * 1000f);
						Projectile.rotation += Projectile.direction * 0.8f;
						if (num150 != num151 || num152 != num153)
						{
							Projectile.rotation += Projectile.direction * 0.8f;
							Projectile.netUpdate = true;
							Projectile.rotation += Projectile.direction * 0.8f;
						}
						Projectile.velocity.X = num147;
						Projectile.rotation += Projectile.direction * 0.8f;
						Projectile.velocity.Y = num148;
						Projectile.rotation += Projectile.direction * 0.8f;
					}
					else
					{
						Projectile.rotation += Projectile.direction * 0.8f;
						int num154 = (int)(num147 * 1000f);
						int num155 = (int)(Projectile.velocity.X * 1000f);
						Projectile.rotation += Projectile.direction * 0.8f;
						int num156 = (int)(num148 * 1000f);
						int num157 = (int)(Projectile.velocity.Y * 1000f);
						Projectile.rotation += Projectile.direction * 0.8f;
						if (num154 != num155 || num156 != num157)
						{
							Projectile.rotation += Projectile.direction * 0.8f;
							Projectile.netUpdate = true;
							Projectile.rotation += Projectile.direction * 0.8f;
						}
						Projectile.velocity.X = num147;
						Projectile.rotation += Projectile.direction * 0.8f;
						Projectile.velocity.Y = num148;
						Projectile.rotation += Projectile.direction * 0.8f;
					}
					Projectile.rotation += Projectile.direction * 0.8f;
				}
				else
				{
					Projectile.rotation += Projectile.direction * 0.8f;
					if (Projectile.ai[0] == 0f)
					{
						Projectile.ai[0] = 1f;
						Projectile.rotation += Projectile.direction * 0.8f;
						Projectile.netUpdate = true;
						Projectile.rotation += Projectile.direction * 0.8f;
						float num158 = 12f;
						Vector2 vector11 = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
						float num159 = Main.mouseX + Main.screenPosition.X - vector11.X;
						Projectile.rotation += Projectile.direction * 0.8f;
						float num160 = Main.mouseY + Main.screenPosition.Y - vector11.Y;
						Projectile.rotation += Projectile.direction * 0.8f;
						if (Main.player[Projectile.owner].gravDir == -1f)
						{
							num160 = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - vector11.Y;
							Projectile.rotation += Projectile.direction * 0.8f;
						}
						float num161 = (float)Math.Sqrt(num159 * num159 + num160 * num160);
						if (num161 == 0f)
						{
							vector11 = new Vector2(Main.player[Projectile.owner].position.X + Main.player[Projectile.owner].width / 2, Main.player[Projectile.owner].position.Y + Main.player[Projectile.owner].height / 2);
							Projectile.rotation += Projectile.direction * 0.8f;
							num159 = Projectile.position.X + Projectile.width * 0.5f - vector11.X;
							Projectile.rotation += Projectile.direction * 0.8f;
							num160 = Projectile.position.Y + Projectile.height * 0.5f - vector11.Y;
							Projectile.rotation += Projectile.direction * 0.8f;
							num161 = (float)Math.Sqrt(num159 * num159 + num160 * num160);
						}
						num161 = num158 / num161;
						num159 *= num161;
						num160 *= num161;
						Projectile.velocity.X = num159;
						Projectile.rotation += Projectile.direction * 0.8f;
						Projectile.velocity.Y = num160;
						Projectile.rotation += Projectile.direction * 0.8f;
						if (Projectile.velocity.X == 0f && Projectile.velocity.Y == 0f)
						{
							Projectile.Kill();
						}
					}
					Projectile.rotation += Projectile.direction * 0.8f;
				}
				Projectile.rotation += Projectile.direction * 0.8f;
			}
			Projectile.rotation += Projectile.direction * 0.8f;
			if (Projectile.velocity.X != 0f || Projectile.velocity.Y != 0f)
			{
				Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) - 2.355f;
				Projectile.rotation += Projectile.direction * 0.8f;
			}
			Projectile.rotation += Projectile.direction * 0.8f;
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
				Projectile.rotation += Projectile.direction * 0.8f;
			}
			if (Projectile.timeLeft % 60 == 0)
                SoundEngine.PlaySound(SoundID.Item23, Projectile.position);
        }
		public override bool OnTileCollide(Vector2 velocityChange)
		{
			if (Projectile.velocity.X != velocityChange.X)
			{
				Projectile.velocity.X = -velocityChange.X;
			}
			if (Projectile.velocity.Y != velocityChange.Y)
			{
				Projectile.velocity.Y = -velocityChange.Y;
			}
			Projectile.penetrate -= 1;
			return false;
		}
	}
}
