using System.IO;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Weapons.Ranged;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TremorMod.Content.Items.BossLoot.TikiTotem;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Materials;
using TremorMod.Utilities;
using System.Linq;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;
using TremorMod.Content.Tiles;
using TremorMod;
using ReLogic.Content;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Weapons.Throwing;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Bag;

namespace TremorMod.Content.NPCs.Bosses.Trinity
{
	[AutoloadBossHead]
	public class SoulofTrust : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("The Doom");
		}

		const int NormalShootRate = 142;
		const int NormalBulletDamage = 10;
		const float NormalBulletSpeed = 7.0f;
		const float NormalBulletKB = 1.0f;
		const int NormalShootType = 291;

		const int PowerBulletDamage = 20;
		const int PowerShootRate = 200;
		const float PowerBulletSpeed = 10.0f;
		const float PowerBulletKB = 2.0f;
		const int PowerShootType = 467;

		const int PowerTime = 300;
		const int BonusDefenseInPower = 5;
		const int BonusDamageInPower = 10;

		bool Power;
		bool OnlyPower;
		int TimeToShoot = NormalShootRate;
		int CurrentPower = PowerTime;
		int Step = -1;
		Color TextColor = Color.Orange;
		bool StateFlag = true;

		public override void SetDefaults()
		{
			NPC.lifeMax = 100000;
			NPC.damage = 134;
			NPC.defense = 120;
			NPC.knockBackResist = 0.0f;
			NPC.width = 170;
			NPC.height = 254;
			NPC.aiStyle = 5;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath10;
			//npc.boss = true;
			NPC.value = Item.buyPrice(0, 1, 0, 0);
		}

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float bossLifeScale, float balance)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.6f);
        }

        bool RunAway;

		public override void AI()
		{
			NPC.position += NPC.velocity * 1.7f;
			if (Main.rand.Next(500) == 0 && Main.expertMode)
			{
				for (int i = 0; i < 50; i++)
				{
					int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, 6);
					Main.dust[dust].scale = 1.5f;
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 0f;
					Main.dust[dust].velocity *= 0f;
				}
				NPC.position.X = (Main.player[NPC.target].position.X - 250) + Main.rand.Next(500);
				NPC.position.Y = (Main.player[NPC.target].position.Y - 250) + Main.rand.Next(500);
			}

			if (Main.rand.Next(500) == 0 && !Main.expertMode)
			{
				NPC.TargetClosest(true);
				Vector2 vector142 = new Vector2(NPC.Center.X, NPC.Center.Y);
				float num1243 = Main.player[NPC.target].Center.X - vector142.X;
				float num1244 = Main.player[NPC.target].Center.Y - vector142.Y;
				float num1245 = (float)Math.Sqrt(num1243 * num1243 + num1244 * num1244);
				if (NPC.ai[1] == 0f)
				{
					if (Main.netMode != 1)
					{
						NPC.localAI[1] += 1f;
						if (NPC.localAI[1] >= 120 + Main.rand.Next(200))
						{
							NPC.localAI[1] = 0f;
							NPC.TargetClosest(true);
							int num1249 = 0;
							int num1250;
							int num1251;
							while (true)
							{
								num1249++;
								num1250 = (int)Main.player[NPC.target].Center.X / 16;
								num1251 = (int)Main.player[NPC.target].Center.Y / 16;
								num1250 += Main.rand.Next(-50, 51);
								num1251 += Main.rand.Next(-50, 51);
								if (!WorldGen.SolidTile(num1250, num1251) && Collision.CanHit(new Vector2(num1250 * 16, num1251 * 16), 1, 1, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
								{
									break;
								}
								if (num1249 > 100)
								{
									//return;
								}
							}
							NPC.ai[1] = 1f;
							NPC.ai[2] = num1250;
							NPC.ai[3] = num1251;
							NPC.netUpdate = true;
							//return;
						}
					}
				}
				else if (NPC.ai[1] == 1f)
				{
					NPC.alpha += 3;
					if (NPC.alpha >= 255)
					{
						NPC.alpha = 255;
						NPC.position.X = NPC.ai[2] * 16f - NPC.width / 2;
						NPC.position.Y = NPC.ai[3] * 16f - NPC.height / 2;
						NPC.ai[1] = 2f;
						//return;
					}
				}
				else if (NPC.ai[1] == 2f)
				{
					NPC.alpha -= 3;
					if (NPC.alpha <= 0)
					{
						NPC.alpha = 0;
						NPC.ai[1] = 0f;
						//return;
					}
				}
			}

			if (NPC.AnyNPCs(ModContent.NPCType<SoulofHope>()) || NPC.AnyNPCs(ModContent.NPCType<SoulofTruth>()))
			{
				NPC.dontTakeDamage = true;
			}
			if (NPC.AnyNPCs(ModContent.NPCType<SoulofHope>()) || NPC.AnyNPCs(ModContent.NPCType<SoulofTruth>()))
            {
				NPC.dontTakeDamage = false;
			}

			if (Main.expertMode && Main.rand.Next(4500) == 0)
			{
				NPC.NewNPC(Entity.GetSource_FromThis(), (int)NPC.position.X - 100, (int)NPC.position.Y - 50, 418);
				NPC.NewNPC(Entity.GetSource_FromThis(), (int)NPC.position.X + 100, (int)NPC.position.Y - 50, 418);
			}

			if (Main.rand.NextBool(2))
			{
				int num706 = Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 0f, 0f, 200, NPC.color, 0.5f);
				Main.dust[num706].velocity *= 0.6f;
			}

			if (NPC.target != -1 && !RunAway) //если(пнс.цель не варно -1 И не убегать)
				if (!Main.player[NPC.target].active) //если (не мой.игрок[нпс.цель].активный)
				{
					if (Helper.GetNearestAlivePlayer(NPC) == -1) //если (Помощьник.ПолучитьКоординатыИгрока(нпс) присвоить -1)
						RunAway = true; //Убегает = да
					else //или
					{
						if (Main.player[Helper.GetNearestAlivePlayer(NPC)].Distance(NPC.Center) > 2500f) //если(Мой.игрок[Помощьник.ПолучитьКоординатыИгрока(нпс)].Дистанция(нпс.Центр) больше 2500фунтов)
							RunAway = true; //Убегает = да
						else //или...
							NPC.target = Helper.GetNearestAlivePlayer(NPC); //нпс.цель равно Помощьник.ПолучитьКоординатыИгрока(нпс)
					}
				}
			if (Main.dayTime || RunAway || NPC.localAI[3] == 1) //если(Мой.День или Убегать или нпс.местный ИИ 3 к 1)
			{
				NPC.localAI[3] = 1; //нпс.местный ИИ[3] равен 3
				if (Main.npc[(int)NPC.ai[2]].type == ModContent.NPCType<SoulofHope>() && Main.npc[(int)NPC.ai[2]].active) //если(Мой.нпс[(значение)нпс.ИИ[2]].тип равен мод.НПС Тип("МОБ") и Мой.нпс[(значение)нпс.ИИ[2]].активен равен да)
					Main.npc[(int)NPC.ai[2]].localAI[3] = 1; //Мой.нпс[(значение)нпс.ИИ[2]].местный ИИ[3] варно 1
                if (Main.npc[(int)NPC.ai[3]].type == ModContent.NPCType<SoulofTruth>() && Main.npc[(int)NPC.ai[3]].active)//если(Мой.нпс[(значение)нпс.ИИ[2]].тип равен мод.НПС Тип("МОБ") и Мой.нпс[(значение)нпс.ИИ[2]].активен равен да)
                    Main.npc[(int)NPC.ai[3]].localAI[3] = 1; //Мой.нпс[(значение)нпс.ИИ[2]].местный ИИ[3] варно 1
				NPC.life += 11; //нпс.жизнь прибавить
				NPC.aiStyle = 0; //нпс.ИИ Стиль - 0
				NPC.rotation = 0;
				NPC.velocity = Helper.VelocityFPTP(NPC.Center, new Vector2(NPC.Center.X, NPC.Center.Y - 4815162342), 30.0f); //нпс.поворот = Помощьник.ПоворотФПТП(нпс.Центр, новый Вектор2(нпс.Центр.X, нпс.Центр.Y - 4815162342))
				CreateDust();
				return;
			}
			if (StateFlag)
				if (
					!((Main.npc[(int)NPC.ai[2]].type == ModContent.NPCType<SoulofHope>() && Main.npc[(int)NPC.ai[2]].active)) ||
					!((Main.npc[(int)NPC.ai[3]].type == ModContent.NPCType<SoulofTruth>() && Main.npc[(int)NPC.ai[3]].active))
				   )
				{
					StateFlag = false;
					OnlyPower = true;
				}
			if (OnlyPower)
				SetStage(true);
			else
			{
				CurrentPower += Step;
				if (CurrentPower <= 0 || CurrentPower >= PowerTime)
				{
					Step *= -1;
					SetStage(!Power);
				}
			}
			SetRotation();
			CreateDust();
			TimeToShoot--;
			if (TimeToShoot <= 0 && !Power)
			{
				TimeToShoot = NormalShootRate;
				Shoot();
				return;
			}
			if (TimeToShoot <= 0 && Power)
			{
				TimeToShoot = PowerShootRate;
				NPC.target = Helper.GetNearestPlayer(NPC);
				if (NPC.target != -1)
				{
					for (int a = 0; a < 5; a++)
					{
						Vector2 velocity = Helper.VelocityFPTP(NPC.Center, Main.player[NPC.target].Center, PowerBulletSpeed);
						int spread = 65;
						float spreadMult = 0.05f;
						velocity.X = velocity.X + Main.rand.Next(-spread, spread + 1) * spreadMult;
						velocity.Y = velocity.Y + Main.rand.Next(-spread, spread + 1) * spreadMult;
						int i = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X, NPC.Center.Y, velocity.X, velocity.Y, PowerShootType, PowerBulletDamage, PowerBulletKB);
						Main.projectile[i].hostile = true;
						Main.projectile[i].friendly = true;
					}
				}
			}
		}

		void CreateDust()
		{
			if (Main.rand.NextBool(3))
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 6);
		}

		void SetRotation()
		{
			NPC.rotation = 0;
		}

		void SetStage(bool stage)
		{
			if (Power == stage)
				return;
			Power = stage;
			if (Power)
			{
				NPC.defense += BonusDefenseInPower;
				NPC.damage += BonusDamageInPower;
			}
			else
			{
				NPC.defense -= BonusDefenseInPower;
				NPC.damage -= BonusDamageInPower;
			}
		}

		void Shoot()
		{
			NPC.target = Helper.GetNearestPlayer(NPC);
			if (NPC.target != -1)
			{
				Vector2 velocity = Helper.VelocityFPTP(NPC.Center, Main.player[NPC.target].Center, NormalBulletSpeed);
				int spread = 95;
				float spreadMult = 0.075f;
				for (int l = 0; l < 2; l++)
				{
					velocity.X = velocity.X + Main.rand.Next(-spread, spread + 1) * spreadMult;
					velocity.Y = velocity.Y + Main.rand.Next(-spread, spread + 1) * spreadMult;
					int i = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X, NPC.Center.Y, velocity.X, velocity.Y, NormalShootType, NormalBulletDamage, NormalBulletKB);
					Main.projectile[i].hostile = true;
					Main.projectile[i].friendly = false;
				}
			}
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TrustGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TrustGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("TrustGore3").Type, 1f);
                if (!NPC.AnyNPCs(ModContent.NPCType<SoulofTruth>()) && !NPC.AnyNPCs(ModContent.NPCType<SoulofHope>()))
                {
                    Main.NewText("The Trinity has been defeated!", 175, 75, 255);
                }
            }
		}

        public override void OnKill()
        {
            if (!NPC.AnyNPCs(ModContent.NPCType<SoulofHope>()) && !NPC.AnyNPCs(ModContent.NPCType<SoulofTruth>()))
            {
                TremorSpawnEnemys.downedTrinity = true;

                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.WorldData);
                }
             
                bool spawnAngelite = !TremorSpawnEnemys.spawnedAngeliteLast;
                TremorSpawnEnemys.spawnedAngeliteLast = spawnAngelite; 

                string msg = spawnAngelite
                    ? "This world has been enlightened with Angelite!"
                    : "This world has been attacked with Collapsium!";

                Main.NewText(msg, (byte)(spawnAngelite ? 0 : 255), (byte)(spawnAngelite ? 191 : 20), (byte)(spawnAngelite ? 255 : 147));

                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(msg),
                        spawnAngelite ? new Color(0, 191, 255) : new Color(255, 20, 147));
                }

                int oreType = spawnAngelite ? ModContent.TileType<AngeliteOreTile>() : ModContent.TileType<CollapsiumOreTile>();

                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                {
                    WorldGen.TileRunner(
                        WorldGen.genRand.Next(0, Main.maxTilesX),
                        WorldGen.genRand.Next((int)(Main.maxTilesY * .3f), (int)(Main.maxTilesY * .65f)),
                        WorldGen.genRand.Next(9, 15),
                        WorldGen.genRand.Next(9, 15),
                        oreType,
                        false,
                        0f, 0f, false, true);
                }
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            if (!NPC.AnyNPCs(ModContent.NPCType<SoulofTruth>()) && !NPC.AnyNPCs(ModContent.NPCType<SoulofHope>()))
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TrustMask>(), 7)); 
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Volcannon>(), 3));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HonestBlade>(), 3));
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<TrinityBag2>(), 1));
            }
        }
    }
}
