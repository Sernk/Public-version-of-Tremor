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
	public class BoneArcher : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bone Archer");
			Main.npcFrameCount[NPC.type] = 21;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 200;
			NPC.damage = 36;
			NPC.defense = 13;
			NPC.knockBackResist = 0.3f;
			NPC.width = 36;
			NPC.height = 44;
			NPC.npcSlots = 0.2f;
			NPC.HitSound = SoundID.NPCHit2;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.aiStyle = 3;
			AIType = 111;
			AnimationType = 111;
			NPC.value = Item.buyPrice(0, 0, 6, 9);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<BoneArcherBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.Hook, 45));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.WoodenArrow, 1, 1, 3));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.FlamingArrow, 1, 1, 3));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<TornPapyrus>(), 20));
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("UndeadGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("UndeadGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("BoneArcherGore").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("UndeadGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("UndeadGore2").Type, 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return Helper.NoZoneAllowWater(spawnInfo) && NPC.downedBoss3 && spawnInfo.SpawnTileY > Main.rockLayer ? 0.02f : 0f;
		}
	}
}