using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.NPCs
{
	public class AncientCursedSkull : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ancient Cursed  Skull");
			Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 4000;
			NPC.damage = 122;
			NPC.defense = 80;
			NPC.knockBackResist = 0.2f;
			NPC.width = 80;
			NPC.height = 65;
			AnimationType = 289;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.aiStyle = 10;
			AIType = 289;
			NPC.npcSlots = 5f;
			NPC.HitSound = SoundID.NPCHit2;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = Item.buyPrice(0, 0, 8, 0);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<AncientCursedSkullBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }
		
		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;
            if (NPC.life <= 0)
			{
				for (int k = 0; k < 60; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 15, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 15, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 15, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}

				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 15, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}

				Dust.NewDust(NPC.position, NPC.width, NPC.height, 15, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 15, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 15, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);				
			}
			else
			{
				for (int k = 0; k < hit.Damage / NPC.lifeMax * 50; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 15, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
			}
				
					
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return Helper.NoZoneAllowWater(spawnInfo) && spawnInfo.Player.ZoneDungeon && NPC.downedMoonlord && Main.hardMode && spawnInfo.SpawnTileY > Main.rockLayer ? 0.008f : 0f;
		}
	}
}