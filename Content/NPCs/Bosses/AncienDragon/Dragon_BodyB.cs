using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.NPCs.Bosses.AncienDragon
{
	public class Dragon_BodyB : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ancient Dragon");
			Main.npcFrameCount[NPC.type] = 2;
			NPCID.Sets.ShouldBeCountedAsBoss[NPC.type] = true;
		}

		public override void SetDefaults()
		{
			NPC.npcSlots = 5f;
			NPC.width = 78;
			NPC.height = 98;
			NPC.defense = 12;
			NPC.lifeMax = 3100;
			NPC.damage = 28;
			NPC.aiStyle = 6;
			AIType = -1;
			AnimationType = 10;
			NPC.knockBackResist = 1f;

			NPC.value = Item.buyPrice(0, 25, 0, 0);
			NPC.alpha = 255;

			NPC.behindTiles = true;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.netAlways = true;
			Music = MusicID.Boss1;
		}

		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			return false;
		}

		int time;
        public override void AI()
        {
            if (!Main.npc[(int)NPC.ai[1]].active)
            {
                NPC.life = 0;
                NPC.HitEffect(0, 10.0);
                NPC.active = false;
            }

            if (Main.npc[(int)NPC.ai[1]].alpha < 128)
            {
                NPC.alpha -= 42;
                if (NPC.alpha < 0)
                {
                    NPC.alpha = 0;
                }
            }

            if (NPC.life < NPC.lifeMax / 2 && Main.netMode != NetmodeID.MultiplayerClient && time == 0 && Main.rand.Next(9000) == 0)
            {
                time = 1;

                int i = NPC.NewNPC(NPC.GetSource_FromAI(),
                (int)(NPC.position.X + NPC.width / 2),
                (int)(NPC.position.Y + NPC.height),
                ModContent.NPCType<DragonMini>(),
                Target: 0);

                NPC.frame = GetFrame(2);

                if (Main.netMode == NetmodeID.Server && i < 200)
                {
                    // NetMessage.SendData(23, -1, -1, "", i, 0f, 0f, 0f, 0, 0, 0);
                }

                NPC.netUpdate = true;
            }
        }

        Rectangle GetFrame(int Number)
		{
			return new Rectangle(0, NPC.frame.Height * (Number - 1), NPC.frame.Width, NPC.frame.Height);
		}

		public override bool CheckActive()
		{
			return false;
		}

		public override bool PreKill()
		{
			return false;
		}

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float bossLifeScale, float balance)
        {
			NPC.lifeMax = (int)(NPC.lifeMax * 0.55f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.75f);
		}

        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D drawTexture = TextureAssets.Npc[NPC.type].Value;
            Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[NPC.type]) * 0.5F);

            Vector2 drawPos = new Vector2(
                NPC.position.X - Main.screenPosition.X + (NPC.width / 2) - (TextureAssets.Npc[NPC.type].Value.Width / 2) * NPC.scale / 2f + origin.X * NPC.scale,
                NPC.position.Y - Main.screenPosition.Y + NPC.height - TextureAssets.Npc[NPC.type].Value.Height * NPC.scale / Main.npcFrameCount[NPC.type] + 4f + origin.Y * NPC.scale + NPC.gfxOffY);

            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(drawTexture, drawPos, NPC.frame, drawColor, NPC.rotation, origin, NPC.scale, effects, 0);

            return false;
        }
    }
}