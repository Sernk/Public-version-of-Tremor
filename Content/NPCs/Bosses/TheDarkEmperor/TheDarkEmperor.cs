using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.NPCs.Bosses.TheDarkEmperor
{
	[AutoloadBossHead]

	public class TheDarkEmperor : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("The Dark Emperor");
			Main.npcFrameCount[NPC.type] = 14;
		}

		public override void SetDefaults()
		{
			NPC.width = 126;
			NPC.height = 106;
			NPC.damage = 200;
			NPC.defense = 170;
			NPC.lifeMax = 100000;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = 80000f;
			NPC.knockBackResist = 0.0f;
			Music = 17;
			NPC.aiStyle = 87;
			AIType = 475;
			AnimationType = 473;
			NPC.npcSlots = 10f;
			NPC.buffImmune[20] = true;
			NPC.buffImmune[24] = true;
			NPC.buffImmune[39] = true;
		}

        public override void AI()
        {
            if (Main.rand.Next(500) == 0)
            {
                NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<DarkServant>());
            }
            if (Main.rand.Next(150) == 0)
            {
                NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<DarkSlime>());
            }
        }


        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
		{
			NPC.lifeMax = NPC.lifeMax * 1;
			NPC.damage = NPC.damage * 1;
		}

        public override void HitEffect(NPC.HitInfo hit)
        {
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
            {
                for (int k = 0; k < 60; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 191, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 191, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 191, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
                }
                SoundEngine.PlaySound(SoundID.WormDig);

                NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<TheDarkEmperorTwo>());
                NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<DarkServant>());
                NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<DarkServant>());
                NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<DarkServant>());
                NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<DarkServant>());

            }
            else
            {
                for (int k = 0; k < (int)(hit.Damage / NPC.lifeMax * 50.0); k++) 
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 191, hitDirection, -2f, 0, default(Color), 0.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 191, hitDirection, -1f, 0, default(Color), 0.7f);
                }
            }
        }
    }
}