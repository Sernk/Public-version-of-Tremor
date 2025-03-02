using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using TremorMod.Content.Projectiles;
using Terraria.DataStructures;
using TremorMod.Content.NPCs.Bosses.NovaPillar.Projectiles;

namespace TremorMod.Content.NPCs.Bosses.NovaPillar.NPCs
{
	public class Varki : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Warkee");
			Main.npcFrameCount[NPC.type] = 2;
		}

		//Int variables
		int AnimationRate = 4;
		int CountFrame;
		int TimeToAnimation = 4;
		int Timer;
		public override void SetDefaults()
		{
			NPC.lifeMax = 750;
			NPC.damage = 300;
			NPC.defense = 25;
			NPC.knockBackResist = 0.34f;
			NPC.width = 26;
			NPC.height = 34;
			NPC.aiStyle = 14;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit55;
			NPC.DeathSound = SoundID.NPCDeath51;
		}

		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */
		{
			NPC.lifeMax = NPC.lifeMax * 1;
			NPC.damage = NPC.damage * 1;
		}

		public override void AI()
		{
			if (Main.player[NPC.target].GetModPlayer<TremorPlayer>().ZoneRuins)
			{
				NPC.life = -1;
				NPC.active = false;
				NPC.checkDead();
				return;
			}
			NPC.spriteDirection = NPC.direction;
			Timer++;
			if (Timer == 2000)
			{
				NPC.Transform(ModContent.NPCType<Youwarkee2>());
			}
			NovaAnimation();
		}

        /*public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            // Используем ModContent.Request для получения текстуры
            Texture2D glowMask = ModContent.Request<Texture2D>("NPCs/Bosses/NovaPillar/NPCs/Varki_GlowMask").Value;
            TremorUtils.DrawNPCGlowMask(spriteBatch, NPC, glowMask);
        }*/

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                if (NovaHandler.ShieldStrength > 0)
                {
                    // Используйте ModContent.NPCType
                    int parentIndex = NPC.FindFirstNPC(ModContent.NPCType<NovaPillar>());
                    if (parentIndex != -1)
                    {
                        NPC parent = Main.npc[parentIndex];

                        // Исправление: расчет вектора скорости
                        Vector2 Velocity = Helper.VelocityToPoint(NPC.Center, parent.Center, 20);

                        // Исправление: использование правильного источника и передачи координат/скорости как Vector2
                        Projectile.NewProjectile(NPC.GetSource_Death(), NPC.Center, Velocity, ModContent.ProjectileType<CogLordLaser>(), 1, 1f);
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(-3f, 3f));
                }

                for (int i = 0; i < 2; i++)
                {
                    // Использование правильного источника для Gore
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("VarkiGore1").Type, 1f);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("VarkiGore2").Type, 1f);
                }

                // Использование правильного источника для Gore
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("VarkiGore3").Type, 1f);

                for (int k = 0; k < 7; k++)
                {
                    Vector2 Vector = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                    Vector.Normalize();
                    Vector *= Main.rand.Next(10, 201) * 0.01f;

                    // Использование правильных типов для координат и скорости
                    int i = Projectile.NewProjectile(NPC.GetSource_Death(), NPC.position, Vector, ModContent.ProjectileType<NovaAlchemistCloud>(), 20, 1f, Main.myPlayer, 0f, Main.rand.Next(-45, 1));
                    Main.projectile[i].friendly = false;
                }
            }
        }

        public override void OnKill()
        {
            base.OnKill();
            // Уведомляем столб о смерти врага
            int pillarIndex = NPC.FindFirstNPC(ModContent.NPCType<NovaPillar>());
            if (pillarIndex != -1)
            {
                NPC pillar = Main.npc[pillarIndex];
                if (pillar != null && pillar.ModNPC is NovaPillar novaPillar)
                {
                    novaPillar.OnEnemyKilled();
                }
            }
        }

        void NovaAnimation()
		{
			if (--TimeToAnimation <= 0)
			{
				if (++CountFrame > 2)
					CountFrame = 1;
				TimeToAnimation = AnimationRate;
				NPC.frame = GetFrame(CountFrame + 0);
			}
		}

		Rectangle GetFrame(int Number)
		{
			return new Rectangle(0, NPC.frame.Height * (Number - 1), NPC.frame.Width, NPC.frame.Height);
		}
	}
}