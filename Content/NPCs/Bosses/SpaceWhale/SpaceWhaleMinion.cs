using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TremorMod.Content.NPCs.Bosses.SpaceWhale
{
	public class SpaceWhaleMinion : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Space Whale Minion");
			Main.npcFrameCount[NPC.type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.width = 72;
			NPC.height = 62;
			NPC.damage = 74;
			NPC.defense = 80;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.lifeMax = 100;
			NPC.npcSlots = 5f;
			NPC.HitSound = SoundID.NPCHit3;
			NPC.DeathSound = SoundID.NPCDeath3;
			NPC.value = Item.buyPrice(0, 0, 3, 12);
			NPC.knockBackResist = 0.1f;
			NPC.aiStyle = 74;
			AIType = 418;
			AnimationType = 23;
		}

		public override void AI()
		{
			if (Main.rand.NextBool(4))
				Main.dust[Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 0f, 0f, 200, NPC.color, 2f)].velocity *= 0.3f;
		}

        public override void HitEffect(NPC.HitInfo hit)
        {
            int hitDirection = hit.HitDirection; // Assuming HitDirection is part of NPC.HitInfo

            if (NPC.life <= 0)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);

                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.6f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.6f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.6f);
                }

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SpaceWhaleMinionGore").Type, 1f);
            }
        }
    }
}