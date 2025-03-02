using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TremorMod.Content.NPCs.Bosses.Brutallisk
{
	public class Quetzalcoatl : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Quetzalcoatl");
			Main.npcFrameCount[NPC.type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 3000;
			NPC.damage = 170;
			NPC.defense = 73;
			NPC.knockBackResist = 1f;
			NPC.width = 32;
			NPC.height = 62;
			AnimationType = 62;
			NPC.aiStyle = 14;
			//aiType = 226;
			NPC.npcSlots = 1f;
			NPC.HitSound = SoundID.NPCHit7;
			NPC.DeathSound = SoundID.NPCDeath10;
			NPC.value = Item.buyPrice(0, 6, 1, 0);
			NPC.noTileCollide = true;
		}

		public override void HitEffect(NPC.HitInfo hit)
        {
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("QGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("QGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("QGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("QGore3").Type, 1f);
			}
			else
			{
				for (int k = 0; k < hit.Damage / NPC.lifeMax * 50; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, hitDirection, -1f, 0, default(Color), 0.7f);
			}
		}
	}
}