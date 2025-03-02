using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.NPCs.Bosses.NovaPillar.Projectiles;

namespace TremorMod.Content.NPCs.Bosses.NovaPillar.NPCs
{

	public class NovaAlchemistC : ModNPC
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Nova Alchemist");
			Main.npcFrameCount[NPC.type] = 4;
		}

		//Int variables
		int AnimationRate = 8;
		int CountFrame;
		int TimeToAnimation = 8;
		int Timer;
		public override void SetDefaults()
		{
			NPC.lifeMax = 1;
			NPC.damage = 200;
			NPC.defense = 50;
			NPC.knockBackResist = 0.4f;
			NPC.width = 34;
			NPC.height = 56;
			NPC.aiStyle = 3;
			AIType = NPCID.AngryBones;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit55;
			NPC.DeathSound = SoundID.NPCDeath51;
			NPC.dontTakeDamage = true;
			NPC.alpha = 150;
		}

		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */
		{
			NPC.damage = 350;
		}

		public override void AI()
		{
			NPC.TargetClosest(true);
			NPC.spriteDirection = NPC.direction;
			Player player = Main.player[NPC.target];
			NPC.rotation = 0f;
			NovaAnimation();
			Timer++;
			if (Timer >= 350)
			{
				NPC.life = -1;
				NPC.active = false;
				NPC.checkDead();
                for (int k = 0; k < 19; k++)
                {
                    Vector2 Vector = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                    Vector.Normalize();
                    Vector *= Main.rand.Next(10, 201) * 0.01f;

                    // Get the source for the projectile
                    var source = NPC.GetSource_FromThis();

                    // Correct the arguments and cast damage to an integer
                    int i = Projectile.NewProjectile(source, NPC.Center, Vector, ModContent.ProjectileType<NovaAlchemistCloud>(), 20, 1f);

                    // Set friendly property
                    Main.projectile[i].friendly = false;
                }

            }
        }

		void NovaAnimation()
		{
			if (--TimeToAnimation <= 0)
			{
				if (++CountFrame > 3)
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