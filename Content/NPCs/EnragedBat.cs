using System;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TremorMod.Content.Items.Placeable.Banners;

namespace TremorMod.Content.NPCs
{
	public class EnragedBat : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Enraged Bat");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 1000;
			NPC.damage = 110;
			NPC.defense = 20;
			NPC.knockBackResist = 0.3f;
			NPC.width = 56;
			NPC.height = 48;
			AnimationType = 93;
			NPC.aiStyle = 14;
			NPC.npcSlots = 0.2f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.noGravity = true;
			NPC.DeathSound = SoundID.NPCDeath4;
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<EnragedBatBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 27, 2.5f * hitDirection, -2.5f, 0, default(Color), 1f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("EnragedGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("EnragedGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("EnragedGore2").Type, 1f);
			}
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.hardMode && NPC.downedMoonlord && !spawnInfo.Player.ZoneDungeon && spawnInfo.SpawnTileY > Main.rockLayer ? 0.1f : 0f;
        }
    }
}