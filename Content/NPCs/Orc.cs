using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
	public class Orc : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Orc");
			Main.npcFrameCount[NPC.type] = 20;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 80;
			NPC.damage = 22;
			NPC.defense = 5;
			NPC.knockBackResist = 0.3f;
			NPC.width = 48;
			AIType = 77;
			NPC.height = 54;
			AnimationType = 482;
			NPC.aiStyle = 3;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath40;
			NPC.value = Item.buyPrice(0, 0, 6, 7);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<OrcBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Orc1Gore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Orc1Gore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Orc1Gore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Orc1Gore2").Type, 1f);
			}
		}

		public override void OnKill()
		{
			if (Main.rand.NextBool(20))
			{
				Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<OrcishShield>());
			}
			if (Main.rand.NextBool(21))
			{
				Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<OrcishKnife>());
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && NPC.downedBoss1 && spawnInfo.SpawnTileY < Main.worldSurface ? 0.1f : 0f;
	}
}