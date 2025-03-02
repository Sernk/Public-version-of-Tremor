using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Placeable.Banners;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.Materials;

namespace TremorMod.Content.NPCs
{
	public class BloodmoonWarrior2 : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bloodmoon Warrior");
			Main.npcFrameCount[NPC.type] = 15;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 150;
			NPC.damage = 20;
			NPC.defense = 10;
			NPC.knockBackResist = 0.4f;
			NPC.width = 36;
			NPC.height = 44;
			AnimationType = 21;
			NPC.aiStyle = 3;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit2;
			AIType = 77;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = Item.buyPrice(0, 0, 6, 9);
            Banner = NPC.type;
            BannerItem = ModContent.ItemType<BloodmoonWarriorBanner>();
            ItemID.Sets.KillsToBanner[BannerItem] = 50; // 50 убийств для баннера
        }

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hit.HitDirection, -2.5f, 0, default(Color), 0.7f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("UndeadGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("UndeadGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("BloodmoonWarrior2Gore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("UndeadGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("UndeadGore2").Type, 1f);
            }
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EvilCup>(), 25));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TornPapyrus>(), 25));
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
            return Main.bloodMoon && spawnInfo.SpawnTileY < Main.worldSurface ? 0.05f : 0f;
        }
	}
}