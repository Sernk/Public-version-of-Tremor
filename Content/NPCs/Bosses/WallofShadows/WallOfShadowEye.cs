using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.NPCs.Bosses.WallofShadows
{
    public class WallOfShadowEye : ModNPC
    {
        public override void SetStaticDefaults()
        {
            NPCID.Sets.ShouldBeCountedAsBoss[NPC.type] = true;
        }

        public override void SetDefaults()
        {
            NPC.width = 100;
            NPC.height = 100;
            NPC.damage = 78;
            NPC.defense = 40;
            NPC.lifeMax = 8000;
            NPC.knockBackResist = 0f;
            NPC.noGravity = true;
            NPC.lavaImmune = true;
            NPC.behindTiles = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit8;
            NPC.DeathSound = SoundID.NPCDeath10;
            Music = MusicID.Boss2;
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float bossLifeScale, float balance)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.6f);
        }

        public override void AI()
        {
            NPC.rotation = NPC.velocity.ToRotation();
            int wallOfShadowIndex = NPC.FindFirstNPC(ModContent.NPCType<WallOfShadow>());
            if (wallOfShadowIndex < 0)
            {
                NPC.active = false;
                return;
            }

            NPC wallOfShadow = Main.npc[wallOfShadowIndex];

            NPC.realLife = wallOfShadowIndex;
            if (wallOfShadow.life > 0)
                NPC.life = wallOfShadow.life;

            NPC.position.X = wallOfShadow.position.X;
            NPC.direction = wallOfShadow.direction;
            NPC.spriteDirection = NPC.direction;

            float targetY = (wallOfShadow.Bottom.Y + wallOfShadow.Top.Y) / 2 - NPC.height / 2;
            if (NPC.position.Y > targetY + 1)
                NPC.velocity.Y = -1f;
            else if (NPC.position.Y < targetY - 1)
                NPC.velocity.Y = 1f;
            else
            {
                NPC.velocity.Y = 0f;
                NPC.position.Y = targetY;
            }

            if (NPC.velocity.Y > 5f)
                NPC.velocity.Y = 5f;
            if (NPC.velocity.Y < -5f)
                NPC.velocity.Y = -5f;

            Vector2 center = NPC.Center;
            Vector2 playerCenter = Main.player[NPC.target].Center;
            float deltaX = playerCenter.X - center.X;
            float deltaY = playerCenter.Y - center.Y;
            float distance = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            if (NPC.direction > 0)
            {
                if (playerCenter.X > center.X)
                    NPC.rotation = (float)Math.Atan2(-deltaY, -deltaX) + MathHelper.Pi;
                else
                    NPC.rotation = 0f;
            }
            else if (playerCenter.X < center.X)
            {
                NPC.rotation = (float)Math.Atan2(deltaY, deltaX) + MathHelper.Pi;
            }
            else
            {
                NPC.rotation = 0f;
            }

            if (Main.netMode != NetmodeID.MultiplayerClient && wallOfShadow.life < wallOfShadow.lifeMax * 0.75f)
            {
                if (NPC.localAI[1]++ > 60)
                {
                    NPC.localAI[1] = 0;
                    Vector2 velocity = (playerCenter - center).SafeNormalize(Vector2.Zero) * 10f;
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), center, velocity, ProjectileID.ShadowFlame, NPC.damage / 2, 2f, Main.myPlayer);
                }
            }
        }
    }
}