using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Bag;
using TremorMod.Content.Items.Placeable;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Weapons.Ranged;
using TremorMod.Content.Items.Weapons.Throwing;
using TremorMod.Content.Items.Weapons.Summon;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items;
using TremorMod.Utilities;
using TremorMod;

namespace TremorMod.Content.NPCs.Bosses.Brutallisk
{
	[AutoloadBossHead]
	public class Brutallisk : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Brutallisk");
			Main.npcFrameCount[NPC.type] = 4;
		}

		int timer;
		int timer2;
		int timer3;
		int timer4;
		//bool SpawnMinion = false;
		public static bool phase2 = false;
		public static bool phase3 = false;
		static bool expertMode = Main.expertMode;
		const int ShootRate = 170;
		const int ShootDamage = 20;
		const float ShootKN = 1.0f;
		const int ShootType = 55;
		const float ShootSpeed = 10;
		const int SpeedMulti = 2;

		//int TimeToShoot = ShootRate;
		static int num1461 = 360;
		float num1453 = expertMode ? 15f : 14f; //сила рывка
		float num1463 = 6.28318548f / (num1461 / 2);
		int num1450 = expertMode ? 160 : 240; //частота рывка
		int num1472;
		//bool flag128;
		static float scaleFactor10 = expertMode ? 8.5f : 7.5f;
		//Vector2 value17 = Main.player[npc.target].Center + new Vector2(npc.ai[1], -200f) - npc.Center;
		//Vector2 vector170 = Vector2.Normalize(Main.player[npc.target].Center + new Vector2(npc.ai[1], -200f) - npc.Center - npc.velocity) * scaleFactor10;
		float num1451 = expertMode ? 0.55f : 0.45f;
		//int num1471 = Math.Sign(Main.player[npc.target].Center.X - npc.Center.X);
		public override void SetDefaults()
		{
			NPC.lifeMax = 115000;
			NPC.damage = 245;
			NPC.defense = 105;
			NPC.knockBackResist = 0f;
			NPC.width = 276;
			NPC.height = 366;
			AnimationType = 82;
			NPC.aiStyle = 2;
			NPC.npcSlots = 1f;
			//npc.soundHit = 7;
			//npc.soundKilled = 10;
			NPC.boss = true;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			Music = 17;
			NPC.value = Item.buyPrice(3, 50, 0, 0);
			//bossBag/* tModPorter Note: Removed. Spawn the treasure bag alongside other loot via npcLoot.Add(ItemDropRule.BossBag(type)) */ = Mod.Find<ModItem>("BrutalliskBag").Type;
		}

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float bossLifeScale, float balance)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.6f);
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
			int hitDirection = hit.HitDirection;

			if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 151, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("BrutalliskGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("BrutalliskGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("BrutalliskGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("BrutalliskGore4").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("BrutalliskGore4").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("BrutalliskCrystal").Type, 1f);
			}
			else
			{
				for (int k = 0; k < hit.Damage / NPC.lifeMax * 50.0; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 59, hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
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

			// Boss Minion spawning.
			int XOffset = 1200;
			int YOffset = 1200;
			if (Main.rand.Next(190) == 0)
				NPC.NewNPC(Entity.GetSource_FromThis(), (int)player.Center.X + XOffset, (int)player.Center.Y - YOffset, ModContent.NPCType<Quetzalcoatl>());

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
			if (timer == 1750)
			{
				timer = 0;
			}

			if (timer >= 200 && timer <= 650)
			{
				if (NPC.ai[1] == 0f)
				{
					NPC.ai[1] = 300 * Math.Sign((NPC.Center - Main.player[NPC.target].Center).X);
				}
				//value17 = Main.player[npc.target].Center + new Vector2(npc.ai[1], -200f) - npc.Center;
				//vector170 = Vector2.Normalize(Main.player[npc.target].Center + new Vector2(npc.ai[1], -200f) - npc.Center - npc.velocity) * scaleFactor10;
				//num1471 = Math.Sign(Main.player[npc.target].Center.X - npc.Center.X);
				if (Math.Sign(Main.player[NPC.target].Center.X - NPC.Center.X) != 0)
				{
					if (NPC.ai[2] == 0f && Math.Sign(Main.player[NPC.target].Center.X - NPC.Center.X) != NPC.direction)
					{
						NPC.rotation += 3.14159274f;
					}
					NPC.direction = Math.Sign(Main.player[NPC.target].Center.X - NPC.Center.X);
					if (NPC.spriteDirection != -NPC.direction)
					{
						NPC.rotation += 3.14159274f;
					}
					NPC.spriteDirection = -NPC.direction;
				}
				NPC.ai[2] += 1f;
				if (NPC.ai[2] >= num1450)
				{
					num1472 = 0;
					switch ((int)NPC.ai[3])
					{
						case 0:
						case 1:
						case 2:
						case 3:
						case 4:
						case 5:
						case 6:
						case 7:
						case 8:
						case 9:
							num1472 = 1;
							break;
						case 10:
							NPC.ai[3] = 1f;
							num1472 = 2;
							break;
						case 11:
							NPC.ai[3] = 0f;
							num1472 = 3;
							break;
					}
					//if (flag128)
					//{
					//	num1472 = 4;
					//}
					if (num1472 == 1)
					{
						NPC.ai[0] = 1f;
						NPC.ai[1] = 0f;
						NPC.ai[2] = 0f;
						NPC.velocity = Vector2.Normalize(Main.player[NPC.target].Center - NPC.Center) * num1453;
						NPC.rotation = (float)Math.Atan2(NPC.velocity.Y, NPC.velocity.X);
						if (Math.Sign(Main.player[NPC.target].Center.X - NPC.Center.X) != 0)
						{
							NPC.direction = Math.Sign(Main.player[NPC.target].Center.X - NPC.Center.X);
							if (NPC.spriteDirection == 1)
							{
								NPC.rotation += 3.14159274f;
							}
							NPC.spriteDirection = -NPC.direction;
						}
					}
					else if (num1472 == 2)
					{
						NPC.ai[0] = 2f;
						NPC.ai[1] = 0f;
						NPC.ai[2] = 0f;
					}
					else if (num1472 == 3)
					{
						NPC.ai[0] = 3f;
						NPC.ai[1] = 0f;
						NPC.ai[2] = 0f;
					}
					else if (num1472 == 4)
					{
						NPC.ai[0] = 4f;
						NPC.ai[1] = 0f;
						NPC.ai[2] = 0f;
					}
					NPC.netUpdate = true;
					return;
				}
			}

			if (timer >= 650 && timer <= 1000)
			{
				NPC.velocity.X *= 0.98f;
				NPC.velocity.Y *= 0.98f;
				Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height * 0.5f));
				{
					float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), (vector8.X) - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
					NPC.velocity.X = (float)(Math.Cos(rotation) * 8) * -1;
					NPC.velocity.Y = (float)(Math.Sin(rotation) * 8) * -1;
				}
				return;
			}

			if (timer >= 1000 && timer <= 1250)
			{
				if ((Main.player[NPC.target].position.X + 400 < NPC.position.X || Main.player[NPC.target].position.X - 400 > NPC.position.X || Main.player[NPC.target].position.Y + 400 < NPC.position.Y || Main.player[NPC.target].position.Y - 400 > NPC.position.Y))
				{
					if (Main.player[NPC.target].position.X + 400 < NPC.position.X)
					{
						if (NPC.velocity.X > -6) { NPC.velocity.X -= 0.2f; }
					}
					else if (Main.player[NPC.target].position.X - 400 > NPC.position.X)
					{
						if (NPC.velocity.X < 6) { NPC.velocity.X += 0.2f; }
					}
					if (Main.player[NPC.target].position.Y + 400 < NPC.position.Y)
					{
						if (NPC.velocity.Y > -6) NPC.velocity.Y -= 0.2f;
					}
					else if (Main.player[NPC.target].position.Y - 400 > NPC.position.Y)
					{
						if (NPC.velocity.Y < 6) NPC.velocity.Y += 0.2f;
					}
				}
				else
				{
					NPC.velocity.X *= 0.95f; NPC.velocity.Y *= 0.95f;
					NPC.ai[1]++;
					if (NPC.ai[1] >= 30)
					{
						NPC.velocity.X += Main.rand.Next(-4, 4);
						NPC.velocity.Y += Main.rand.Next(-4, 4);
						NPC.ai[1] = 0;
					}
				}

				Vector2 vector = NPC.velocity;
				NPC.velocity = Collision.TileCollision(NPC.position, NPC.velocity, NPC.width, NPC.height, false, false);
				if (NPC.velocity.X != vector.X)
				{
					NPC.velocity.X = -vector.X;
				}
				if (NPC.velocity.Y != vector.Y)
				{
					NPC.velocity.Y = -vector.Y;
				}

				if (NPC.ai[0] >= 0)
				{
					if ((Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height)))
					{
						//float num48 = 12f;
						//int damage = 30;
						NPC.ai[0] = -100 - Main.rand.Next(100);
					}
				}

				if (Main.time % 2 == 0 && Main.netMode == 2 && NPC.whoAmI < 200)
				{
					//NetMessage.SendData(23, -1, -1, "", npc.whoAmI, 0f, 0f, 0f, 0);
				}
			}

			if (timer >= 1250 && timer <= 1500)
			{
				if (Main.player[NPC.target].position.X < NPC.position.X)
				{
					if (NPC.velocity.X > -8) NPC.velocity.X -= 0.22f;
				}

				if (Main.player[NPC.target].position.X > NPC.position.X)
				{
					if (NPC.velocity.X < 8) NPC.velocity.X += 0.22f;
				}

				if (Main.player[NPC.target].position.Y < NPC.position.Y + 300)
				{
					if (NPC.velocity.Y < 0)
					{
						if (NPC.velocity.Y > -4) NPC.velocity.Y -= 0.8f;
					}
					else NPC.velocity.Y -= 0.6f;
				}

				if (Main.player[NPC.target].position.Y > NPC.position.Y + 300)
				{
					if (NPC.velocity.Y > 0)
					{
						if (NPC.velocity.Y < 4) NPC.velocity.Y += 0.8f;
					}
					else NPC.velocity.Y += 0.6f;
				}
				NPC.ai[0]++;
				if (NPC.ai[0] >= 70)
				{
					//float Speed = 12f;
					Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width / 2), NPC.position.Y + (NPC.height / 2));
					//int damage = 45;
					//Main.PlaySound(2, (int) npc.position.X, (int) npc.position.Y, 33);
					float rotation = (float)Math.Atan2(vector8.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), vector8.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
					//int num54 = npc.NewProjectile(vector8.X, vector8.Y,(float)((Math.Cos(rotation) * Speed)*-1),(float)((Math.Sin(rotation) * Speed)*-1), 100, damage, 0f, 0);
					NPC.ai[0] = 0;
				}
				NPC.ai[1]++;
				if (NPC.ai[1] >= 300)
				{
					NPC.velocity.X *= 0.98f;
					NPC.velocity.Y *= 0.98f;
					Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height / 2));
					if ((NPC.velocity.X < 2f) && (NPC.velocity.X > -2f) && (NPC.velocity.Y < 2f) && (NPC.velocity.Y > -2f))
					{
						float rotation = (float)Math.Atan2((vector8.Y) - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), (vector8.X) - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
						NPC.velocity.X = (float)(Math.Cos(rotation) * 25) * -1;
						NPC.velocity.Y = (float)(Math.Sin(rotation) * 25) * -1;
					}
				}
			}

			if (timer >= 1500)
			{
				NPC.netUpdate = true;
				NPC.ai[1]++;
				NPC.TargetClosest();
				Player tarP = Main.player[NPC.target]; //float num74 = 0.022f;
				float num75 = tarP.position.X + tarP.width / 2;
				float num76 = tarP.position.Y + tarP.height / 2;
				Vector2 vector11 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
				num75 = (int)(num75 / 8f) * 8;
				num76 = (int)(num76 / 8f) * 8;
				vector11.X = (int)(vector11.X / 8f) * 8;
				vector11.Y = (int)(vector11.Y / 8f) * 8;
				num75 -= vector11.X;
				num76 -= vector11.Y;
				if ((tarP.position.X + 300 < NPC.position.X || tarP.position.X - 300 > NPC.position.X || tarP.position.Y + 300 < NPC.position.Y || tarP.position.Y - 300 > NPC.position.Y))
				{
					if (tarP.position.X + 300 < NPC.position.X)
					{
						if (NPC.velocity.X > -6)
						{
							NPC.velocity.X -= 0.2f;
						}
					}
					else if (tarP.position.X - 300 > NPC.position.X)
					{
						if (NPC.velocity.X < 6)
						{
							NPC.velocity.X += 0.2f;
						}
					}
					if (tarP.position.Y + 300 < NPC.position.Y)
					{
						if (NPC.velocity.Y > -6)
						{
							NPC.velocity.Y -= 0.2f;
						}
					}
					else if (tarP.position.Y - 300 > NPC.position.Y)
					{
						if (NPC.velocity.Y < 6)
						{
							NPC.velocity.Y += 0.2f;
						}
					}
				}
				else
				{
					NPC.velocity.X *= 0.95f; NPC.velocity.Y *= 0.95f;
					NPC.ai[2]++;
					if (NPC.ai[2] == 60)
					{
						NPC.ai[0] = Main.rand.Next(-7, 7);
						NPC.velocity.X += NPC.ai[0];
						NPC.velocity.Y += NPC.ai[0];
						NPC.ai[2] = 0;
					}
				}
				Vector2 vector = NPC.velocity;
				NPC.velocity = Collision.TileCollision(NPC.position, NPC.velocity, NPC.width, NPC.height, false, false);
				if (NPC.velocity.X != vector.X)
				{
					NPC.velocity.X = -vector.X;
				}
				if (NPC.velocity.Y != vector.Y)
				{
					NPC.velocity.Y = -vector.Y;
				}
				NPC.rotation = (float)Math.Atan2(num76, num75) - 1.57f;
				float num83 = 0.7f;
				if (NPC.collideX)
				{
					NPC.netUpdate = true;
					NPC.velocity.X = NPC.oldVelocity.X * -num83;
					if (NPC.direction == -1 && NPC.velocity.X > 0f && NPC.velocity.X < 2f)
					{
						NPC.velocity.X = 2f;
					}
					if (NPC.direction == 1 && NPC.velocity.X < 0f && NPC.velocity.X > -2f)
					{
						NPC.velocity.X = -2f;
					}
				}
				if (NPC.collideY)
				{
					NPC.netUpdate = true;
					NPC.velocity.Y = NPC.oldVelocity.Y * -num83;
					if (NPC.velocity.Y > 0f && NPC.velocity.Y < 1.5)
					{
						NPC.velocity.Y = 2f;
					}
					if (NPC.velocity.Y < 0f && NPC.velocity.Y > -1.5)
					{
						NPC.velocity.Y = -2f;
					}
				}

				if ((int)(Main.time % 120) == 0)
				{
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X + 40, NPC.position.Y + 40, -7, 0, 686, NPC.damage, 0, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X + 40, NPC.position.Y + 40, 7, 0, 467, NPC.damage, 0, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X + 40, NPC.position.Y + 40, 0, 7, 467, NPC.damage, 0, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X + 40, NPC.position.Y + 40, 0, -7, 467, NPC.damage, 0, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X + 40, NPC.position.Y + 40, -7, -7, 686, NPC.damage, 0, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X + 40, NPC.position.Y + 40, 7, -7, 467, NPC.damage, 0, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X + 40, NPC.position.Y + 40, -7, 7, 467, NPC.damage, 0, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X + 40, NPC.position.Y + 40, 7, 7, 686, NPC.damage, 0, Main.myPlayer, 0f, 0f);
				}

			}

			if (!Main.expertMode && Main.rand.Next(320) == 0)
			{
				SoundEngine.PlaySound(SoundID.Zombie97, NPC.position);

				for (int i = 0; i < 255; ++i)
				{
					if (Main.player[i].active && !Main.player[i].dead)
					{
						//Main.player[i].Hurt(45, 1, false, false, "was roared to death.", false, -1);
					}
				}
			}

			if (Main.expertMode && Main.rand.Next(310) == 0)
			{
				SoundEngine.PlaySound(SoundID.Zombie97, NPC.position);

				for (int i = 0; i < 255; ++i)
				{
					if (Main.player[i].active && !Main.player[i].dead)
					{
						//Main.player[i].Hurt(60, 1, false, false, "was roared to death.", false, -1);
					}
				}
			}

			if (Main.rand.Next(380) == 0)
			{
				NPC.NewNPC(Entity.GetSource_FromThis(), (int)NPC.position.X - 50, (int)NPC.position.Y, ModContent.NPCType<Naga>());
            }

			if (Main.rand.Next(380) == 0)
			{
				NPC.NewNPC(Entity.GetSource_FromThis(), (int)NPC.position.Y + 100, (int)NPC.position.Y, ModContent.NPCType<Quetzalcoatl>());
			}

		}

		Vector2 VelocityFPTP(Vector2 pos1, Vector2 pos2, float speed)
		{
			Vector2 move = pos2 - pos1;
			return move * (speed / (float)Math.Sqrt(move.X * move.X + move.Y * move.Y));
		}

       

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrutalliskMask>(), 7));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LightningStaff>(), 4));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Awakening>(), 4));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SnakeDevourer>(), 4));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<QuetzalcoatlStave>(), 4));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TreasureGlaive>(), 4));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FallenSnake>(), 4));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StrangeEgg>(), 5));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrutalliskTrophy>(), 10));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Aquamarine>(), 1, 25, 30));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<BrutalliskBag>(), 1));
        }

    }
}