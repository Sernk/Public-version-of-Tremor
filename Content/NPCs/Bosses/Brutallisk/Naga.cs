using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TremorMod.Content.NPCs.Bosses.Brutallisk
{
	public class Naga : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Naga");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 2000;
			NPC.damage = 130;
			NPC.defense = 30;
			NPC.knockBackResist = 1f;
			NPC.width = 46;
			NPC.height = 44;
			AnimationType = 3;
			NPC.aiStyle = 26;
			NPC.npcSlots = 1f;
			//npc.soundHit = 7;
			//npc.soundKilled = 10;
			NPC.value = Item.buyPrice(0, 5, 3, 2);
		}

		public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
		{
			if (Main.rand.NextBool())
			{
				target.AddBuff(BuffID.Venom, 300, true);
			}
		}

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("NagaGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("NagaGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("NagaGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("NagaGore3").Type, 1f);
			}
			else
			{
				for (int k = 0; k < hit.Damage / NPC.lifeMax * 50; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, hitDirection, -1f, 0, default(Color), 0.7f);
			}
		}
	}
}