using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.BossLoot.TheDarkEmperor;

namespace TremorMod.Content.NPCs.Bosses.TheDarkEmperor
{

	public class DarkSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Dark Slime");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 600;
			NPC.damage = 125;
			NPC.defense = 40;
			NPC.knockBackResist = 0.3f;
			NPC.width = 30;
			NPC.height = 23;
			AnimationType = 244;
			NPC.aiStyle = 41;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = Item.buyPrice(0, 0, 0, 0);
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 191, 2.5f * hitDirection, -2.5f, 0, Color.Green, 0.7f);

				Dust.NewDust(NPC.position, NPC.width, NPC.height, 191, 2.5f * hitDirection, -2.5f, 0, Color.Green, 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 191, 2.5f * hitDirection, -2.5f, 0, Color.Green, 0.7f);
			}
		}

        public override void OnKill()
        {
            if (Main.rand.NextBool(8))
            {
                int amount = Main.rand.Next(1, 4);
                Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ModContent.ItemType<DarkGel>(), amount);
            }
        }
    }
}