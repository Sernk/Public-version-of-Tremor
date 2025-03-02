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
	public class HeavyZombie : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Heavy Zombie");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 300;
			NPC.damage = 80;
			NPC.defense = 30;
			NPC.knockBackResist = 0.03f;
			NPC.width = 34;
			NPC.height = 40;
			AnimationType = 3;
			NPC.aiStyle = 3;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = Item.buyPrice(0, 0, 11, 0);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<HeavyZombieBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

        public override void OnKill()
        {
            if (Main.rand.NextBool(3))
            {
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<UntreatedFlesh>());
            }
            if (Main.rand.NextBool(4))
            {
                int amount = Main.rand.Next(2, 4);
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.SilverBar, amount);
			}
			if (Main.rand.NextBool(4))
			{
				int amount = Main.rand.Next(2, 4);
				Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.IronBar, amount);
			}
			if (Main.rand.NextBool(4))
			{
				int amount = Main.rand.Next(2, 4);
				Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.LeadBar, amount);
			}
            if (Main.rand.NextBool(4))
            {
                int amount = Main.rand.Next(2, 4);
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.TungstenBar, amount);
            }
        }


		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("HeavyGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("HeavyGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("HeavyGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("HeavyGore3").Type, 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> (Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo)) && Main.hardMode && !Main.dayTime && spawnInfo.SpawnTileY < Main.worldSurface ? 0.03f : 0f;
	}
}