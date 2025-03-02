using System;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;

namespace TremorMod.Content.NPCs
{
	public class EvolvedZombie2 : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Evolved Zombie");
			Main.npcFrameCount[NPC.type] = 8;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 1000;
			NPC.damage = 110;
			NPC.defense = 7;
			NPC.knockBackResist = 0.3f;
			NPC.width = 34;
			NPC.height = 46;
			AnimationType = 525;
			NPC.aiStyle = 3;
			AIType = 525;
			NPC.npcSlots = 0.3f;
			NPC.HitSound = SoundID.NPCHit37;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = Item.buyPrice(0, 0, 6, 7);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<EvolvedZombieBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

        public override void OnKill()
        {
            if (Main.rand.NextBool(2))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<ConcentratedEther>());
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 1f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("EvolvGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("EvolvGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("EvolvGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("EvolvGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("EvolvGore4").Type, 1f);
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hitDirection, -2.5f, 0, Color.White, 3f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hitDirection, -2.5f, 0, Color.White, 2f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hitDirection, -2.5f, 0, Color.White, 3f);
			}
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return NPC.downedMoonlord && Main.hardMode && !Main.dayTime && spawnInfo.SpawnTileY < Main.worldSurface ? 0.03f : 0f;
        }
    }
}