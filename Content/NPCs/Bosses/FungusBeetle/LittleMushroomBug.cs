using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Bag;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Placeable;

namespace TremorMod.Content.NPCs.Bosses.FungusBeetle
{

	public class LittleMushroomBug : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Little Mushroom Bug");
			Main.npcFrameCount[NPC.type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 30;
			NPC.damage = 28;
			NPC.defense = 10;
			NPC.knockBackResist = 0.2f;
			NPC.width = 28;
			NPC.height = 26;
			AnimationType = 2;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.aiStyle = 14;
			AIType = 49;
			NPC.npcSlots = 5f;
			NPC.HitSound = SoundID.NPCHit35;
			NPC.DeathSound = SoundID.NPCDeath57;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 60; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 67, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 67, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
			}
			else
			{
				for (int k = 0; k < hit.Damage / NPC.lifeMax * 50; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 67, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
			}
		}
	}
}