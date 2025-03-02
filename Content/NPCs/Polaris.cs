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
	public class Polaris : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Polaris");
			Main.npcFrameCount[NPC.type] = 10;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 125;
			NPC.damage = 20;
			NPC.defense = 12;
			NPC.knockBackResist = 0.4f;
			NPC.width = 56;
			NPC.height = 48;
			AIType = 429;
			AnimationType = 429;
			NPC.aiStyle = 3;
			NPC.npcSlots = 0.2f;
			NPC.HitSound = SoundID.NPCHit37;
			NPC.DeathSound = SoundID.NPCDeath57;
			NPC.value = Item.buyPrice(0, 0, 6, 9);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("PolarisBanner");
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<FrostFreshness>(), 20));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<FrostCore>(), 2));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<IceSoul>(), 5));
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 1f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.8f);
				}

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PolarisGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PolarisGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PolarisGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PolarisGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PolarisGore3").Type, 1f);

				Dust.NewDust(NPC.position, NPC.width, NPC.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 1f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 2f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 1f);

			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && Main.cloudAlpha > 0f && spawnInfo.SpawnTileY < Main.worldSurface && spawnInfo.Player.ZoneSnow ? 0.03f : 0f;
	}
}