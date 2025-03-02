using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.NPCs.Bosses.NovaPillar.NPCs
{
    public static class Helper
    {
        public static Vector2 VelocityToPoint(Vector2 start, Vector2 end, float speed)
        {
            Vector2 direction = end - start;
            direction.Normalize();
            return direction * speed;
        }
    }

    public class NovaAlchemist : ModNPC
    {
        // Int variables
        int AnimationRate = 8;
        int CountFrame;
        int TimeToAnimation = 8;
        int Timer;

        // Bool variables
        bool TimeToPortals;

        public override void SetDefaults()
        {
            NPC.lifeMax = 2500;
            NPC.damage = 100;
            NPC.defense = 25;
            NPC.knockBackResist = 0.4f;
            NPC.width = 34;
            NPC.height = 56;
            NPC.aiStyle = 3;
            AIType = NPCID.AngryBones;
            NPC.npcSlots = 0.5f;
            NPC.HitSound = SoundID.NPCHit55;
            NPC.DeathSound = SoundID.NPCDeath51;
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 4;
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = NPC.lifeMax * 1;
            NPC.damage = NPC.damage * 1;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                if (NovaHandler.ShieldStrength > 0)
                {
                    int parentIndex = NPC.FindFirstNPC(ModContent.NPCType<NovaPillar>());
                    if (parentIndex != -1)
                    {
                        NPC parent = Main.npc[parentIndex];
                        Vector2 Velocity = Helper.VelocityToPoint(NPC.Center, parent.Center, 20);
                        var source = NPC.GetSource_FromThis();
                        Projectile.NewProjectile(source, NPC.Center, Velocity, ModContent.ProjectileType<CogLordLaser>(), 1, 1f);
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(-3f, 3f));
                }

                for (int i = 0; i < 2; i++)
                {
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("NovaAlchemistGore3").Type, 1f);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("NovaAlchemistGore4").Type, 1f);
                }

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("NovaAlchemistGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("NovaAlchemistGore1").Type, 1f);
            }
        }

        public override void AI()
        {
            NPC.TargetClosest(true);
            Player player = Main.player[NPC.target];
            if (player.GetModPlayer<TremorPlayer>().ZoneRuins)
            {
                NPC.life = -1;
                NPC.active = false;
                NPC.checkDead();
                return;
            }
            NPC.spriteDirection = NPC.direction;
            if (Main.rand.Next(800) == 0)
            {
                SoundEngine.PlaySound(SoundID.NPCDeath51, NPC.Center);
            }
            Timer++;
            NovaAnimation();
            if (Timer >= 600)
            {
                TimeToPortals = true;
            }
            if (Timer >= 600 && Timer % 200 == 0)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    SoundEngine.PlaySound(SoundID.NPCDeath55, NPC.Center);

                    // Используем NPC.GetSource_FromAI() для источника
                    NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X + 25, (int)NPC.Center.Y, ModContent.NPCType<NovaAlchemistC>());
                    NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X - 25, (int)NPC.Center.Y, ModContent.NPCType<NovaAlchemistC>());
                }
            }

            if (Timer < 600)
            {
                TimeToPortals = false;
            }
            if (Timer >= 800)
            {
                Timer = 0;
            }
            if (TimeToPortals)
            {
                NPC.velocity.X = 0f;
                NPC.velocity.Y += 5f;
            }
        }

        /*public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            var texture = ModContent.Request<Texture2D>("NPCs/Bosses/NovaPillar/NPCs/NovaAlchemist_GlowMask").Value;
            TremorUtils.DrawNPCGlowMask(spriteBatch, NPC, texture);
        }*/

        public void NovaAnimation()
        {
            if (!TimeToPortals)
            {
                if (--TimeToAnimation <= 0)
                {
                    if (++CountFrame > 3)
                        CountFrame = 1;
                    TimeToAnimation = AnimationRate;
                    NPC.frame = GetFrame(CountFrame);
                }
            }
            else
                NPC.frame = GetFrame(4);
        }

        public override void OnKill()
        {
            base.OnKill();
            // Уведомляем столб о смерти врага
            int pillarIndex = NPC.FindFirstNPC(ModContent.NPCType<NovaPillar>());

            // Ensure that the NPC type is found before accessing the array
            if (pillarIndex != -1)
            {
                NPC pillar = Main.npc[pillarIndex];
                if (pillar != null && pillar.ModNPC is NovaPillar novaPillar)
                {
                    novaPillar.OnEnemyKilled();
                }
            }
        }

        Rectangle GetFrame(int Num)
        {
            return new Rectangle(0, NPC.frame.Height * (Num - 1), NPC.frame.Width, NPC.frame.Height);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.GetModPlayer<TremorPlayer>().ZoneTowerNova)
                return 1f; // 100% шанс спавна в зоне башни Nova
            return 0;
        }
    }
}