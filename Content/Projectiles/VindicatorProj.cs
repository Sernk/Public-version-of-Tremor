using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{

	public class VindicatorProj : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 26;
			Projectile.height = 76;
			//Main.projFrames[projectile.type] = 6;
			//projectile.aiStyle = 20;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.hide = true;
			Projectile.ownerHitCheck = true;
			Projectile.DamageType = DamageClass.Ranged;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Vindicator");

		}

		public override void AI()
		{
			Vector2 vector22;
			float num263;
			Vector2 vector23;
			float num264;
			float num265;
			float num266;
			//int num267;
			vector22 = Main.player[Projectile.owner].RotatedRelativePoint(Main.player[Projectile.owner].MountedCenter, true);
			if (Main.myPlayer == Projectile.owner)
			{
				if (Main.player[Projectile.owner].channel)
				{
					num263 = Main.player[Projectile.owner].inventory[Main.player[Projectile.owner].selectedItem].shootSpeed * Projectile.scale;
					vector23 = vector22;
					num264 = Main.mouseX + Main.screenPosition.X - vector23.X - 20;
					num265 = Main.mouseY + Main.screenPosition.Y - vector23.Y;
					if (Main.player[Projectile.owner].gravDir == -1f)
					{
						num265 = Main.screenHeight - Main.mouseY + Main.screenPosition.Y - vector23.Y;
					}
					num266 = (float)Math.Sqrt(num264 * num264 + num265 * num265);
					num266 = (float)Math.Sqrt(num264 * num264 + num265 * num265);
					num266 = num263 / num266;
					num264 *= num266;
					num265 *= num266;
					if (num264 != Projectile.velocity.X || num265 != Projectile.velocity.Y)
					{
						Projectile.netUpdate = true;
					}
					Projectile.velocity.X = num264;
					Projectile.velocity.Y = num265;
				}
				else
				{
					Projectile.Kill();
				}
			}
			if (Projectile.velocity.X > 0f)
			{
				Main.player[Projectile.owner].ChangeDir(1);
			}
			else if (Projectile.velocity.X < 0f)
			{
				Main.player[Projectile.owner].ChangeDir(-1);
			}
			Projectile.spriteDirection = Projectile.direction;
			Main.player[Projectile.owner].ChangeDir(Projectile.direction);
			Main.player[Projectile.owner].heldProj = Projectile.whoAmI;
			Main.player[Projectile.owner].itemTime = 2;
			Main.player[Projectile.owner].itemAnimation = 2;
			Projectile.position.X = vector22.X - Projectile.width / 2;
			Projectile.position.Y = vector22.Y - Projectile.height / 2;
			Projectile.rotation = (float)(Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.5700000524520874);
			if (Main.player[Projectile.owner].direction == 1)
			{
				Main.player[Projectile.owner].itemRotation = (float)Math.Atan2(Projectile.velocity.Y * Projectile.direction, Projectile.velocity.X * Projectile.direction);
			}
			else
			{
				Main.player[Projectile.owner].itemRotation = (float)Math.Atan2(Projectile.velocity.Y * Projectile.direction, Projectile.velocity.X * Projectile.direction);
			}
			Projectile.velocity.X = Projectile.velocity.X * (1f + Main.rand.Next(-3, 4) * 0.01f);
			Player player = Main.player[Projectile.owner];
			//float num = 1.57079637f;
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			Projectile.ai[0] += 1f;
			int num2 = 0;
			if (Projectile.ai[0] >= 40f)
			{
				num2++;
			}
			if (Projectile.ai[0] >= 80f)
			{
				num2++;
			}
			if (Projectile.ai[0] >= 120f)
			{
				num2++;
			}
			int num3 = 24;
			int num4 = 6;
			Projectile.ai[1] += 1f;
			bool flag = false;
			if (Projectile.ai[1] >= num3 - num4 * num2)
			{
				Projectile.ai[1] = 0f;
				flag = true;
			}
			Projectile.frameCounter += 1 + num2;
			if (Projectile.frameCounter >= 4)
			{
				Projectile.frameCounter = 0;
				Projectile.frame++;
				if (Projectile.frame >= 6)
				{
					Projectile.frame = 0;
				}
			}
			if (Projectile.soundDelay <= 0)
			{
				Projectile.soundDelay = num3 - num4 * num2;
				if (Projectile.ai[0] != 1f)
				{

				}
			}
			if (Projectile.ai[1] == 1f && Projectile.ai[0] != 1f)
			{
				Vector2 vector2 = Vector2.UnitX * 24f;
				vector2 = vector2.RotatedBy(Projectile.rotation - 1.57079637f, default(Vector2));
				Vector2 value = Projectile.Center + vector2;
				for (int i = 0; i < 2; i++)
				{
					/* TODO: CryotechDust does not exist
                    int num5 = Dust.NewDust(value - Vector2.One * 8f, 16, 16, mod.DustType<Dusts.CryotechDust>(), projectile.velocity.X / 2f, projectile.velocity.Y / 2f, 100, default(Color), 1f);
                    Main.dust[num5].velocity *= 0.66f;
                    Main.dust[num5].noGravity = true;
                    Main.dust[num5].scale = 1.4f;
					*/
				}
			}
			if (flag && Main.myPlayer == Projectile.owner)
			{
				bool flag2 = player.channel && player.CheckMana(player.inventory[player.selectedItem].mana, true, false) && !player.noItems && !player.CCed;
				if (flag2)
				{
					float scaleFactor = player.inventory[player.selectedItem].shootSpeed * Projectile.scale;
					Vector2 value2 = vector;
					Vector2 value3 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - value2;
					if (player.gravDir == -1f)
					{
						value3.Y = Main.screenHeight - Main.mouseY + Main.screenPosition.Y - value2.Y;
					}
					Vector2 vector3 = Vector2.Normalize(value3);
					if (float.IsNaN(vector3.X) || float.IsNaN(vector3.Y))
					{
						vector3 = -Vector2.UnitY;
					}
					vector3 *= scaleFactor;
					if (vector3.X != Projectile.velocity.X || vector3.Y != Projectile.velocity.Y)
					{
						Projectile.netUpdate = true;
					}
					Projectile.velocity = vector3;
					int num6 = 14;
					float scaleFactor2 = 28f;
					int num7 = 7;
					for (int j = 0; j < 2; j++)
					{
						value2 = Projectile.Center + new Vector2(Main.rand.Next(-num7, num7 + 1), Main.rand.Next(-num7, num7 + 1));
						Vector2 spinningpoint = Vector2.Normalize(Projectile.velocity) * scaleFactor2;
						spinningpoint = spinningpoint.RotatedBy(Main.rand.NextDouble() * 0.19634954631328583 - 0.098174773156642914, default(Vector2));
						if (float.IsNaN(spinningpoint.X) || float.IsNaN(spinningpoint.Y))
						{
							spinningpoint = -Vector2.UnitY;
						}
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), value2.X + 10, value2.Y + 10, spinningpoint.X, spinningpoint.Y, num6, Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
					}
				}
				else
				{
					Projectile.Kill();
				}
			}
		}
	}
}
