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
	public class Zarprite : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Zarprite");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 150;
			NPC.damage = 10;
			NPC.defense = 12;
			NPC.knockBackResist = 0.3f;
			NPC.width = 34;
			NPC.height = 48;
			AnimationType = 75;
			NPC.aiStyle = 14;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit35;
			NPC.noGravity = true;
			NPC.DeathSound = SoundID.NPCDeath57;
			NPC.value = Item.buyPrice(0, 0, 15, 0);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<ZarpriteBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ZarpriteGore").Type, 1f);

                if (Main.netMode == 1) return;

				NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X - 6, (int)NPC.position.Y + 6, ModContent.NPCType<Parasprite>());
				NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X + 6, (int)NPC.position.Y, ModContent.NPCType<Parasprite>());
				NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X, (int)NPC.position.Y - 6, ModContent.NPCType<Parasprite>());
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> (Helper.NoZoneAllowWater(spawnInfo)) && spawnInfo.SpawnTileY > Main.rockLayer ? 0.01f : 0f;
	}
}