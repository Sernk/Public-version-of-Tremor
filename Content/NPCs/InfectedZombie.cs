using System;
using Terraria;
using Terraria.Audio;
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
	public class InfectedZombie : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Infected Zombie");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 95;
			NPC.damage = 25;
			Main.npcFrameCount[NPC.type] = 3;
			NPC.defense = 14;
			NPC.knockBackResist = 0.3f;
			NPC.width = 34;
			NPC.height = 46;
			AnimationType = 3;
			NPC.aiStyle = 3;
			NPC.npcSlots = 1f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = Item.buyPrice(0, 0, 15, 9);
			//bannerItem = mod.ItemType("InfectedZombieBanner");
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && !Main.dayTime && NPC.downedBoss2 && spawnInfo.Player.ZoneCrimson && spawnInfo.SpawnTileY < Main.worldSurface ? 0.02f : 0;
	}
}