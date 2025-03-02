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
	public class GoblinStandardBearer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Goblin Standard Bearer");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 175;
			NPC.damage = 34;
			NPC.defense = 14;
			NPC.knockBackResist = 0.1f;
			NPC.width = 34;
			NPC.height = 70;
			NPC.aiStyle = 3;
			AIType = 77;
			NPC.npcSlots = 3f;
			NPC.noGravity = true;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 0, 0);
		}

		public override void AI()
		{
			NPC.TargetClosest(true);

			if (NPC.direction == -1 && NPC.velocity.X > -2f)
			{
				NPC.velocity.X = NPC.velocity.X - 0.1f;
				if (NPC.velocity.X > 2f)
				{
					NPC.velocity.X = NPC.velocity.X - 0.1f;
				}
				else
				{
					if (NPC.velocity.X > 0f)
					{
						NPC.velocity.X = NPC.velocity.X + 0.05f;
					}
				}
				if (NPC.velocity.X < -2f)
				{
					NPC.velocity.X = -2f;
				}
			}
			else
			{
				if (NPC.direction == 1 && NPC.velocity.X < 2f)
				{
					NPC.velocity.X = NPC.velocity.X + 0.1f;
					if (NPC.velocity.X < -2f)
					{
						NPC.velocity.X = NPC.velocity.X + 0.1f;
					}
					else
					{
						if (NPC.velocity.X < 0f)
						{
							NPC.velocity.X = NPC.velocity.X - 0.05f;
						}
					}
					if (NPC.velocity.X > 2f)
					{
						NPC.velocity.X = 2f;
					}
				}
			}
			if (NPC.directionY == -1 && NPC.velocity.Y > -1.5)
			{
				NPC.velocity.Y = NPC.velocity.Y - 0.05f;

				if (NPC.velocity.Y < -1.5)
				{
					NPC.velocity.Y = -1.5f;
				}
			}
			else
			{
				if (NPC.directionY == 1 && NPC.velocity.Y < 1.5)
				{
					NPC.velocity.Y = NPC.velocity.Y + 0.05f;
					if (NPC.velocity.Y > 1.5)
					{
						NPC.velocity.Y = 1.5f;
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

		public override bool CheckDead()
		{
			NPC.SetDefaults(ModContent.NPCType<GoblinStandardBearer_Balloon>());
			return false;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Main.invasionType == InvasionID.GoblinArmy && NPC.downedBoss3 && spawnInfo.SpawnTileY < Main.worldSurface ? 0.3f : 0f;
	}
}