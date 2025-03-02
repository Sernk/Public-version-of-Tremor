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

namespace TremorMod.Content.NPCs.ZombieEvent
{

	public class Cryptomage : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Cryptomage");
			Main.npcFrameCount[NPC.type] = 9;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 1250;
			NPC.damage = 90;
			NPC.defense = 30;
			NPC.knockBackResist = 0.3f;
			NPC.width = 34;
			NPC.height = 34;
			AnimationType = 462;
			AIType = 462;
			NPC.aiStyle = 3;
			NPC.npcSlots = 0.2f;
			NPC.scale *= 1f;
			NPC.HitSound = SoundID.NPCHit2;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = Item.buyPrice(0, 1, 12, 7);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("CryptomageBanner");
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            if (Main.netMode != 1)
            {
                int centerX = (int)(NPC.position.X + NPC.width / 2) / 16;
                int centerY = (int)(NPC.position.Y + NPC.height / 2) / 16;
                int halfLength = NPC.width / 2 / 16 + 1;
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CryptStone>(), 1, 5, 15));
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CursedCloth>(), 1, 5, 15));
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CryptomageGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CryptomageGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CryptomageGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CryptomageGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CryptomageGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CryptomageGore4").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("CryptomageGore4").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Corpse2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Corpse2").Type, 1f);
			}
		}
	}
}