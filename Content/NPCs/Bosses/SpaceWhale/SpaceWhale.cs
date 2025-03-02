using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Utilities;
using Terraria;
using TremorMod.Utilities;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Filters = Terraria.Graphics.Effects.Filters;
using TremorMod;
using TremorMod.Content.Items.SpaceWhaleItems;

namespace TremorMod.Content.NPCs.Bosses.SpaceWhale
{
	[AutoloadBossHead]
	public class SpaceWhale : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Space Whale");
			Main.npcFrameCount[NPC.type] = 8;
		}

		public override void SetDefaults()
		{
			NPC.width = 500;
			NPC.height = 80;
			NPC.damage = 120;
			NPC.defense = 135;
			NPC.lifeMax = 120000;
			NPC.scale = 1.2f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.noTileCollide = true;
			NPC.DeathSound = SoundID.NPCDeath10;
			NPC.boss = true;
			NPC.knockBackResist = 0f;
			NPC.noGravity = true;
			Music = 39;
			NPC.aiStyle = -1;
			AnimationType = 370;
			//bossBag/* tModPorter Note: Removed. Spawn the treasure bag alongside other loot via npcLoot.Add(ItemDropRule.BossBag(type)) */ = Mod.Find<ModItem>("SpaceWhaleTreasureBag").Type;
		}

        public override void HitEffect(NPC.HitInfo hitInfo)
        {
            if (NPC.life <= 0)
            {
                for (int k = 0; k < 60; k++)
                {
                    Dust.NewDust(NPC.Center, NPC.width, NPC.height, 6, 2.5f * hitInfo.HitDirection, -2.5f, 0, default(Color), 0.7f);
                    Dust.NewDust(NPC.Center, NPC.width, NPC.height, 6, 2.5f * hitInfo.HitDirection, -2.5f, 0, default(Color), 0.7f);
                    Dust.NewDust(NPC.Center, NPC.width, NPC.height, 6, 2.5f * hitInfo.HitDirection, -2.5f, 0, default(Color), 0.7f);
                }
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SWGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SWGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SWGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SWGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SWGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("SWGore4").Type, 1f);
            }
            else
            {
                for (int k = 0; k < hitInfo.Damage / (float)NPC.lifeMax * 20.0f; k++)
                {
                    Dust.NewDust(NPC.Center, NPC.width, NPC.height, 226, hitInfo.HitDirection, -2f, 0, default(Color), 0.7f);
                    Dust.NewDust(NPC.Center, NPC.width, NPC.height, 27, hitInfo.HitDirection, -1f, 0, default(Color), 0.7f);
                }
            }
        }

		public override void AI()
		{

			if (NPC.AnyNPCs(Mod.Find<ModNPC>("SpaceWhaleMinion").Type))
			{
				NPC.dontTakeDamage = true;
			}
			if (!NPC.AnyNPCs(Mod.Find<ModNPC>("SpaceWhaleMinion").Type))
			{
				NPC.dontTakeDamage = false;
			}

			bool flag75 = NPC.life <= 45000;
			if (flag75)
			{
				NPC.damage = 150;
				NPC.defense = 50;
			}
			int num1076 = 60;
			float num1077 = 0.45f;
			float scaleFactor = 7.5f;
			if (NPC.ai[0] == 5f)
			{
				num1077 = 0.5f;
				scaleFactor = 8f;
			}
			int num1078 = 30;
			float scaleFactor2 = 16f;
			if (NPC.ai[0] < 4f && NPC.ai[3] < 10f)
			{
				num1076 = 30;
			}
			else if (NPC.ai[0] > 4f && NPC.ai[3] < 10f)
			{
				num1076 = 20;
				num1078 = 30;
			}
			int num1079 = 80;
			int num1080 = 4;
			float num1081 = 0.3f;
			float scaleFactor3 = 5f;
			int num1082 = 90;
			int num1083 = 180;
			int num1084 = 120;
			int num1085 = 4;
			//float scaleFactor4 = 6f;
			float scaleFactor5 = 20f;
			float num1086 = 6.28318548f / (num1084 / 2);
			int num1087 = 75;
			Vector2 vector134 = NPC.Center;
			Player player2 = Main.player[NPC.target];
			if (NPC.target < 0 || NPC.target == 255 || player2.dead || !player2.active)
			{
				NPC.TargetClosest(true);
				player2 = Main.player[NPC.target];
				NPC.netUpdate = true;
			}
			if (player2.dead || Vector2.Distance(player2.Center, vector134) > 2400f)
			{
				NPC.velocity.Y = NPC.velocity.Y - 0.4f;
				if (NPC.timeLeft > 10)
				{
					NPC.timeLeft = 10;
				}
				if (NPC.ai[0] > 4f)
				{
					NPC.ai[0] = 5f;
				}
				else
				{
					NPC.ai[0] = 0f;
				}
				NPC.ai[2] = 0f;
			}
			if (NPC.localAI[0] == 0f)
			{
				NPC.localAI[0] = 1f;
				NPC.alpha = 255;
				NPC.rotation = 0f;
				if (Main.netMode != 1)
				{
					NPC.ai[0] = -1f;
					NPC.netUpdate = true;
				}
			}
			float num1088 = (float)Math.Atan2(player2.Center.Y - vector134.Y, player2.Center.X - vector134.X);
			if (NPC.spriteDirection == 1)
			{
				num1088 += 3.14159274f;
			}
			if (num1088 < 0f)
			{
				num1088 += 6.28318548f;
			}
			if (num1088 > 6.28318548f)
			{
				num1088 -= 6.28318548f;
			}
			if (NPC.ai[0] == -1f)
			{
				num1088 = 0f;
			}
			if (NPC.ai[0] == 3f)
			{
				num1088 = 0f;
			}
			if (NPC.ai[0] == 4f)
			{
				num1088 = 0f;
			}
			if (NPC.ai[0] == 8f)
			{
				num1088 = 0f;
			}
			float num1089 = 0.04f;
			if (NPC.ai[0] == 1f || NPC.ai[0] == 6f)
			{
				num1089 = 0f;
			}
			if (NPC.ai[0] == 7f)
			{
				num1089 = 0f;
			}
			if (NPC.ai[0] == 3f)
			{
				num1089 = 0.01f;
			}
			if (NPC.ai[0] == 4f)
			{
				num1089 = 0.01f;
			}
			if (NPC.ai[0] == 8f)
			{
				num1089 = 0.01f;
			}
			if (NPC.rotation < num1088)
			{
				if (num1088 - NPC.rotation > 3.1415926535897931)
				{
					NPC.rotation -= num1089;
				}
				else
				{
					NPC.rotation += num1089;
				}
			}
			if (NPC.rotation > num1088)
			{
				if (NPC.rotation - num1088 > 3.1415926535897931)
				{
					NPC.rotation += num1089;
				}
				else
				{
					NPC.rotation -= num1089;
				}
			}
			if (NPC.rotation > num1088 - num1089 && NPC.rotation < num1088 + num1089)
			{
				NPC.rotation = num1088;
			}
			if (NPC.rotation < 0f)
			{
				NPC.rotation += 6.28318548f;
			}
			if (NPC.rotation > 6.28318548f)
			{
				NPC.rotation -= 6.28318548f;
			}
			if (NPC.rotation > num1088 - num1089 && NPC.rotation < num1088 + num1089)
			{
				NPC.rotation = num1088;
			}
			if (NPC.ai[0] != -1f)
			{
				bool flag76 = Collision.SolidCollision(NPC.position, NPC.width, NPC.height);
				if (flag76)
				{
					NPC.alpha += 15;
				}
				else
				{
					NPC.alpha -= 15;
				}
				if (NPC.alpha < 0)
				{
					NPC.alpha = 0;
				}
				if (NPC.alpha > 150)
				{
					NPC.alpha = 150;
				}
			}
			if (NPC.ai[0] == -1f)
			{
				NPC.velocity *= 0.98f;
				int num1090 = Math.Sign(player2.Center.X - vector134.X);
				if (num1090 != 0)
				{
					NPC.direction = num1090;
					NPC.spriteDirection = -NPC.direction;
				}
				if (NPC.ai[2] > 20f)
				{
					NPC.velocity.Y = -2f;
					NPC.alpha -= 5;
					bool flag77 = Collision.SolidCollision(NPC.position, NPC.width, NPC.height);
					if (flag77)
					{
						NPC.alpha += 15;
					}
					if (NPC.alpha < 0)
					{
						NPC.alpha = 0;
					}
					if (NPC.alpha > 150)
					{
						NPC.alpha = 150;
					}
				}
				if (NPC.ai[2] == num1082 - 30)
				{
					int num1091 = 36;
					for (int num1092 = 0; num1092 < num1091; num1092++)
					{
						Vector2 vector135 = Vector2.Normalize(NPC.velocity) * new Vector2(NPC.width / 2f, NPC.height) * 0.75f * 0.5f;
						vector135 = vector135.RotatedBy((num1092 - (num1091 / 2 - 1)) * 6.28318548f / num1091, default(Vector2)) + NPC.Center;
						Vector2 value2 = vector135 - NPC.Center;
						int num1093 = Dust.NewDust(vector135 + value2, 0, 0, 172, value2.X * 2f, value2.Y * 2f, 100, default(Color), 1.4f);
						Main.dust[num1093].noGravity = true;
						Main.dust[num1093].noLight = true;
						Main.dust[num1093].velocity = Vector2.Normalize(value2) * 3f;
					}
					SoundEngine.PlaySound(SoundID.Zombie96, vector134);
				}
				NPC.ai[2] += 1f;
				if (NPC.ai[2] >= num1087)
				{
					NPC.ai[0] = 0f;
					NPC.ai[1] = 0f;
					NPC.ai[2] = 0f;
					NPC.netUpdate = true;
				}
			}
			else if (NPC.ai[0] == 0f && !player2.dead)
			{
				if (NPC.ai[1] == 0f)
				{
					NPC.ai[1] = 300 * Math.Sign((vector134 - player2.Center).X);
				}
				Vector2 value3 = player2.Center + new Vector2(NPC.ai[1], -200f) - vector134;
				Vector2 vector136 = Vector2.Normalize(value3 - NPC.velocity) * scaleFactor;
				if (NPC.velocity.X < vector136.X)
				{
					NPC.velocity.X = NPC.velocity.X + num1077;
					if (NPC.velocity.X < 0f && vector136.X > 0f)
					{
						NPC.velocity.X = NPC.velocity.X + num1077;
					}
				}
				else if (NPC.velocity.X > vector136.X)
				{
					NPC.velocity.X = NPC.velocity.X - num1077;
					if (NPC.velocity.X > 0f && vector136.X < 0f)
					{
						NPC.velocity.X = NPC.velocity.X - num1077;
					}
				}
				if (NPC.velocity.Y < vector136.Y)
				{
					NPC.velocity.Y = NPC.velocity.Y + num1077;
					if (NPC.velocity.Y < 0f && vector136.Y > 0f)
					{
						NPC.velocity.Y = NPC.velocity.Y + num1077;
					}
				}
				else if (NPC.velocity.Y > vector136.Y)
				{
					NPC.velocity.Y = NPC.velocity.Y - num1077;
					if (NPC.velocity.Y > 0f && vector136.Y < 0f)
					{
						NPC.velocity.Y = NPC.velocity.Y - num1077;
					}
				}
				int num1094 = Math.Sign(player2.Center.X - vector134.X);
				if (num1094 != 0)
				{
					if (NPC.ai[2] == 0f && num1094 != NPC.direction)
					{
						NPC.rotation += 3.14159274f;
					}
					NPC.direction = num1094;
					if (NPC.spriteDirection != -NPC.direction)
					{
						NPC.rotation += 3.14159274f;
					}
					NPC.spriteDirection = -NPC.direction;
				}
				NPC.ai[2] += 1f;
				if (NPC.ai[2] >= num1076)
				{
					int num1095 = 0;
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
							num1095 = 1;
							break;
						case 10:
							NPC.ai[3] = 1f;
							num1095 = 2;
							break;
						case 11:
							NPC.ai[3] = 0f;
							num1095 = 3;
							break;
					}
					if (flag75)
					{
						num1095 = 4;
					}
					if (num1095 == 1)
					{
						NPC.ai[0] = 1f;
						NPC.ai[1] = 0f;
						NPC.ai[2] = 0f;
						NPC.velocity = Vector2.Normalize(player2.Center - vector134) * scaleFactor2;
						NPC.rotation = (float)Math.Atan2(NPC.velocity.Y, NPC.velocity.X);
						if (num1094 != 0)
						{
							NPC.direction = num1094;
							if (NPC.spriteDirection == 1)
							{
								NPC.rotation += 3.14159274f;
							}
							NPC.spriteDirection = -NPC.direction;
						}
					}
					else if (num1095 == 2)
					{
						NPC.ai[0] = 2f;
						NPC.ai[1] = 0f;
						NPC.ai[2] = 0f;
					}
					else if (num1095 == 3)
					{
						NPC.ai[0] = 3f;
						NPC.ai[1] = 0f;
						NPC.ai[2] = 0f;
					}
					else if (num1095 == 4)
					{
						NPC.ai[0] = 4f;
						NPC.ai[1] = 0f;
						NPC.ai[2] = 0f;
					}
					NPC.netUpdate = true;
				}
			}
			else if (NPC.ai[0] == 1f)
			{
				int num1096 = 7;
				for (int num1097 = 0; num1097 < num1096; num1097++)
				{
					Vector2 vector137 = Vector2.Normalize(NPC.velocity) * new Vector2((NPC.width + 50) / 2f, NPC.height) * 0.75f;
					vector137 = vector137.RotatedBy((num1097 - (num1096 / 2 - 1)) * 3.1415926535897931 / num1096, default(Vector2)) + vector134;
					Vector2 value4 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - 1.57079637f).ToRotationVector2() * Main.rand.Next(3, 8);
					int num1098 = Dust.NewDust(vector137 + value4, 0, 0, 172, value4.X * 2f, value4.Y * 2f, 100, default(Color), 1.4f);
					Main.dust[num1098].noGravity = true;
					Main.dust[num1098].noLight = true;
					Main.dust[num1098].velocity /= 4f;
					Main.dust[num1098].velocity -= NPC.velocity;
				}
				NPC.ai[2] += 1f;
				if (NPC.ai[2] >= num1078)
				{
					NPC.ai[0] = 0f;
					NPC.ai[1] = 0f;
					NPC.ai[2] = 0f;
					NPC.ai[3] += 2f;
					NPC.netUpdate = true;
				}
			}
			else if (NPC.ai[0] == 2f)
			{
				if (NPC.ai[1] == 0f)
				{
					NPC.ai[1] = 300 * Math.Sign((vector134 - player2.Center).X);
				}
				Vector2 value5 = player2.Center + new Vector2(NPC.ai[1], -200f) - vector134;
				Vector2 vector138 = Vector2.Normalize(value5 - NPC.velocity) * scaleFactor3;
				if (NPC.velocity.X < vector138.X)
				{
					NPC.velocity.X = NPC.velocity.X + num1081;
					if (NPC.velocity.X < 0f && vector138.X > 0f)
					{
						NPC.velocity.X = NPC.velocity.X + num1081;
					}
				}
				else if (NPC.velocity.X > vector138.X)
				{
					NPC.velocity.X = NPC.velocity.X - num1081;
					if (NPC.velocity.X > 0f && vector138.X < 0f)
					{
						NPC.velocity.X = NPC.velocity.X - num1081;
					}
				}
				if (NPC.velocity.Y < vector138.Y)
				{
					NPC.velocity.Y = NPC.velocity.Y + num1081;
					if (NPC.velocity.Y < 0f && vector138.Y > 0f)
					{
						NPC.velocity.Y = NPC.velocity.Y + num1081;
					}
				}
				else if (NPC.velocity.Y > vector138.Y)
				{
					NPC.velocity.Y = NPC.velocity.Y - num1081;
					if (NPC.velocity.Y > 0f && vector138.Y < 0f)
					{
						NPC.velocity.Y = NPC.velocity.Y - num1081;
					}
				}
				if (NPC.ai[2] == 0f)
				{
					SoundEngine.PlaySound(SoundID.Zombie96, vector134);
				}
                if (NPC.ai[2] % num1080 == 0f)
                {
                    // Ensure SoundID.NPCDeath19 is a string or convert it to the appropriate type
                    //SoundEngine.PlaySound(SoundID.NPCDeath19.ToString(), new EntitySource_Misc(NPC), NPC.Center);

                    if (Main.netMode != 1)
                    {
                        Vector2 vector139 = Vector2.Normalize(player2.Center - vector134) * (NPC.width + 20) / 2f + vector134;
                        NPC.NewNPC(NPC.GetSource_FromThis(), (int)vector139.X, (int)vector139.Y + 45, Mod.Find<ModNPC>("SpaceWhaleMinion").Type, 0);
                    }
                }
                int num1099 = Math.Sign(player2.Center.X - vector134.X);
				if (num1099 != 0)
				{
					NPC.direction = num1099;
					if (NPC.spriteDirection != -NPC.direction)
					{
						NPC.rotation += 3.14159274f;
					}
					NPC.spriteDirection = -NPC.direction;
				}
				NPC.ai[2] += 1f;
				if (NPC.ai[2] >= num1079)
				{
					NPC.ai[0] = 0f;
					NPC.ai[1] = 0f;
					NPC.ai[2] = 0f;
					NPC.netUpdate = true;
				}
			}
			else if (NPC.ai[0] == 3f)
			{
				NPC.velocity *= 0.98f;
				NPC.velocity.Y = MathHelper.Lerp(NPC.velocity.Y, 0f, 0.02f);
				if (NPC.ai[2] == num1082 - 30)
				{
					SoundEngine.PlaySound(SoundID.Zombie95, vector134);
				}
                if (Main.netMode != 1 && NPC.ai[2] == num1082 - 30)
                {
                    Vector2 vector140 = NPC.rotation.ToRotationVector2() * (Vector2.UnitX * NPC.direction) * (NPC.width + 20) / 2f + vector134;

                    Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(vector140.X, vector140.Y), new Vector2(NPC.direction * 2, 8f), 467, 0, 0, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(vector140.X, vector140.Y), new Vector2(NPC.direction * 3, 8f), 467, 0, 0, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(vector140.X, vector140.Y), new Vector2(NPC.direction * 4, 8f), 467, 0, 0, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(vector140.X, vector140.Y), new Vector2(NPC.direction * 5, 8f), 467, 0, 0, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(vector140.X, vector140.Y), new Vector2(NPC.direction * 6, 8f), 467, 0, 0, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(vector140.X, vector140.Y), new Vector2(NPC.direction * 7, 8f), 467, 0, 0, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(vector140.X, vector140.Y), new Vector2(NPC.direction * 8, 8f), 467, 0, 0, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(vector140.X, vector140.Y), new Vector2(NPC.direction * 9, 8f), 467, 0, 0, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(vector140.X, vector140.Y), new Vector2(-(float)NPC.direction * 2, 8f), 467, 0, 0, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(vector140.X, vector140.Y), new Vector2(-(float)NPC.direction * 3, 8f), 467, 0, 0, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(vector140.X, vector140.Y), new Vector2(-(float)NPC.direction * 4, 8f), 467, 0, 0, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(vector140.X, vector140.Y), new Vector2(-(float)NPC.direction * 5, 8f), 467, 0, 0, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(vector140.X, vector140.Y), new Vector2(-(float)NPC.direction * 6, 8f), 467, 0, 0, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(vector140.X, vector140.Y), new Vector2(-(float)NPC.direction * 7, 8f), 467, 0, 0, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(vector140.X, vector140.Y), new Vector2(-(float)NPC.direction * 8, 8f), 467, 0, 0, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(vector140.X, vector140.Y), new Vector2(-(float)NPC.direction * 9, 8f), 467, 0, 0, Main.myPlayer);
                }
                NPC.ai[2] += 1f;
				if (NPC.ai[2] >= num1082)
				{
					NPC.ai[0] = 0f;
					NPC.ai[1] = 0f;
					NPC.ai[2] = 0f;
					NPC.netUpdate = true;
				}
			}
			else if (NPC.ai[0] == 4f)
			{
				NPC.velocity *= 0.98f;
				NPC.velocity.Y = MathHelper.Lerp(NPC.velocity.Y, 0f, 0.02f);
				if (NPC.ai[2] == num1083 - 60)
				{
					SoundEngine.PlaySound(SoundID.Zombie98, vector134);
				}
				NPC.ai[2] += 1f;
				if (NPC.ai[2] >= num1083)
				{
					NPC.ai[0] = 5f;
					NPC.ai[1] = 0f;
					NPC.ai[2] = 0f;
					NPC.ai[3] = 0f;
					NPC.netUpdate = true;
				}
			}
			else if (NPC.ai[0] == 5f && !player2.dead)
			{
				if (NPC.ai[1] == 0f)
				{
					NPC.ai[1] = 300 * Math.Sign((vector134 - player2.Center).X);
				}
				Vector2 value6 = player2.Center + new Vector2(NPC.ai[1], -200f) - vector134;
				Vector2 vector141 = Vector2.Normalize(value6 - NPC.velocity) * scaleFactor;
				if (NPC.velocity.X < vector141.X)
				{
					NPC.velocity.X = NPC.velocity.X + num1077;
					if (NPC.velocity.X < 0f && vector141.X > 0f)
					{
						NPC.velocity.X = NPC.velocity.X + num1077;
					}
				}
				else if (NPC.velocity.X > vector141.X)
				{
					NPC.velocity.X = NPC.velocity.X - num1077;
					if (NPC.velocity.X > 0f && vector141.X < 0f)
					{
						NPC.velocity.X = NPC.velocity.X - num1077;
					}
				}
				if (NPC.velocity.Y < vector141.Y)
				{
					NPC.velocity.Y = NPC.velocity.Y + num1077;
					if (NPC.velocity.Y < 0f && vector141.Y > 0f)
					{
						NPC.velocity.Y = NPC.velocity.Y + num1077;
					}
				}
				else if (NPC.velocity.Y > vector141.Y)
				{
					NPC.velocity.Y = NPC.velocity.Y - num1077;
					if (NPC.velocity.Y > 0f && vector141.Y < 0f)
					{
						NPC.velocity.Y = NPC.velocity.Y - num1077;
					}
				}
				int num1100 = Math.Sign(player2.Center.X - vector134.X);
				if (num1100 != 0)
				{
					if (NPC.ai[2] == 0f && num1100 != NPC.direction)
					{
						NPC.rotation += 3.14159274f;
					}
					NPC.direction = num1100;
					if (NPC.spriteDirection != -NPC.direction)
					{
						NPC.rotation += 3.14159274f;
					}
					NPC.spriteDirection = -NPC.direction;
				}
				NPC.ai[2] += 1f;
				if (NPC.ai[2] >= num1076)
				{
					int num1101 = 0;
					switch ((int)NPC.ai[3])
					{
						case 0:
						case 1:
						case 2:
						case 3:
						case 4:
						case 5:
							num1101 = 1;
							break;
						case 6:
							NPC.ai[3] = 1f;
							num1101 = 2;
							break;
						case 7:
							NPC.ai[3] = 0f;
							num1101 = 3;
							break;
					}
					if (num1101 == 1)
					{
						NPC.ai[0] = 6f;
						NPC.ai[1] = 0f;
						NPC.ai[2] = 0f;
						NPC.velocity = Vector2.Normalize(player2.Center - vector134) * scaleFactor2;
						NPC.rotation = (float)Math.Atan2(NPC.velocity.Y, NPC.velocity.X);
						if (num1100 != 0)
						{
							NPC.direction = num1100;
							if (NPC.spriteDirection == 1)
							{
								NPC.rotation += 3.14159274f;
							}
							NPC.spriteDirection = -NPC.direction;
						}
					}
					else if (num1101 == 2)
					{
						NPC.velocity = Vector2.Normalize(player2.Center - vector134) * scaleFactor5;
						NPC.rotation = (float)Math.Atan2(NPC.velocity.Y, NPC.velocity.X);
						if (num1100 != 0)
						{
							NPC.direction = num1100;
							if (NPC.spriteDirection == 1)
							{
								NPC.rotation += 3.14159274f;
							}
							NPC.spriteDirection = -NPC.direction;
						}
						NPC.ai[0] = 7f;
						NPC.ai[1] = 0f;
						NPC.ai[2] = 0f;
					}
					else if (num1101 == 3)
					{
						NPC.ai[0] = 8f;
						NPC.ai[1] = 0f;
						NPC.ai[2] = 0f;
					}
					NPC.netUpdate = true;
				}
			}
			else if (NPC.ai[0] == 6f)
			{
				int num1102 = 7;
				for (int num1103 = 0; num1103 < num1102; num1103++)
				{
					Vector2 vector142 = Vector2.Normalize(NPC.velocity) * new Vector2((NPC.width + 50) / 2f, NPC.height) * 0.75f;
					vector142 = vector142.RotatedBy((num1103 - (num1102 / 2 - 1)) * 3.1415926535897931 / num1102, default(Vector2)) + vector134;
					Vector2 value7 = ((float)(Main.rand.NextDouble() * 3.1415927410125732) - 1.57079637f).ToRotationVector2() * Main.rand.Next(3, 8);
					int num1104 = Dust.NewDust(vector142 + value7, 0, 0, 172, value7.X * 2f, value7.Y * 2f, 100, default(Color), 1.4f);
					Main.dust[num1104].noGravity = true;
					Main.dust[num1104].noLight = true;
					Main.dust[num1104].velocity /= 4f;
					Main.dust[num1104].velocity -= NPC.velocity;
				}
				NPC.ai[2] += 1f;
				if (NPC.ai[2] >= num1078)
				{
					NPC.ai[0] = 5f;
					NPC.ai[1] = 0f;
					NPC.ai[2] = 0f;
					NPC.ai[3] += 2f;
					NPC.netUpdate = true;
				}
			}
            else if (NPC.ai[0] == 7f)
            {
                /*if (NPC.ai[2] == 0f)
                {
                    SoundEngine.PlaySound(SoundID.Zombie98, new EntitySource_Misc(NPC), vector134);
                }*/
                if (NPC.ai[2] % num1085 == 0f)
                {
                    //SoundEngine.PlaySound(SoundID.NPCDeath19, new EntitySource_Misc(NPC), NPC.Center);
                    if (Main.netMode != 1)
                    {
                        Vector2 vector143 = Vector2.Normalize(NPC.velocity) * (NPC.width + 20) / 2f + vector134;
                        int num1105 = NPC.NewNPC(NPC.GetSource_FromThis(), (int)vector143.X, (int)vector143.Y + 45, Mod.Find<ModNPC>("SpaceWhaleMinion").Type);
                        Main.npc[num1105].target = NPC.target;
                        //Main.npc[num1105].velocity = Vector2.Normalize(NPC.velocity).RotatedBy(1.57079637f * NPC.direction) * scaleFactor4;
                        Main.npc[num1105].netUpdate = true;
                        Main.npc[num1105].ai[3] = Main.rand.Next(80, 121) / 100f;
                    }
                }
                NPC.velocity = NPC.velocity.RotatedBy(-(double)num1086 * NPC.direction);
                NPC.rotation -= num1086 * NPC.direction;
                NPC.ai[2] += 1f;
                if (NPC.ai[2] >= num1084)
                {
                    NPC.ai[0] = 5f;
                    NPC.ai[1] = 0f;
                    NPC.ai[2] = 0f;
                    NPC.netUpdate = true;
                }
            }
            else if (NPC.ai[0] == 8f)
            {
                NPC.velocity *= 0.98f;
                NPC.velocity.Y = MathHelper.Lerp(NPC.velocity.Y, 0f, 0.02f);
                if (NPC.ai[2] == num1082 - 30)
                {
                    //SoundEngine.PlaySound(SoundID.Zombie94, NPC.GetSource_FromThis(), vector134);
                }
                if (Main.netMode != 1 && NPC.ai[2] == num1082 - 30)
                {
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), vector134.X, vector134.Y, 0f, 0f, Mod.Find<ModProjectile>("VulcanBladeRing").Type, 0, 0f, Main.myPlayer, 1f, NPC.target + 1);
                }
                NPC.ai[2] += 1f;
                if (NPC.ai[2] >= num1082)
                {
                    NPC.ai[0] = 5f;
                    NPC.ai[1] = 0f;
                    NPC.ai[2] = 0f;
                    NPC.netUpdate = true;
                }
            }
        }
		public override void OnKill()
		{
            TremorSpawnEnemys.downedSpaceWhale = true;
            if (Main.netMode != 1)
			{
				int CenterX = (int)(NPC.Center.X + NPC.width / 2) / 16;
				int CenterY = (int)(NPC.Center.Y + NPC.height / 2) / 16;
				int halfLength = NPC.width / 2 / 16 + 1;
			}
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            // Выпадение обычных предметов
            npcLoot.Add(ItemDropRule.Common(ItemID.PlatinumCoin, 1, 1, 7)); // 6-25 золотых монет
            npcLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 1, 25, 60)); // 6-25 серебряных монет

            // Выпадение трофея с шансом 10%
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SpaceWhaleTrophy>(), 10));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CosmicFuel>(), 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StarLantern>(), 4));

            // Выпадение маски с шансом 1/7 (14.29%) вне экспертного режима
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SpaceWhaleMask>(), 7));

            // Гарантированное выпадение одного из трёх предметов.
            npcLoot.Add(ItemDropRule.OneFromOptions(1,
                ModContent.ItemType<BlackHoleCannon>(),
                ModContent.ItemType<HornedWarHammer>(),
                ModContent.ItemType<SDL>(),
                ModContent.ItemType<WhaleFlippers>()));

            // Альтернативное использование условия:
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<SpaceWhaleTreasureBag>(), 1));
        }

    }
}