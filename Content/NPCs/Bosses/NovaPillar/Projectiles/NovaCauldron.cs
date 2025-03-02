using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Utilities;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Filters = Terraria.Graphics.Effects.Filters;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs.Bosses.NovaPillar.Projectiles
{
	public class NovaCauldron : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.netImportant = true;
			Projectile.friendly = true;
			Projectile.ignoreWater = true;
			Projectile.timeLeft = 18000;
			Projectile.penetrate = -1;
			Projectile.timeLeft *= 5;
			Projectile.tileCollide = false;
			Projectile.minion = true;
			Main.projFrames[Projectile.type] = 4;
			Projectile.width = 32;
			Projectile.height = 30;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void AI()
		{
			Projectile.frameCounter++;
			if (Projectile.frameCounter > 4)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
			}
			if (Projectile.frame >= 4)
			{
				Projectile.frame = 0;
			}
			bool Flag1 = Projectile.type == ModContent.ProjectileType<NovaCauldron>();
			Player player = Main.player[Projectile.owner];
			MPlayer modPlayer = MPlayer.GetModPlayer(player);
			if (Flag1)
			{
				if (player.dead)
				{
					modPlayer.novaSet = false;
				}
				if (modPlayer.novaSet)
				{
					Projectile.timeLeft = 2;
				}
			}
			if (!modPlayer.novaSet)
			{
				Projectile.Kill();
			}
			Projectile.rotation = 0f;
			Vector2 value = Projectile.position;
			float num2 = 500f;
			bool flag = false;
			Projectile.tileCollide = true;
			for (int j = 0; j < 200; j++)
			{
				NPC nPC = Main.npc[j];
				if (nPC.CanBeChasedBy(this, false))
				{
					float num3 = Vector2.Distance(nPC.Center, Projectile.Center);
					if ((num3 < num2 || !flag) && Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, nPC.position, nPC.width, nPC.height))
					{
						num2 = num3;
						value = nPC.Center;
						flag = true;
					}
				}
			}
			if (Vector2.Distance(player.Center, Projectile.Center) > (flag ? 1000f : 500f))
			{
				Projectile.ai[0] = 1f;
				Projectile.netUpdate = true;
			}
			if (Projectile.ai[0] == 1f)
			{
				Projectile.tileCollide = false;
			}
			if (flag && Projectile.ai[0] == 0f)
			{
				Vector2 value2 = value - Projectile.Center;
				if (value2.Length() > 200f)
				{
					value2.Normalize();
					Projectile.velocity = (Projectile.velocity * 20f + value2 * 6f) / 21f;
				}
				else
				{
					Projectile.velocity *= (float)Math.Pow(0.97, 2.0);
				}
			}
			else
			{
				if (!Collision.CanHitLine(Projectile.Center, 1, 1, player.Center, 1, 1))
				{
					Projectile.ai[0] = 1f;
				}
				float num4 = 6f;
				if (Projectile.ai[0] == 1f)
				{
					num4 = 15f;
				}
				Vector2 center = Projectile.Center;
				Vector2 vector = player.Center - center;
				Projectile.ai[1] = 3600f;
				Projectile.netUpdate = true;
				int num5 = 1;
				for (int k = 0; k < Projectile.whoAmI; k++)
				{
					if (Main.projectile[k].active && Main.projectile[k].owner == Projectile.owner && Main.projectile[k].type == Projectile.type)
					{
						num5++;
					}
				}
				vector.X -= (10 + num5 * 40) * player.direction;
				vector.Y -= 70f;
				float num6 = vector.Length();
				if (num6 > 200f && num4 < 9f)
				{
					num4 = 9f;
				}
				if (num6 < 100f && Projectile.ai[0] == 1f && !Collision.SolidCollision(Projectile.position, Projectile.width, Projectile.height))
				{
					Projectile.ai[0] = 0f;
					Projectile.netUpdate = true;
				}
				if (num6 > 2000f)
				{
					Projectile.Center = player.Center;
				}
				if (num6 > 48f)
				{
					vector.Normalize();
					vector *= num4;
					float num7 = 10f;
					Projectile.velocity = (Projectile.velocity * num7 + vector) / (num7 + 1f);
				}
				else
				{
					Projectile.direction = Main.player[Projectile.owner].direction;
					Projectile.velocity *= (float)Math.Pow(0.9, 2.0);
				}
			}
			Projectile.rotation = Projectile.velocity.X * 0.05f;
			if (Projectile.velocity.X > 0f)
			{
				Projectile.spriteDirection = (Projectile.direction = -1);
			}
			else if (Projectile.velocity.X < 0f)
			{
				Projectile.spriteDirection = (Projectile.direction = 1);
			}
			if (Projectile.ai[1] > 0f)
			{
				Projectile.ai[1] += 1f;
			}
			if (Projectile.ai[1] > 140f)
			{
				Projectile.ai[1] = 0f;
				Projectile.netUpdate = true;
			}
			if (Projectile.ai[0] == 0f && flag)
			{
				if ((value - Projectile.Center).X > 0f)
				{
					Projectile.spriteDirection = (Projectile.direction = -1);
				}
				else if ((value - Projectile.Center).X < 0f)
				{
					Projectile.spriteDirection = (Projectile.direction = 1);
				}
			}
			if (Projectile.owner == Main.myPlayer)
			{
				if (Projectile.ai[0] != 0f)
				{
					Projectile.ai[0] -= 1f;
					return;
				}
				float Num3 = Projectile.position.X;
				float Num4 = Projectile.position.Y;
				float Num5 = 700f;
				bool Flag2 = false;
				for (int k = 0; k < 200; k++)
				{
					if (Main.npc[k].CanBeChasedBy(Projectile, true))
					{
						float Num6 = Main.npc[k].position.X + Main.npc[k].width / 2;
						float Num7 = Main.npc[k].position.Y + Main.npc[k].height / 2;
						float Num8 = Math.Abs(Projectile.position.X + Projectile.width / 2 - Num6) + Math.Abs(Projectile.position.Y + Projectile.height / 2 - Num7);
						if (Num8 < Num5 && Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, Main.npc[k].position, Main.npc[k].width, Main.npc[k].height))
						{
							Num5 = Num8;
							Num3 = Num6;
							Num4 = Num7;
							Flag2 = true;
						}
					}
				}
                if (Flag2)
                {
                    float Num9 = 12f;
                    Vector2 Vector = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
                    float Num10 = Num3 - Vector.X;
                    float Num11 = Num4 - Vector.Y;
                    float Num12 = (float)Math.Sqrt(Num10 * Num10 + Num11 * Num11);
                    Num12 = Num9 / Num12;
                    Num10 *= Num12;
                    Num11 *= Num12;

                    // Исправление аргументов для NewProjectile
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X - 4f, Projectile.Center.Y, Num10, Num11, ModContent.ProjectileType<NovaCauldron_Fire>(), 65, Projectile.knockBack, Projectile.owner, 0f, 0f);
                    Projectile.ai[0] = 50f;
                }

            }
        }
	}
}