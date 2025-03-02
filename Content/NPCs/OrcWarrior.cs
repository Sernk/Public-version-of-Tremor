using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Armor.Orcish;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
	public class OrcWarrior : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Orc Warrior");
			Main.npcFrameCount[NPC.type] = 20;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 175;
			NPC.damage = 30;
			NPC.defense = 10;
			NPC.knockBackResist = 0.3f;
			NPC.width = 48;
			NPC.height = 54;
			AnimationType = 482;
			NPC.aiStyle = 3;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath40;
			NPC.value = Item.buyPrice(0, 0, 6, 7);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<OrcWarriorBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OrcWarriorGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OrcWarriorGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OrcWarriorGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OrcWarriorGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("OrcWarriorGore4").Type, 1f);
			}
		}

        public override void OnKill()
        {
            if (Main.rand.NextBool(30))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<OrcishHelmet>());
            }
            if (Main.rand.NextBool(31))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<OrcishBreastplate>());
            }
            if (Main.rand.NextBool(32))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<OrcishGreaves>());
            }
            if (Main.rand.NextBool(34))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<OrcishBroadsword>());
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && NPC.downedBoss1 && !Main.dayTime && spawnInfo.SpawnTileY < Main.worldSurface ? 0.1f : 0f;
	}
}