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
	public class NovaFlier : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Nova Flier");
			Main.npcFrameCount[NPC.type] = 4;
		}

		//Int variables
		int AnimationRate = 4;
		int CountFrame;
		int TimeToAnimation = 4;
		//int Timer = 0;

		//Vanilla AI
		static int num1461 = 360;
		//float num1453 = 7f;
		float num1463 = 6.28318548f / (num1461 / 2);
		//int num1450 = 200;
		//int num1472 = 0;
		//bool flag128;
		//static float scaleFactor10 = 8.5f;
		//float num1451 = 0.55f;
		public override void SetDefaults()
		{
			NPC.lifeMax = 2150;
			NPC.damage = 67;
			NPC.defense = 15;
			NPC.knockBackResist = 0.2f;
			NPC.width = 44;
			NPC.height = 56;
			NPC.HitSound = SoundID.NPCHit55;
			NPC.DeathSound = SoundID.NPCDeath51;
			NPC.buffImmune[31] = false;
			NPC.npcSlots = 2f;
			NPC.aiStyle = 14;
			NPC.noGravity = true;
			NPC.noTileCollide = false;
		}

		Vector2 RandomPointInArea(Vector2 areaStart, Vector2 areaEnd)
        {
            float x = Main.rand.NextFloat(areaStart.X, areaEnd.X);
            float y = Main.rand.NextFloat(areaStart.Y, areaEnd.Y);
            return new Vector2(x, y);
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */
		{
			NPC.lifeMax = NPC.lifeMax * 1;
			NPC.damage = NPC.damage * 1;
		}

        public static class Helper
        {
            // Метод для получения случайной точки внутри заданной области
            public static Vector2 RandomPointInArea(Vector2 topLeft, Vector2 bottomRight)
            {
                float randomX = Main.rand.NextFloat(topLeft.X, bottomRight.X);
                float randomY = Main.rand.NextFloat(topLeft.Y, bottomRight.Y);
                return new Vector2(randomX, randomY);
            }

            // Метод для вычисления вектора скорости от одной точки к другой с заданной скоростью
            public static Vector2 VelocityToPoint(Vector2 startPoint, Vector2 endPoint, float speed)
            {
                Vector2 direction = endPoint - startPoint;
                direction.Normalize();
                return direction * speed;
            }
        }

        public override void AI()
        {
            Player player = Main.player[NPC.target];

            if (player.GetModPlayer<TremorPlayer>().ZoneRuins)
            {
                NPC.life = -1;
                NPC.active = false;
                NPC.checkDead();
                return;
            }

            NPC.spriteDirection = NPC.direction;
            NovaAnimation();

            if (Main.time % 200 == 0)
            {
                Vector2 targetAreaTopLeft = new Vector2(player.Center.X - 10, player.Center.Y - 10);
                Vector2 targetAreaBottomRight = new Vector2(player.Center.X + 20, player.Center.Y + 20);

                // Используем метод, который мы добавили
                Vector2 randomPoint = Helper.RandomPointInArea(targetAreaTopLeft, targetAreaBottomRight);

                Vector2 velocity = Helper.VelocityToPoint(NPC.Center, randomPoint, 7);
                var source = NPC.GetSource_FromThis();

                Projectile.NewProjectile(source, NPC.Center, velocity, ModContent.ProjectileType<NovaFlierProj>(), 20, 1f);
            }
        }


        /*public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D glowMask = ModContent.Request<Texture2D>("NPCs/Bosses/NovaPillar/NPCs/NovaFlier_GlowMask").Value;
            TremorUtils.DrawNPCGlowMask(spriteBatch, NPC, glowMask);
        }*/


        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                if (NovaHandler.ShieldStrength > 0)
                {
                    int parentIndex = NPC.FindFirstNPC(ModContent.NPCType<NovaPillar>());

                    // Ensure that the NPC type is found before accessing the array
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
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("NovaFlierGore1").Type, 1);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("NovaFlierGore2").Type, 1);
                }
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("NovaFlierGore3").Type, 1);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("NovaFlierGore3").Type, 1);
            }
        }

        public override void OnKill()
        {
            base.OnKill();
            // Find the first NPC of type NovaPillar
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

        void NovaAnimation()
		{
			if (--TimeToAnimation <= 0)
			{
				if (++CountFrame > 4)
					CountFrame = 1;
				TimeToAnimation = AnimationRate;
				NPC.frame = GetFrame(CountFrame + 0);
			}
		}

		Rectangle GetFrame(int Number)
		{
			return new Rectangle(0, NPC.frame.Height * (Number - 1), NPC.frame.Width, NPC.frame.Height);
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.GetModPlayer<TremorPlayer>().ZoneTowerNova)
                return 1f; // 100% шанс спавна в зоне башни Nova
            return 0;
        }
    }
}
