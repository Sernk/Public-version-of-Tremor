using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.NPCs.Bosses.WallofShadows
{

	public class ShadowSteed : ModNPC
	{
        public int wallOfShadowIndex = -1;
        //private Player targetPlayer;
        private int respawnTimer = 0;
        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Shadow Steed");
			Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.width = NPC.height = 48;
			NPC.lifeMax = 940;
			NPC.damage = 75;
			NPC.defense = 30;
			NPC.knockBackResist = 0.2f;
			NPC.HitSound = SoundID.NPCHit31;
			NPC.noGravity = true;
			NPC.DeathSound = SoundID.NPCDeath6;
			NPC.noTileCollide = true;
		}

		public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
		{
			if (Main.expertMode)
				target.AddBuff(153, 180);
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
				Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, 99, 1f);
                NPC.NewNPC(Entity.GetSource_FromThis(), (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<ShadowHandTwo>());
                NPC.NewNPC(Entity.GetSource_FromThis(), (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<ShadowHandTwo>());
                NPC.NewNPC(Entity.GetSource_FromThis(), (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<ShadowHandTwo>());

                /*NPC.NewNPC((int)NPC.position.X, (int)NPC.position.Y,ModContent.NPCType<ShadowHandTwo>());
				
				NPC.NewNPC((int)NPC.position.X, (int)NPC.position.Y,
                ModContent.NPCType<ShadowHandTwo>());
                NPC.NewNPC((int)NPC.position.X, (int)NPC.position.Y,
                ModContent.NPCType<ShadowHandTwo>());*/
            }
		}

        public override void AI()
        {
            NPC.ai[0]++; 

            if (NPC.ai[0] >= 980)
            {
                NPC.active = false;
                NPC.netUpdate = true; 
                return;
            }

            // Стандартная логика AI
            NPC.rotation = NPC.velocity.ToRotation();

            NPC.TargetClosest(true);
            Player targetPlayer = Main.player[NPC.target];
            if (!targetPlayer.active || targetPlayer.dead)
            {
                NPC.target = -1;
                NPC.netUpdate = true;
            }
            else
            {
                float currentRot = NPC.velocity.ToRotation();
                Vector2 direction = targetPlayer.Center - NPC.Center;
                float targetAngle = direction.ToRotation();
                if (direction == Vector2.Zero)
                {
                    targetAngle = currentRot;
                }

                float desiredRot = currentRot.AngleLerp(targetAngle, 0.06f);
                NPC.velocity = new Vector2(NPC.velocity.Length(), 0f).RotatedBy(desiredRot);
            }
            if (wallOfShadowIndex == -1)
            {
                FindWallOfShadow();
            }

            if (wallOfShadowIndex != -1 && Main.npc[wallOfShadowIndex].active)
            {

            }
            else
            {
                NPC.active = false;
            }
            if (!NPC.active)
            {
                respawnTimer++;
                if (respawnTimer >= 480)
                {
                    respawnTimer = 0;
                }
            }
        }

        private void FindWallOfShadow()
        {
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                if (Main.npc[i].type == ModContent.NPCType<WallOfShadow>() && Main.npc[i].active)
                {
                    wallOfShadowIndex = i;
                    break;
                }
            }
        }

        public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter++;
			if (NPC.frameCounter >= 5)
			{
				NPC.frame.Y = (NPC.frame.Y + frameHeight) % (Main.npcFrameCount[NPC.type] * frameHeight);
				NPC.frameCounter = 0;
			}
			// npc.spriteDirection = -npc.direction;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
			Texture2D texture = TextureAssets.Npc[NPC.type].Value;
			Vector2 origin = new Vector2(texture.Width * 0.5F, (texture.Height / Main.npcFrameCount[NPC.type]) * 0.5F);
			SpriteEffects effects = NPC.velocity.X < 0 ? SpriteEffects.FlipVertically : SpriteEffects.None;
			spriteBatch.Draw(texture, NPC.Center - Main.screenPosition, NPC.frame, drawColor, NPC.rotation, origin, 1, effects, 0);

			return false;
		}
	}
}
