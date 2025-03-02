using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.NPCs
{
	public class Avenger : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Avenger");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 1750;
			NPC.damage = 165;
			NPC.defense = 80;
			NPC.knockBackResist = 0.0f;
			NPC.width = 80;
			NPC.height = 80;
			AnimationType = 82;
			NPC.aiStyle = 97;
			AIType = 420;
			NPC.npcSlots = 0.4f;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.noGravity = true;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 0, 4, 15);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("AvengerBanner");
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life > 0)
				Main.dust[Dust.NewDust(NPC.position, NPC.width, NPC.height, 71, 0f, 0f, 200)].velocity *= 1.5F;
			else
			{
				for (int i = 0; i < 50; i++)
				{
					Main.dust[Dust.NewDust(NPC.position, NPC.width, NPC.height, 71, hitDirection, 0f, 200)].velocity *= 1.5f;

                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AvengerGore1").Type, 1f);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AvengerGore1").Type, 1f);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AvengerGore2").Type, 1f);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AvengerGore2").Type, 1f);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AvengerGore3").Type, 1f);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("AvengerGore4").Type, 1f);
				}
			}
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CarbonSteel>(), 3, 1, 3));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<GoldenClaw>(), 5, 1, 5));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<AngryShard>(), 10, 1, 3));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && NPC.downedMoonlord && Main.hardMode && !Main.dayTime && spawnInfo.SpawnTileY < Main.worldSurface ? 0.03f : 0f;
		}
	}
}