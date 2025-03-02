using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Bag;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Placeable;

namespace TremorMod.Content.NPCs.Bosses.FrostKing
{
	[AutoloadBossHead]
	public class FrostKing : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Frost King");
			Main.npcFrameCount[NPC.type] = 8;
		}

		private float timeToNextFrame;
		private int frame;

		public override void SetDefaults()
		{
			NPC.aiStyle = -1;
			NPC.lifeMax = 60000;
			NPC.damage = 78;
			NPC.defense = 65;
			NPC.knockBackResist = 0f;
			NPC.width = 252;
			NPC.height = 254;
			NPC.value = Item.buyPrice(0, 0, 15, 0);
			NPC.npcSlots = 1;
			NPC.boss = true;
			NPC.lavaImmune = true;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit41;
			NPC.DeathSound = SoundID.NPCDeath44;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("FrostKingGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("FrostKingGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("FrostKingGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("FrostKingGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("FrostKingGore4").Type, 1f);
			}
		}

		private float timeToAtack = 2;
		//private float vel = 2.5f;
		private float lifeTime;
		private int minTimeToAtack = 3;
		private int maxTimeToAtack = 5;
		private Vector2 localTargPos = new Vector2(666, 666);
		private int mode;
		private float atackTimer;
		private float atackLenghtTimer;
		private float preAtack;

		public Vector2 bossCenter
		{
			get { return NPC.Center; }
			set { NPC.position = value - new Vector2(NPC.width / 2, NPC.height / 2); }
		}

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float bossLifeScale, float balance)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.6f);
        }

        private void findNewLocalTargetPos()
		{
			float a = Main.rand.Next(0, (int)(Math.PI) * 200) / 100f;
			float r = Main.rand.Next(0, 5000) / 100f;
			localTargPos = new Vector2((float)Math.Cos(a) * r, (float)Math.Sin(a) * r);
		}

		public override void AI()
		{
			bool allDead = false;
			for (int i = 0; i < Main.player.Length; i++)
			{
				if (Main.player[i].dead) allDead = true;
			}

			if (allDead)
			{
				if (NPC.velocity.X > 0f)
				{
					NPC.velocity.X = NPC.velocity.X + 0.75f;
				}
				else
				{
					NPC.velocity.X = NPC.velocity.X - 0.75f;
				}
				NPC.velocity.Y = NPC.velocity.Y - 0.1f;
				NPC.rotation = NPC.velocity.X * 0.05f;
			}

			lifeTime += 0.016f;
			Player player = Main.player[NPC.target];
			Vector2 targetPos = player.Center + localTargPos;
			if (localTargPos == new Vector2(666, 666) || Vector2.Distance(bossCenter, targetPos) < 5)
			{
				findNewLocalTargetPos();
			}
			Lighting.AddLight(bossCenter, 0.8f, 0.8f, 1f);
			if (mode == 0)
			{
				bossCenter = Vector2.Lerp(bossCenter, targetPos, 0.01f);
			}
			else if (mode == 1)
			{
				bossCenter = Vector2.Lerp(bossCenter, targetPos, 0.005f);
				if (preAtack > 0)
				{
					preAtack -= 0.016f;
				}
				else
				{
					if (atackLenghtTimer > 0)
					{
						atackLenghtTimer -= 0.016f;
						if (atackTimer > 0)
						{
							atackTimer -= 0.016f;
						}
						else
						{
                            for (int i = 0; i < 30; i++)
                            {
                                float angle = Main.rand.Next(0, (int)(Math.PI) * 200) / 100f;
                                Vector2 velocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 25;

                                IEntitySource source = Main.player[Main.myPlayer].GetSource_FromThis();
                                Vector2 position = new Vector2(bossCenter.X - 90, bossCenter.Y + 7);

                                Projectile.NewProjectile(source, position, velocity, 349, 20, 5);
                            }
                        }
                    }
					else
					{
						mode = 0;
					}
				}
			}
			else if (mode == 2)
			{
				bossCenter = Vector2.Lerp(bossCenter, targetPos, 0.005f);
				if (preAtack > 0)
				{
					preAtack -= 0.016f;
				}
				else
				{
					if (atackLenghtTimer > 0)
					{
						atackLenghtTimer -= 0.016f;
						if (atackTimer > 0)
						{
							atackTimer -= 0.016f;
						}
						else
						{
                            Vector2 shootPos = bossCenter + new Vector2(88, 32);
                            float angle = (float)Math.Atan2(targetPos.Y - shootPos.Y, targetPos.X - shootPos.X)
                                          + Main.rand.Next((int)(Math.PI * -100f), (int)(Math.PI * 100f)) / 3600f;
                            Vector2 velocity = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 20;
                            IEntitySource source = Main.player[Main.myPlayer].GetSource_FromThis();
                            Projectile.NewProjectile(source, shootPos, velocity, 348, 40, 5);
                            atackTimer = 1;

                        }
                    }
					else
					{
						mode = 0;
					}
				}
			}
			else
			{
				bossCenter = Vector2.Lerp(bossCenter, targetPos, 0.005f);
				if (preAtack > 0)
				{
					preAtack -= 0.016f;
				}
				else
				{
					if (atackLenghtTimer > 0)
					{
						atackLenghtTimer -= 0.016f;
						if (atackTimer > 0)
						{
							atackTimer -= 0.016f;
						}
						else
						{
                            Vector2 shootPos = bossCenter + new Vector2(-90, 25);
                            IEntitySource source = Main.player[Main.myPlayer].GetSource_FromThis(); // Источник снаряда

                            Projectile.NewProjectile(source, shootPos, new Vector2(-20, 0), 464, 40, 5);

                            shootPos = bossCenter + new Vector2(90, 25);
                            Projectile.NewProjectile(source, shootPos, new Vector2(20, 0), 464, 40, 5);

                            atackTimer = 3;

                        }
                    }
					else
					{
						mode = 0;
					}
				}
			}
			if (timeToNextFrame > 0)
			{
				timeToNextFrame -= 0.016f;
			}
			else
			{
				if (mode == 0)
				{
					timeToNextFrame = 0.1f;
					if (frame < 4)
					{
						frame++;
					}
					else
					{
						frame = 0;
					}
				}
				else
				{
					frame = 4 + mode;
				}
			}
			if (timeToAtack > 0)
			{
				timeToAtack -= 0.016f;
			}
			else
			{
				Shoot(player, Main.rand.Next(0, 3));
			}
			if (Vector2.Distance(targetPos, bossCenter) > 10000 && Main.dayTime)
			{
				NPC.active = false;
			}
		}

		private void Shoot(Player player, int type)
		{
			mode = type + 1;
			if (type == 0)
			{
				timeToAtack = Main.rand.Next(5 + minTimeToAtack, 5 + maxTimeToAtack + 1);
				atackLenghtTimer = 5;
			}
			else if (type == 1)
			{
				timeToAtack = Main.rand.Next(5 + minTimeToAtack, 5 + maxTimeToAtack + 1);
				atackLenghtTimer = 5;
			}
			else
			{
				timeToAtack = Main.rand.Next(7 + minTimeToAtack, 9 + maxTimeToAtack + 1);
				atackLenghtTimer = 7;
			}
			preAtack = 0.5f;
		}

		private float clamp(float value, float min, float max)
		{
			if (value < min)
			{
				return min;
			}
			if (value > max)
			{
				return max;
			}
			return value;
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frame.Y = frameHeight * frame + 2;
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FrostKingTrophy>(), 10));

            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<FrostKingMask>(), 7));

            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<FrostoneOre>(), 1, 24, 42));

            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<FrostKingBag>(), 1));
        }
    }
}
