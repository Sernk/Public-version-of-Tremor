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

	public class Arsonist : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Arsonist");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 115;
			NPC.damage = 20;
			NPC.defense = 16;
			NPC.knockBackResist = 0.3f;
			NPC.width = 34;
			NPC.height = 46;
			AnimationType = 3;
			NPC.aiStyle = 3;
			NPC.npcSlots = 2f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.value = Item.buyPrice(0, 0, 1, 0);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("ArsonistBanner");
		}

		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */
		{
			NPC.lifeMax = NPC.lifeMax * 1;
			NPC.damage = NPC.damage * 1;
		}

		public override void AI()
		{
			if (Main.rand.NextBool(4))
			{
				int num706 = Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 0f, 0f, 200, NPC.color, 1f);
				Main.dust[num706].velocity *= 0.3f;
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
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("DeadlingHead1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("DeadlingLeg").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("DeadlingArm").Type, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("DeadlingLeg").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("DeadlingArm").Type, 1f);
			}
		}

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (Main.rand.NextBool())
            {
                target.AddBuff(BuffID.Darkness, 60); 
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
			if (Main.netMode != 1)
			{
				int centerX = (int)(NPC.position.X + NPC.width / 2) / 16;
				int centerY = (int)(NPC.position.Y + NPC.height / 2) / 16;
				int halfLength = NPC.width / 2 / 16 + 1;
				if (Main.rand.NextBool(2))
				{
					Item.NewItem(NPC.GetSource_FromThis(), (int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, 8, Main.rand.Next(1, 2));
				};
			}
		}
    }
}