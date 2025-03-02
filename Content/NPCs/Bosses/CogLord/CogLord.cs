using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.NPCs.Bosses.CogLord;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;
using TremorMod.Content.Items.CogLordItems;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs.Bosses.CogLord
{
	// todo: redo
	[AutoloadBossHead]
	public class CogLord : ModNPC
	{

		//Framework
		private Vector2 _cogHands = new Vector2(-1, -1);

		//Bool variables
		private bool Ram => ((_cogHands.X == -1 && _cogHands.Y == -1) || NPC.ai[1] == 1);

		private bool _firstAi = true;
		private bool _secondAi = true;
		private bool _needCheck;
		private bool _flag = true;
		private bool _flag1 = true;
		private bool _flag2 = true;
		private bool _rockets = true;

		//Float variables
		private float _distanseBlood = 150f;

		private float _rotationSpeed = 0.3f;
		private float _rotation;
		private float _laserRotation = MathHelper.PiOver2;
		//private float _newRotation = MathHelper.PiOver2;

		//Int variables
		private int GetLaserDamage => 30;

		private int _animationRate = 6;
		private int _currentFrame;
		private int _timeToAnimation = 6;
		private int _timer;
		//private int _timer2 = 0;
		private int _shootType = ProjectileID.HeatRay;
		//private int _laserPosition = 20;
		private int _shootRate = 10;
		private int _timeToShoot = 4;
		//private float _previousRageRotation;

		//String variables
		//private string _leftHandName = "CogLordHand";
        //private string _rightHandName = "CogLordGun";

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 5; // Количество кадров
            NPCID.Sets.MPAllowedEnemies[Type] = true;
            NPCID.Sets.BossBestiaryPriority.Add(Type);
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
        }


        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++; // Увеличиваем счетчик кадров
            if (NPC.frameCounter >= 10) // Скорость смены кадров (чем больше число, тем медленнее анимация)
            {
                NPC.frameCounter = 0; // Сбрасываем счётчик
                NPC.frame.Y += frameHeight; // Переключаем кадр

                // Если кадры закончились, возвращаемся к первому
                if (NPC.frame.Y >= Main.npcFrameCount[NPC.type] * frameHeight)
                {
                    NPC.frame.Y = 0;
                }
            }
        }

        public override void SetDefaults()
		{
            NPC.lifeMax = 45000;
			NPC.damage = 25;
            NPC.defense = 5;
            NPC.knockBackResist = 0.0f;
            NPC.width = 86;
            NPC.height = 124;
            NPC.aiStyle = 11;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath10;
            NPC.boss = true;
            Music = MusicLoader.GetMusicSlot("TremorMod/Content/Music/CogLord");
            //bossBag = mod.ItemType("CogLordBag");
		}

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cog Lord");
			Main.npcFrameCount[npc.type] = 5;
		}*/

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float bossLifeScale, float balance)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.6f);
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
			// Загрузка текстуры через ModContent
			Texture2D cogLordTexture = ModContent.Request<Texture2D>("TremorMod/Content/NPCs/Bosses/CogLord/CogLordBody").Value;
			spriteBatch.Draw(
				cogLordTexture,
				NPC.Center - Main.screenPosition,
				null,
				Color.White,
				0f,
				new Vector2(44, -18),
				1f,
				SpriteEffects.None,
				0f
			);

			// Загрузка текстуры NPC
			Texture2D drawTexture = ModContent.Request<Texture2D>(Texture).Value;
			Vector2 origin = new Vector2(
				(drawTexture.Width / 2) * 0.5f,
				(drawTexture.Height / Main.npcFrameCount[NPC.type]) * 0.5f
			);

			Vector2 drawPos = new Vector2(
				NPC.position.X - Main.screenPosition.X + (NPC.width / 2) - (drawTexture.Width / 2) * NPC.scale / 2f + origin.X * NPC.scale,
				NPC.position.Y - Main.screenPosition.Y + NPC.height - drawTexture.Height * NPC.scale / Main.npcFrameCount[NPC.type] + 4f + origin.Y * NPC.scale + NPC.gfxOffY
			);

			SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

			spriteBatch.Draw(drawTexture, drawPos, NPC.frame, Color.White, NPC.rotation, origin, NPC.scale, effects, 0f);
			return false;
		}

        private Vector2 RandomPointInArea(Vector2 min, Vector2 max)
        {
            float randomX = Main.rand.NextFloat(min.X, max.X);  // Random X value between min.X and max.X
            float randomY = Main.rand.NextFloat(min.Y, max.Y);  // Random Y value between min.Y and max.Y
            return new Vector2(randomX, randomY);  // Return the random point as a Vector2
        }


        public override void AI()
		{
            NPC.TargetClosest();
			if (Main.dayTime)
			{
				_timer = 0;
			}
            if (NPC.AnyNPCs(ModContent.NPCType<CogLordProbe>()))
            {
                NPC.dontTakeDamage = true;
			}
			else
                NPC.dontTakeDamage = false;
			if (!Main.expertMode)
                NPC.position += NPC.velocity * 1.7f;
			else
                NPC.position += NPC.velocity * 1.02f;
			_timer++;
			Animation();
			for (int i = 0; i < Main.dust.Length; i++)
			{
				if (Main.dust[i].type == DustID.Blood && NPC.Distance(Main.dust[i].position) < _distanseBlood)
				{
					Main.dust[i].scale /= 1000000f;
					Main.dust[i].active = false;
				}
			}
            foreach (NPC NPC2 in Main.npc)
            {
                if (NPC2.type == 36)
				{
                    NPC2.active = false;
                    NPC2.life = 0;
                    NPC2.checkDead();
				}
			}
			foreach (var proj in Main.projectile)
			{
				if (proj.type == ProjectileID.Skull && Vector2.Distance(proj.Center, NPC.Center) < 100f)
				{
					proj.active = false;
				}
			}
            if (NPC.life < NPC.lifeMax * 0.6f && _flag)
            {
                _flag = false;
                if (Main.expertMode)
                    CogMessage("Low health is detected. Launching support drones.");
                else
                    CogMessage("Low health is detected. Launching support drone.");

                var source = NPC.GetSource_FromAI(); 

                if (Main.expertMode)
                    NPC.NewNPC(source, (int)NPC.Center.X - 100, (int)NPC.Center.Y - 100, ModContent.NPCType<CogLordProbe>(), 0, NPC.whoAmI, 0, 200);

                NPC.NewNPC(source, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<CogLordProbe>(), 0, NPC.whoAmI, 0, 200);
            }

            if (NPC.life < NPC.lifeMax * 0.4f && _flag1)
            {
                _flag1 = false;
                if (Main.expertMode)
                    CogMessage("Low health is detected. Launching support drones.");
                else
                    CogMessage("Low health is detected. Launching support drone.");

                var source = NPC.GetSource_FromAI(); 

                if (Main.expertMode)
                    NPC.NewNPC(source, (int)NPC.Center.X - 100, (int)NPC.Center.Y - 100, ModContent.NPCType<CogLordProbe>(), 0, NPC.whoAmI, 0, 200);

                NPC.NewNPC(source, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<CogLordProbe>(), 0, NPC.whoAmI, 0, 200);
            }

            if (NPC.life < NPC.lifeMax * 0.2f && _flag2)
            {
                _flag2 = false;
                if (Main.expertMode)
                    CogMessage("Low health is detected. Launching support drones.");
                else
                    CogMessage("Low health is detected. Launching support drone.");

                var source = NPC.GetSource_FromAI(); 

                if (Main.expertMode)
                    NPC.NewNPC(source, (int)NPC.Center.X - 100, (int)NPC.Center.Y - 100, ModContent.NPCType<CogLordProbe>(), 0, NPC.whoAmI, 0, 200);

                NPC.NewNPC(source, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<CogLordProbe>(), 0, NPC.whoAmI, 0, 200);
            }

            if (_firstAi)
			{
				_firstAi = false;
			}
			else
			{
				if (_secondAi)
				{
					MakeHands();
					_secondAi = false;
					_needCheck = true;
				}
			}
			if (!Ram)
			{
				if (_needCheck)
					CheckHands();
				if (_cogHands.Y != -1 && _needCheck)
				{
					Main.npc[(int)_cogHands.Y].localAI[3] = 0;
				}
			}

            else
            {
                if (_rockets)
                {
                    _rockets = false;
                    CogMessage("Protocol 10 is activated: Preparing for rocket storm.");
                }

                NPC.frame = GetFrame(5);
                _rotation += _rotationSpeed;
                NPC.rotation = _rotation;

                if ((int)(Main.time % 120) == 0)
                {
                    for (int k = 0; k < ((Main.expertMode) ? 2 : 1); k++)
                    {
                        Vector2 randomPoint = RandomPointInArea(
                            new Vector2(Main.player[Main.myPlayer].Center.X - 10, Main.player[Main.myPlayer].Center.Y - 10),
                            new Vector2(Main.player[Main.myPlayer].Center.X + 20, Main.player[Main.myPlayer].Center.Y + 20)
                        );

                        // Use NPC.GetSource_FromAI() for IEntitySource
                        Vector2 velocity = Helper.VelocityToPoint(NPC.Center, randomPoint, 20);
                        int i = Projectile.NewProjectile(NPC.GetSource_FromAI(), NPC.Center.X, NPC.Center.Y, velocity.X, velocity.Y, 134, GetLaserDamage * ((Main.expertMode) ? 3 : 2), 1f);

                        Main.projectile[i].hostile = true;
                        Main.projectile[i].tileCollide = true;
                        Main.projectile[i].friendly = false;
                    }
                }

                if (_needCheck)
                    CheckHands();
                if (_cogHands.Y != -1 && _needCheck)
                {
                    Main.npc[(int)_cogHands.Y].localAI[3] = 1;
                }
            }
            if (_timer == 400)
			{
				CogMessage("Protocol 11 is activated: Clockwork laser cutter is being enabled.");
			}
            if (_timer >= 500 && _timer < 800)
            {
                //_previousRageRotation = 0f;
                if (Main.netMode != 1)
                {
                    _laserRotation += 0.01f;
                    if (--_timeToShoot <= 0)
                    {
                        _timeToShoot = _shootRate;
                        var shootPos = NPC.Center + new Vector2(0, 17);
                        var shootVel = new Vector2(0, 7).RotatedBy(_laserRotation);

                        // Corrected calls to Projectile.NewProjectile with proper IEntitySource and arguments
                        int[] i = {
                Projectile.NewProjectile(NPC.GetSource_FromAI(), shootPos.X, shootPos.Y, shootVel.X, shootVel.Y, _shootType, GetLaserDamage, 1f),
                Projectile.NewProjectile(NPC.GetSource_FromAI(), shootPos.X, shootPos.Y, shootVel.X, shootVel.Y, _shootType, GetLaserDamage, 1f),
                Projectile.NewProjectile(NPC.GetSource_FromAI(), shootPos.X, shootPos.Y, shootVel.X, shootVel.Y, _shootType, GetLaserDamage, 1f),
                Projectile.NewProjectile(NPC.GetSource_FromAI(), shootPos.X, shootPos.Y, shootVel.X, shootVel.Y, _shootType, GetLaserDamage, 1f)
            };

                        for (int l = 0; l < i.Length; l++)
                        {
                            Main.projectile[i[l]].hostile = true;
                            Main.projectile[i[l]].tileCollide = false;
                        }
                    }
                }
            }

            if (_timer >= 800 && _timer < 1200)
			{
                NPC.velocity.X *= 2.00f;
                NPC.velocity.Y *= 2.00f;
				Vector2 vector = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height * 0.5f));
				{
					float clRad = (float)Math.Atan2((vector.Y) - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), (vector.X) - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
                    NPC.velocity.X = (float)(Math.Cos(clRad) * 4) * -1;
                    NPC.velocity.Y = (float)(Math.Sin(clRad) * 4) * -1;
				}
			}
			if (_timer == 1100)
			{
				CogMessage("Protocol 12 is activated: Summoning gears.");
			}
            if (_timer > 1200 && _timer < 1700)
            {
                if ((int)(Main.time % 15) == 0)
                    NPC.NewNPC(NPC.GetSource_FromAI(),
                               (int)((Main.player[NPC.target].position.X - 500) + Main.rand.Next(1000)),
                               (int)((Main.player[NPC.target].position.Y - 500) + Main.rand.Next(1000)),
                               ModContent.NPCType<GogLordGog>());
            }

            if (_timer == 1600)
			{
				CogMessage("Protocol 13 is activated: Rocket attack incoming.");
			}
            if (_timer >= 1700 && _timer < 1775)
            {
                if (Main.rand.NextBool(3))
                {
                    var shootPos = Main.player[NPC.target].position + new Vector2(Main.rand.Next(-1000, 1000), -1000);
                    var shootVel = new Vector2(Main.rand.NextFloat(-3f, 3f), Main.rand.NextFloat(15f, 20f));
                    IEntitySource source = NPC.GetSource_FromAI(); 

                    int i = Projectile.NewProjectile(source, shootPos, shootVel, 134, GetLaserDamage * ((Main.expertMode) ? 3 : 2), 1f);

                    Main.projectile[i].hostile = true;
                    Main.projectile[i].tileCollide = true;
                    Main.projectile[i].friendly = false;
                }
            }

            if (_timer > 1775)
			{
				_rockets = true;
				_timer = 0;
			}
			_rotation = 0;
		}

        public void CheckHands()
        {
            if (NPC.life < NPC.lifeMax * 0.4f && _flag1)
            {
                _flag1 = false;
                if (Main.expertMode)
                    CogMessage("Low health is detected. Launching support drones.");
                else
                    CogMessage("Low health is detected. Launching support drone.");

                IEntitySource source = NPC.GetSource_FromAI(); 

                if (Main.expertMode)
                    NPC.NewNPC(source, (int)NPC.Center.X - 100, (int)NPC.Center.Y - 100, ModContent.NPCType<CogLordProbe>(), 0, NPC.whoAmI, 0, 200);

                NPC.NewNPC(source, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<CogLordProbe>(), 0, NPC.whoAmI, 0, 200);
            }
        }

        public void MakeHands()
        {
            IEntitySource source = NPC.GetSource_FromAI(); 

            _cogHands.X = NPC.NewNPC(source, (int)NPC.Center.X - 50, (int)NPC.Center.Y,
                ModContent.NPCType<CogLordHand>(), 0, 1, NPC.whoAmI);

            _cogHands.Y = NPC.NewNPC(source, (int)NPC.Center.X + 50, (int)NPC.Center.Y,
                ModContent.NPCType<CogLordGun>(), 0, -1, NPC.whoAmI);
        }


        public void Animation()
		{
			if (--_timeToAnimation <= 0)
			{
				if (++_currentFrame > 4)
					_currentFrame = 1;
				_timeToAnimation = _animationRate;
				NPC.frame = GetFrame(_currentFrame);
			}
		}

		private Rectangle GetFrame(int number)
		{
			return new Rectangle(0, NPC.frame.Height * (number - 1), NPC.frame.Width, NPC.frame.Height);
        }

        public void CogMessage(string message)
        {
            string text = "[CL-AI]: " + message;
            if (Main.netMode != 2)
            {
                Main.NewText("[CL-AI]: " + message, 208, 137, 55);
            }
        }
        public override void OnKill()
        {
            IEntitySource source = NPC.GetSource_Death();
            // TremorWorld.Boss.CogLord.Downed();
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 1, 6, 25)); 
            npcLoot.Add(ItemDropRule.Common(ItemID.SilverCoin, 1, 6, 25)); 
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CogLordTrophy>(), 10));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<CogLordMask>(), 7));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BrassChip>(), 8));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<BrassNugget>(),1, 18, 32));
            npcLoot.Add(ItemDropRule.OneFromOptions(1,
                ModContent.ItemType<BrassRapier>(),
                ModContent.ItemType <BrassChainRepeater>(),
                ModContent.ItemType<BrassStave>()));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<CogLordBag>(), 1));
        
        }
    }
}