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
	public class TempleSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Temple Slime");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 2000;
			NPC.damage = 125;
			NPC.defense = 32;
			NPC.knockBackResist = 0.3f;
			NPC.width = 70;
			NPC.height = 46;
			AnimationType = 244;
			NPC.aiStyle = 41;
			AIType = 138;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath23;
			NPC.value = Item.buyPrice(0, 0, 12, 15);
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.LihzahrdPowerCell, 1));
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Brown, 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Brown, 0.7f);
				}

				Dust.NewDust(NPC.position, NPC.width, NPC.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Brown, 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Brown, 1.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Brown, 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 4, 2.5f * hitDirection, -2.5f, 0, Color.Brown, 1.7f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Main.hardMode && spawnInfo.SpawnTileType == TileID.LihzahrdBrick && NPC.downedMoonlord && spawnInfo.SpawnTileY > Main.rockLayer ? 0.005f : 0f;
	}
}