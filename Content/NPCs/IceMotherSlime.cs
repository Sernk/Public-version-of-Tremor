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
	public class IceMotherSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ice Mother Slime");
			Main.npcFrameCount[NPC.type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 120;
			NPC.damage = 22;
			NPC.defense = 4;
			NPC.knockBackResist = 0.6f;
			NPC.width = 32;
			NPC.height = 22;
			AnimationType = 1;
			NPC.aiStyle = 1;
			AIType = 141;
			NPC.npcSlots = 0.1f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 6, 50);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("IceMotherSlimeBanner");
		}

		public override void AI()
		{
			if (Main.rand.Next(10) == 0)
				Main.dust[Dust.NewDust(NPC.position, NPC.width, NPC.height, 80, 0f, 0f, 200, NPC.color)].velocity *= 0.3f;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 80, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.6f);
				}

				if (Main.netMode == 1)
				{
					NPC.NewNPC(NPC.GetSource_Death(), (int)NPC.position.X, (int)NPC.position.Y - 48, NPCID.IceSlime);
					NPC.NewNPC(NPC.GetSource_Death(), (int)NPC.position.X, (int)NPC.position.Y - 48, NPCID.IceSlime);
					NPC.NewNPC(NPC.GetSource_Death(), (int)NPC.position.X, (int)NPC.position.Y - 48, NPCID.IceSlime);
				}
               
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.SpawnTileY < Main.worldSurface && spawnInfo.Player.ZoneSnow ? 0.01f : 0f;
	}
}