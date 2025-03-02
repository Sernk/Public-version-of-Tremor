using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Dusts;
using TremorMod.Content.Event;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items;

namespace TremorMod.Content.NPCs.Invasion
{
	public class ParadoxSun : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Forgotten Creature");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 5750;
			NPC.damage = 125;
			NPC.defense = 115;
			NPC.knockBackResist = 0f;
			NPC.width = 34;
			NPC.height = 40;
			AnimationType = 3;
			NPC.aiStyle = -1;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.color = Color.White;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>();
			//float spawn = 20f;
			if (InvasionWorld.CyberWrath)
				return 10000f;
			//return 0f;

			int x = spawnInfo.SpawnTileX;
			int y = spawnInfo.SpawnTileY;
			int tile = Main.tile[x, y].TileType;
			return InvasionWorld.CyberWrath && y > Main.worldSurface ? 1f : 0f;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 10; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<CyberDust>(), 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}

				CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>();
				if (InvasionWorld.CyberWrath && Main.rand.NextBool(2))
				{
					InvasionWorld.CyberWrathPoints1 += 2;
					//Main.NewText(("Wave 1: Complete " + TremorWorld.CyberWrathPoints + "%"), 39, 86, 134);
				}
			}

			for (int k = 0; k < hit.Damage / NPC.lifeMax * 50.0; k++)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<CyberDust>(), hitDirection, -1f, 0, default(Color), 0.7f);
			}
		}

		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */
		{
			NPC.lifeMax = NPC.lifeMax * 1;
			NPC.damage = NPC.damage * 1;
		}

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (Main.rand.NextBool())
            {
                target.AddBuff(BuffID.Confused, 1000);
            }
        }

        public override void AI()
		{
			if (Main.rand.Next(320) == 5)
			{
				do
				{
					NPC.position.X = (Main.player[NPC.target].position.X - 500) + Main.rand.Next(1000);
					NPC.position.Y = (Main.player[NPC.target].position.Y - 500) + Main.rand.Next(1000);
				} while (NPC.Distance(Main.player[NPC.target].position) < 40);
			}

			int num5 = 60;
			bool flag2 = false;
			bool flag3 = true;

			if (NPC.velocity.Y == 0f && ((NPC.velocity.X > 0f && NPC.direction < 0) || (NPC.velocity.X < 0f && NPC.direction > 0)))
			{
				flag2 = true;
			}
			if (NPC.position.X == NPC.oldPosition.X || NPC.ai[3] >= num5 || flag2)
			{
				NPC.ai[3] += 1f;
			}
			else
			{
				if (Math.Abs(NPC.velocity.X) > 0.9 && NPC.ai[3] > 0f)
				{
					NPC.ai[3] -= 1f;
				}
			}
			if (NPC.ai[3] > num5 * 10)
			{
				NPC.ai[3] = 0f;
			}
			if (NPC.justHit)
			{
				NPC.ai[3] = 0f;
			}
			if (NPC.ai[3] == num5)
			{
				NPC.netUpdate = true;
			}

			if (NPC.ai[3] < num5)
			{
				NPC.TargetClosest(true);
			}
			else
			{
				if (NPC.velocity.X == 0f)
				{
					if (NPC.velocity.Y == 0f)
					{
						NPC.ai[0] += 1f;
						if (NPC.ai[0] >= 2f)
						{
							NPC.direction *= -1;
							NPC.spriteDirection = NPC.direction;
							NPC.ai[0] = 0f;
						}
					}
				}
				else
				{
					NPC.ai[0] = 0f;
				}
				if (NPC.direction == 0)
				{
					NPC.direction = 1;
				}
			}

			if (NPC.velocity.X < -3f || NPC.velocity.X > 3f)
			{
				if (NPC.velocity.Y == 0f)
				{
					NPC.velocity *= 0.8f;
				}
			}
			else
			{
				if (NPC.velocity.X < 3f && NPC.direction == 1)
				{
					NPC.velocity.X = NPC.velocity.X + 0.1f;
					if (NPC.velocity.X > 3f)
					{
						NPC.velocity.X = 3f;
					}
				}
				else
				{
					if (NPC.velocity.X > -3f && NPC.direction == -1)
					{
						NPC.velocity.X = NPC.velocity.X - 0.1f;
						if (NPC.velocity.X < -3f)
						{
							NPC.velocity.X = -3f;
						}
					}
				}
			}

			bool flag4 = false;
			if (NPC.velocity.Y == 0f)
			{
				int num29 = (int)(NPC.position.Y + NPC.height + 8f) / 16;
				int num30 = (int)NPC.position.X / 16;
				int num31 = (int)(NPC.position.X + NPC.width) / 16;
				for (int l = num30; l <= num31; l++)
				{
					if (Main.tile[l, num29] == null)
					{
						return;
					}
					if (Main.tile[l, num29].HasTile && Main.tileSolid[Main.tile[l, num29].TileType])
					{
						flag4 = true;
						break;
					}
				}
			}

            if (flag4)
            {
                int num32 = (int)((NPC.position.X + NPC.width / 2 + (NPC.width / 2 + 6) * NPC.direction) / 16f);
                int num33 = (int)((NPC.position.Y + NPC.height - 15f) / 16f);

                if (Main.tile[num32, num33] == null)
                {
                    //Main.tile[num32, num33] = new Tile();
                }
                if (Main.tile[num32, num33 - 1] == null)
                {
                    //Main.tile[num32, num33 - 1] = new Tile();
                }
                if (Main.tile[num32, num33 - 2] == null)
                {
                   // Main.tile[num32, num33 - 2] = new Tile();
                }
                if (Main.tile[num32, num33 - 3] == null)
                {
                    //Main.tile[num32, num33 - 3] = new Tile();
                }
                if (Main.tile[num32, num33 + 1] == null)
                {
                    //Main.tile[num32, num33 + 1] = new Tile();
                }
                if (Main.tile[num32 + NPC.direction, num33 - 1] == null)
                {
                    //Main.tile[num32 + NPC.direction, num33 - 1] = new Tile();
                }
                if (Main.tile[num32 + NPC.direction, num33 + 1] == null)
                {
                    //Main.tile[num32 + NPC.direction, num33 + 1] = new Tile();
                }

                if (Main.tile[num32, num33 - 1].HasTile && Main.tile[num32, num33 - 1].TileType == 10 && flag3)
                {
                    NPC.ai[2] += 1f;
                    NPC.ai[3] = 0f;
                    if (NPC.ai[2] >= 60f)
                    {
                        NPC.velocity.X = 0.5f * -(float)NPC.direction;
                        NPC.ai[1] += 1f;
                        NPC.ai[2] = 0f;
                        bool flag5 = false;
                        if (NPC.ai[1] >= 10f)
                        {
                            flag5 = true;
                            NPC.ai[1] = 10f;
                        }
                        WorldGen.KillTile(num32, num33 - 1, true, false, false);
                        if ((Main.netMode != NetmodeID.MultiplayerClient || !flag5) && flag5 && Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            bool flag6 = WorldGen.OpenDoor(num32, num33, NPC.direction);
                            if (!flag6)
                            {
                                NPC.ai[3] = num5;
                                NPC.netUpdate = true;
                            }
                        }
                    }
                }

				if ((NPC.velocity.X < 0f && NPC.spriteDirection == -1) || (NPC.velocity.X > 0f && NPC.spriteDirection == 1))
				{
					if (Main.tile[num32, num33 - 2].HasTile && Main.tileSolid[Main.tile[num32, num33 - 2].TileType])
					{
						if ((Main.tile[num32, num33 - 3].HasTile && Main.tileSolid[Main.tile[num32, num33 - 3].TileType]))
						{
							NPC.velocity.Y = -8f;
							NPC.netUpdate = true;
						}
						else
						{
							NPC.velocity.Y = -7f;
							NPC.netUpdate = true;
						}
					}
					else
					{
						if (Main.tile[num32, num33 - 1].HasTile && Main.tileSolid[Main.tile[num32, num33 - 1].TileType])
						{
							NPC.velocity.Y = -6f;
							NPC.netUpdate = true;
						}
						else
						{
							if (Main.tile[num32, num33].HasTile && Main.tileSolid[Main.tile[num32, num33].TileType])
							{
								NPC.velocity.Y = -5f;
								NPC.netUpdate = true;
							}
							else
							{
								if (NPC.directionY < 0 && (!Main.tile[num32, num33 + 1].HasTile || !Main.tileSolid[Main.tile[num32, num33 + 1].TileType]) && (!Main.tile[num32 + NPC.direction, num33 + 1].HasTile || !Main.tileSolid[Main.tile[num32 + NPC.direction, num33 + 1].TileType]))
								{
									NPC.velocity.Y = -8f;
									NPC.velocity.X = NPC.velocity.X * 1.5f;
									NPC.netUpdate = true;
								}
								else
								{
									if (flag3)
									{
										NPC.ai[1] = 0f;
										NPC.ai[2] = 0f;
									}
								}
							}
						}
					}
				}
			}
			else
			{
				if (flag3)
				{
					NPC.ai[1] = 0f;
					NPC.ai[2] = 0f;
				}
			}
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            if (Main.netMode != 1)
            {
                int centerX = (int)(NPC.position.X + NPC.width / 2) / 16;
                int centerY = (int)(NPC.position.Y + NPC.height / 2) / 16;
                int halfLength = NPC.width / 2 / 16 + 1;
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ClockofTime>(), 20));
            }
        }
    }
}