using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace TremorMod.Content.NPCs.Bosses.TikiTotem
{
	[AutoloadBossHead]
	public class AngerSoul : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Soul of Anger");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 750;
			NPC.damage = 26;
			NPC.defense = 5;
			NPC.knockBackResist = 1f;
			NPC.width = 60;
			NPC.height = 85;
			AnimationType = 288;
			NPC.aiStyle = 17;
			NPC.npcSlots = 15f;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit31;
			NPC.noGravity = true;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.value = Item.buyPrice(0, 2, 0, 9);
		}

		public override void AI()
		{
			NPC.position += NPC.velocity * 2f;
			if (Main.rand.NextBool(6))
				Main.dust[Dust.NewDust(NPC.position, NPC.width, NPC.height, 64, 0f, 0f, 200, NPC.color, 1f)].velocity *= 0.3F;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 64, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 64, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 64, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 64, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 64, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 64, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 64, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.6f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 64, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 64, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.6f);
				}
			}
		}
	}
}