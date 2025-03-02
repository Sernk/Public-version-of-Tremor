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

namespace TremorMod.Content.NPCs.Bosses.NovaPillar.Projectiles
{
	public class NovaAlchemistProjectile : ModProjectile
	{
		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nova Portal");
		}*/

		public override void SetDefaults()
		{
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.friendly = true;
			Projectile.alpha = 255;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.hostile = true;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255 - Projectile.alpha, 255 - Projectile.alpha, 255 - Projectile.alpha, 255 - Projectile.alpha);
		}

		public override void AI()
		{
			if (Projectile.localAI[0] == 0f)
			{
				Projectile.localAI[0] = 1f;
				int num960 = Player.FindClosest(Projectile.Center, 0, 0);
				Vector2 vector103 = Main.player[num960].Center - Projectile.Center;
				if (vector103 == Vector2.Zero)
				{
					vector103 = Vector2.UnitY;
				}
				Projectile.ai[1] = vector103.ToRotation();
				Projectile.netUpdate = true;
			}
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] <= 50f)
			{
				if (Main.rand.NextBool(2))
				{
					Vector2 vector106 = Projectile.ai[1].ToRotationVector2();
					Vector2 vector107 = vector106.RotatedBy(1.5707963705062866, default(Vector2)) * (Main.rand.NextBool(2)).ToDirectionInt() * Main.rand.Next(10, 21);
					Vector2 value60 = vector106 * Main.rand.Next(-80, 81);
					Vector2 vector108 = value60 - vector107;
					vector108 /= 10f;
					int num961 = 57;
					Dust dust14 = Main.dust[Dust.NewDust(Projectile.Center, 0, 0, num961, 0f, 0f, 0, default(Color), 1f)];
					dust14.noGravity = true;
					dust14.position = Projectile.Center + vector107;
					dust14.velocity = vector108;
					dust14.scale = 0.5f + Main.rand.NextFloat();
					dust14.fadeIn = 0.5f;
					value60 = vector106 * Main.rand.Next(40, 121);
					vector108 = value60 - vector107 / 2f;
					vector108 /= 10f;
					dust14 = Main.dust[Dust.NewDust(Projectile.Center, 0, 0, num961, 0f, 0f, 0, default(Color), 1f)];
					dust14.noGravity = true;
					dust14.position = Projectile.Center + vector107 / 2f;
					dust14.velocity = vector108;
					dust14.scale = 1f + Main.rand.NextFloat();
				}
			}
			else if (Projectile.ai[0] <= 90f)
			{
				Projectile.scale = (Projectile.ai[0] - 50f) / 40f;
				Projectile.alpha = 255 - (int)(255f * Projectile.scale);
				Vector2 vector111 = Projectile.ai[1].ToRotationVector2();
				Vector2 value61 = vector111.RotatedBy(1.5707963705062866, default(Vector2)) * (Main.rand.NextBool(2)).ToDirectionInt() * Main.rand.Next(10, 21);
				vector111 *= (float)Main.rand.Next(-80, 81);
				Vector2 vector112 = vector111 - value61;
				vector112 /= 10f;
				int num962 = Utils.SelectRandom(Main.rand, 57, 57);
				Dust dust17 = Main.dust[Dust.NewDust(Projectile.Center, 0, 0, num962, 0f, 0f, 0, default(Color), 1f)];
				dust17.noGravity = true;
				dust17.position = Projectile.Center + value61;
				dust17.velocity = vector112;
				dust17.scale = 0.5f + Main.rand.NextFloat();
				dust17.fadeIn = 0.5f;
                if (Projectile.ai[0] == 90f && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Vector2 vector113 = Projectile.ai[1].ToRotationVector2() * 8f;
                    float ai2 = Main.rand.Next(80);

                    Projectile.NewProjectile(
                        Projectile.GetSource_FromAI(), // Источник
                        Projectile.Center - vector113, // Позиция
                        vector113, // Скорость
                        ModContent.ProjectileType<NovaFlask_Proj>(), // Тип снаряда
                        15, // Урон
                        1f, // Отдача
                        Main.myPlayer, // Владелец
                        Projectile.ai[1], // AI0
                        ai2 // AI1
                    );
                }

            }
            else
			{
				if (Projectile.ai[0] > 120f)
				{
					Projectile.scale = 1f - (Projectile.ai[0] - 120f) / 60f;
					Projectile.alpha = 255 - (int)(255f * Projectile.scale);
					if (Projectile.alpha >= 255)
					{
						Projectile.Kill();
					}
					for (int num965 = 0; num965 < 2; num965++)
					{
						int num966 = Main.rand.Next(3);
						if (num966 == 0)
						{
							Vector2 vector114 = Vector2.UnitY.RotatedByRandom(6.2831854820251465) * Projectile.scale;
							Dust dust18 = Main.dust[Dust.NewDust(Projectile.Center - vector114 * 30f, 0, 0, 57, 0f, 0f, 0, default(Color), 1f)];
							dust18.noGravity = true;
							dust18.position = Projectile.Center - vector114 * Main.rand.Next(10, 21);
							dust18.velocity = vector114.RotatedBy(1.5707963705062866, default(Vector2)) * 6f;
							dust18.scale = 0.5f + Main.rand.NextFloat();
							dust18.fadeIn = 0.5f;
							dust18.customData = Projectile.Center;
						}
						else if (num966 == 1)
						{
							Vector2 vector115 = Vector2.UnitY.RotatedByRandom(6.2831854820251465) * Projectile.scale;
							Dust dust19 = Main.dust[Dust.NewDust(Projectile.Center - vector115 * 30f, 0, 0, 57, 0f, 0f, 0, default(Color), 1f)];
							dust19.noGravity = true;
							dust19.position = Projectile.Center - vector115 * 30f;
							dust19.velocity = vector115.RotatedBy(-1.5707963705062866, default(Vector2)) * 3f;
							dust19.scale = 0.5f + Main.rand.NextFloat();
							dust19.fadeIn = 0.5f;
							dust19.customData = Projectile.Center;
						}
					}
					return;
				}
				Projectile.scale = 1f;
				Projectile.alpha = 0;
				if (Main.rand.NextBool(2))
				{
					Vector2 vector116 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
					Dust dust20 = Main.dust[Dust.NewDust(Projectile.Center - vector116 * 30f, 0, 0, 57, 0f, 0f, 0, default(Color), 1f)];
					dust20.noGravity = true;
					dust20.position = Projectile.Center - vector116 * Main.rand.Next(10, 21);
					dust20.velocity = vector116.RotatedBy(1.5707963705062866, default(Vector2)) * 6f;
					dust20.scale = 0.5f + Main.rand.NextFloat();
					dust20.fadeIn = 0.5f;
					dust20.customData = Projectile.Center;
					return;
				}
				Vector2 vector117 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
				Dust dust21 = Main.dust[Dust.NewDust(Projectile.Center - vector117 * 30f, 0, 0, 57, 0f, 0f, 0, default(Color), 1f)];
				dust21.noGravity = true;
				dust21.position = Projectile.Center - vector117 * 30f;
				dust21.velocity = vector117.RotatedBy(-1.5707963705062866, default(Vector2)) * 3f;
				dust21.scale = 0.5f + Main.rand.NextFloat();
				dust21.fadeIn = 0.5f;
				dust21.customData = Projectile.Center;
			}
		}
	}
}
