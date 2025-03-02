using Terraria;
using System.IO;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.ModLoader.Utilities;
using Microsoft.Xna.Framework;
using TremorMod.Content.Items.Placeable.Banners;

namespace TremorMod.Content.NPCs
{
	public class CloudSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Cloud Slime");
			Main.npcFrameCount[NPC.type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 80;
			NPC.damage = 20;
			NPC.defense = 8;
			NPC.knockBackResist = 0.3f;
			NPC.width = 34;
			NPC.height = 28;
			AnimationType = 138;
			NPC.aiStyle = 14;
			AIType = 138;
			NPC.npcSlots = 1f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath4;
			NPC.value = Item.buyPrice(0, 0, 8, 9);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<CloudSlimeBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50; // 50 убийств для баннера
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            int hitDirection = hit.HitDirection;
            int damage = hit.Damage;

            if (NPC.life <= 0)
            {
                for (int k = 0; k < 60; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 15, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 15, 3.5f * hitDirection, -3.5f, 0, default(Color), 0.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 15, 4.5f * hitDirection, -4.5f, 0, default(Color), 0.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 15, 1.5f * hitDirection, -1.5f, 0, default(Color), 0.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 15, 0.5f * hitDirection, -0.5f, 0, default(Color), 0.7f);
                }
            }
            else
            {
                for (int k = 0; k < damage / NPC.lifeMax * 50.0; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 15, hitDirection, -2f, 0, default(Color), 0.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 15, hitDirection, -1f, 0, default(Color), 0.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 15, hitDirection, -1f, 0, default(Color), 0.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 15, hitDirection, -1f, 0, default(Color), 0.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 15, hitDirection, -2f, 0, default(Color), 0.7f);
                }
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.Player.ZoneSkyHeight ? 0.02f : 0f;
        }
    }
}