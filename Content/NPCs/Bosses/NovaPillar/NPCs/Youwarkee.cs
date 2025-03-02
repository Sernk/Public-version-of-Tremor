using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace TremorMod.Content.NPCs.Bosses.NovaPillar.NPCs
{
	public class Youwarkee : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Yuwarkee");
			Main.npcFrameCount[NPC.type] = 4;
		}

		//Int variables
		int AnimationRate = 4;
		int CountFrame;
		int TimeToAnimation = 4;
		int Timer;
		public override void SetDefaults()
		{
			NPC.lifeMax = 1750;
			NPC.damage = 81;
			NPC.defense = 35;
			NPC.knockBackResist = 0.96f;
			NPC.width = 66;
			NPC.height = 68;
			NPC.HitSound = SoundID.NPCHit55;
			NPC.DeathSound = SoundID.NPCDeath51;
			NPC.buffImmune[31] = false;
			NPC.npcSlots = 2f;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
		}

		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */
		{
			NPC.lifeMax = NPC.lifeMax * 1;
			NPC.damage = NPC.damage * 1;
		}

		const float Speed = 4f;
		const float Acceleration = 0.27f;

		int k;
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
			Vector2 StartPosition = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
			float DirectionX = player.position.X + player.width / 2 - StartPosition.X;
			float DirectionY = player.position.Y + (player.height / 2) - 120 - StartPosition.Y;
			float Length = (float)Math.Sqrt(DirectionX * DirectionX + DirectionY * DirectionY);
			float Num = Speed / Length;
			DirectionX = DirectionX * Num;
			DirectionY = DirectionY * Num;
			if (NPC.velocity.X < DirectionX)
			{
				NPC.velocity.X = NPC.velocity.X + Acceleration;
				if (NPC.velocity.X < 0 && DirectionX > 0)
					NPC.velocity.X = NPC.velocity.X + Acceleration;
			}
			else if (NPC.velocity.X > DirectionX)
			{
				NPC.velocity.X = NPC.velocity.X - Acceleration;
				if (NPC.velocity.X > 0 && DirectionX < 0)
					NPC.velocity.X = NPC.velocity.X - Acceleration;
			}
			if (NPC.velocity.Y < DirectionY)
			{
				NPC.velocity.Y = NPC.velocity.Y + Acceleration;
				if (NPC.velocity.Y < 0 && DirectionY > 0)
					NPC.velocity.Y = NPC.velocity.Y + Acceleration;
			}
			else if (NPC.velocity.Y > DirectionY)
			{
				NPC.velocity.Y = NPC.velocity.Y - Acceleration;
				if (NPC.velocity.Y > 0 && DirectionY < 0)
					NPC.velocity.Y = NPC.velocity.Y - Acceleration;
			}
			if (Main.rand.Next(46) == 1)
			{
				Vector2 StartPosition2 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height / 2));
				float AndasRotation = (float)Math.Atan2(StartPosition2.Y - (player.position.Y + (player.height * 0.5f)), StartPosition2.X - (player.position.X + (player.width * 0.5f)));
				NPC.velocity.X = (float)(Math.Cos(AndasRotation) * 15) * -1;
				NPC.velocity.Y = (float)(Math.Sin(AndasRotation) * 15) * -1;
				NPC.netUpdate = true;
			}
			Timer++;
			if (Timer >= 700)
			{
				Timer = 0;
			}
            if (NPC.CountNPCS(k) < 3 && Timer % 200 == 0)
            {
                var source = NPC.GetSource_FromAI();
                k = NPC.NewNPC(source, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<Varki>(), 0, NPC.whoAmI, 0, 200);
            }
            NPC.rotation = NPC.velocity.X * 0.1f;
			NovaAnimation();
		}

		/*public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            // Загружаем текстуру с помощью ModContent.Request
            Texture2D glowMask = ModContent.Request<Texture2D>("NPCs/Bosses/NovaPillar/NPCs/Youwarkee_GlowMask").Value;

            // Используем загруженную текстуру в методе TremorUtils.DrawNPCGlowMask
            TremorUtils.DrawNPCGlowMask(spriteBatch, NPC, glowMask);
        }*/

		    public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                if (NovaHandler.ShieldStrength > 0)
                {
                    int parentIndex = NPC.FindFirstNPC(Mod.Find<ModNPC>("NovaPillar").Type);
                    if (parentIndex >= 0)
                    {
                        NPC parent = Main.npc[parentIndex];
                        Vector2 Velocity = Helper.VelocityToPoint(NPC.Center, parent.Center, 20);
                        Projectile.NewProjectile(NPC.GetSource_Death(), NPC.Center, Velocity, Mod.Find<ModProjectile>("CogLordLaser").Type, 1, 1f);
                    }
                }
                for (int i = 0; i < 5; i++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(-3f, 3f));
                }
                for (int i = 0; i < 2; i++)
                {
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("YouwarkeeGore1").Type, 1f);
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("YouwarkeeGore2").Type, 1f);
                }
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("YouwarkeeGore3").Type, 1f);
            }
        }

		public override void OnKill()
		{
			base.OnKill();
			// Уведомляем столб о смерти врага
			NPC pillar = Main.npc[NPC.FindFirstNPC(ModContent.NPCType<NovaPillar>())];
			if (pillar != null && pillar.ModNPC is NovaPillar novaPillar)
			{
				novaPillar.OnEnemyKilled();
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
