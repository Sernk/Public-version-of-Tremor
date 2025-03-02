using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TremorMod.Content.Dusts;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
	public class QuartzBeetle : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Quartz Beetle");
			Main.npcFrameCount[NPC.type] = 12;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 3500;
			NPC.damage = 140;
			NPC.defense = 62;
			NPC.knockBackResist = 0.05f;
			NPC.width = 32;
			NPC.height = 50;
			AnimationType = 185;
			NPC.aiStyle = 3;
			AIType = 525;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit41;
			NPC.DeathSound = SoundID.NPCDeath44;
			NPC.value = Item.buyPrice(0, 0, 8, 0);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<QuartzBeetleBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

        public override void OnKill()
        {
            if (Main.rand.NextBool())
            {
                int amount = Main.rand.Next(1, 2);
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<PurpleQuartz>(), amount);
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
			int hitDirection = hit.HitDirection;

			if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<NightmareFlame>(), 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				//Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/QBGore1"), 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.Player.ZoneJungle && NPC.downedMoonlord && Main.hardMode && spawnInfo.SpawnTileY > Main.rockLayer ? 0.01f : 0f;
	}
}