using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TremorMod.Content.NPCs.Bosses.AncienDragon
{
	public class DragonMini : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Baby Dragon");
		}

		public override void SetDefaults()
		{
			NPC.noTileCollide = true;
			NPC.noGravity = true;
			NPC.lifeMax = 150;
			NPC.damage = 19;
			NPC.defense = 4;
			NPC.knockBackResist = 0.5f;
			NPC.width = 64;
			NPC.height = 42;
			AIType = 6;
			NPC.aiStyle = 5;
			AnimationType = 2;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			Main.npcFrameCount[NPC.type] = 2;
		}

		public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
		{
			if (Main.expertMode)
				target.AddBuff(BuffID.Stoned, 180);
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
			Texture2D drawTexture = TextureAssets.Npc[NPC.type].Value;
			Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[NPC.type]) * 0.5F);
			Vector2 drawPos = new Vector2(
				NPC.position.X - Main.screenPosition.X + (NPC.width / 2) - (TextureAssets.Npc[NPC.type].Value.Width / 2) * NPC.scale / 2f + origin.X * NPC.scale,
				NPC.position.Y - Main.screenPosition.Y + NPC.height - TextureAssets.Npc[NPC.type].Value.Height * NPC.scale / Main.npcFrameCount[NPC.type] + 4f + origin.Y * NPC.scale + NPC.gfxOffY);
			SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(drawTexture, drawPos, NPC.frame, Color.White, NPC.rotation, origin, NPC.scale, effects, 0);
			return false;
		}
	}
}