using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Materials;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
	public class GeneralSnowman : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("General Snowman");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 800;
			NPC.damage = 50;
			NPC.defense = 22;
			NPC.knockBackResist = 0.1f;
			NPC.width = 34;
			NPC.height = 46;
			AnimationType = 143;
			NPC.aiStyle = 38;
			AIType = 143;
			NPC.npcSlots = 0.3f;
			NPC.HitSound = SoundID.NPCHit11;
			NPC.DeathSound = SoundID.NPCDeath15;
			NPC.value = Item.buyPrice(0, 0, 8, 7);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<GeneralSnowmanBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 1f);

				Dust.NewDust(NPC.position, NPC.width, NPC.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 3f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 2f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 76, 2.5f * hitDirection, -2.5f, 0, default(Color), 3f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> NPC.AnyNPCs(NPCID.MisterStabby) && Main.hardMode && spawnInfo.SpawnTileY < Main.worldSurface ? 0.01f : 0f;
	}
}