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
	public class IceBlazer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ice Blazer");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 2000;
			NPC.damage = 112;
			NPC.defense = 30;
			NPC.knockBackResist = 0.6f;
			NPC.width = 45;
			NPC.height = 75;
			AnimationType = 169;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.aiStyle = 22;
			AIType = 169;
			NPC.npcSlots = 5f;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath7;
			NPC.value = Item.buyPrice(0, 0, 5, 0);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<IceBlazerBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

        public override void OnKill()
        {
            if (Main.rand.NextBool(2))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<FrostCore>());
            }
			if (Main.rand.NextBool(5))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<IceSoul>());
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 60; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 92, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 92, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 92, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 92, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
			}
			else
			{
				for (int k = 0; k < hit.Damage / NPC.lifeMax * 50.0; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 92, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && NPC.downedMoonlord && Main.hardMode && spawnInfo.Player.ZoneSnow && spawnInfo.SpawnTileY < Main.worldSurface ? 0.004f : 0f;
	}
}