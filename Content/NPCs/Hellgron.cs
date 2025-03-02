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
	public class Hellgron : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Hellgron");
			Main.npcFrameCount[NPC.type] = 14;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 200;
			NPC.damage = 26;
			NPC.defense = 16;
			NPC.knockBackResist = 0.7f;
			NPC.width = 44;
			NPC.height = 36;
			AnimationType = 180;
			NPC.aiStyle = 2;
			AIType = 180;
			NPC.npcSlots = 0.8f;
			NPC.noTileCollide = true;
			NPC.buffImmune[20] = true;
			NPC.buffImmune[24] = true;
			NPC.buffImmune[39] = true;
			NPC.buffImmune[31] = false;
			NPC.HitSound = SoundID.NPCHit27;
			NPC.DeathSound = SoundID.NPCDeath30;
			NPC.value = Item.buyPrice(0, 0, 25, 0);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("HellgronBanner");
		}

		public override void AI()
		{
			if (Main.rand.NextBool(4))
				Main.dust[Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 0f, 0f, 200, NPC.color, 2f)].velocity *= 0.3f;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("HellgronGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("HellgronGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("HellgronGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("HellgronGore3").Type, 1f);
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.6f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> (Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo)) && spawnInfo.SpawnTileY > Main.maxTilesY - 200 ? 0.03f : 0;
	}
}