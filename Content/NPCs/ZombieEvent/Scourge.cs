using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using TremorMod.Content.Items.Weapons.Melee;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items;

namespace TremorMod.Content.NPCs.ZombieEvent
{

	public class Scourge : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Scourge");
			Main.npcFrameCount[NPC.type] = 10;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 250;
			NPC.damage = 60;
			NPC.defense = 60;
			NPC.knockBackResist = 0.3f;
			NPC.width = 56;
			NPC.height = 48;
			AnimationType = 429;
			AIType = 429;
			NPC.aiStyle = 3;
			NPC.npcSlots = 0.2f;
			NPC.scale *= 0.8f;
			NPC.HitSound = SoundID.NPCHit37;
			NPC.DeathSound = SoundID.NPCDeath33;
			NPC.value = Item.buyPrice(0, 0, 9, 9);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("ScourgeBanner");
		}

		public override void AI()
		{
			if (NPC.AnyNPCs(ModContent.NPCType<Cryptomage>()))
			{
				NPC.Transform(ModContent.NPCType<SuperScourge>());
			}
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            if (Main.netMode != 1)
            {
                int centerX = (int)(NPC.position.X + NPC.width / 2) / 16;
                int centerY = (int)(NPC.position.Y + NPC.height / 2) / 16;
                int halfLength = NPC.width / 2 / 16 + 1;
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CursedCleaver>(), 30));
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<IchorCleaver>(), 30));
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CursedCloth>(), 3, 1, 3));
            }
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (Main.rand.NextBool(5))
            {
                target.AddBuff(BuffID.CursedInferno, 600);
            }

            if (Main.rand.NextBool(5))
            {
                target.AddBuff(BuffID.Ichor, 600);
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
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 0.8f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 0.8f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 0.8f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 0.8f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 0.8f);
            }
		}

	}
}