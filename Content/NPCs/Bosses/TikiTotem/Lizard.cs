using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.NPCs.Bosses.TikiTotem
{
	public class Lizard : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Lizard");
			Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 30;
			NPC.damage = 18;
			NPC.defense = 9;
			NPC.knockBackResist = 0.6f;
			NPC.width = 42;
			NPC.height = 22;
			AnimationType = 102;
			NPC.aiStyle = 26;
			NPC.npcSlots = 15f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 0, 0);
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("LizardGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("LizardGore2").Type, 1f);
			}
		}
	}
}