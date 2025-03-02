using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Placeable.Banners;

namespace TremorMod.Content.NPCs
{
	public class CrimsonBicholmere : ModNPC
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Crimson Bicholmere");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
            NPC.lifeMax = 300;
            NPC.damage = 28;
            NPC.defense = 11;
            NPC.knockBackResist = 0.3f;
            NPC.width = 62;
            NPC.height = 46;
            AnimationType = 244;
            NPC.aiStyle = 1;
            NPC.npcSlots = 0.9f;
            NPC.HitSound = SoundID.NPCHit47;
            NPC.DeathSound = SoundID.NPCDeath23;
            NPC.value = Item.buyPrice(0, 0, 5, 25);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<CrimsonBiholmerBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
		}

        public override void HitEffect(NPC.HitInfo hit)
        {
			if (NPC.life <= 0)
			{
				int hitDirection = NPC.direction;

				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CrimsonBicholmereGore1").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CrimsonBicholmereGore2").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CrimsonBicholmereGore3").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CrimsonBicholmereGore3").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CrimsonBicholmereGore3").Type, 1f);
			}
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Vertebrae, 1));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.Player.ZoneCrimson && spawnInfo.SpawnTileY > Main.rockLayer ? 0.05f : 0f;
        }
    }
}