﻿using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Armor.DesertExplorer;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.NPCs
{ 
    public class DesertPrincess2 : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Desert Wasp");
			Main.npcFrameCount[NPC.type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.npcSlots = 5f;
			NPC.aiStyle = -1;
			AIType = -1;
			NPC.damage = 65;
			NPC.width = 56;
			NPC.height = 56;
			NPC.defense = 45;
			NPC.lifeMax = 2500;
			NPC.knockBackResist = 0f;

			NPC.buffImmune[BuffID.Poisoned] = true;
			NPC.buffImmune[BuffID.Venom] = true;
			NPC.buffImmune[BuffID.Confused] = true;

			NPC.lavaImmune = true;
			NPC.noGravity = true;
			NPC.HitSound = SoundID.NPCHit45;
			NPC.DeathSound = SoundID.NPCDeath47;
		}

		Rectangle GetFrame(int Number)
		{
			return new Rectangle(0, NPC.frame.Height * (Number - 1), NPC.frame.Width, NPC.frame.Height);
		}

		int CurrentFrame;
		int TimeToAnimation = 4;
		public override void AI()
		{
			if (--TimeToAnimation <= 0)
			{
				if (++CurrentFrame > 2)
					CurrentFrame = 1;
				TimeToAnimation = 4;
				NPC.frame = GetFrame(CurrentFrame + 0);
			}
			int num1305 = 3;
			NPC.noTileCollide = false;
			NPC.noGravity = true;
			NPC.damage = NPC.defDamage;
			if (NPC.target < 0 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
			{
				NPC.TargetClosest(true);
				Vector2 vector204 = Main.player[NPC.target].Center - NPC.Center;
				if (Main.player[NPC.target].dead || vector204.Length() > 3000f)
				{
					NPC.ai[0] = -1f;
				}
			}
			else
			{
				Vector2 vector205 = Main.player[NPC.target].Center - NPC.Center;
				if (NPC.ai[0] > 1f && vector205.Length() > 1000f)
				{
					NPC.ai[0] = 1f;
				}
			}
			if (NPC.ai[0] == -1f)
			{
				Vector2 value50 = new Vector2(0f, -8f);
				NPC.velocity = (NPC.velocity * 9f + value50) / 10f;
				NPC.noTileCollide = true;
				NPC.dontTakeDamage = true;
				return;
			}
			if (NPC.ai[0] == 0f)
			{
				NPC.TargetClosest(true);
				if (NPC.Center.X < Main.player[NPC.target].Center.X - 2f)
				{
					NPC.direction = 1;
				}
				if (NPC.Center.X > Main.player[NPC.target].Center.X + 2f)
				{
					NPC.direction = -1;
				}
				NPC.spriteDirection = NPC.direction;
				NPC.rotation = (NPC.rotation * 9f + NPC.velocity.X * 0.1f) / 10f;
				if (NPC.collideX)
				{
					NPC.velocity.X = NPC.velocity.X * (-NPC.oldVelocity.X * 0.5f);
					if (NPC.velocity.X > 4f)
					{
						NPC.velocity.X = 4f;
					}
					if (NPC.velocity.X < -4f)
					{
						NPC.velocity.X = -4f;
					}
				}
				if (NPC.collideY)
				{
					NPC.velocity.Y = NPC.velocity.Y * (-NPC.oldVelocity.Y * 0.5f);
					if (NPC.velocity.Y > 4f)
					{
						NPC.velocity.Y = 4f;
					}
					if (NPC.velocity.Y < -4f)
					{
						NPC.velocity.Y = -4f;
					}
				}
				Vector2 value51 = Main.player[NPC.target].Center - NPC.Center;
				value51.Y -= 200f;
				if (value51.Length() > 800f)
				{
					NPC.ai[0] = 1f;
					NPC.ai[1] = 0f;
					NPC.ai[2] = 0f;
					NPC.ai[3] = 0f;
				}
				else if (value51.Length() > 80f)
				{
					float scaleFactor15 = 6f;
					float num1306 = 30f;
					value51.Normalize();
					value51 *= scaleFactor15;
					NPC.velocity = (NPC.velocity * (num1306 - 1f) + value51) / num1306;
				}
				else if (NPC.velocity.Length() > 2f)
				{
					NPC.velocity *= 0.95f;
				}
				else if (NPC.velocity.Length() < 1f)
				{
					NPC.velocity *= 1.05f;
				}
				NPC.ai[1] += 1f;
				if (NPC.justHit)
				{
					NPC.ai[1] += Main.rand.Next(10, 30);
				}
				if (NPC.ai[1] >= 180f && Main.netMode != 1)
				{
					NPC.ai[1] = 0f;
					NPC.ai[2] = 0f;
					NPC.ai[3] = 0f;
					NPC.netUpdate = true;
					while (NPC.ai[0] == 0f)
					{
						int num1307 = Main.rand.Next(3);
						if (num1307 == 0 && Collision.CanHit(NPC.Center, 1, 1, Main.player[NPC.target].Center, 1, 1))
						{
							NPC.ai[0] = 2f;
						}
						else if (num1307 == 1)
						{
							NPC.ai[0] = 3f;
						}
						else if (num1307 == 2 && NPC.CountNPCS(ModContent.NPCType<DesertPrincess2>()) < num1305)
						{
							NPC.ai[0] = 4f;
						}
					}
				}
			}
			else
			{
				if (NPC.ai[0] == 1f)
				{
					NPC.collideX = false;
					NPC.collideY = false;
					NPC.noTileCollide = true;
					if (NPC.target < 0 || !Main.player[NPC.target].active || Main.player[NPC.target].dead)
					{
						NPC.TargetClosest(true);
					}
					if (NPC.velocity.X < 0f)
					{
						NPC.direction = -1;
					}
					else if (NPC.velocity.X > 0f)
					{
						NPC.direction = 1;
					}
					NPC.spriteDirection = NPC.direction;
					NPC.rotation = (NPC.rotation * 9f + NPC.velocity.X * 0.08f) / 10f;
					Vector2 value52 = Main.player[NPC.target].Center - NPC.Center;
					if (value52.Length() < 300f && !Collision.SolidCollision(NPC.position, NPC.width, NPC.height))
					{
						NPC.ai[0] = 0f;
						NPC.ai[1] = 0f;
						NPC.ai[2] = 0f;
						NPC.ai[3] = 0f;
					}
					float scaleFactor16 = 7f + value52.Length() / 100f;
					float num1308 = 25f;
					value52.Normalize();
					value52 *= scaleFactor16;
					NPC.velocity = (NPC.velocity * (num1308 - 1f) + value52) / num1308;
					return;
				}
				if (NPC.ai[0] == 2f)
				{
					NPC.damage = (int)(NPC.defDamage * 0.5);
					if (NPC.target < 0 || !Main.player[NPC.target].active || Main.player[NPC.target].dead)
					{
						NPC.TargetClosest(true);
						NPC.ai[0] = 0f;
						NPC.ai[1] = 0f;
						NPC.ai[2] = 0f;
						NPC.ai[3] = 0f;
					}
					if (Main.player[NPC.target].Center.X - 10f < NPC.Center.X)
					{
						NPC.direction = -1;
					}
					else if (Main.player[NPC.target].Center.X + 10f > NPC.Center.X)
					{
						NPC.direction = 1;
					}
					NPC.spriteDirection = NPC.direction;
					NPC.rotation = (NPC.rotation * 4f + NPC.velocity.X * 0.1f) / 5f;
					if (NPC.collideX)
					{
						NPC.velocity.X = NPC.velocity.X * (-NPC.oldVelocity.X * 0.5f);
						if (NPC.velocity.X > 4f)
						{
							NPC.velocity.X = 4f;
						}
						if (NPC.velocity.X < -4f)
						{
							NPC.velocity.X = -4f;
						}
					}
					if (NPC.collideY)
					{
						NPC.velocity.Y = NPC.velocity.Y * (-NPC.oldVelocity.Y * 0.5f);
						if (NPC.velocity.Y > 4f)
						{
							NPC.velocity.Y = 4f;
						}
						if (NPC.velocity.Y < -4f)
						{
							NPC.velocity.Y = -4f;
						}
					}
					Vector2 value53 = Main.player[NPC.target].Center - NPC.Center;
					value53.Y -= 20f;
					NPC.ai[2] += 0.0222222228f;
					if (Main.expertMode)
					{
						NPC.ai[2] += 0.0166666675f;
					}
					float scaleFactor17 = 4f + NPC.ai[2] + value53.Length() / 120f;
					float num1309 = 20f;
					value53.Normalize();
					value53 *= scaleFactor17;
					NPC.velocity = (NPC.velocity * (num1309 - 1f) + value53) / num1309;
					NPC.ai[1] += 1f;
					if (NPC.ai[1] > 240f || !Collision.CanHit(NPC.Center, 1, 1, Main.player[NPC.target].Center, 1, 1))
					{
						NPC.ai[0] = 0f;
						NPC.ai[1] = 0f;
						NPC.ai[2] = 0f;
						NPC.ai[3] = 0f;
					}
				}
				else
				{
					if (NPC.ai[0] == 3f)
					{
						NPC.noTileCollide = true;
						if (NPC.velocity.X < 0f)
						{
							NPC.direction = -1;
						}
						else
						{
							NPC.direction = 1;
						}
						NPC.spriteDirection = NPC.direction;
						NPC.rotation = (NPC.rotation * 4f + NPC.velocity.X * 0.07f) / 5f;
						Vector2 value54 = Main.player[NPC.target].Center - NPC.Center;
						value54.Y -= 12f;
						if (NPC.Center.X > Main.player[NPC.target].Center.X)
						{
							value54.X += 400f;
						}
						else
						{
							value54.X -= 400f;
						}
						if (Math.Abs(NPC.Center.X - Main.player[NPC.target].Center.X) > 350f && Math.Abs(NPC.Center.Y - Main.player[NPC.target].Center.Y) < 20f)
						{
							NPC.ai[0] = 3.1f;
							NPC.ai[1] = 0f;
						}
						NPC.ai[1] += 0.0333333351f;
						float scaleFactor18 = 8f + NPC.ai[1];
						float num1310 = 4f;
						value54.Normalize();
						value54 *= scaleFactor18;
						NPC.velocity = (NPC.velocity * (num1310 - 1f) + value54) / num1310;
						return;
					}
					if (NPC.ai[0] == 3.1f)
					{
						NPC.noTileCollide = true;
						NPC.rotation = (NPC.rotation * 4f + NPC.velocity.X * 0.07f) / 5f;
						Vector2 vector206 = Main.player[NPC.target].Center - NPC.Center;
						vector206.Y -= 12f;
						float scaleFactor19 = 16f;
						float num1311 = 8f;
						vector206.Normalize();
						vector206 *= scaleFactor19;
						NPC.velocity = (NPC.velocity * (num1311 - 1f) + vector206) / num1311;
						if (NPC.velocity.X < 0f)
						{
							NPC.direction = -1;
						}
						else
						{
							NPC.direction = 1;
						}
						NPC.spriteDirection = NPC.direction;
						NPC.ai[1] += 1f;
						if (NPC.ai[1] > 10f)
						{
							NPC.velocity = vector206;
							if (NPC.velocity.X < 0f)
							{
								NPC.direction = -1;
							}
							else
							{
								NPC.direction = 1;
							}
							NPC.ai[0] = 3.2f;
							NPC.ai[1] = 0f;
							NPC.ai[1] = NPC.direction;
						}
					}
					else
					{
						if (NPC.ai[0] == 3.2f)
						{
							NPC.damage = (int)(NPC.defDamage * 1.3);
							NPC.collideX = false;
							NPC.collideY = false;
							NPC.noTileCollide = true;
							NPC.ai[2] += 0.0333333351f;
							NPC.velocity.X = (16f + NPC.ai[2]) * NPC.ai[1];
							if ((NPC.ai[1] > 0f && NPC.Center.X > Main.player[NPC.target].Center.X + 260f) || (NPC.ai[1] < 0f && NPC.Center.X < Main.player[NPC.target].Center.X - 260f))
							{
								if (!Collision.SolidCollision(NPC.position, NPC.width, NPC.height))
								{
									NPC.ai[0] = 0f;
									NPC.ai[1] = 0f;
									NPC.ai[2] = 0f;
									NPC.ai[3] = 0f;
								}
								else if (Math.Abs(NPC.Center.X - Main.player[NPC.target].Center.X) > 800f)
								{
									NPC.ai[0] = 1f;
									NPC.ai[1] = 0f;
									NPC.ai[2] = 0f;
									NPC.ai[3] = 0f;
								}
							}
							NPC.rotation = (NPC.rotation * 4f + NPC.velocity.X * 0.07f) / 5f;
							return;
						}
						if (NPC.ai[0] == 4f)
						{
							NPC.ai[0] = 0f;
							NPC.TargetClosest(true);
							if (Main.netMode != 1)
							{
								NPC.ai[1] = -1f;
								NPC.ai[2] = -1f;
								for (int num1312 = 0; num1312 < 1000; num1312++)
								{
									int num1313 = (int)Main.player[NPC.target].Center.X / 16;
									int num1314 = (int)Main.player[NPC.target].Center.Y / 16;
									int num1315 = 30 + num1312 / 50;
									int num1316 = 20 + num1312 / 75;
									num1313 += Main.rand.Next(-num1315, num1315 + 1);
									num1314 += Main.rand.Next(-num1316, num1316 + 1);
									if (!WorldGen.SolidTile(num1313, num1314))
									{
										while (!WorldGen.SolidTile(num1313, num1314) && num1314 < Main.worldSurface)
										{
											num1314++;
										}
										if ((new Vector2(num1313 * 16 + 8, num1314 * 16 + 8) - Main.player[NPC.target].Center).Length() < 600f)
										{
											NPC.ai[0] = 4.1f;
											NPC.ai[1] = num1313;
											NPC.ai[2] = num1314;
											break;
										}
									}
								}
							}
							NPC.netUpdate = true;
							return;
						}
						if (NPC.ai[0] == 4.1f)
						{
							if (NPC.velocity.X < -2f)
							{
								NPC.direction = -1;
							}
							else if (NPC.velocity.X > 2f)
							{
								NPC.direction = 1;
							}
							NPC.spriteDirection = NPC.direction;
							NPC.rotation = (NPC.rotation * 9f + NPC.velocity.X * 0.1f) / 10f;
							NPC.noTileCollide = true;
							int num1317 = (int)NPC.ai[1];
							int num1318 = (int)NPC.ai[2];
							float x2 = num1317 * 16 + 8;
							float y2 = num1318 * 16 - 20;
							Vector2 vector207 = new Vector2(x2, y2);
							vector207 -= NPC.Center;
							float num1319 = 6f + vector207.Length() / 150f;
							if (num1319 > 10f)
							{
								num1319 = 10f;
							}
							float num1320 = 10f;
							if (vector207.Length() < 10f)
							{
								NPC.ai[0] = 4.2f;
							}
							vector207.Normalize();
							vector207 *= num1319;
							NPC.velocity = (NPC.velocity * (num1320 - 1f) + vector207) / num1320;
							return;
						}
						if (NPC.ai[0] == 4.2f)
						{
							NPC.rotation = (NPC.rotation * 9f + NPC.velocity.X * 0.1f) / 10f;
							NPC.noTileCollide = true;
							int num1321 = (int)NPC.ai[1];
							int num1322 = (int)NPC.ai[2];
							float x3 = num1321 * 16 + 8;
							float y3 = num1322 * 16 - 20;
							Vector2 vector208 = new Vector2(x3, y3);
							vector208 -= NPC.Center;
							float num1323 = 4f;
							float num1324 = 2f;
							if (Main.netMode != 1 && vector208.Length() < 4f)
							{
								int num1325 = 70;
								if (Main.expertMode)
								{
									num1325 = (int)(num1325 * 0.75);
								}
								NPC.ai[3] += 1f;
								if (NPC.ai[3] == num1325)
								{
									NPC.NewNPC(NPC.GetSource_FromThis(), num1321 * 16 + 8, num1322 * 16, ModContent.NPCType<DesertPrincess2>(), NPC.whoAmI, 0f, 0f, 0f, 0f, 255);
								}
								else if (NPC.ai[3] == num1325 * 2)
								{
									NPC.ai[0] = 0f;
									NPC.ai[1] = 0f;
									NPC.ai[2] = 0f;
									NPC.ai[3] = 0f;
									if (NPC.CountNPCS(ModContent.NPCType<DesertPrincess2>()) < num1305 && Main.rand.Next(3) != 0)
									{
										NPC.ai[0] = 4f;
									}
									else if (Collision.SolidCollision(NPC.position, NPC.width, NPC.height))
									{
										NPC.ai[0] = 1f;
									}
								}
							}
							if (vector208.Length() > num1323)
							{
								vector208.Normalize();
								vector208 *= num1323;
							}
							NPC.velocity = (NPC.velocity * (num1324 - 1f) + vector208) / num1324;
						}
					}
				}
			}
		}

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float bossLifeScale, float balance)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.6f);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
	}
}