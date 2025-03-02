using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;

namespace TremorMod.Content.NPCs
{
	public class SnowmanWarrior : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Snowman Warrior");
			Main.npcFrameCount[NPC.type] = 5;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 350;
			NPC.damage = 60;
			NPC.defense = 12;
			NPC.knockBackResist = 0.1f;
			NPC.width = 34;
			NPC.height = 46;
			AnimationType = 174;
			NPC.aiStyle = 41;
			AIType = 174;
			NPC.npcSlots = 0.3f;
			NPC.HitSound = SoundID.NPCHit11;
			NPC.DeathSound = SoundID.NPCDeath15;
			NPC.value = Item.buyPrice(0, 0, 8, 7);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<SnowmanWarriorBanner>();
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
			=> NPC.AnyNPCs(NPCID.MisterStabby) && Main.hardMode && spawnInfo.SpawnTileY < Main.worldSurface ? 0.08f : 0f;
	}
}