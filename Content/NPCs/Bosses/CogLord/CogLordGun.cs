using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace TremorMod.Content.NPCs.Bosses.CogLord
{
    public class CogLordGun : ModNPC
    {
        private const int ShootRate = 120;
        private const int ShootDamage = 20;
        private const float ShootKn = 1.0f;
        private const int ShootType = ProjectileID.Bullet; 
        private const float ShootSpeed = 5f;
        private const float MaxDist = 250f;

        private int _timeToShoot = ShootRate;
        private bool _firstAi = true;

        public override void SetDefaults()
        {
            NPC.lifeMax = 20000;
            NPC.damage = 80;
            NPC.defense = 20;
            NPC.knockBackResist = 0f;
            NPC.width = 88;
            NPC.height = 46;
            NPC.aiStyle = -1;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath14;
            NPC.value = Item.buyPrice(0, 0, 5, 0);
        }

        public override void AI()
        {
            if (_firstAi)
            {
                _firstAi = false;
                MakeArms();
            }

            if (Main.npc[(int)NPC.ai[1]].type == ModContent.NPCType<CogLord>() && Main.npc[(int)NPC.ai[1]].active)
            {
                Player targetPlayer = Main.player[Main.npc[(int)NPC.ai[1]].target];
                if (targetPlayer.active)
                {
                    NPC.rotation = (targetPlayer.Center - NPC.Center).ToRotation();

                    if (--_timeToShoot <= 0)
                        Shoot(targetPlayer);
                }
            }

            Vector2 cogLordCenter = Main.npc[(int)NPC.ai[1]].Center;
            Vector2 distance = NPC.Center - cogLordCenter;
            if (distance.Length() >= MaxDist)
            {
                distance.Normalize();
                NPC.Center = cogLordCenter + distance * MaxDist;
            }
        }

        private void MakeArms()
        {
            IEntitySource source = NPC.GetSource_FromAI();

            int arm1 = NPC.NewNPC(source, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<CogLordArm>(), 0, NPC.whoAmI, 0, 0, NPC.ai[1]);
            int arm2 = NPC.NewNPC(source, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<CogLordArmSecond>(), 0, NPC.whoAmI, 0, 0, arm1);

            Main.npc[arm1].ai[0] = arm2; 
        }

        private void Shoot(Player target)
        {
            _timeToShoot = ShootRate;

            Vector2 velocity = (target.Center - NPC.Center).SafeNormalize(Vector2.Zero) * ShootSpeed;
            for (int i = 0; i < 3; i++) 
            {
                Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(10)); 
                Projectile.NewProjectile(
                    NPC.GetSource_FromAI(),
                    NPC.Center,
                    perturbedSpeed,
                    ShootType,
                    ShootDamage,
                    ShootKn,
                    Main.myPlayer
                );
            }
        }

        public override bool CheckDead()
        {
            if (NPC.ai[1] != -1)
            {
                NPC.aiStyle = -1;
                NPC.ai[1] = -1;
                return false; 
            }

            return true; 
        }

        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>(Texture).Value;
            Vector2 origin = new Vector2(texture.Width / 2f, texture.Height / Main.npcFrameCount[NPC.type] / 2f);
            Vector2 drawPos = NPC.Center - screenPos;

            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(texture, drawPos, NPC.frame, drawColor, NPC.rotation, origin, NPC.scale, effects, 0f);
        }
    }
}
/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.NPCs.Bosses.CogLord;


namespace TremorMod.Content.NPCs.Bosses.CogLord
{
	*
	 * npc.ai[0] = Index of the Cog Lord boss in the Main.npc array.
	 * npc.ai[1] = State manager.
	 * npc.ai[2] = (Shoot) timer.
	 *
public class CogLordGun : ModNPC
	{
		*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cog Lord Gun");
		}

		private const int ShootRate = 120;
		private const int ShootDamage = 20;
		private const float ShootKn = 1.0f;
		private const int ShootType = 88;
		private const float ShootSpeed = 5;
		private const int ShootCount = 10;
		private const int Spread = 45;
		private const float SpreadMult = 0.045f;
		private const float MaxDist = 250f;

		private int _timeToShoot = ShootRate;

		public override void SetDefaults()
		{
            NPC.lifeMax = 20000;
            NPC.damage = 80;
            NPC.defense = 20;
            NPC.knockBackResist = 0f;
            NPC.width = 88;
            NPC.height = 46;
            NPC.aiStyle = 12;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath14;
            NPC.value = Item.buyPrice(0, 0, 5, 0);
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Gores/CogLordGun").Type, 1f);
            }
        }

        public static class Helper
        {
            // Метод для вычисления угла между двумя точками
            public static float rotateBetween2Points(Vector2 point1, Vector2 point2)
            {
                return (point2 - point1).ToRotation();
            }
        }

        private bool _firstAi = true;
        public override void AI()
        {
            if (_firstAi)
            {
                _firstAi = false;
                MakeArms();
            }

            // Проверяем, активен ли "CogLord"
            if (Main.npc[(int)NPC.ai[1]].type == ModContent.NPCType<CogLord>() && Main.npc[(int)NPC.ai[1]].active)
            {
                // Проверяем, активен ли игрок, на которого нацелен NPC
                if (Main.player[Main.npc[(int)NPC.ai[1]].target].active)
                {
                    if (NPC.localAI[3] == 0f)
                    {
                        NPC.rotation = Helper.rotateBetween2Points(NPC.Center, Main.player[Main.npc[(int)NPC.ai[1]].target].Center);

                        if (--_timeToShoot <= 0)
                            Shoot();
                    }
                }
            }

            // Проверяем наличие других NPC
            if (NPC.AnyNPCs(ModContent.NPCType<CogLordProbe>()))
            {
                NPC.dontTakeDamage = true;
            }
            else
            {
                NPC.dontTakeDamage = false;
            }

            // Ограничиваем расстояние NPC от центра "CogLord"
            Vector2 cogLordCenter = Main.npc[(int)NPC.ai[1]].Center;
            Vector2 distance = NPC.Center - cogLordCenter;
            if (distance.Length() >= MaxDist)
            {
                distance.Normalize();
                distance *= MaxDist;
                NPC.Center = cogLordCenter + distance;
            }
        }


        private void MakeArms()
		{
            IEntitySource source = NPC.GetSource_FromAI();
            int arm = NPC.NewNPC(source, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<CogLordArm>(), 0, 9999, 1, 1, NPC.ai[1]);
            int arm2 = NPC.NewNPC(source, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<CogLordArmSecond>(), 0, NPC.whoAmI, 0, 1, arm);
            Main.NPC[arm].ai[0] = arm2;
		}

		private void Shoot()
		{
			_timeToShoot = ShootRate;
			if (Main.NPC[(int)NPC.ai[1]].target != -1)
			{
				Vector2 velocity = Helper.VelocityToPoint(NPC.Center, Main.player[Main.NPC[(int)NPC.ai[1]].target].Center, ShootSpeed);
				for (int l = 0; l < 2; l++)
				{
                    Vector2 spawnPosition = NPC.Center;
                    Vector2 velocity = new Vector2(velocity.X, velocity.Y);
                    int i = Projectile.NewProjectile(NPC.GetSource_FromAI(), spawnPosition, velocity, ShootType, ShootDamage, ShootKn);
                    Main.projectile[i].hostile = true;
					Main.projectile[i].friendly = false;
				}
			}
		}

        public override bool CheckDead()
        {
            if (NPC.ai[1] != -1)
            {
                NPC.aiStyle = -1;
                NPC.ai[1] = -1;
                return false; // NPC не умрет
            }

            return true; // Разрешить смерть NPC
        }


        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D drawTexture = ModContent.Request<Texture2D>(Texture).Value;
            int frameCount = Main.npcFrameCount[NPC.type];
          Vector2 origin = new Vector2(drawTexture.Width / 2, drawTexture.Height / Main.npcFrameCount[NPC.type] / 2);
            Vector2 drawPos = new Vector2(
                NPC.position.X - screenPos.X + NPC.width / 2 - drawTexture.Width / 2 * NPC.scale / 2f + origin.X * NPC.scale,
                NPC.position.Y - screenPos.Y + NPC.height - drawTexture.Height * NPC.scale / Main.NPCFrameCount[NPC.type] + 4f + origin.Y * NPC.scale + NPC.gfxOffY
            );
            SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(drawTexture, drawPos, NPC.frame, Color.White, NPC.rotation, origin, NPC.scale, effects, 0f);
        }
        public static Vector2 VelocityToPoint(Vector2 source, Vector2 target, float speed)
        {
            Vector2 direction = target - source;
            direction.Normalize();
            return direction * speed;
        }

    }
}*/