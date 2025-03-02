using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.NPCs.Bosses.PixieQueen
{
	public class PixieQueenGuardian : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Pixie Queen Guardian");
			Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 200;
			NPC.damage = 75;
			NPC.defense = 25;
			NPC.knockBackResist = 0f;
			NPC.width = 28;
			NPC.height = 30;
			AnimationType = 116;
			NPC.aiStyle = 44;
			NPC.npcSlots = 15f;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath7;
			NPC.noGravity = true;
			NPC.value = Item.buyPrice(0, 0, 0, 9);
		}

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            if (Main.rand.NextBool(3))
            {
                target.AddBuff(BuffID.Confused, 1800, true);
            }

            if (Main.rand.NextBool(2))
            {
                target.AddBuff(BuffID.Slow, 1800, true);
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);

				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
			}
		}

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D drawTexture = TextureAssets.Npc[NPC.type].Value;
            Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[NPC.type]) * 0.5F);

            Vector2 drawPos = new Vector2(
                NPC.position.X - Main.screenPosition.X + (NPC.width / 2) - (TextureAssets.Npc[NPC.type].Value.Width / 2) * NPC.scale / 2f + origin.X * NPC.scale,
                NPC.position.Y - Main.screenPosition.Y + NPC.height - TextureAssets.Npc[NPC.type].Value.Height * NPC.scale / Main.npcFrameCount[NPC.type] + 4f + origin.Y * NPC.scale + NPC.gfxOffY
            );

            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(drawTexture, drawPos, NPC.frame, Color.White, 0f, origin, NPC.scale, effects, 0);

            return false;
        }
    }
}