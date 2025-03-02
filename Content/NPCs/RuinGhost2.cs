using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod;
using TremorMod.Content.Biomes.Ruins.Items;
using TremorMod.Content.Biomes.Ruins.Tiles;
using TremorMod.Content.Items.BossSumonItems;
using TremorMod.Utilities;
using System;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;
using ReLogic.Content;

namespace TremorMod.Content.NPCs
{
	public class RuinGhost2 : ModNPC
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ruin Ghost");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.width = 24;
			NPC.height = 46;
			NPC.damage = 6;
			NPC.defense = 10;
			NPC.npcSlots = 1;
			NPC.lifeMax = 105;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = 100;
			NPC.knockBackResist = 0.3f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.aiStyle = 22;
			AIType = NPCID.Wraith;
			AnimationType = NPCID.Wraith;
			NPC.stepSpeed = .5f;
			NPC.lavaImmune = true;
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<RuinKey>(), 6));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<RustyLantern>(), 6));
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				//Gore.NewGore(npc.position, npc.velocity, 13);
				//Gore.NewGore(npc.position, npc.velocity, 12);
				//Gore.NewGore(npc.position, npc.velocity, 11);
			}
		}

        public override void AI()
        {
            if (!TremorSpawnEnemys.downedTikiTotem)
            {
                NPC.active = false; 
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (!TremorSpawnEnemys.downedTikiTotem)
                return 0f;

            if (!spawnInfo.Player.InModBiome<RuinBiome>())
                return 0f;

            return 0.45f;
        }
    }
}