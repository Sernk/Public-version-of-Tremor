using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
	public class NightTerror : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Night Terror");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 10000;
			NPC.damage = 122;
			NPC.defense = 30;
			NPC.knockBackResist = 0.6f;
			NPC.width = 75;
			NPC.height = 95;
			AnimationType = 82;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.aiStyle = 22;
			AIType = 82;
			NPC.npcSlots = 5f;
			NPC.HitSound = SoundID.NPCHit54;
			NPC.DeathSound = SoundID.NPCDeath52;
			NPC.value = Item.buyPrice(0, 0, 8, 0);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<NightTerrorBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

		public override void OnKill()
		{
			if (Main.rand.NextBool(40))
			{
				Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<AxeofExecutioner>());
			}
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 60; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}

				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 54, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
			}
			else
			{
				for (int k = 0; k < hit.Damage / NPC.lifeMax * 50; k++)
					Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
            }
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> (Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo)) && NPC.downedMoonlord && Main.hardMode && Main.bloodMoon && spawnInfo.SpawnTileY < Main.worldSurface ? 0.004f : 0f;
	}
}