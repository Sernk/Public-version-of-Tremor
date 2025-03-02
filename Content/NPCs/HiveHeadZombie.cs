using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
	public class HiveHeadZombie : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Hivehead Zombie");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 125;
			NPC.damage = 25;
			NPC.defense = 15;
			NPC.knockBackResist = 0.3f;
			NPC.width = 34;
			NPC.height = 40;
			AnimationType = 3;
			NPC.aiStyle = 3;
			NPC.npcSlots = 1f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = Item.buyPrice(0, 0, 3, 0);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<HiveHeadZombieBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ZombieGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ZombieGore2").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ZombieGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ZombieGore2").Type, 1f);

				if (Main.netMode != 1)
				{
                    if (Main.netMode != NetmodeID.MultiplayerClient)
					{
						NPC.NewNPC(NPC.GetSource_Death(), (int)NPC.position.X - 22, (int)NPC.position.Y + 55, NPCID.Bee);
						NPC.NewNPC(NPC.GetSource_Death(), (int)NPC.position.X + 37, (int)NPC.position.Y, NPCID.Bee);
						NPC.NewNPC(NPC.GetSource_Death(), (int)NPC.position.X, (int)NPC.position.Y - 48, NPCID.Bee);
					}                     
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> (Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo)) && NPC.downedQueenBee && !Main.dayTime && spawnInfo.SpawnTileY < Main.worldSurface ? 0.01f : 0f;
	}
}