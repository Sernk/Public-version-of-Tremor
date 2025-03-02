using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.NPCs.ZombieEvent
{
	public class Almagron : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Almagron");
			Main.npcFrameCount[NPC.type] = 10;
		}

		public override void SetDefaults()
		{
			NPC.width = 85;
			NPC.height = 85;
			NPC.damage = 141;
			NPC.defense = 30;
			NPC.lifeMax = 2500;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 0, 28, 7);
			NPC.knockBackResist = 0.3f;
			NPC.aiStyle = 3;
			AIType = 343;
			AnimationType = 343;
			NPC.buffImmune[20] = true;
			NPC.buffImmune[31] = false;
			NPC.buffImmune[24] = true;
		}

		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */
		{
			NPC.lifeMax = NPC.lifeMax * 1;
			NPC.damage = NPC.damage * 1;
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			if (Main.netMode != 1)
			{
				int centerX = (int)(NPC.position.X + NPC.width / 2) / 16;
				int centerY = (int)(NPC.position.Y + NPC.height / 2) / 16;
				int halfLength = NPC.width / 2 / 16 + 1;
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ChargedLamp>(), 22));
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<DreadLance>(), 25));
				npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<DreadLance>(), 20));

			}
		}


		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 31, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("IGGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("IGGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("IGGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("IGGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("IGGore4").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("IGGore4").Type, 1f);
			}
		}
	}
}
