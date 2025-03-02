using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.NPCs
{
	public class GoblinAssassin : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Goblin Assassin");
			Main.npcFrameCount[NPC.type] = 3;
		}

		//int CountFrame;
		//int TimeToAnimation = 4;
		bool TimetoShoot;

		public override void SetDefaults()
		{
			NPC.lifeMax = 200;
			NPC.damage = 21;
			NPC.defense = 10;
			NPC.knockBackResist = 0.4f;
			NPC.width = 46;
			NPC.height = 44;
			NPC.aiStyle = -1;
			NPC.npcSlots = 0.2f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 0, 56);
		}

		public override void AI()
		{
			NPC.TargetClosest(true);
			DoAI();
			ExpertSetting();
		}

		public void ExpertSetting()
		{
			if (!Main.expertMode) return;

			if (NPC.life > NPC.lifeMax * 0.5f)
				NPC.defense = 13;
			if (NPC.life < NPC.lifeMax * 0.5f && NPC.life > NPC.lifeMax * 0.3f)
				NPC.defense = 15;
			if (NPC.life < NPC.lifeMax * 0.3f)
				NPC.defense = 18;
		}

		public void DoAI()
		{
			Vector2 VectorPos = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
			float FirstPos = Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f - VectorPos.X;
			float SecondPos = Main.player[NPC.target].position.Y - VectorPos.Y;
			float FinallyPos = (float)Math.Sqrt(FirstPos * FirstPos + SecondPos * SecondPos);
			if (!NPC.wet && !Main.player[NPC.target].npcTypeNoAggro[NPC.type])
			{
				if (FinallyPos < 400f && Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
				{
					TimetoShoot = true;
				}
				else
					TimetoShoot = false;
			}
			if (TimetoShoot)
			{
				int Num = 15;
				bool Flag = false;
				bool Flag2 = true;

				if (NPC.velocity.Y == 0f && ((NPC.velocity.X > 0f && NPC.direction < 0) || (NPC.velocity.X < 0f && NPC.direction > 0)))
				{
					Flag = true;
				}
				if (NPC.position.X == NPC.oldPosition.X || NPC.ai[3] >= Num || Flag)
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
				if (NPC.ai[3] > Num * 10)
				{
					NPC.ai[3] = 0f;
				}
				if (NPC.justHit)
				{
					NPC.ai[3] = 0f;
				}
				if (NPC.ai[3] == Num)
				{
					NPC.netUpdate = true;
				}

				if (NPC.ai[3] < Num)
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

				if (NPC.velocity.X < -5f || NPC.velocity.X > 5f)
				{
					if (NPC.velocity.Y == 0f)
					{
						NPC.velocity *= 0.8f;
					}
				}
				else
				{
					if (NPC.velocity.X < 5f && NPC.direction == 1)
					{
						NPC.velocity.X = NPC.velocity.X + 0.1f;
						if (NPC.velocity.X > 5f)
						{
							NPC.velocity.X = 5f;
						}
					}
					else
					{
						if (NPC.velocity.X > -5f && NPC.direction == -1)
						{
							NPC.velocity.X = NPC.velocity.X - 0.1f;
							if (NPC.velocity.X < -5f)
							{
								NPC.velocity.X = -5f;
							}
						}
					}
				}

				bool Flag3 = false;
				if (NPC.velocity.Y == 0f)
				{
					int Num2 = (int)(NPC.position.Y + NPC.height + 8f) / 16;
					int Num3 = (int)NPC.position.X / 16;
					int Num4 = (int)(NPC.position.X + NPC.width) / 16;
					for (int l = Num3; l <= Num4; l++)
					{
						if (Main.tile[l, Num2] == null)
						{
							return;
						}
						if (Main.tile[l, Num2].HasTile && Main.tileSolid[Main.tile[l, Num2].TileType])
						{
							Flag3 = true;
							break;
						}
					}
				}

				if (Flag3)
				{
					int Num5 = (int)((NPC.position.X + NPC.width / 2 + (NPC.width / 2 + 6) * NPC.direction) / 16f);
					int Num6 = (int)((NPC.position.Y + NPC.height - 15f) / 16f);
					if (Main.tile[Num5, Num6] == null)
					{
						//Main.tile[Num5, Num6] = new Tile();
					}
					if (Main.tile[Num5, Num6 - 1] == null)
					{
						//Main.tile[Num5, Num6 - 1] = new Tile();
					}
					if (Main.tile[Num5, Num6 - 2] == null)
					{
						//Main.tile[Num5, Num6 - 2] = new Tile();
					}
					if (Main.tile[Num5, Num6 - 3] == null)
					{
						//Main.tile[Num5, Num6 - 3] = new Tile();
					}
					if (Main.tile[Num5, Num6 + 1] == null)
					{
						//Main.tile[Num5, Num6 + 1] = new Tile();
					}
					if (Main.tile[Num5 + NPC.direction, Num6 - 1] == null)
					{
						//Main.tile[Num5 + NPC.direction, Num6 - 1] = new Tile();
					}
					if (Main.tile[Num5 + NPC.direction, Num6 + 1] == null)
					{
						//Main.tile[Num5 + NPC.direction, Num6 + 1] = new Tile();
					}

					if (Main.tile[Num5, Num6 - 1].HasTile && Main.tile[Num5, Num6 - 1].TileType == 10 && Flag2)
					{
						NPC.ai[2] += 1f;
						NPC.ai[3] = 0f;
						if (NPC.ai[2] >= 60f)
						{
							NPC.velocity.X = 0.5f * -(float)NPC.direction;
							NPC.ai[1] += 1f;
							NPC.ai[2] = 0f;
							bool Flag4 = false;
							if (NPC.ai[1] >= 10f)
							{
								Flag4 = true;
								NPC.ai[1] = 10f;
							}
							WorldGen.KillTile(Num5, Num6 - 1, true, false, false);
							if ((Main.netMode != 1 || !Flag4) && Flag4 && Main.netMode != 1)
							{
								bool Flag5 = WorldGen.OpenDoor(Num5, Num6, NPC.direction);
								if (!Flag5)
								{
									NPC.ai[3] = Num;
									NPC.netUpdate = true;
								}
								if (Main.netMode == 2 && Flag5)
								{
									//NetMessage.SendData(19, -1, -1, "", 0, (float)Num5, (float)Num6, (float)npc.direction, 0);
								}
							}
						}
					}

					if ((NPC.velocity.X < 0f && NPC.spriteDirection == -1) || (NPC.velocity.X > 0f && NPC.spriteDirection == 1))
					{
						if (Main.tile[Num5, Num6 - 2].HasTile && Main.tileSolid[Main.tile[Num5, Num6 - 2].TileType])
						{
							if ((Main.tile[Num5, Num6 - 3].HasTile && Main.tileSolid[Main.tile[Num5, Num6 - 3].TileType]))
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
							if (Main.tile[Num5, Num6 - 1].HasTile && Main.tileSolid[Main.tile[Num5, Num6 - 1].TileType])
							{
								NPC.velocity.Y = -6f;
								NPC.netUpdate = true;
							}
							else
							{
								if (Main.tile[Num5, Num6].HasTile && Main.tileSolid[Main.tile[Num5, Num6].TileType])
								{
									NPC.velocity.Y = -5f;
									NPC.netUpdate = true;
								}
								else
								{
									if (NPC.directionY < 0 && (!Main.tile[Num5, Num6 + 1].HasTile || !Main.tileSolid[Main.tile[Num5, Num6 + 1].TileType]) && (!Main.tile[Num5 + NPC.direction, Num6 + 1].HasTile || !Main.tileSolid[Main.tile[Num5 + NPC.direction, Num6 + 1].TileType]))
									{
										NPC.velocity.Y = -8f;
										NPC.velocity.X = NPC.velocity.X * 1.5f;
										NPC.netUpdate = true;
									}
									else
									{
										if (Flag2)
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
					if (Flag2)
					{
						NPC.ai[1] = 0f;
						NPC.ai[2] = 0f;
					}
				}
			}
			else
			{
				int Num = 15;
				bool Flag = false;
				bool Flag2 = true;

				if (NPC.velocity.Y == 0f && ((NPC.velocity.X > 0f && NPC.direction < 0) || (NPC.velocity.X < 0f && NPC.direction > 0)))
				{
					Flag = true;
				}
				if (NPC.position.X == NPC.oldPosition.X || NPC.ai[3] >= Num || Flag)
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
				if (NPC.ai[3] > Num * 10)
				{
					NPC.ai[3] = 0f;
				}
				if (NPC.justHit)
				{
					NPC.ai[3] = 0f;
				}
				if (NPC.ai[3] == Num)
				{
					NPC.netUpdate = true;
				}

				if (NPC.ai[3] < Num)
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

				bool Flag3 = false;
				if (NPC.velocity.Y == 0f)
				{
					int Num2 = (int)(NPC.position.Y + NPC.height + 8f) / 16;
					int Num3 = (int)NPC.position.X / 16;
					int Num4 = (int)(NPC.position.X + NPC.width) / 16;
					for (int l = Num3; l <= Num4; l++)
					{
						if (Main.tile[l, Num2] == null)
						{
							return;
						}
						if (Main.tile[l, Num2].HasTile && Main.tileSolid[Main.tile[l, Num2].TileType])
						{
							Flag3 = true;
							break;
						}
					}
				}

				if (Flag3)
				{
					int Num5 = (int)((NPC.position.X + NPC.width / 2 + (NPC.width / 2 + 6) * NPC.direction) / 16f);
					int Num6 = (int)((NPC.position.Y + NPC.height - 15f) / 16f);
					if (Main.tile[Num5, Num6] == null)
					{
						//Main.tile[Num5, Num6] = new Tile();
					}
					if (Main.tile[Num5, Num6 - 1] == null)
					{
						//Main.tile[Num5, Num6 - 1] = new Tile();
					}
					if (Main.tile[Num5, Num6 - 2] == null)
					{
						//Main.tile[Num5, Num6 - 2] = new Tile();
					}
					if (Main.tile[Num5, Num6 - 3] == null)
					{
						//Main.tile[Num5, Num6 - 3] = new Tile();
					}
					if (Main.tile[Num5, Num6 + 1] == null)
					{
						//Main.tile[Num5, Num6 + 1] = new Tile();
					}
					if (Main.tile[Num5 + NPC.direction, Num6 - 1] == null)
					{
						//Main.tile[Num5 + NPC.direction, Num6 - 1] = new Tile();
					}
					if (Main.tile[Num5 + NPC.direction, Num6 + 1] == null)
					{
						//Main.tile[Num5 + NPC.direction, Num6 + 1] = new Tile();
					}

					if (Main.tile[Num5, Num6 - 1].HasTile && Main.tile[Num5, Num6 - 1].TileType == 10 && Flag2)
					{
						NPC.ai[2] += 1f;
						NPC.ai[3] = 0f;
						if (NPC.ai[2] >= 60f)
						{
							NPC.velocity.X = 0.5f * -(float)NPC.direction;
							NPC.ai[1] += 1f;
							NPC.ai[2] = 0f;
							bool Flag4 = false;
							if (NPC.ai[1] >= 10f)
							{
								Flag4 = true;
								NPC.ai[1] = 10f;
							}
							WorldGen.KillTile(Num5, Num6 - 1, true, false, false);
							if ((Main.netMode != 1 || !Flag4) && Flag4 && Main.netMode != 1)
							{
								bool Flag5 = WorldGen.OpenDoor(Num5, Num6, NPC.direction);
								if (!Flag5)
								{
									NPC.ai[3] = Num;
									NPC.netUpdate = true;
								}
								if (Main.netMode == 2 && Flag5)
								{
									//NetMessage.SendData(19, -1, -1, "", 0, (float)Num5, (float)Num6, (float)npc.direction, 0);
								}
							}
						}
					}

					if ((NPC.velocity.X < 0f && NPC.spriteDirection == -1) || (NPC.velocity.X > 0f && NPC.spriteDirection == 1))
					{
						if (Main.tile[Num5, Num6 - 2].HasTile && Main.tileSolid[Main.tile[Num5, Num6 - 2].TileType])
						{
							if ((Main.tile[Num5, Num6 - 3].HasTile && Main.tileSolid[Main.tile[Num5, Num6 - 3].TileType]))
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
							if (Main.tile[Num5, Num6 - 1].HasTile && Main.tileSolid[Main.tile[Num5, Num6 - 1].TileType])
							{
								NPC.velocity.Y = -6f;
								NPC.netUpdate = true;
							}
							else
							{
								if (Main.tile[Num5, Num6].HasTile && Main.tileSolid[Main.tile[Num5, Num6].TileType])
								{
									NPC.velocity.Y = -5f;
									NPC.netUpdate = true;
								}
								else
								{
									if (NPC.directionY < 0 && (!Main.tile[Num5, Num6 + 1].HasTile || !Main.tileSolid[Main.tile[Num5, Num6 + 1].TileType]) && (!Main.tile[Num5 + NPC.direction, Num6 + 1].HasTile || !Main.tileSolid[Main.tile[Num5 + NPC.direction, Num6 + 1].TileType]))
									{
										NPC.velocity.Y = -8f;
										NPC.velocity.X = NPC.velocity.X * 1.5f;
										NPC.netUpdate = true;
									}
									else
									{
										if (Flag2)
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
					if (Flag2)
					{
						NPC.ai[1] = 0f;
						NPC.ai[2] = 0f;
					}
				}
			}
		}

		public override void FindFrame(int frameHeight)
		{
			if ((NPC.frameCounter += Math.Abs(NPC.velocity.X)) >= 20)
			{
				NPC.frame.Y = (NPC.frame.Y + frameHeight) % (Main.npcFrameCount[NPC.type] * frameHeight);
				NPC.frameCounter = 0;
			}
			NPC.spriteDirection = NPC.direction;
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.SpikyBall, 2, 1, 16));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.Harpoon, 200));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Main.invasionType == InvasionID.GoblinArmy && NPC.downedBoss3 && spawnInfo.SpawnTileY < Main.worldSurface ? 0.08f : 0f;
	}
}