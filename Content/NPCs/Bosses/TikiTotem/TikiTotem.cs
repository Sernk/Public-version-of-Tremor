using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.BossLoot.TikiTotem;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Materials;
using TremorMod.Utilities;
using System.Linq;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;
using TremorMod;
using ReLogic.Content; 

namespace TremorMod.Content.NPCs.Bosses.TikiTotem
{
	[AutoloadBossHead]
	public class TikiTotem : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Tiki Totem");
			Main.npcFrameCount[NPC.type] = 10;
			NPCID.Sets.TrailCacheLength[NPC.type] = 5;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 2500;
			NPC.damage = 12;
			NPC.defense = 12;
			NPC.knockBackResist = 0.02f;
			NPC.width = 86;
			NPC.height = 162;
			AnimationType = 325;
			Music = 39;
			AIType = 77;
			NPC.aiStyle = -1;
			NPC.npcSlots = 15f;
            Music = MusicLoader.GetMusicSlot("TremorMod/Content/Music/TikiTotem");
            NPC.boss = true;
			NPC.dontTakeDamage = true;

			//bossBag/* tModPorter Note: Removed. Spawn the treasure bag alongside other loot via npcLoot.Add(ItemDropRule.BossBag(type)) */ = Mod.ItemType<TikiTotemBag>();
			NPC.HitSound = SoundID.NPCHit3;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 60, 0);
		}
		
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = NPC.lifeMax * 1;
            NPC.damage = NPC.damage * 1;
        }

        //Variables
        bool _firstState = true;
		bool _spawnTiki;
		int _timer;
		bool _flag1 = true;
		bool _flag2 = true;
		bool _flag3 = true;
		List<int> _tikiSouls = new List<int>();

		// todo: rework the fuck out of this, lol
		public override void AI()
		{
            if (NPC.AnyNPCs(ModContent.NPCType<HappySoul>()) || NPC.AnyNPCs(ModContent.NPCType<AngerSoul>()) || NPC.AnyNPCs(ModContent.NPCType<IndifferenceSoul>()))
            {
				NPC.position += NPC.velocity * 1f;
			}
			_timer++;
			for (int num74 = NPC.oldPos.Length - 1; num74 > 0; num74--)
			{
				NPC.oldPos[num74] = NPC.oldPos[num74 - 1];
			}
			NPC.oldPos[0] = NPC.position;
			if (Main.time % 600 == 0)
			{
				NPC.position.X = Main.player[NPC.target].position.X;
				NPC.position.Y = Main.player[NPC.target].position.Y - 300f;
			}
			if (NPC.CountNPCS(ModContent.NPCType<TikiSoul>()) <= ((Main.expertMode) ? 6 : 3) && Main.time % 60 == 0 && !_spawnTiki)
			{
                NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<TikiSoul>());
            }
            if (NPC.CountNPCS(ModContent.NPCType<TikiSoul>()) >= ((Main.expertMode) ? 6 : 3))
			{
				_spawnTiki = true;
			}
			if (NPC.CountNPCS(ModContent.NPCType<TikiSoul>()) == 0 && _timer >= 200)
			{
				_firstState = false;
			}
			if (_firstState)
			{
				NPC.aiStyle = 3;
			}
			else
			{
				NPC.aiStyle = -1;
				NPC.dontTakeDamage = false;
				if (Main.rand.Next(280) == 0 && NPC.CountNPCS(ModContent.NPCType<TikiWarrior>()) < 7)
				{
                    NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<TikiWarrior>());

				}

				if (Main.rand.Next(180) == 0 && NPC.CountNPCS(ModContent.NPCType<TikiWarrior>()) < 4)
				{
                    NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<TikiWarrior>());
				}
				float num1263 = 2f;
				NPC.noGravity = true;
				NPC.noTileCollide = true;
				if (!Main.dayTime)
				{
					NPC.TargetClosest(true);
				}
				bool flag116 = false;
				if (NPC.life < NPC.lifeMax * 0.75)
				{
					num1263 = 3f;
				}
				if (NPC.life < NPC.lifeMax * 0.5)
				{
					num1263 = 4f;
				}
				else if (NPC.ai[0] == 0f)
				{
					NPC.ai[1] += 1f;
					if (NPC.life < NPC.lifeMax * 0.5)
					{
						NPC.ai[1] += 1f;
					}
					if (NPC.life < NPC.lifeMax * 0.25)
					{
						NPC.ai[1] += 1f;
					}
					if (NPC.ai[1] >= 300f && Main.netMode != 1)
					{
						NPC.ai[1] = 0f;
						if (NPC.life < NPC.lifeMax * 0.25 && NPC.type != 344)
						{
							NPC.ai[0] = Main.rand.Next(3, 5);
						}
						else
						{
							NPC.ai[0] = Main.rand.Next(1, 3);
						}
						NPC.netUpdate = true;
					}
				}
				else if (NPC.ai[0] == 1f)
				{
					if (NPC.type == 344)
					{
						flag116 = true;
						NPC.ai[1] += 1f;
                        if (NPC.ai[1] % 5f == 0f)
                        {
                            Vector2 vector146 = new Vector2(NPC.position.X + 20f + Main.rand.Next(NPC.width - 40),
                                                            NPC.position.Y + 20f + Main.rand.Next(NPC.height - 40));
                            float num1264 = Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f - vector146.X;
                            float num1265 = Main.player[NPC.target].position.Y - vector146.Y;
                            num1264 += Main.rand.Next(-50, 51);
                            num1265 += Main.rand.Next(-50, 51);
                            num1265 -= Math.Abs(num1264) * (Main.rand.Next(0, 21) * 0.01f);

                            float num1266 = (float)Math.Sqrt(num1264 * num1264 + num1265 * num1265);
                            float num1267 = 12.5f;
                            num1266 = num1267 / num1266;
                            num1264 *= num1266;
                            num1265 *= num1266;
                            num1264 *= 1f + Main.rand.Next(-20, 21) * 0.02f;
                            num1265 *= 1f + Main.rand.Next(-20, 21) * 0.02f;

                            Projectile.NewProjectile(NPC.GetSource_FromAI(), vector146, new Vector2(num1264, num1265),
                            ModContent.ProjectileType<LizardPro>(), 23, 0f, Main.myPlayer,
                            Main.rand.Next(0, 31), 0f);
                        }

                        if (NPC.ai[1] >= 180f)
						{
							NPC.ai[1] = 0f;
							NPC.ai[0] = 0f;
						}
					}
					else
					{
						flag116 = true;
						NPC.ai[1] += 1f;
                        if (NPC.ai[1] % 15f == 0f)
                        {
                            Vector2 vector147 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f + 30f);
                            float num1268 = Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f - vector147.X;
                            float num1269 = Main.player[NPC.target].position.Y - vector147.Y;
                            float num1270 = (float)Math.Sqrt(num1268 * num1268 + num1269 * num1269);
                            float num1271 = 10f;

                            num1270 = num1271 / num1270;
                            num1268 *= num1270;
                            num1269 *= num1270;
                            num1268 *= 1f + Main.rand.Next(-20, 21) * 0.01f;
                            num1269 *= 1f + Main.rand.Next(-20, 21) * 0.01f;
                            Projectile.NewProjectile(NPC.GetSource_FromAI(), vector147, new Vector2(num1268, num1269),
                            ModContent.ProjectileType<LizardPro>(), 50, 0f, Main.myPlayer);
                        }
                        if (NPC.ai[1] >= 120f)
						{
							NPC.ai[1] = 0f;
							NPC.ai[0] = 0f;
						}
					}
				}
				else if (NPC.ai[0] == 2f)
				{
					if (NPC.type == 344)
					{
						flag116 = true;
						NPC.ai[1] += 1f;
						if (NPC.ai[1] > 60f && NPC.ai[1] < 240f && NPC.ai[1] % 15f == 0f)
						{
							float num1272 = 4.5f;
							Vector2 vector148 = new Vector2(NPC.position.X + 20f + Main.rand.Next(NPC.width - 40), NPC.position.Y + 60f + Main.rand.Next(NPC.height - 80));
							float num1273 = Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f - vector148.X;
							float num1274 = Main.player[NPC.target].position.Y - vector148.Y;
							num1274 -= Math.Abs(num1273) * 0.3f;
							num1272 += Math.Abs(num1273) * 0.004f;
							num1273 += Main.rand.Next(-50, 51);
							num1274 -= Main.rand.Next(50, 201);
							float num1275 = (float)Math.Sqrt(num1273 * num1273 + num1274 * num1274);
							num1275 = num1272 / num1275;
							num1273 *= num1275;
							num1274 *= num1275;
							num1273 *= 1f + Main.rand.Next(-30, 31) * 0.01f;
							num1274 *= 1f + Main.rand.Next(-30, 31) * 0.01f;
                            Projectile.NewProjectile(NPC.GetSource_FromAI(), vector148, new Vector2(num1273, num1274),
                            ModContent.ProjectileType<LizardPro>(), 23, 0f, Main.myPlayer);
                        }
						if (NPC.ai[1] >= 300f)
						{
							NPC.ai[1] = 0f;
							NPC.ai[0] = 0f;
						}
					}
                    else
                    {
                        flag116 = true;
                        NPC.ai[1] += 1f;

                        if (NPC.ai[1] > 60f && NPC.ai[1] < 240f && NPC.ai[1] % 8f == 0f)
                        {
                            float num1276 = 10f;
                            Vector2 vector149 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f + 30f);
                            float num1277 = Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f - vector149.X;
                            float num1278 = Main.player[NPC.target].position.Y - vector149.Y;

                            num1278 -= Math.Abs(num1277) * 0.3f;
                            num1276 += Math.Abs(num1277) * 0.004f;
                            if (num1276 > 14f)
                            {
                                num1276 = 14f;
                            }

                            num1277 += Main.rand.Next(-50, 51);
                            num1278 -= Main.rand.Next(50, 61);
                            float num1279 = (float)Math.Sqrt(num1277 * num1277 + num1278 * num1278);
                            num1279 = num1276 / num1279;
                            num1277 *= num1279;
                            num1278 *= num1279;
                            num1277 *= 1f + Main.rand.Next(-30, 31) * 0.01f;
                            num1278 *= 1f + Main.rand.Next(-30, 31) * 0.01f;
                            Projectile.NewProjectile(NPC.GetSource_FromAI(), vector149, new Vector2(num1277, num1278),
                                                     81, 23, 0f, Main.myPlayer);
                        }

                        if (NPC.ai[1] >= 300f)
                        {
                            NPC.ai[1] = 0f;
                            NPC.ai[0] = 0f;
                        }
                    }

                }
                else if (NPC.ai[0] == 3f)
				{
					num1263 = 4f;
					NPC.ai[1] += 1f;
					if (NPC.ai[1] % 30f == 0f)
					{
						Vector2 vector150 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f + 30f);
						float num1280 = Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f - vector150.X;
						float num1281 = Main.player[NPC.target].position.Y - vector150.Y;
						float num1282 = (float)Math.Sqrt(num1280 * num1280 + num1281 * num1281);
						float num1283 = 16f;
						num1282 = num1283 / num1282;
						num1280 *= num1282;
						num1281 *= num1282;
						num1280 *= 1f + Main.rand.Next(-20, 21) * 0.001f;
						num1281 *= 1f + Main.rand.Next(-20, 21) * 0.001f;
                        Projectile.NewProjectile(NPC.GetSource_FromAI(), vector150, new Vector2(num1280, num1281),
						ModContent.ProjectileType<LizardPro>(), 23, 0f, Main.myPlayer);
                    }
					if (NPC.ai[1] >= 120f)
					{
						NPC.ai[1] = 0f;
						NPC.ai[0] = 0f;
					}
				}
				else if (NPC.ai[0] == 4f)
				{
					num1263 = 4f;
					NPC.ai[1] += 1f;
					if (NPC.ai[1] % 10f == 0f)
					{
						float num1284 = 12f;
						Vector2 vector151 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f + 30f);
						float num1285 = Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f - vector151.X;
						float num1286 = Main.player[NPC.target].position.Y - vector151.Y;
						num1286 -= Math.Abs(num1285) * 0.2f;
						num1284 += Math.Abs(num1285) * 0.002f;
						if (num1284 > 16f)
						{
							num1284 = 16f;
						}
						num1285 += Main.rand.Next(-50, 51);
						num1286 -= Main.rand.Next(50, 71);
						float num1287 = (float)Math.Sqrt(num1285 * num1285 + num1286 * num1286);
						num1287 = num1284 / num1287;
						num1285 *= num1287;
						num1286 *= num1287;
						num1285 *= 1f + Main.rand.Next(-30, 31) * 0.005f;
						num1286 *= 1f + Main.rand.Next(-30, 31) * 0.005f;
                        Projectile.NewProjectile(NPC.GetSource_FromAI(), vector151, new Vector2(num1285, num1286),
                        81, 23, 0f, Main.myPlayer);

                    }
					if (NPC.ai[1] >= 240f)
					{
						NPC.ai[1] = 0f;
						NPC.ai[0] = 0f;
					}
				}
				if (Math.Abs(NPC.Center.X - Main.player[NPC.target].Center.X) < 50f)
				{
					flag116 = true;
				}
				if (flag116)
				{
					NPC.velocity.X = NPC.velocity.X * 0.9f;
					if (NPC.velocity.X > -0.1 && NPC.velocity.X < 0.1)
					{
						NPC.velocity.X = 0f;
					}
				}
				else
				{
					if (NPC.direction > 0)
					{
						NPC.velocity.X = (NPC.velocity.X * 20f + num1263) / 21f;
					}
					if (NPC.direction < 0)
					{
						NPC.velocity.X = (NPC.velocity.X * 20f - num1263) / 21f;
					}
				}
				int num1288 = 80;
				int num1289 = 20;
				Vector2 position7 = new Vector2(NPC.Center.X - num1288 / 2, NPC.position.Y + NPC.height - num1289);
				bool flag117 = NPC.position.X < Main.player[NPC.target].position.X && NPC.position.X + NPC.width > Main.player[NPC.target].position.X + Main.player[NPC.target].width && NPC.position.Y + NPC.height < Main.player[NPC.target].position.Y + Main.player[NPC.target].height - 16f;
				if (flag117)
				{
					NPC.velocity.Y = NPC.velocity.Y + 0.5f;
				}
				else if (Collision.SolidCollision(position7, num1288, num1289))
				{
					if (NPC.velocity.Y > 0f)
					{
						NPC.velocity.Y = 0f;
					}
					if (NPC.velocity.Y > -0.2)
					{
						NPC.velocity.Y = NPC.velocity.Y - 0.025f;
					}
					else
					{
						NPC.velocity.Y = NPC.velocity.Y - 0.2f;
					}
					if (NPC.velocity.Y < -4f)
					{
						NPC.velocity.Y = -4f;
					}
				}
				else
				{
					if (NPC.velocity.Y < 0f)
					{
						NPC.velocity.Y = 0f;
					}
					if (NPC.velocity.Y < 0.1)
					{
						NPC.velocity.Y = NPC.velocity.Y + 0.025f;
					}
					else
					{
						NPC.velocity.Y = NPC.velocity.Y + 0.5f;
					}
				}
				if (NPC.velocity.Y > 10f)
				{
					NPC.velocity.Y = 10f;
					return;
				}

				if (NPC.life < NPC.lifeMax * 0.5f && _flag1)
				{
					_flag1 = false;
                    NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y + 95, ModContent.NPCType<HappySoul>());
                }
                if (NPC.life < NPC.lifeMax * 0.3f && _flag2)
				{
					_flag2 = false;
                    NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y + 110, ModContent.NPCType<AngerSoul>());
                }
                if (NPC.life < NPC.lifeMax * 0.1f && _flag3)
				{
					_flag3 = false;
                    NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y + 110, ModContent.NPCType<IndifferenceSoul>());
                }
            }
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				_timer = 0;
				for (int i = 0; i < 3; i++)
				{
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TikiTotemGore1").Type, 1f);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TikiTotemGore2").Type, 1f);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TikiTotemGore3").Type, 1f);
                }
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
			for (int k = 0; k < NPC.oldPos.Length; k++)
			{
				Vector2 drawPos = NPC.oldPos[k] - Main.screenPosition;
                Color color = NPC.GetAlpha(drawColor) * ((NPC.oldPos.Length - k) / (float)NPC.oldPos.Length);
				Rectangle frame = new Rectangle(0, 0, 86, 162);
				frame.Y += 164 * (k / 60);

				spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, drawPos, frame, color, 0, Vector2.Zero, NPC.scale, SpriteEffects.None, 1f);
			}
			return true;
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ItemID.HealingPotion, 1, 5, 16));

			npcLoot.Add(ItemDropRule.Common(ItemID.ManaPotion, 1, 5, 16)); 

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ToxicBlade>(), 3));

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<JungleAlloy>(), 1));

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PickaxeofBloom>(), 3));

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ToxicHilt>(), 5));

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AngryTotemMask>(), 7));

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HappyTotemMask>(), 7));

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<IndifferentTotemMask>(), 7));

            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<TikiTotemBag>(), 1));
        }

        public override void OnKill()
		{
            TremorSpawnEnemys.downedTikiTotem = true; 

            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.WorldData); 
            }

            string msg = "Ghosts are returning to ruins...";
			Main.NewText(msg, 193, 139, 77);
			if (Main.netMode == NetmodeID.MultiplayerClient)
			{
				ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(msg), new Color(193, 139, 77));
			}
		}
	}
}