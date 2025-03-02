using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Armor.King;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.NPCs
{
	/*
	 * Rework AI into something more comprehensible and functional.
	 */
	public class MagiumKeeper : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Magium Keeper");
			Main.npcFrameCount[NPC.type] = 20;
		}

		public override void SetDefaults()
		{
			NPC.width = 40;
			NPC.height = 40;
			NPC.damage = 40;
			NPC.defense = 25;
			NPC.lifeMax = 3000;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath42;
			NPC.value = Item.buyPrice(0, 12, 12, 7);
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = 3;
			AIType = 482;
			AnimationType = 471;
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("MagiumKeeperBanner");
		}

		public override void AI()
		{
			if (NPC.ai[3] < 0f)
			{
				NPC.knockBackResist = 0f;
				NPC.defense = (int)(NPC.defDefense * 1.1);
				NPC.noGravity = true;
				NPC.noTileCollide = true;
				if (NPC.velocity.X < 0f)
				{
					NPC.direction = -1;
				}
				else if (NPC.velocity.X > 0f)
				{
					NPC.direction = 1;
				}
				NPC.rotation = NPC.velocity.X * 0.1f;
				if (Main.netMode != 1)
				{
					NPC.localAI[3] += 1f;
					if (NPC.localAI[3] > Main.rand.Next(20, 180))
					{
						NPC.localAI[3] = 0f;
						Vector2 value3 = NPC.position;
						value3 += NPC.velocity;
						NPC.NewNPC(NPC.GetSource_FromThis(), (int)value3.X, (int)value3.Y, ModContent.NPCType<MagiumSword>(), 0, 0f, 0f, 0f, 0f, 255);
					}
				}
			}
			else
			{
				NPC.localAI[3] = 0f;
				NPC.knockBackResist = 0.35f * Main.GameModeInfo.KnockbackToEnemiesMultiplier;
				NPC.rotation *= 0.9f;
				NPC.defense = NPC.defDefense;
				NPC.noGravity = false;
				NPC.noTileCollide = false;
			}
			if (NPC.ai[3] == 1f)
			{
				NPC.knockBackResist = 0f;
				NPC.defense += 10;
			}
			if (NPC.ai[3] == -1f)
			{
				NPC.TargetClosest(true);
				float num46 = 8f;
				float num47 = 40f;
				Vector2 value4 = Main.player[NPC.target].Center - NPC.position;
				float num48 = value4.Length();
				num46 += num48 / 200f;
				value4.Normalize();
				value4 *= num46;
				NPC.velocity = (NPC.velocity * (num47 - 1f) + value4) / num47;
				if (num48 < 500f && !Collision.SolidCollision(NPC.position, NPC.width, NPC.height))
				{
					NPC.ai[3] = 0f;
					NPC.ai[2] = 0f;
				}
				return;
			}
			if (NPC.ai[3] == -2f)
			{
				NPC.velocity.Y = NPC.velocity.Y - 0.2f;
				if (NPC.velocity.Y < -10f)
				{
					NPC.velocity.Y = -10f;
				}
				if (Main.player[NPC.target].Center.Y - NPC.position.Y > 200f)
				{
					NPC.TargetClosest(true);
					NPC.ai[3] = -3f;
					if (Main.player[NPC.target].Center.X > NPC.position.X)
					{
						NPC.ai[2] = 1f;
					}
					else
					{
						NPC.ai[2] = -1f;
					}
				}
				NPC.velocity.X = NPC.velocity.X * 0.99f;
				return;
			}
			if (NPC.ai[3] == -3f)
			{
				if (NPC.direction == 0)
				{
					NPC.TargetClosest(true);
				}
				if (NPC.ai[2] == 0f)
				{
					NPC.ai[2] = NPC.direction;
				}
				NPC.velocity.Y = NPC.velocity.Y * 0.9f;
				NPC.velocity.X = NPC.velocity.X + NPC.ai[2] * 0.3f;
				if (NPC.velocity.X > 10f)
				{
					NPC.velocity.X = 10f;
				}
				if (NPC.velocity.X < -10f)
				{
					NPC.velocity.X = -10f;
				}
				float num49 = Main.player[NPC.target].Center.X - NPC.position.X;
				if ((NPC.ai[2] < 0f && num49 > 300f) || (NPC.ai[2] > 0f && num49 < -300f))
				{
					NPC.ai[3] = -4f;
					NPC.ai[2] = 0f;
				}
			}
			else
			{
				if (NPC.ai[3] == -4f)
				{
					NPC.ai[2] += 1f;
					NPC.velocity.Y = NPC.velocity.Y + 0.1f;
					if (NPC.velocity.Length() > 4f)
					{
						NPC.velocity *= 0.9f;
					}
					int num50 = (int)NPC.position.X / 16;
					int num51 = (int)(NPC.position.Y + NPC.height + 12f) / 16;
					bool flag4 = false;
					for (int num52 = num50 - 1; num52 <= num50 + 1; num52++)
					{
						if (Main.tile[num52, num51] == null)
						{
							//Main.tile[num50, num51] = new Tile();
						}
						if (Main.tile[num52, num51].HasTile && Main.tileSolid[Main.tile[num52, num51].TileType])
						{
							flag4 = true;
						}
					}
					if (flag4 && !Collision.SolidCollision(NPC.position, NPC.width, NPC.height))
					{
						NPC.ai[3] = 0f;
						NPC.ai[2] = 0f;
					}
					else if (NPC.ai[2] > 300f || NPC.position.Y > Main.player[NPC.target].Center.Y + 200f)
					{
						NPC.ai[3] = -1f;
						NPC.ai[2] = 0f;
					}
				}
				else
				{
					if (NPC.ai[3] == 1f)
					{
						Vector2 center3 = NPC.position;
						center3.Y -= 70f;
						NPC.velocity.X = NPC.velocity.X * 0.8f;
						NPC.ai[2] += 1f;
						if (NPC.ai[2] == 60f)
						{
							if (Main.netMode != 1)
							{
								NPC.NewNPC(NPC.GetSource_FromThis(), (int)center3.X, (int)center3.Y + 18, ModContent.NPCType<MagiumFlyer>(), 0, 0f, 0f, 0f, 0f, 255);
							}
						}
						else if (NPC.ai[2] >= 90f)
						{
							NPC.ai[3] = -2f;
							NPC.ai[2] = 0f;
						}
						for (int num53 = 0; num53 < 2; num53++)
						{
							Vector2 vector11 = center3;
							Vector2 value5 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
							value5.Normalize();
							value5 *= Main.rand.Next(0, 100) * 0.1f;
							vector11 += value5;
							value5.Normalize();
							value5 *= Main.rand.Next(50, 90) * 0.1f;
							int num54 = Dust.NewDust(vector11, 1, 1, 59, 0f, 0f, 0, default(Color), 3f);
							Main.dust[num54].velocity = -value5 * 0.3f;
							Main.dust[num54].alpha = 100;
							if (Main.rand.NextBool(2))
							{
								Main.dust[num54].noGravity = true;
								Main.dust[num54].scale += 0.3f;
							}
						}
						return;
					}
					NPC.ai[2] += 1f;
					int num55 = 10;
					if (NPC.velocity.Y == 0f && NPC.CountNPCS(472) < num55)
					{
						if (NPC.ai[2] >= 180f)
						{
							NPC.ai[2] = 0f;
							NPC.ai[3] = 1f;
						}
					}
					else
					{
						if (NPC.CountNPCS(472) >= num55)
						{
							NPC.ai[2] += 1f;
						}
						if (NPC.ai[2] >= 360f)
						{
							NPC.ai[2] = 0f;
							NPC.ai[3] = -2f;
							NPC.velocity.Y = NPC.velocity.Y - 3f;
						}
					}
					if (NPC.target >= 0 && !Main.player[NPC.target].dead && (Main.player[NPC.target].Center - NPC.position).Length() > 800f)
					{
						NPC.ai[3] = -1f;
						NPC.ai[2] = 0f;
					}
				}
				if (Main.player[NPC.target].dead)
				{
					NPC.TargetClosest(true);
					if (Main.player[NPC.target].dead && NPC.timeLeft > 1)
					{
						NPC.timeLeft = 1;
					}
				}
			}
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<KnightHelmet>(), 1, 5, 12));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<RuneBar>(), 1, 6, 16));
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				}
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("MagiumGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("MagiumGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("MagiumGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("MagiumGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("MagiumGore3").Type, 1f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && Main.hardMode && spawnInfo.SpawnTileY > Main.rockLayer ? 0.0003f : 0f;
	}
}
