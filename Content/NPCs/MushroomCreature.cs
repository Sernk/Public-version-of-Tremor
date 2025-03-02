using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
	public class MushroomCreature : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Mushroom Creature");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 80;
			NPC.damage = 22;
			NPC.defense = 5;
			NPC.knockBackResist = 0.3f;
			NPC.width = 38;
			NPC.height = 50;
			AnimationType = 75;
			NPC.aiStyle = 3;
			NPC.npcSlots = 1f;
			NPC.HitSound = SoundID.NPCHit40;
			NPC.DeathSound = SoundID.NPCDeath24;
			NPC.value = Item.buyPrice(0, 0, 3, 20);
			AIType = 21;
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<MushroomCreatureBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

		public override void AI()
		{ 
			if (Main.rand.Next(1000) == 0)
				SoundEngine.PlaySound(SoundID.Unlock, NPC.position);
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && spawnInfo.SpawnTileType == TileID.MushroomGrass && spawnInfo.SpawnTileY < Main.rockLayer ? 0.03f : 0f;
	}
}