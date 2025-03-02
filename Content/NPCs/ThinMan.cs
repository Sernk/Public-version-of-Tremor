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
	public class ThinMan : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Thin Man");
			Main.npcFrameCount[NPC.type] = 10;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 10000;
			NPC.damage = 160;
			NPC.defense = 50;
			NPC.knockBackResist = 0.3f;
			NPC.width = 18;
			NPC.height = 90;
			NPC.aiStyle = 3;
			AIType = 77;
			AnimationType = 351;
			NPC.npcSlots = 0.2f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = Item.buyPrice(0, 1, 10, 9);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("ThinManBanner");
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
			npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BrokenHeroArmorplate>(), 5));
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 74, 2.5f * hitDirection, -2.5f, 0, default(Color), 1f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TMGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TMGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TMGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TMGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TMGore3").Type, 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> spawnInfo.SpawnTileY < Main.rockLayer && NPC.downedMoonlord && Main.eclipse ? 0.001f : 0f;
	}
}