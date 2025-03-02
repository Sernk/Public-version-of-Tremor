using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Placeable.Banners;

namespace TremorMod.Content.NPCs
{
	public class Snowcopter : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Snowcopter");
			Main.npcFrameCount[NPC.type] = 8;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 600;
			NPC.damage = 55;
			NPC.defense = 46;
			NPC.knockBackResist = 0.1f;
			NPC.width = 58;
			NPC.height = 36;
			AnimationType = 347;
			NPC.aiStyle = 62;
			AIType = 347;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.npcSlots = 3f;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 0, 8, 7);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<SnowcopterBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;
            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 61, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 61, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 62, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 62, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 63, 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> NPC.AnyNPCs(NPCID.SnowBalla) && Main.hardMode && spawnInfo.SpawnTileY < Main.worldSurface ? 0.06f : 0f;
	}
}