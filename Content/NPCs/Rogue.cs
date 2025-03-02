using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TremorMod.Content.Dusts;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs
{
	public class Rogue : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Rogue");
			Main.npcFrameCount[NPC.type] = 12;
		}

		public override void SetDefaults()
		{
			NPC.width = 18;
			NPC.height = 40;
			NPC.damage = 16;
			NPC.defense = 10;
			NPC.lifeMax = 86;
			NPC.HitSound = SoundID.NPCHit40;
			NPC.DeathSound = SoundID.NPCDeath42;
			NPC.value = Item.buyPrice(0, 0, 4, 7);
			NPC.knockBackResist = 0.5f;
			NPC.aiStyle = 3;
			AIType = 111;
			AnimationType = 379;
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<RogueBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

        public override void OnKill()
        {
            if (Main.rand.NextBool(2))
            {
                int amount = Main.rand.Next(2, 6);
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.WoodenArrow, amount);
            }
			if (Main.rand.NextBool(4))
            {
                int amount = Main.rand.Next(2, 6);
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.FlamingArrow, amount);
            }
			if (Main.rand.NextBool(15))
            {
                int amount = Main.rand.Next(1, 3);
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.Sapphire, amount);
            }
			if (Main.rand.NextBool(15))
            {
                int amount = Main.rand.Next(1, 3);
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.Ruby, amount);
            }
			if (Main.rand.NextBool(15))
            {
                int amount = Main.rand.Next(1, 3);
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.Emerald, amount);
            }
			if (Main.rand.NextBool(15))
            {
                int amount = Main.rand.Next(1, 3);
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.Topaz, amount);
            }
			if (Main.rand.NextBool(15))
            {
                int amount = Main.rand.Next(1, 3);
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.Amethyst, amount);
            }
			if (Main.rand.NextBool(15))
            {
                int amount = Main.rand.Next(1, 3);
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.Amethyst, amount);
            }
			if (Main.rand.NextBool(15))
            {
                int amount = Main.rand.Next(1, 3);
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.Diamond, amount);
            }
			if (Main.rand.NextBool(3))
            {
                int amount = Main.rand.Next(2, 6);
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.ThrowingKnife, amount);
            }
			if (Main.rand.NextBool(5))
            {
                int amount = Main.rand.Next(2, 4);
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.ThrowingKnife, amount);
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				for(int i = 0; i < 3; ++i)
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("RogueGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("RogueGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("RogueGore3").Type, 1f);
            }
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> spawnInfo.SpawnTileY < Main.rockLayer && !Main.dayTime ? 0.01f : 0f;
	}
}
