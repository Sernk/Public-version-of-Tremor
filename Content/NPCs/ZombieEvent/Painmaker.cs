using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items;

namespace TremorMod.Content.NPCs.ZombieEvent
{

	public class Painmaker : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Painmaker");
			Main.npcFrameCount[NPC.type] = 4;
		}

		const int SpeedMulti = 3; 

		public override void SetDefaults()
		{
			NPC.lifeMax = 500;
			NPC.damage = 64;
			NPC.defense = 50;
			NPC.knockBackResist = 0.3f;
			NPC.width = 42;
			NPC.height = 62;
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
			// Todo: bannerItem = mod.ItemType("Painmaker");
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            if (Main.netMode != 1)
            {
                int centerX = (int)(NPC.position.X + NPC.width / 2) / 16;
                int centerY = (int)(NPC.position.Y + NPC.height / 2) / 16;
                int halfLength = NPC.width / 2 / 16 + 1;
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ScaryCloak>(), 30));
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
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 61, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 61, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 62, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 62, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 63, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 63, 1f);
            }
        }
    }
}