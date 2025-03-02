using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Placeable.Banners;

namespace TremorMod.Content.NPCs
{
	public class DeepwaterVilefish : ModNPC
	{
		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Deepwater Vilefish");
			Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 50;
			NPC.damage = 12;
			NPC.defense = 3;
			NPC.knockBackResist = 0.3f;
			NPC.width = 62;
			NPC.height = 46;
			AnimationType = 241;
			NPC.aiStyle = 16;
			NPC.npcSlots = 1f;
			NPC.HitSound = SoundID.NPCHit47;
			NPC.DeathSound = SoundID.NPCDeath23;
			NPC.value = Item.buyPrice(0, 0, 0, 3);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<DeepwaterVilefishBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = NPC.direction;

            if (NPC.life <= 0)
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
		}

		public override void OnKill()
		{
            Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.RottenChunk);
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.RottenChunk, 1));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> spawnInfo.Player.ZoneCorrupt && spawnInfo.Water && spawnInfo.SpawnTileY > Main.rockLayer ? 0.05f : 0f;
	}
}