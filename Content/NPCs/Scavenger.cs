using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.NPCs
{
	public class Scavenger : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Scavenger");
			Main.npcFrameCount[NPC.type] = 10;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 1000;
			NPC.damage = 20;
			if (NPC.downedBoss2)
			{
				NPC.lifeMax = 1500;
				NPC.damage = 25;
			}
			if (NPC.downedBoss3)
			{
				NPC.lifeMax = 2000;
				NPC.damage = 30;
			}
			if (Main.hardMode)
			{
				NPC.lifeMax = 5000;
				NPC.damage = 70;
			}
			if (NPC.downedMechBossAny)
			{
				NPC.lifeMax = 10000;
				NPC.damage = 80;
			}
			if (NPC.downedPlantBoss)
			{
				NPC.lifeMax = 12000;
				NPC.damage = 100;
			}
			if (NPC.downedGolemBoss)
			{
				NPC.lifeMax = 15000;
				NPC.damage = 150;
			}
			NPC.defense = 4;
			NPC.knockBackResist = 0.3f;
			NPC.width = 18;
			NPC.height = 90;
			AnimationType = 351;
			NPC.aiStyle = 3;
			AIType = 77;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = Item.buyPrice(0, 0, 8, 0);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("ScavengerBanner");
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ScavengerGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ScavengerGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ScavengerGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ScavengerGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ScavengerGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ScavengerGore4").Type, 1f);

			}
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            if (!Main.hardMode)
            {
                npcLoot.Add(ItemDropRule.Common(29, 2, 1, 3));

                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsCrimson(), 1257, 1, 10, 26));
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsCorruption(), 57, 1, 10, 26));

                npcLoot.Add(ItemDropRule.Common(188, 1, 2, 11));
                npcLoot.Add(ItemDropRule.Common(189, 1, 2, 11));
                npcLoot.Add(ItemDropRule.Common(178, 1, 5, 16));
                npcLoot.Add(ItemDropRule.Common(182, 1, 5, 16));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Opal>(), 5, 1, 3));
                npcLoot.Add(ItemDropRule.Common(227, 1, 2, 11));
                npcLoot.Add(ItemDropRule.Common(175, 1, 2, 11));
                npcLoot.Add(ItemDropRule.Common(3532, 1, 1, 3));
            }
            else
            {
                npcLoot.Add(ItemDropRule.Common(2161, 5, 1, 3));
                npcLoot.Add(ItemDropRule.Common(2351, 3, 1, 6));
                npcLoot.Add(ItemDropRule.Common(723, 10));
                npcLoot.Add(ItemDropRule.Common(855, 50));
                npcLoot.Add(ItemDropRule.Common(499, 3, 1, 6));
                npcLoot.Add(ItemDropRule.Common(500, 3, 1, 6));
                npcLoot.Add(ItemDropRule.Common(1242, 15));
                npcLoot.Add(ItemDropRule.Common(1291, 3, 1, 3));
                npcLoot.Add(ItemDropRule.Common(1321, 50));
                npcLoot.Add(ItemDropRule.Common(1326, 100));
                npcLoot.Add(ItemDropRule.Common(1324, 25));
                npcLoot.Add(ItemDropRule.Common(3368, 80));
                npcLoot.Add(ItemDropRule.Common(3260, 80));
                npcLoot.Add(ItemDropRule.Common(3262, 80));
                npcLoot.Add(ItemDropRule.Common(3212, 80));
                npcLoot.Add(ItemDropRule.Common(3099, 80));
                npcLoot.Add(ItemDropRule.Common(3095, 80));
                npcLoot.Add(ItemDropRule.Common(3096, 80));
                npcLoot.Add(ItemDropRule.Common(3091, 80));
                npcLoot.Add(ItemDropRule.Common(3092, 80));
                npcLoot.Add(ItemDropRule.Common(2674, 8, 1, 6));
                npcLoot.Add(ItemDropRule.Common(2675, 15, 1, 10));
                npcLoot.Add(ItemDropRule.Common(2676, 50, 1, 15));
                npcLoot.Add(ItemDropRule.Common(2336, 60));
                npcLoot.Add(ItemDropRule.Common(2335, 50));
                npcLoot.Add(ItemDropRule.Common(2334, 30));
                npcLoot.Add(ItemDropRule.Common(422, 15, 1, 10));
                npcLoot.Add(ItemDropRule.Common(423, 15, 1, 10));
                npcLoot.Add(ItemDropRule.Common(497, 45));
                npcLoot.Add(ItemDropRule.Common(502, 3, 1, 10));
                npcLoot.Add(ItemDropRule.Common(501, 3, 1, 15));
                npcLoot.Add(ItemDropRule.Common(507, 26));
                npcLoot.Add(ItemDropRule.Common(508, 26));
                npcLoot.Add(ItemDropRule.Common(527, 62));
                npcLoot.Add(ItemDropRule.Common(528, 62));
            }
        }


        public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && !Main.dayTime && spawnInfo.SpawnTileY < Main.worldSurface ? 0.0001f : 0f;
	}
}