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
	public class SpiderMan : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Spider Man");
			Main.npcFrameCount[NPC.type] = 15;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 400;
			NPC.damage = 80;
			NPC.defense = 25;
			NPC.knockBackResist = 1f;
			NPC.width = 46;
			NPC.height = 50;
			AnimationType = 21;
			NPC.aiStyle = 26;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit47;
			NPC.DeathSound = SoundID.NPCDeath23;
			NPC.value = Item.buyPrice(0, 0, 25, 0);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<SpiderManBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.SpiderFang, 2, 60, 150));
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;
            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                //Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SpiderManGore1").Type, 1f);
                //Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SpiderManGore2").Type, 1f);
                //Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SpiderManGore2").Type, 1f);
                //Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SpiderManGore2").Type, 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.SpiderCave ? 0.08f : 0f;
	}
}