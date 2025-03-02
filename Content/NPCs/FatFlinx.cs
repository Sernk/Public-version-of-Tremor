using System;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
	public class FatFlinx : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Fat Flinx");
			Main.npcFrameCount[NPC.type] = 12;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 3000;
			NPC.damage = 110;
			NPC.defense = 45;
			NPC.knockBackResist = 0.9f;
			NPC.width = 46;
			NPC.height = 46;
			AnimationType = 185;
			NPC.aiStyle = 3;
			AIType = 166;
			NPC.npcSlots = 0.3f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath23;
			NPC.value = Item.buyPrice(0, 0, 9, 15);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<FatFlinxBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

        public override void OnKill()
        {
            if (Main.rand.NextBool(5))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<IceSoul>());
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				}
                //Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("FFGore2").Type, 1f);
                //Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("FFGore1").Type, 1f); ?
                //Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("FFGore1").Type, 1f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
			}
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.hardMode && NPC.downedMoonlord && spawnInfo.Player.ZoneSnow && spawnInfo.SpawnTileY > Main.rockLayer ? 0.5f : 0f;
        }
    }
}