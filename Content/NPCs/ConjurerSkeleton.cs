using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TremorMod.Content.Items.Placeable.Banners;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.NPCs
{
	public class ConjurerSkeleton : ModNPC
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Conjurer Skeleton");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.width = 40;
			NPC.height = 40;
			NPC.damage = 16;
			NPC.defense = 16;
			NPC.lifeMax = 270;
			NPC.HitSound = SoundID.NPCHit2;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 1, 5, 7);
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = 8;
			AIType = 29;
			AnimationType = 29;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<ConjurerSkeletonBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50; 
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.MagicHat, 30));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TornPapyrus>(), 5));
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
                for (int k = 0; k < 20; k++)
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hit.HitDirection, -2.5f, 0, default(Color), 0.7f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("UndeadGore1").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("UndeadGore2").Type, 1f);                
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("UndeadWarrior2Gore1").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("UndeadWarrior2Gore2").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("UndeadGore1").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("UndeadGore2").Type, 1f);
			}
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return NPC.downedBoss3 && spawnInfo.SpawnTileY > Main.rockLayer ? 0.02f : 0f;
        }
    }
}
