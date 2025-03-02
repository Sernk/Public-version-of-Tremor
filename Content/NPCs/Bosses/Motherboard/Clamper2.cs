using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.NPCs.Bosses.Motherboard
{
	public class Clamper2 : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Clamper");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.noTileCollide = true;
			NPC.noGravity = true;
			NPC.lifeMax = 2400;
			NPC.damage = 30;
			NPC.defense = 6;
			NPC.knockBackResist = 0f;
			NPC.width = 36;
			NPC.height = 33;
			NPC.aiStyle = 2;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
			AnimationType = 2;
		}

		public override void AI()
		{
			NPC.position += NPC.velocity;
			Lighting.AddLight(NPC.Center, Color.OrangeRed.ToVector3() * 0.01333f);
		}
	}
}