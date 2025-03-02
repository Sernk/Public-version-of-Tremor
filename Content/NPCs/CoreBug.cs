using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TremorMod.Content.Items.Placeable.Banners;

namespace TremorMod.Content.NPCs
{
	public class CoreBug : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Space Bug");
			Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 150;
			NPC.damage = 18;
			NPC.defense = 10;
			NPC.knockBackResist = 0.6f;
			NPC.width = 38;
			NPC.height = 44;
			AnimationType = 258;
			NPC.aiStyle = 3;
			AIType = 258;
			NPC.npcSlots = 0.2f;
			NPC.HitSound = SoundID.NPCHit45;
			NPC.DeathSound = SoundID.NPCDeath47;
			NPC.value = Item.buyPrice(0, 0, 2, 24);
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<CoreBugBanner>();
			ItemID.Sets.KillsToBanner[BannerItem] = 50;
		}

		public override void AI()
		{
			if (Main.rand.NextBool(4))
				Main.dust[Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 0f, 0f, 200, NPC.color)].velocity *= 0.3f;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hit.HitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hit.HitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hit.HitDirection, -2.5f, 0, default(Color), 0.7f);

				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hit.HitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hit.HitDirection, -2.5f, 0, default(Color), 0.6f);
				}
			}
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.Player.ZoneMeteor ? 1f : 0f;
        }
    }
}