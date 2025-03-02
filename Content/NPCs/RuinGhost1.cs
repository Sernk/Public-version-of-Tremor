using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod;
using TremorMod.Content.Biomes.Ruins.Items;
using TremorMod.Content.Biomes.Ruins.Tiles;
using TremorMod.Utilities;
using System;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;
using ReLogic.Content;

namespace TremorMod.Content.NPCs
{
	public class RuinGhost1 : ModNPC
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
			NPC.damage = 4;
			NPC.defense = 12;
			NPC.npcSlots = 1;
			NPC.lifeMax = 90;
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

		public override void OnKill()
		{
			if (Main.rand.NextBool(33))
			{
				Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<RuinKey>());
			}
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
                NPC.active = false; // Если босс не убит, удаляем NPC
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