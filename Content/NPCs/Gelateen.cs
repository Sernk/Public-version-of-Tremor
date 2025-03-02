using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.NPCs
{
	public class Gelateen : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Gelateen");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 500;
			NPC.damage = 20;
			NPC.defense = 24;
			NPC.knockBackResist = 0.6f;
			NPC.width = 90;
			NPC.height = 62;
			AnimationType = 141;
			NPC.aiStyle = 1;
			NPC.npcSlots = 1f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 12, 24);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("GelateenBanner");
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BounceTome>(), 1));
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Green, 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Green, 0.7f);
				}
				for (int i = 0; i < 3; ++i)
				{
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("GelateenGore1").Type, 1f);
                }

				Dust.NewDust(NPC.position, NPC.width, NPC.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Green, 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Green, 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Green, 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 1, 2.5f * hitDirection, -2.5f, 0, Color.Green, 0.7f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.SpawnTileY > Main.rockLayer ? 0.001f : 0f;
	}
}