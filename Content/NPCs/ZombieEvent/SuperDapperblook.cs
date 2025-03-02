using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items;

namespace TremorMod.Content.NPCs.ZombieEvent
{

	public class SuperDapperblook : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Dapperblook");
			Main.npcFrameCount[NPC.type] = 4;
		}

		const int SpeedMulti = 3; 

		public override void SetDefaults()
		{
			NPC.lifeMax = 400;
			NPC.damage = 84;
			NPC.defense = 46;
			NPC.knockBackResist = 0.0f;
			NPC.width = 42;
			NPC.height = 82;
			NPC.alpha = 100;
			AnimationType = 82;
			NPC.aiStyle = 22;
			NPC.npcSlots = 0.5f;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit52;
			NPC.noGravity = true;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 0, 4, 9);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("DapperblookBanner");
		}

        public override void AI()
        {
            if (!NPC.AnyNPCs(ModContent.NPCType<Cryptomage>()))
            {
                NPC.Transform(ModContent.NPCType<Dapperblook>());
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            if (Main.netMode != 1)
            {
                int centerX = (int)(NPC.position.X + NPC.width / 2) / 16;
                int centerY = (int)(NPC.position.Y + NPC.height / 2) / 16;
                int halfLength = NPC.width / 2 / 16 + 1;
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CursedInk>(), 4));
            }
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */
		{
			NPC.lifeMax = NPC.lifeMax * 1;
			NPC.damage = NPC.damage * 1;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 61, 0.8f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 61, 0.8f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 62, 0.8f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 62, 0.8f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 63, 0.8f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 63, 0.8f);
            }
		}

	}
}