using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.NPCs.Bosses.CogLord
{
	public class CogLordCog : ModNPC
	{
		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cog");
		}*/

		public override void SetDefaults()
		{
            NPC.lifeMax = 1;
            NPC.damage = 100;
            NPC.defense = 0;
            NPC.knockBackResist = 1f;
            NPC.width = 42;
            NPC.height = 46;
            NPC.aiStyle = -1;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.dontTakeDamage = true;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath10;
            NPC.value = Item.buyPrice(0, 1, 0, 0);

            NPC.alpha = 244;
            NPC.scale = 0.25F;
		}
		
		public override bool PreAI()
		{
			if(NPC.ai[0] == 0) // First update/spawn sequence.
			{
                NPC.localAI[0] = Main.rand.NextBool() ? -Main.rand.Next(1, 11) : Main.rand.Next(1, 11);
                NPC.ai[0] = 1;
			}
			else if (NPC.ai[0] == 1) // 'Appear' sequence.
			{
				if(NPC.scale < 1)
                    NPC.scale += 0.75F / 60;
				else
                    NPC.scale = 1;

				if ((NPC.alpha -= 4) <= 0)
				{
					if (NPC.ai[1]++ >= 120)
					{
                        NPC.scale = 1;
                        NPC.ai[0] = 2;
					}
                    NPC.alpha = 0;
				}
			}
			else if (NPC.ai[0] == 2) // 'Disappear' sequence.
			{
                NPC.scale -= 0.75F / 60;
				if ((NPC.alpha += 4) >= 255)
				{
                    NPC.life = -1;
                    NPC.active = false;
                    NPC.checkDead();
				}
			}

            NPC.velocity *= Vector2.Zero;
            NPC.rotation += (NPC.localAI[0] * 0.05F) / NPC.Opacity;
			return false;
		}

		public override bool CanHitPlayer(Player target, ref int cooldownSlot)
		{
			return NPC.alpha <= 125;
		}
	}
}