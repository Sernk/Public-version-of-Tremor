using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
	public class GiantGastropod : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Giant Gastropod");
			Main.npcFrameCount[NPC.type] = 11;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 3200;
			NPC.damage = 150;
			NPC.defense = 70;
			NPC.knockBackResist = 0.1f;
			NPC.width = 40;
			NPC.height = 40;
			AnimationType = 122;
			NPC.aiStyle = 22;
			AIType = 122;
			NPC.noGravity = true;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.buffImmune[20] = true;
			NPC.buffImmune[24] = true;
			NPC.buffImmune[39] = true;
			NPC.buffImmune[31] = false;
			NPC.DeathSound = SoundID.NPCDeath7;
			NPC.value = Item.buyPrice(0, 0, 12, 0);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<GiantGastropodBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

		public override void AI()
		{
			if (Main.rand.NextBool(4))
				Main.dust[Dust.NewDust(NPC.position, NPC.width, NPC.height, 72, 0f, 0f, 200, NPC.color)].velocity *= 0.3f;
		}

		public override void OnKill()
		{
            if (Main.rand.NextBool(2))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.Glowstick, 6);
            }
        }

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 72, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 72, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 72, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				/*for(int i = 0; i < 2; ++i)
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot($"Gores/GGGore{i+1}"), 1f);*/

				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 72, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 72, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.6f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && !Main.dayTime && NPC.downedMoonlord && Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.Player.ZoneHallow && spawnInfo.SpawnTileY < Main.worldSurface ? 0.01f : 0f;
	}
}