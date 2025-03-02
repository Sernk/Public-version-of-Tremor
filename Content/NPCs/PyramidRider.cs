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
	public class PyramidRider : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Pyramid Rider");
			Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 116;
			NPC.damage = 20;
			NPC.defense = 10;
			NPC.knockBackResist = 0.6f;
			NPC.width = 76;
			NPC.height = 38;
			AnimationType = 508;
			NPC.aiStyle = 26;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.value = Item.buyPrice(0, 0, 5, 0);
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 18, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				if (Main.netMode == 1) return;

				NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X, (int)NPC.position.Y + 55, NPCID.WalkingAntlion);
				NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X - 22, (int)NPC.position.Y + 55, ModContent.NPCType<PyramidHead>());
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.Player.ZoneDesert && NPC.downedBoss1 && !Main.dayTime && spawnInfo.SpawnTileY < Main.worldSurface ? 0.03f : 0f;
	}
}