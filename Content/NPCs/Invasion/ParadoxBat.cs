using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Dusts;
using TremorMod.Content.Event;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.NPCs.Invasion.ParadoxTitan;
using TremorMod.Content.Items.Accessories;

namespace TremorMod.Content.NPCs.Invasion
{
	public class ParadoxBat : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Paradox Bat");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 750;
			NPC.damage = 105;
			NPC.defense = 35;
			NPC.knockBackResist = 0f;
			NPC.width = 34;
			NPC.height = 20;
			AnimationType = 75;
			NPC.aiStyle = -1;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit55;
			NPC.noGravity = true;
			NPC.DeathSound = SoundID.NPCDeath44;
			NPC.color = Color.White;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>();
			//float spawn = 20f;
			if (InvasionWorld.CyberWrath)
				return 1000f;
			//return 0f;

			int x = spawnInfo.SpawnTileX;
			int y = spawnInfo.SpawnTileY;
			int tile = Main.tile[x, y].TileType;
			return InvasionWorld.CyberWrath && y > Main.worldSurface ? 1f : 0f;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 10; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<CyberDust>(), 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}

				CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>();
				if (InvasionWorld.CyberWrath && Main.rand.NextBool(2))
				{
					InvasionWorld.CyberWrathPoints1 += 1;
					//Main.NewText(("Wave 1: Complete " + TremorWorld.CyberWrathPoints + "%"), 39, 86, 134);
				}
			}

			for (int k = 0; k < hit.Damage / NPC.lifeMax * 50.0; k++)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<CyberDust>(), hitDirection, -1f, 0, default(Color), 0.7f);
			}
		}

		//int TimeToAnimation = 6;
		//int AnimationRate = 6;
		//int FrameCount = 4;
		//float DistortPercent = 0.15f;
		//int Frame = 0;

		/*void PlayAnimation()
        {
            if (--TimeToAnimation <= 0)
            {
                TimeToAnimation = (int)Helper.DistortFloat(AnimationRate, DistortPercent);
                if (++Frame >= FrameCount)
                    Frame = 0;
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            SpriteEffects Direction = (npc.target == -1) ? SpriteEffects.None : ((Main.player[npc.target].position.X < npc.position.X) ? SpriteEffects.None : SpriteEffects.FlipHorizontally);
            spriteBatch.Draw(Main.npcTexture[npc.type], new Rectangle((int)(npc.position.X - Main.screenPosition.X), (int)(npc.position.Y - Main.screenPosition.Y), npc.width, npc.height), new Rectangle(0, Frame * npc.height, npc.width, npc.height), drawColor, 0, new Vector2(0, 0), Direction, 0);
            return false;
        }  */

		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */
		{
			NPC.lifeMax = NPC.lifeMax * 1;
			NPC.damage = NPC.damage * 1;
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            if (Main.netMode != 1)
            {
                int centerX = (int)(NPC.position.X + NPC.width / 2) / 16;
                int centerY = (int)(NPC.position.Y + NPC.height / 2) / 16;
                int halfLength = NPC.width / 2 / 16 + 1;
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ParadoxElement>(), 1, 3, 5));
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<SecondHand>(), 50));
            }
        }

        float customAi1;
		bool FirstState;
		bool SecondState;
		public override void AI()
		{
			//PlayAnimation();
			if (NPC.life > NPC.lifeMax / 2)
			{
				FirstState = true;
			}

			if (NPC.life < NPC.lifeMax / 2)
			{
				FirstState = false;
				SecondState = true;
			}

			if (Main.rand.Next(150) == 0)
			{
				for (int num36 = 0; num36 < 25; num36++)
				{
					int dust = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, ModContent.DustType<CyberDust>(), NPC.velocity.X + Main.rand.Next(-10, 10), NPC.velocity.Y + Main.rand.Next(-10, 10), 1, NPC.color, 1f);
					Main.dust[dust].noGravity = true;
				}

				NPC.ai[3] = (float)(Main.rand.Next(360) * (Math.PI / 180));
				NPC.ai[2] = 0;
				NPC.ai[1] = 0;
				if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
				{
					NPC.TargetClosest(true);
				}
				if (Main.player[NPC.target].dead)
				{
					NPC.position.X = 0;
					NPC.position.Y = 0;
					if (NPC.timeLeft > 10)
					{
						NPC.timeLeft = 10;
						return;
					}
				}
				else
				{
					NPC.position.X = Main.player[NPC.target].position.X + (float)((250 * Math.Cos(NPC.ai[3])) * -1);
					NPC.position.Y = Main.player[NPC.target].position.Y + (float)((250 * Math.Sin(NPC.ai[3])) * -1);
				}
			}
			if (Main.rand.NextBool(2))
			{
				int num706 = Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<CyberDust>(), 0f, 0f, 200, NPC.color, 0.5f);
				Main.dust[num706].velocity *= 0.6f;
			}
			if (FirstState)
			{
				NPC.TargetClosest(true);
				Vector2 PTC = Main.player[NPC.target].position + new Vector2(NPC.width / 2, NPC.height / 2);
				Vector2 NPos = NPC.position + new Vector2(NPC.width / 2, NPC.height / 2);
				NPC.netUpdate = true;

				if (NPC.ai[1] == 0)
				{
					if (Main.player[NPC.target].position.X < NPC.position.X)
					{
						if (NPC.velocity.X > -8) NPC.velocity.X -= 0.10f;
					}

					if (Main.player[NPC.target].position.X > NPC.position.X)
					{
						if (NPC.velocity.X < 8) NPC.velocity.X += 0.10f;
					}

					if (Main.player[NPC.target].position.Y < NPC.position.Y + 200)
					{
						if (NPC.velocity.Y < 0)
						{
							if (NPC.velocity.Y > -4) NPC.velocity.Y -= 0.4f;
						}
						else NPC.velocity.Y -= 0.8f;
					}

					if (Main.player[NPC.target].position.Y > NPC.position.Y + 200)
					{
						if (NPC.velocity.Y > 0)
						{
							if (NPC.velocity.Y < 4) NPC.velocity.Y += 0.4f;
						}
						else NPC.velocity.Y += 0.6f;
					}
				}

				customAi1 += (Main.rand.Next(2, 5) * 0.1f) * NPC.scale;
				if (customAi1 >= 4f)
					if (Main.rand.Next(120) == 1)
					{
						SoundEngine.PlaySound(SoundID.DoubleJump, NPC.position);
						float Angle = (float)Math.Atan2(NPos.Y - PTC.Y, NPos.X - PTC.X);
						int SpitShot1 = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPos.X, NPos.Y, (float)((Math.Cos(Angle) * 22f) * -1), (float)((Math.Sin(Angle) * 22f) * -1), ModContent.ProjectileType<CyberLaserBat>(), 30, 0f, 0);
						//Main.projectile[SpitShot1].friendly = false;
						Main.projectile[SpitShot1].timeLeft = 500;
						customAi1 = 1f;
					}
				NPC.netUpdate = true;

				if (Main.rand.NextBool(6))
				{
					int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<CyberDust>(), 0f, 0f, 200, NPC.color, 0.4f);
					Main.dust[dust].velocity *= 0.4f;
				}

				if (NPC.ai[1] == 1)
				{

				}

				NPC.ai[2] += 1;
				if (NPC.ai[2] >= 600)
				{
					if (NPC.ai[1] == 0) NPC.ai[1] = 1;
					else NPC.ai[1] = 0;
				}
				if (NPC.life > 500)
				{
					Color color = new Color();
					int dust = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, ModContent.DustType<CyberDust>(), NPC.velocity.X, NPC.velocity.Y, 100, color, 0.6f);
					Main.dust[dust].noGravity = true;
				}
				else if (NPC.life <= 200)
				{
					Color color = new Color();
					int dust = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, ModContent.DustType<CyberDust>(), NPC.velocity.X, NPC.velocity.Y, 50, color, 0.8f);
					Main.dust[dust].noGravity = true;
				}
			}

			if (SecondState && !FirstState)
			{
				Vector2 PTC = Main.player[NPC.target].position + new Vector2(NPC.width / 2, NPC.height / 2);
				Vector2 NPos = NPC.position + new Vector2(NPC.width / 2, NPC.height / 2);
				if (Main.rand.Next(70) == 1)
				{
					SoundEngine.PlaySound(SoundID.DoubleJump, NPC.position);
					float Angle = (float)Math.Atan2(NPos.Y - PTC.Y, NPos.X - PTC.X);
					int SpitShot1 = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPos.X, NPos.Y, (float)((Math.Cos(Angle) * 22f) * -1), (float)((Math.Sin(Angle) * 22f) * -1), ModContent.ProjectileType<CyberLaserBat>(), 30, 0f, 0);
					//Main.projectile[SpitShot1].friendly = false;
					Main.projectile[SpitShot1].timeLeft = 500;
					customAi1 = 1f;
				}
				float npc_to_target_x = NPC.position.X + NPC.width / 2 - Main.player[NPC.target].position.X - Main.player[NPC.target].width / 2;
				float npc_to_target_y = NPC.position.Y + NPC.height - 59f - Main.player[NPC.target].position.Y - Main.player[NPC.target].height / 2; // 59(3.7 blocks) above bottom(slightly above center; ht is 110) to target center
				float npc_to_target_angle = (float)Math.Atan2(npc_to_target_y, npc_to_target_x) + 1.57f; // angle+pi/2
				if (npc_to_target_angle < 0f) // modulus
					npc_to_target_angle += 6.283f;
				else if (npc_to_target_angle > 6.283)
					npc_to_target_angle -= 6.283f;
				//float rotation_rate = 0.15f;
				float top_speed = 4f;
				float accel = 0.1f;
				int close_side_of_target = 1;
				if (NPC.position.X + NPC.width / 2 < Main.player[NPC.target].position.X + Main.player[NPC.target].width)
					close_side_of_target = -1;

				Vector2 npc_pos = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
				npc_to_target_x = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 + close_side_of_target * 360 - npc_pos.X;
				npc_to_target_y = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 + close_side_of_target * 160 - npc_pos.Y;
				float dist_to_target = (float)Math.Sqrt(npc_to_target_x * npc_to_target_x + npc_to_target_y * npc_to_target_y);
				dist_to_target = top_speed / dist_to_target;
				npc_to_target_x *= dist_to_target;
				npc_to_target_y *= dist_to_target;

				if (NPC.velocity.X < npc_to_target_x)
				{
					NPC.velocity.X = NPC.velocity.X + accel;
					if (NPC.velocity.X < 0f && npc_to_target_x > 0f)
						NPC.velocity.X = NPC.velocity.X + accel;
				}
				else if (NPC.velocity.X > npc_to_target_x)
				{
					NPC.velocity.X = NPC.velocity.X - accel;
					if (NPC.velocity.X > 0f && npc_to_target_x < 0f)
						NPC.velocity.X = NPC.velocity.X - accel;
				}
				if (NPC.velocity.Y < npc_to_target_y)
				{
					NPC.velocity.Y = NPC.velocity.Y + accel;
					if (NPC.velocity.Y < 0f && npc_to_target_y > 0f)
						NPC.velocity.Y = NPC.velocity.Y + accel;
				}
				else if (NPC.velocity.Y > npc_to_target_y)
				{
					NPC.velocity.Y = NPC.velocity.Y - accel;
					if (NPC.velocity.Y > 0f && npc_to_target_y < 0f)
						NPC.velocity.Y = NPC.velocity.Y - accel;
				}

				bool target_dead = Main.player[NPC.target].dead;
				if (target_dead)
				{
					NPC.velocity.Y = NPC.velocity.Y - 0.04f;
					if (NPC.timeLeft > 10)
					{
						NPC.timeLeft = 10;
					}
				}
				else
				{
					if (NPC.ai[1] == 0f)
					{
						top_speed = 4f;
						accel = 0.1f;
						close_side_of_target = 1;
						if (NPC.position.X + NPC.width / 2 < Main.player[NPC.target].position.X + Main.player[NPC.target].width)
							close_side_of_target = -1;

						npc_pos = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
						npc_to_target_x = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 + close_side_of_target * 360 - npc_pos.X; //360 pix in front of target
						npc_to_target_y = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 + close_side_of_target * 160 - npc_pos.Y; //160 pix above target
						dist_to_target = (float)Math.Sqrt(npc_to_target_x * npc_to_target_x + npc_to_target_y * npc_to_target_y);
						dist_to_target = top_speed / dist_to_target;
						npc_to_target_x *= dist_to_target;
						npc_to_target_y *= dist_to_target;

						if (NPC.velocity.X < npc_to_target_x)
						{
							NPC.velocity.X = NPC.velocity.X + accel;
							if (NPC.velocity.X < 0f && npc_to_target_x > 0f)
								NPC.velocity.X = NPC.velocity.X + accel;
						}
						else if (NPC.velocity.X > npc_to_target_x)
						{
							NPC.velocity.X = NPC.velocity.X - accel;
							if (NPC.velocity.X > 0f && npc_to_target_x < 0f)
								NPC.velocity.X = NPC.velocity.X - accel;
						}
						if (NPC.velocity.Y < npc_to_target_y)
						{
							NPC.velocity.Y = NPC.velocity.Y + accel;
							if (NPC.velocity.Y < 0f && npc_to_target_y > 0f)
								NPC.velocity.Y = NPC.velocity.Y + accel;
						}
						else if (NPC.velocity.Y > npc_to_target_y)
						{
							NPC.velocity.Y = NPC.velocity.Y - accel;
							if (NPC.velocity.Y > 0f && npc_to_target_y < 0f)
								NPC.velocity.Y = NPC.velocity.Y - accel;
						}

						NPC.ai[2] += 1f; // inc count till charge
						if (NPC.ai[2] >= 400f) // charge after 400 ticks
						{
							NPC.ai[1] = 1f; // transition state to 'start charge'
							NPC.ai[2] = 0f;
							NPC.ai[3] = 0f;
							NPC.target = 255; // retarget
							NPC.netUpdate = true;
						}
						if (Collision.CanHit(NPC.position, NPC.width, NPC.height, Main.player[NPC.target].position, Main.player[NPC.target].width, Main.player[NPC.target].height))
						{
							NPC.localAI[2] += 1f; // ???
							if (Main.netMode != 1) // is server
							{ // localAI[1] grows faster the less life left
								NPC.localAI[1] += 1f;

								if (NPC.localAI[1] > 12f)
								{
									NPC.localAI[1] = 10f;
									float projectile_velocity = 15f;
									//int projectile_dmg = 75;
									npc_pos = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
									npc_to_target_x = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - npc_pos.X;
									npc_to_target_y = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - npc_pos.Y;
									dist_to_target = (float)Math.Sqrt(npc_to_target_x * npc_to_target_x + npc_to_target_y * npc_to_target_y);
									dist_to_target = projectile_velocity / dist_to_target; // prep to normalize by velocity
									npc_to_target_x *= dist_to_target; // normalize by velocity
									npc_to_target_y *= dist_to_target; // normalize by velocity
									npc_to_target_y += NPC.velocity.Y * 0.5f; // advance fwd half a tick
									npc_to_target_x += NPC.velocity.X * 0.5f; // advance fwd half a tick
									npc_pos.X -= npc_to_target_x * 1f;
									npc_pos.Y -= npc_to_target_y * 1f;
									//Projectile.NewProjectile(npc_pos.X, npc_pos.Y, npc_to_target_x, npc_to_target_y, ProjDef.byName["Pumpking:TerraGuardLaser"].type, projectile_dmg, 0f, Main.myPlayer);
								}
							}
						}
					}
					else if (NPC.ai[1] == 1f)
					{
						NPC.rotation = npc_to_target_angle;
						float speed = 14f;
						npc_pos = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
						npc_to_target_x = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - npc_pos.X;
						npc_to_target_y = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - npc_pos.Y;
						dist_to_target = (float)Math.Sqrt(npc_to_target_x * npc_to_target_x + npc_to_target_y * npc_to_target_y);
						dist_to_target = speed / dist_to_target;
						NPC.velocity.X = npc_to_target_x * dist_to_target;
						NPC.velocity.Y = npc_to_target_y * dist_to_target;
						NPC.ai[1] = 2f;
					}
					else if (NPC.ai[1] == 2f)
					{
						NPC.ai[2] += 1f;
						if (NPC.ai[2] >= 50f)
						{
							NPC.velocity.X = NPC.velocity.X * 0.93f;
							NPC.velocity.Y = NPC.velocity.Y * 0.93f;
							if (NPC.velocity.X > -0.1 && NPC.velocity.X < 0.1)
								NPC.velocity.X = 0f;
							if (NPC.velocity.Y > -0.1 && NPC.velocity.Y < 0.1)
								NPC.velocity.Y = 0f;
						}
						else
							NPC.rotation = (float)Math.Atan2(NPC.velocity.Y, NPC.velocity.X) - 1.57f;

						if (NPC.ai[2] >= 80f)
						{
							NPC.ai[3] += 1f;
							NPC.ai[2] = 0f;
							NPC.target = 255;
							NPC.rotation = npc_to_target_angle;
							if (NPC.ai[3] >= 6f)
							{
								NPC.ai[1] = 0f;
								NPC.ai[3] = 0f;
								return;
							}
							NPC.ai[1] = 1f;
						}
					}
				}
			}
		}
	}
}