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
	public class RichSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Rich Slime");
			Main.npcFrameCount[NPC.type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 1100;
			NPC.damage = 210;
			NPC.defense = 45;
			NPC.knockBackResist = 0.3f;
			NPC.width = 32;
			NPC.height = 46;
			AnimationType = 1;
			NPC.aiStyle = 1;
			AIType = 1;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath23;
			NPC.value = Item.buyPrice(1, 0, 0, 0);
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<FashionableHat>(), 50));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.Gel, 1, 5, 9));
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Yellow, 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Yellow, 0.7f);
				}

				Dust.NewDust(NPC.position, NPC.width, NPC.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Yellow, 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Yellow, 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Yellow, 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 1, 2.5f * hitDirection, -2.5f, 0, Color.Yellow, 0.7f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> spawnInfo.SpawnTileY < Main.rockLayer && Main.hardMode && Helper.NoInvasion(spawnInfo) && NPC.downedMoonlord && Main.dayTime ? 0.005f : 0f;
	}
}