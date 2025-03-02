using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.NPCs
{
	public class CreatorofNightmares : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Creator of Nightmares");
			Main.npcFrameCount[NPC.type] = 16;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 6000;
			NPC.damage = 155;
			NPC.defense = 38;
			NPC.knockBackResist = 0.3f;
			NPC.width = 34;
			NPC.height = 54;
			AnimationType = 460;
			NPC.aiStyle = 3;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit1;
			AIType = 604;
			NPC.DeathSound = SoundID.NPCDeath52;
			NPC.value = Item.buyPrice(0, 3, 1, 0);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("CreatorofNightmaresBanner");
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BrokenHeroArmorplate>(), 5));
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);

                for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && spawnInfo.SpawnTileY < Main.rockLayer && NPC.downedMoonlord && Main.eclipse ? 0.01f : 0f;
	}
}