using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Bag;
using TremorMod.Content.Items.Placeable;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.NPCs;
using TremorMod.Utilities;
using TremorMod;

namespace TremorMod.Content.NPCs.Bosses.PixieQueen
{
	[AutoloadBossHead]
	public class PixieQueen : ModNPC
	{
		#region "Константы"
		const int AnimationRate = 8; // Частота смены кадров (То, сколько кадров не будет сменятся кадр)
		const int FrameCount = 4; // Кол-во кадров

		const int ShootRate = 70; // Частота выстрела. Будет производить 60/ShootRate выстрелов в секунду
		const int ShootDamage = 15; // Урон от выстрела
		//int ShootType = 100; // Тип выстрела (задаётся в SetDefaults())
		const float ShootKnockback = 1; // Отбрасование от выстрела
		const float ShootSpeed = 10; // Скорость выстрела

		const float DistortPercent = 0.15f; // Процент деформации статов (неточности) (1.0 == 100%)

		const int MinionsID = 61; // ID вуртулек
		const int MinionsCount = 4; // Кол-во вуртулек которых заспавнит

		const int StateTime_Flying = 600; // Сколько будет летать в воздухе до призыва миньонов
		const int StateTime_Minions = 120; // Сколько времени будет спавнить вуртулек

		const int FlyingAI = 2;
		const int MinionsAI = 0;

		const float MinionsState_XDeaccelerationPower = 0.05f; // Скорость замедления по X
		const float MinionsState_YMaxSpeed = 2.80f; // Макс. скорость взлёта во время спавна миньонов
		const float MinionsStete_YSpeedStep = 0.02f; // Скорость увеличения скорости по Y во время спавна миньонов

		const int States = 2;
		#endregion
		#region "Переменные"
		//int TimeToAnimation = AnimationRate;
		//int Frame = 0;
		bool Shoots = true;
		int TimeToShoot = ShootRate;
		//int State = 0;
		//int TimeToState = StateTime_Flying;
		//bool runAway = false;
		#endregion

		int timer;
		int timer2;
		int timer3;
		int timer4;
		//bool SpawnMinion = false;
		public static bool phase2;
		public static bool phase3;

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Pixie Queen");
			Main.npcFrameCount[NPC.type] = 8;
		}

		public override void SetDefaults()
		{
			NPC.aiStyle = 63;
			NPC.lifeMax = 25000;
			NPC.damage = 80;
			NPC.defense = 35;
			NPC.knockBackResist = 0f;
			NPC.width = 122;
			NPC.height = 122;
			NPC.value = Item.buyPrice(0, 10, 0, 0);
			NPC.npcSlots = 15f;
			NPC.boss = true;
			NPC.lavaImmune = true;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath7;
			NPC.buffImmune[24] = true;
			Music = 12;
		}

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float bossLifeScale, float balance)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.6f);
        }

        public override void AI()
		{
			NPC.TargetClosest(true);
			NPC.spriteDirection = NPC.direction;
			Player player = Main.player[NPC.target];
			if (!player.active || player.dead)
			{
				NPC.TargetClosest(false);
				NPC.velocity.Y = 50;
				timer = 0;
				timer2 = 0;
				timer3 = 0;
				timer4 = 0;
			}
			timer++;
			if (timer <= 1000)
			{
				timer2++;
			}
			if (timer <= 1000)
			{
				timer3++;
			}
			if (timer >= 1000)
			{
				timer4++;
			}
			if (timer == 1500)
			{
				timer = 0;
			}
			if (timer >= 200 && timer <= 650)
			{
				Shoot();
				NPC.position += NPC.velocity * 1.2f;
			}
			if (timer >= 650 && timer <= 1000)
			{
				Shoot();
				int currentLifeP2 = NPC.lifeMax * (2 / 3);
				int currentLifeP3 = NPC.lifeMax * (1 / 3);
				if (NPC.life <= currentLifeP2)
				{
					phase2 = true;
				}
				if (NPC.life <= currentLifeP3)
				{
					phase3 = true;
				}
				if (Main.rand.Next(300) == 0)
				{
					SoundEngine.PlaySound(SoundID.Zombie35, NPC.position);
				}
				//Player player = Main.player[npc.target];
				bool playerWet = player.wet;
				//Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0f, 0.25f, 0.15f);
				int num1038 = 0;
				for (int num1039 = 0; num1039 < 255; num1039++)
				{
					if (Main.player[num1039].active && !Main.player[num1039].dead && (NPC.Center - Main.player[num1039].Center).Length() < 1000f)
					{
						num1038++;
					}
				}
				if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
				{
					NPC.TargetClosest(true);
				}
				if (Main.player[NPC.target].dead)
				{
					NPC.TargetClosest(false);
					NPC.velocity.Y = NPC.velocity.Y + 1f;
					if (NPC.position.Y > Main.worldSurface * 16.0)
					{
						NPC.velocity.Y = NPC.velocity.Y + 1f;
					}
					if (NPC.position.Y > Main.rockLayer * 16.0)
					{
						for (int num957 = 0; num957 < 200; num957++)
						{
							if (Main.npc[num957].aiStyle == NPC.aiStyle)
							{
								Main.npc[num957].active = false;
							}
						}
					}
				}
				else if (NPC.ai[0] == -1f)
				{
					if (Main.netMode != 1)
					{
						float num1041 = NPC.ai[1];
						int num1042;
						do
						{
							num1042 = Main.rand.Next(3);
							if (num1042 == 1)
							{
								num1042 = 2;
							}
							else if (num1042 == 2)
							{
								num1042 = 3;
							}
						}
						while (num1042 == num1041);
						NPC.ai[0] = num1042;
						NPC.ai[1] = 0f;
						NPC.ai[2] = 0f;
						return;
					}
				}
				else if (NPC.ai[0] == 0f)
				{
					int num1043 = 2; //2 not a prob
					if (NPC.life < NPC.lifeMax / 2)
					{
						num1043++;
					}
					if (NPC.life < NPC.lifeMax / 3)
					{
						num1043++;
					}
					if (NPC.life < NPC.lifeMax / 5)
					{
						num1043++;
					}
					if (NPC.ai[1] > 2 * num1043 && NPC.ai[1] % 2f == 0f)
					{
						NPC.ai[0] = -1f;
						NPC.ai[1] = 0f;
						NPC.ai[2] = 0f;
						NPC.netUpdate = true;
						return;
					}
					if (NPC.ai[1] % 2f == 0f)
					{
						NPC.TargetClosest(true);
						if (Math.Abs(NPC.position.Y + NPC.height / 2 - (Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2)) < 20f)
						{
							NPC.localAI[0] = 1f;
							NPC.ai[1] += 1f;
							NPC.ai[2] = 0f;
							float num1044 = 16f; //16
							if (NPC.life < NPC.lifeMax * 0.75)
							{
								num1044 += 2f; //2 not a prob
							}
							if (NPC.life < NPC.lifeMax * 0.5)
							{
								num1044 += 2f; //2 not a prob
							}
							if (NPC.life < NPC.lifeMax * 0.25)
							{
								num1044 += 2f; //2 not a prob
							}
							if (NPC.life < NPC.lifeMax * 0.1)
							{
								num1044 += 2f; //2 not a prob
							}
							Vector2 vector117 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
							float num1045 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector117.X;
							float num1046 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector117.Y;
							float num1047 = (float)Math.Sqrt(num1045 * num1045 + num1046 * num1046);
							num1047 = num1044 / num1047;
							NPC.velocity.X = num1045 * num1047;
							NPC.velocity.Y = num1046 * num1047;
							NPC.spriteDirection = NPC.direction;
							SoundEngine.PlaySound(SoundID.Zombie34, NPC.position);
							return;
						}
						NPC.localAI[0] = 0f;
						float num1048 = 12f; //12 not a prob
						float num1049 = 0.15f; //0.15 not a prob
						if (NPC.life < NPC.lifeMax * 0.75)
						{
							num1048 += 1f; //1 not a prob
							num1049 += 0.05f; //0.05 not a prob
						}
						if (NPC.life < NPC.lifeMax * 0.5)
						{
							num1048 += 1f; //1 not a prob
							num1049 += 0.05f; //0.05 not a prob
						}
						if (NPC.life < NPC.lifeMax * 0.25)
						{
							num1048 += 2f; //2 not a prob
							num1049 += 0.05f; //0.05 not a prob
						}
						if (NPC.life < NPC.lifeMax * 0.1)
						{
							num1048 += 2f; //2 not a prob
							num1049 += 0.1f; //0.1 not a prob
						}
						if (NPC.position.Y + NPC.height / 2 < Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2)
						{
							NPC.velocity.Y = NPC.velocity.Y + num1049;
						}
						else
						{
							NPC.velocity.Y = NPC.velocity.Y - num1049;
						}
						if (NPC.velocity.Y < -12f)
						{
							NPC.velocity.Y = -num1048;
						}
						if (NPC.velocity.Y > 12f)
						{
							NPC.velocity.Y = num1048;
						}
						if (Math.Abs(NPC.position.X + NPC.width / 2 - (Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2)) > 600f)
						{
							NPC.velocity.X = NPC.velocity.X + 0.15f * NPC.direction;
						}
						else if (Math.Abs(NPC.position.X + NPC.width / 2 - (Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2)) < 300f)
						{
							NPC.velocity.X = NPC.velocity.X - 0.15f * NPC.direction;
						}
						else
						{
							NPC.velocity.X = NPC.velocity.X * 0.8f;
						}
						if (NPC.velocity.X < -16f)
						{
							NPC.velocity.X = -16f;
						}
						if (NPC.velocity.X > 16f)
						{
							NPC.velocity.X = 16f;
						}
						NPC.spriteDirection = NPC.direction;
						return;
					}
					if (NPC.velocity.X < 0f)
					{
						NPC.direction = -1;
					}
					else
					{
						NPC.direction = 1;
					}
					NPC.spriteDirection = NPC.direction;
					int num1050 = 600; //600 not a prob
					if (!playerWet)
					{
						num1050 = 350;
					}
					else
					{
						num1050 = 600;
						if (NPC.life < NPC.lifeMax * 0.1)
						{
							num1050 = 800; //300 not a prob
						}
						else if (NPC.life < NPC.lifeMax * 0.25)
						{
							num1050 = 750; //450 not a prob
						}
						else if (NPC.life < NPC.lifeMax * 0.5)
						{
							num1050 = 700; //500 not a prob
						}
						else if (NPC.life < NPC.lifeMax * 0.75)
						{
							num1050 = 650; //550 not a prob
						}
					}
					int num1051 = 1;
					if (NPC.position.X + NPC.width / 2 < Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2)
					{
						num1051 = -1;
					}
					if (NPC.direction == num1051 && Math.Abs(NPC.position.X + NPC.width / 2 - (Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2)) > num1050)
					{
						NPC.ai[2] = 1f;
					}
					if (NPC.ai[2] != 1f)
					{
						NPC.localAI[0] = 1f;
						return;
					}
					NPC.TargetClosest(true);
					NPC.spriteDirection = NPC.direction;
					NPC.localAI[0] = 0f;
					NPC.velocity *= 0.9f;
					float num1052 = 0.1f; //0.1
					if (NPC.life < NPC.lifeMax / 2)
					{
						NPC.velocity *= 0.9f;
						num1052 += 0.05f; //0.05
					}
					if (NPC.life < NPC.lifeMax / 3)
					{
						NPC.velocity *= 0.9f;
						num1052 += 0.05f; //0.05
					}
					if (NPC.life < NPC.lifeMax / 5)
					{
						NPC.velocity *= 0.9f;
						num1052 += 0.05f; //0.05
					}
					if (Math.Abs(NPC.velocity.X) + Math.Abs(NPC.velocity.Y) < num1052)
					{
						NPC.ai[2] = 0f;
						NPC.ai[1] += 1f;
						return;
					}
				}
				else if (NPC.ai[0] == 2f)
				{
					NPC.TargetClosest(true);
					NPC.spriteDirection = NPC.direction;
					float num1053 = 12f; //12 found one!  dictates speed during bee spawn
					float num1054 = 0.1f; //0.1 found one!  dictates speed during bee spawn
					Vector2 vector118 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
					float num1055 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector118.X;
					float num1056 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - 200f - vector118.Y;
					float num1057 = (float)Math.Sqrt(num1055 * num1055 + num1056 * num1056);
					if (num1057 < 800f)
					{
						NPC.ai[0] = 1f;
						NPC.ai[1] = 0f;
						NPC.netUpdate = true;
						return;
					}
					num1057 = num1053 / num1057;
					if (NPC.velocity.X < num1055)
					{
						NPC.velocity.X = NPC.velocity.X + num1054;
						if (NPC.velocity.X < 0f && num1055 > 0f)
						{
							NPC.velocity.X = NPC.velocity.X + num1054;
						}
					}
					else if (NPC.velocity.X > num1055)
					{
						NPC.velocity.X = NPC.velocity.X - num1054;
						if (NPC.velocity.X > 0f && num1055 < 0f)
						{
							NPC.velocity.X = NPC.velocity.X - num1054;
						}
					}
					if (NPC.velocity.Y < num1056)
					{
						NPC.velocity.Y = NPC.velocity.Y + num1054;
						if (NPC.velocity.Y < 0f && num1056 > 0f)
						{
							NPC.velocity.Y = NPC.velocity.Y + num1054;
							return;
						}
					}
					else if (NPC.velocity.Y > num1056)
					{
						NPC.velocity.Y = NPC.velocity.Y - num1054;
						if (NPC.velocity.Y > 0f && num1056 < 0f)
						{
							NPC.velocity.Y = NPC.velocity.Y - num1054;
							return;
						}
					}
				}
				else if (NPC.ai[0] == 1f)
				{
					NPC.localAI[0] = 0f;
					NPC.TargetClosest(true);
					Vector2 vector119 = new Vector2(NPC.position.X + NPC.width / 2 + Main.rand.Next(20) * NPC.direction, NPC.position.Y + NPC.height * 0.8f);
					Vector2 vector120 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
					float num1058 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector120.X;
					float num1059 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector120.Y;
					float num1060 = (float)Math.Sqrt(num1058 * num1058 + num1059 * num1059);
					NPC.ai[1] += 1f;
					NPC.ai[1] += num1038 / 2;
					if (NPC.life < NPC.lifeMax * 0.75)
					{
						NPC.ai[1] += 0.25f; //0.25 not a prob
					}
					if (NPC.life < NPC.lifeMax * 0.5)
					{
						NPC.ai[1] += 0.25f; //0.25 not a prob
					}
					if (NPC.life < NPC.lifeMax * 0.25)
					{
						NPC.ai[1] += 0.25f; //0.25 not a prob
					}
					if (NPC.life < NPC.lifeMax * 0.1)
					{
						NPC.ai[1] += 0.25f; //0.25 not a prob
					}
					bool flag103 = false;
					if (NPC.ai[1] > 40f) //changed from 40 not a prob
					{
						NPC.ai[1] = 0f;
						NPC.ai[2] += 1f;
						flag103 = true;
					}
                    if (Collision.CanHit(vector119, 1, 1, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height) && flag103)
                    {
                        SoundEngine.PlaySound(SoundID.NPCHit25, NPC.position);
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            /*int num1061; Не было обнаружено 
                            if (Main.rand.NextBool(4))
                            {
                                num1061 = ModContent.NPCType<AquaticAberration>(); //Aquatic entity spawns
                            }
                            else
                            {
                                num1061 = ModContent.NPCType<Parasea>();
                            }
                            int num1062 = NPC.NewNPC(NPC.GetSource_FromAI(), (int)vector119.X, (int)vector119.Y, num1061, 0);
                            Main.npc[num1062].velocity.X = Main.rand.Next(-200, 201) * 0.01f;
                            Main.npc[num1062].velocity.Y = Main.rand.Next(-200, 201) * 0.01f;
                            Main.npc[num1062].localAI[0] = 60f;
                            Main.npc[num1062].netUpdate = true;*/
                        }
                    }
                    if (num1060 > 400f || !Collision.CanHit(new Vector2(vector119.X, vector119.Y - 30f), 1, 1, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
					{
						float num1063 = 14f; //changed from 14 not a prob
						float num1064 = 0.1f; //changed from 0.1 not a prob
						vector120 = vector119;
						num1058 = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - vector120.X;
						num1059 = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - vector120.Y;
						num1060 = (float)Math.Sqrt(num1058 * num1058 + num1059 * num1059);
						num1060 = num1063 / num1060;
						if (NPC.velocity.X < num1058)
						{
							NPC.velocity.X = NPC.velocity.X + num1064;
							if (NPC.velocity.X < 0f && num1058 > 0f)
							{
								NPC.velocity.X = NPC.velocity.X + num1064;
							}
						}
						else if (NPC.velocity.X > num1058)
						{
							NPC.velocity.X = NPC.velocity.X - num1064;
							if (NPC.velocity.X > 0f && num1058 < 0f)
							{
								NPC.velocity.X = NPC.velocity.X - num1064;
							}
						}
						if (NPC.velocity.Y < num1059)
						{
							NPC.velocity.Y = NPC.velocity.Y + num1064;
							if (NPC.velocity.Y < 0f && num1059 > 0f)
							{
								NPC.velocity.Y = NPC.velocity.Y + num1064;
							}
						}
						else if (NPC.velocity.Y > num1059)
						{
							NPC.velocity.Y = NPC.velocity.Y - num1064;
							if (NPC.velocity.Y > 0f && num1059 < 0f)
							{
								NPC.velocity.Y = NPC.velocity.Y - num1064;
							}
						}
					}
					else
					{
						NPC.velocity *= 0.9f;
					}
					NPC.spriteDirection = NPC.direction;
					if (NPC.ai[2] > 3f)
					{
						NPC.ai[0] = -1f;
						NPC.ai[1] = 1f;
						NPC.netUpdate = true;
						return;
					}
				}
			}
			if (timer >= 1000 && timer <= 1250)
			{
				Shoot();
				NPC.ai[0]++;
				if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
				{
					NPC.TargetClosest(true);
				}
				NPC.netUpdate = true;
				NPC.ai[1]++;
				if (NPC.ai[1] >= 100 && NPC.ai[1] < 200)
				{
					if (Main.rand.Next(10) == 0)
					{
						NPC.velocity.X *= 5.00f;
						NPC.velocity.Y *= 5.00f;
						Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height * 0.5f));
						{
							float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), (vector8.X) - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
							NPC.velocity.X = (float)(Math.Cos(rotation) * 12) * -1;
							NPC.velocity.Y = (float)(Math.Sin(rotation) * 12) * -1;
						}
						return;
					}
				}
				if (NPC.ai[1] >= 280 && NPC.ai[1] < 320)
				{
					if (Main.rand.NextBool(5))
					{
						NPC.velocity.X *= 10.00f;
						NPC.velocity.Y *= 10.00f;
						Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height * 0.5f));
						{
							float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), (vector8.X) - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
							NPC.velocity.X = (float)(Math.Cos(rotation) * 12) * -1;
							NPC.velocity.Y = (float)(Math.Sin(rotation) * 12) * -1;
						}
						return;
					}
				}
				if (NPC.ai[1] >= 450)
				{
					NPC.ai[1] = 0;
				}
			}
            if (timer >= 1250)
            {
                NPC.velocity.Y = 0;
                NPC.velocity.X = 0;
                NPC.rotation = 0f;
                if (Main.rand.Next(70) == 0)
                {
                    NPC.NewNPC(Entity.GetSource_FromThis(), (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<PixieQueenGuardian>());
                }
            }
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            if (Main.rand.NextBool())
            {
                target.AddBuff(BuffID.Confused, 60, true);
            }

            if (Main.rand.NextBool())
            {
                target.AddBuff(BuffID.Slow, 60, true);
            }

            if (Main.rand.NextBool(3))
            {
                target.AddBuff(BuffID.Cursed, 60, true);
            }
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}

				Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 57, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PixieQueenGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PixieQueenGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PixieQueenGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PixieQueenGore4").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PixieQueenGore5").Type, 1f);
			}
		}

		public override void FindFrame(int frameHeight)
		{
			int frameWidth = 122;
			NPC.spriteDirection = NPC.direction;

			//Здесь делается процесс:
			NPC.frameCounter++;
			if (NPC.frameCounter >= 4)
			{
				if (timer > 200 && timer < 1250)
				{
					NPC.frame.Y += 122;
					if (NPC.frame.Y >= 976)
					{
						NPC.frame.Y = 0;
						NPC.frame.X = (NPC.frame.X + (frameWidth * 2)) % (3 * frameWidth);
					}
				}
				if (timer <= 200)
				{
					NPC.frame.Y += 122;
					if (NPC.frame.Y >= 976)
					{
						NPC.frame.Y = 0;
						NPC.frame.X = 0;
					}
				}
				if (timer >= 1250)
				{
					NPC.frame.Y += 122;
					if (NPC.frame.Y >= 976)
					{
						NPC.frame.Y = 0;
						NPC.frame.X = (NPC.frame.X + frameWidth) % (2 * frameWidth);
						///SpawnMinion = false;
					}
				}
				NPC.frameCounter = 0;
			}
			NPC.frame.Width = frameWidth;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
			Texture2D drawTexture = TextureAssets.Npc[NPC.type].Value;
			Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[NPC.type]) * 0.5F);

			Vector2 drawPos = new Vector2(
			NPC.position.X - Main.screenPosition.X + (NPC.width / 2) - (TextureAssets.Npc[NPC.type].Value.Width / 2) * NPC.scale / 2f + origin.X * NPC.scale,
			NPC.position.Y - Main.screenPosition.Y + NPC.height - TextureAssets.Npc[NPC.type].Value.Height * NPC.scale / Main.npcFrameCount[NPC.type] + 4f + origin.Y * NPC.scale + NPC.gfxOffY);

			SpriteEffects effects = NPC.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(drawTexture, drawPos, NPC.frame, Color.White, 0f, origin, NPC.scale, effects, 0);

			return false;
		}

        void Shoot()
        {
            if (!Shoots && NPC.target < 0) //если не время для не стрельбы, то вырубаем автоматом
                return;
            if (--TimeToShoot > 0) //если таймер меньше нуля, то вырубаем автоматом
                return;
            TimeToShoot = (int)Helper.DistortFloat(ShootRate, DistortPercent); //устанавливаем частоту выстрела
            for (int i = 0; i < ((Main.expertMode) ? 4 : 2); i++) //в цикле указываем кол-во перьев при выстреле
            {
                Player player = Main.player[NPC.target];
                Vector2 position1 = player.Center;
                Vector2 vector2 = new Vector2(player.position.X + 75f * (float)Math.Cos(12), player.position.Y + 1075f * (float)Math.Sin(12));
                Vector2 Velocity = Helper.VelocityToPoint(vector2, Helper.RandomPointInArea(new Vector2(Main.player[NPC.target].Center.X - 10, Main.player[NPC.target].Center.Y - 10), new Vector2(Main.player[NPC.target].Center.X + 20, Main.player[NPC.target].Center.Y + 20)), ShootSpeed); //здесь устанавливаем позиции (здесь от перса в плеера)
                int Proj = Projectile.NewProjectile(NPC.GetSource_FromThis(), vector2.X, vector2.Y, Velocity.X, Velocity.Y, 671, (int)Helper.DistortFloat(ShootDamage, DistortPercent), Helper.DistortFloat(ShootKnockback, DistortPercent)); //подтверждаем все выше действие: от перса к мобу, от моба к персу (второе выстрел)
                Main.projectile[Proj].friendly = false;
                Main.projectile[Proj].damage = NPC.damage;
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PixieQueenMask>(), 7));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EtherealFeather>(), 6));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PixiePulse>(), 6));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HeartMagnet>(), 6));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PixieQueenTrophy>(), 10));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChaosBar>(), 1, 25, 30));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<PixieQueenBag>(), 1));
        }      
    }
}