using Terraria;
using TremorMod.Content.Items.Placeable.Banners;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Utilities;
using TremorMod.Content.Items.Weapons.Throwing;
using TremorMod.Content.Items.Materials;
using Terraria.GameContent.ItemDropRules;
using System.IO;

namespace TremorMod.Content.NPCs
{
	public class Bicholmere : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bicholmere");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 250;
			NPC.damage = 20;
			NPC.defense = 9;
			NPC.knockBackResist = 0.3f;
			NPC.width = 62;
			NPC.height = 46;
			AnimationType = 244;
			NPC.aiStyle = 1;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit47;
			NPC.DeathSound = SoundID.NPCDeath23;
			NPC.value = Item.buyPrice(0, 0, 5, 15);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<BicholmereBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50; // 50 убийств для баннера
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
			if (NPC.life <= 0)
			{
                int hitDirection = NPC.direction;

                for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("BicholmereGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("BicholmereGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("BicholmereGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("BicholmereGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("BicholmereGore3").Type, 1f);
			}
		}

		public override void OnKill()
		{
            if (Main.rand.NextFloat() < 0.10f) // 10% шанс
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<BicholmereSpear>());
            }
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.Gel);
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BicholmereSpear>(), 10));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
            return spawnInfo.Player.ZoneRockLayerHeight ? 0.02f : 0f;
        }
	}
}