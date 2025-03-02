using System;
using Terraria;
using Terraria.Audio;
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
	public class GoblinBomber : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Goblin Bomber");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 90;
			NPC.damage = 50;
			NPC.defense = 0;
			NPC.knockBackResist = 0.3f;
			NPC.width = 42;
			NPC.height = 56;
			NPC.aiStyle = -1;
			NPC.npcSlots = 15f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 1, 21);
		}
		
		public override void AI()
		{
			NPC.TargetClosest(true);
			NPC.spriteDirection = NPC.direction;
			DoAI();
		}

		public void DoAI()
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
					//Main.tile[Num5 + npc.direction, Num6 - 1] = new Tile();
				}
				if (Main.tile[Num5 + NPC.direction, Num6 + 1] == null)
				{
					//Main.tile[Num5 + npc.direction, Num6 + 1] = new Tile();
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

		public override void FindFrame(int frameHeight)
		{
			if ((NPC.frameCounter += Math.Abs(NPC.velocity.X)) >= 20)
			{
				NPC.frame.Y = (NPC.frame.Y + frameHeight) % (Main.npcFrameCount[NPC.type] * frameHeight);
				NPC.frameCounter = 0;
			}
			NPC.spriteDirection = NPC.direction;
		}

		public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
		{
			NPC.life = -1;
			NPC.checkDead();
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				SoundEngine.PlaySound(SoundID.Item62, NPC.position);
				NPC.position.X = NPC.position.X + NPC.width / 2;
				NPC.position.Y = NPC.position.Y + NPC.height / 2;
				NPC.width = 80;
				NPC.height = 80;
				NPC.position.X = NPC.position.X - NPC.width / 2;
				NPC.position.Y = NPC.position.Y - NPC.height / 2;

				for (int i = 0; i < 40; i++)
				{
					int num629 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, 31, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num629].velocity *= 3f;
					if (Main.rand.NextBool(2))
					{
						Main.dust[num629].scale = 0.5f;
						Main.dust[num629].fadeIn = 1f + Main.rand.Next(10) * 0.1f;
					}
				}
				for (int i = 0; i < 70; i++)
				{
					int num631 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, 6, 0f, 0f, 100, default(Color), 3f);
					Main.dust[num631].noGravity = true;
					Main.dust[num631].velocity *= 5f;
					num631 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, 6, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num631].velocity *= 2f;
				}
				for (int num632 = 0; num632 < 3; num632++)
				{
					float scaleFactor10 = 0.33f;
					if (num632 == 1)
					{
						scaleFactor10 = 0.66f;
					}
					if (num632 == 2)
					{
						scaleFactor10 = 1f;
					}
					Gore gore = Main.gore[Gore.NewGore(NPC.GetSource_Death(), new Vector2(NPC.position.X + NPC.width / 2 - 24f, NPC.position.Y + NPC.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64))];
					gore.velocity *= scaleFactor10;
					gore.velocity.X = gore.velocity.X + 1f;
					gore.velocity.Y = gore.velocity.Y + 1f;

					gore = Main.gore[Gore.NewGore(NPC.GetSource_Death(), new Vector2(NPC.position.X + NPC.width / 2 - 24f, NPC.position.Y + NPC.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64), 2f)];
					gore.velocity *= scaleFactor10;
					gore.velocity.X = gore.velocity.X - 1f;
					gore.velocity.Y = gore.velocity.Y + 1f;

					gore = Main.gore[Gore.NewGore(NPC.GetSource_Death(), new Vector2(NPC.position.X + NPC.width / 2 - 24f, NPC.position.Y + NPC.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64))];
					gore.velocity *= scaleFactor10;
					gore.velocity.X = gore.velocity.X + 1f;
					gore.velocity.Y = gore.velocity.Y - 1f;

					gore = Main.gore[Gore.NewGore(NPC.GetSource_Death(), new Vector2(NPC.position.X + NPC.width / 2 - 24f, NPC.position.Y + NPC.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64))];
					gore.velocity *= scaleFactor10;
					gore.velocity.X = gore.velocity.X - 1f;
					gore.velocity.Y = gore.velocity.Y - 1f;
				}
				NPC.position.X = NPC.position.X + NPC.width / 2;
				NPC.position.Y = NPC.position.Y + NPC.height / 2;
				NPC.width = 10;
				NPC.height = 10;
				NPC.position.X = NPC.position.X - NPC.width / 2;
				NPC.position.Y = NPC.position.Y - NPC.height / 2;
			}
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