using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;	
using TremorMod.Content.Items.Placeable.Banners;

namespace TremorMod.Content.NPCs
{
	public class Deimos : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Deimos");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 10000;
			NPC.damage = 180;
			NPC.defense = 100;
			NPC.knockBackResist = 0.0f;
			NPC.width = 145;
			NPC.height = 145;
			AnimationType = 82;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.aiStyle = 22;
			AIType = 226;
			NPC.npcSlots = 5f;
			NPC.HitSound = SoundID.NPCHit54;
			NPC.DeathSound = SoundID.NPCDeath52;
			NPC.value = Item.buyPrice(0, 10, 15, 12);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<DeimosBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

		public override void AI()
		{
			if (Main.rand.NextBool(6))
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 27, 0f, 0f, 200, NPC.color);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 70, 0f, 0f, 200, NPC.color);
			}
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EyeofOblivion>(), 2));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CarbonSteel>(), 2, 3, 6));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ToothofAbraxas>(), 2, 2, 17));
        }


        public override void HitEffect(NPC.HitInfo hit)
        {
            int hitDirection = hit.HitDirection; 

            if (NPC.life <= 0)
            {
                for (int k = 0; k < 60; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 27, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 70, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
                }

                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 27, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
                }

                Dust.NewDust(NPC.position, NPC.width, NPC.height, 27, 2.5f * hitDirection, -2.5f, 0, default(Color), 3.7f);
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 70, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("DeimosGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("DeimosGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("DeimosGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("DeimosGore3").Type, 1f);
            }
            else
            {
                for (int k = 0; k < hit.Damage / NPC.lifeMax * 50; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 27, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
                }
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			int x = spawnInfo.SpawnTileX;
			int y = spawnInfo.SpawnTileY;
			int tile = Main.tile[x, y].TileType;
            return NPC.downedMoonlord && Main.hardMode && !Main.dayTime && spawnInfo.SpawnTileY < Main.worldSurface ? 0.20f : 0f;
        }
	}
}