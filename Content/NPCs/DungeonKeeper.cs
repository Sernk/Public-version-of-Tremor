using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;

namespace TremorMod.Content.NPCs
{
	public class DungeonKeeper : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Dungeon Keeper");
			Main.npcFrameCount[NPC.type] = 15;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 250;
			AIType = 77;
			NPC.damage = 20;
			NPC.defense = 32;
			NPC.knockBackResist = 0.05f;
			NPC.width = 32;
			NPC.height = 50;
			AnimationType = 21;
			NPC.aiStyle = 3;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 0, 8, 0);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<DungeonKeeperBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("KeeperGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("KeeperGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("KeeperGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("KeeperGore3").Type, 1f);
			}
		}

        public override void OnKill()
        {
            if (Main.rand.NextBool(25))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<ShadowReaperBook>());
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.Player.ZoneDungeon && spawnInfo.SpawnTileY > Main.rockLayer ? 0.10f : 0f;
        }
    }
}