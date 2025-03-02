using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
	public class Leprechaun : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Leprechaun");
			Main.npcFrameCount[NPC.type] = 14;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 500;
			NPC.damage = 15;
			NPC.defense = 14;
			NPC.knockBackResist = 0f;
			NPC.width = 28;
			NPC.height = 46;
			NPC.aiStyle = 87;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 3, 0, 0);
			AnimationType = NPCID.BigMimicHallow;
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<LeprechaunBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;
            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 31, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 220, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 221, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 222, 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.SpawnTileY > Main.rockLayer ? 0.0007f : 0f;
	}
}