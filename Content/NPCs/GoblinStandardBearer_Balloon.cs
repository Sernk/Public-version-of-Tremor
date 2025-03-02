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
	public class GoblinStandardBearer_Balloon : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Goblin Standard Bearer");
			Main.npcFrameCount[NPC.type] = 3;
		}

		const int maxXMoveSpeed = 4;

		public override void SetDefaults()
		{
			NPC.lifeMax = 100;
			NPC.damage = 34;
			NPC.defense = 14;
			NPC.knockBackResist = 0.1f;
			NPC.width = 34;
			NPC.height = 70;
			NPC.aiStyle = 3;
			AIType = 77;
			NPC.npcSlots = 3f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 1, 64);
		}

		public override void AI()
		{
			NPC.TargetClosest(true);

			if (NPC.direction == -1 && NPC.velocity.X > -maxXMoveSpeed)
			{
				NPC.velocity.X = NPC.velocity.X - 0.1f;
				if (NPC.velocity.X > 2f)
					NPC.velocity.X = NPC.velocity.X - 0.1f;
				else if (NPC.velocity.X > 0f)
					NPC.velocity.X = NPC.velocity.X + 0.05f;

				if (NPC.velocity.X < -maxXMoveSpeed)
					NPC.velocity.X = -maxXMoveSpeed;
			}
			else if(NPC.direction == 1 && NPC.velocity.X < maxXMoveSpeed)
			{
				NPC.velocity.X = NPC.velocity.X + 0.1f;
				if (NPC.velocity.X < -2f)
					NPC.velocity.X = NPC.velocity.X + 0.1f;

				else if(NPC.velocity.X < 0f)
					NPC.velocity.X = NPC.velocity.X - 0.05f;

				if (NPC.velocity.X > maxXMoveSpeed)
					NPC.velocity.X = maxXMoveSpeed;
			}

			if (NPC.directionY == -1 && NPC.velocity.Y > -1.5)
			{
				NPC.velocity.Y = NPC.velocity.Y - 0.05f;

				if (NPC.velocity.Y < -1.5)
					NPC.velocity.Y = -1.5f;
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

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.SpikyBall, 2, 1, 16));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.Harpoon, 200));
        }
    }
}