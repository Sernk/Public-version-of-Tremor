using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class TrueDeathSickleProj : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 120;
			Projectile.height = 112;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = 10;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.hide = true;
			Projectile.ownerHitCheck = false;
			Projectile.DamageType = DamageClass.Melee;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("True Death Sickle");

		}

		public override void AI()
		{
			Projectile.soundDelay--;
			if (Projectile.soundDelay <= 0)
			{
				SoundEngine.PlaySound(SoundID.Item71, Projectile.Center);
				Projectile.soundDelay = 45;
			}
			Player player = Main.player[Projectile.owner];
			if (Main.myPlayer == Projectile.owner)
			{
				if (!player.channel || player.noItems || player.CCed)
				{
					Projectile.Kill();
				}
				else
				{
					Projectile.ai[0] -= 1f;
					if (Projectile.ai[0] <= 0f)
					{
						Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
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
						int num6 = 274;
						float scaleFactor2 = 14f;
						int num7 = 7;
						value2 = Projectile.Center + new Vector2(Main.rand.Next(-num7, num7 + 1), Main.rand.Next(-num7, num7 + 1));
						Vector2 spinningpoint = Vector2.Normalize(Projectile.velocity) * scaleFactor2;
						spinningpoint = spinningpoint.RotatedBy(Main.rand.NextDouble() * 0.19634954631328583 - 0.098174773156642914, default(Vector2));
						if (float.IsNaN(spinningpoint.X) || float.IsNaN(spinningpoint.Y))
						{
							spinningpoint = -Vector2.UnitY;
						}
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), value2.X, value2.Y, spinningpoint.X, spinningpoint.Y, num6, Projectile.damage, Projectile.knockBack, Projectile.owner, 0f, 0f);
						Projectile.ai[0] = 50f;
					}
				}
			}
			Projectile.Center = player.MountedCenter;
			Projectile.position.X += player.width / 2 * player.direction;
			Projectile.spriteDirection = player.direction;
			Projectile.timeLeft = 2;
			Projectile.rotation += 0.19f * player.direction;
			if (Projectile.rotation > MathHelper.TwoPi)
			{
				Projectile.rotation -= MathHelper.TwoPi;
			}
			else if (Projectile.rotation < 0)
			{
				Projectile.rotation += MathHelper.TwoPi;
			}
			player.heldProj = Projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = Projectile.rotation;
		}
	}
}
