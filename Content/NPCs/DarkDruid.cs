using Terraria;
using Terraria.Audio;
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
	public class DarkDruid : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Dark Druid");
			Main.npcFrameCount[NPC.type] = 15;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 300;
			NPC.damage = 25;
			NPC.defense = 2;
			NPC.knockBackResist = 0.3f;
			NPC.width = 36;
			NPC.height = 44;
			AnimationType = 21;
			NPC.aiStyle = 3;
			NPC.npcSlots = 1f;
			NPC.HitSound = SoundID.NPCHit2;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = Item.buyPrice(0, 0, 6, 50);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<DarkDruidBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50;
        }

		public override void AI()
		{
			if (Main.netMode != 1 && Main.rand.Next(160) == 0)
				NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X - 50, (int)NPC.position.Y, ModContent.NPCType<DarkDruidMinion>());

			if (Main.rand.Next(1000) == 0)
				SoundEngine.PlaySound(SoundID.Roar, NPC.position);
			if (Main.rand.Next(1000) == 0)
				SoundEngine.PlaySound(SoundID.Roar, NPC.position);
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("UndeadGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("UndeadGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("DarkDruidGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("DarkDruidGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("UndeadGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("UndeadGore2").Type, 1f);
			}
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<DarkDruidMask>(), 20));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<TearsofDeath>(), 1, 1, 5));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.Topaz, 8));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.Ruby, 8));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.Diamond, 8));
        }

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> (Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo)) && Main.bloodMoon && spawnInfo.SpawnTileY < Main.worldSurface ? 0.004f : 0f;
	}
}