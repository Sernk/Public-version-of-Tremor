using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class ManiacChainsawPro : ModProjectile
	{
		public override void SetDefaults()
		{
			//projectile.CloneDefaults(509);

			//aiType = 509;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Main.projFrames[Projectile.type] = 2;
			Projectile.width = 34;
			Projectile.height = 140;

			Projectile.tileCollide = false;
			Projectile.hide = true;
			Projectile.ownerHitCheck = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("ManiacChainsawPro");

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

			Projectile.frameCounter += 1;
			if (Projectile.frameCounter >= 4)
			{
				Projectile.frameCounter = 0;
				Projectile.frame++;
				if (Projectile.frame >= 2)
				{
					Projectile.frame = 0;
				}
			}

			SoundEngine.PlaySound(SoundID.Item22, Projectile.position);
		}
	}
}
