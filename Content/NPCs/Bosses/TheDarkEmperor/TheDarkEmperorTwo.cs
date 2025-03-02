using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.BossLoot.TheDarkEmperor;
using TremorMod.Content.Items.Weapons.Melee;

namespace TremorMod.Content.NPCs.Bosses.TheDarkEmperor
{
	[AutoloadBossHead]
	public class TheDarkEmperorTwo : ModNPC
	{

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("DEGore1").Type, 1f);
               // Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("DEGore2").Type, 1f); // Нету
               // Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("DEGore2").Type, 1f); 
			}
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("The Dark Emperor");
			Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.aiStyle = -1;
			NPC.lifeMax = 95000;
			NPC.damage = 180;
			NPC.defense = 220;
			AnimationType = 345;
			NPC.knockBackResist = 0f;
			NPC.width = 130;
			NPC.height = 140;
			NPC.value = Item.buyPrice(0, 20, 0, 0);
			NPC.boss = true;
			NPC.lavaImmune = true;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath10;
			Music = 17;
			NPC.buffImmune[20] = true;
			NPC.buffImmune[24] = true;
			NPC.buffImmune[39] = true;
			NPC.npcSlots = 10f;
		}

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float bossLifeScale, float balance)
        {
			NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * bossLifeScale);
			NPC.damage = (int)(NPC.damage * 0.6f);
		}

		public override void AI()
		{

			Lighting.AddLight(NPC.position, 1f, 0.3f, 0.3f);

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
			else if (NPC.ai[0] == 0f)
			{
				if (NPC.ai[2] == 0f)
				{
					NPC.TargetClosest(true);
					if (NPC.Center.X < Main.player[NPC.target].Center.X)
					{
						NPC.ai[2] = 1f;
					}
					else
					{
						NPC.ai[2] = -1f;
					}
				}
				NPC.TargetClosest(true);
				int num1319 = 800;
				float num1320 = Math.Abs(NPC.Center.X - Main.player[NPC.target].Center.X);
				if (NPC.Center.X < Main.player[NPC.target].Center.X && NPC.ai[2] < 0f && num1320 > num1319)
				{
					NPC.ai[2] = 0f;
				}
				if (NPC.Center.X > Main.player[NPC.target].Center.X && NPC.ai[2] > 0f && num1320 > num1319)
				{
					NPC.ai[2] = 0f;
				}
				float num1321 = 0.45f;
				float num1322 = 7f;
				if (NPC.life < NPC.lifeMax * 0.75)
				{
					num1321 = 0.55f;
					num1322 = 8f;
				}
				if (NPC.life < NPC.lifeMax * 0.5)
				{
					num1321 = 0.7f;
					num1322 = 10f;
				}
				if (NPC.life < NPC.lifeMax * 0.25)
				{
					num1321 = 0.8f;
					num1322 = 11f;
				}
				NPC.velocity.X = NPC.velocity.X + NPC.ai[2] * num1321;
				if (NPC.velocity.X > num1322)
				{
					NPC.velocity.X = num1322;
				}
				if (NPC.velocity.X < -num1322)
				{
					NPC.velocity.X = -num1322;
				}
				float num1323 = Main.player[NPC.target].position.Y - (NPC.position.Y + NPC.height);
				if (num1323 < 150f)
				{
					NPC.velocity.Y = NPC.velocity.Y - 0.2f;
				}
				if (num1323 > 200f)
				{
					NPC.velocity.Y = NPC.velocity.Y + 0.2f;
				}
				if (NPC.velocity.Y > 8f)
				{
					NPC.velocity.Y = 8f;
				}
				if (NPC.velocity.Y < -8f)
				{
					NPC.velocity.Y = -8f;
				}
				NPC.rotation = NPC.velocity.X * 0.05f;
				if ((num1320 < 500f || NPC.ai[3] < 0f) && NPC.position.Y < Main.player[NPC.target].position.Y)
				{
					NPC.ai[3] += 1f;
					int num1324 = 13;
					if (NPC.life < NPC.lifeMax * 0.75)
					{
						num1324 = 12;
					}
					if (NPC.life < NPC.lifeMax * 0.5)
					{
						num1324 = 11;
					}
					if (NPC.life < NPC.lifeMax * 0.25)
					{
						num1324 = 10;
					}
					num1324++;
					if (NPC.ai[3] > num1324)
					{
						NPC.ai[3] = -(float)num1324;
					}
                    if (NPC.ai[3] == 0f && Main.netMode != 1)
                    {
                        Vector2 vector159 = new Vector2(NPC.Center.X, NPC.Center.Y);
                        vector159.X += NPC.velocity.X * 7f;
                        float num1325 = Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f - vector159.X;
                        float num1326 = Main.player[NPC.target].Center.Y - vector159.Y;
                        float num1327 = (float)Math.Sqrt(num1325 * num1325 + num1326 * num1326);
                        float num1328 = 6f;
                        if (NPC.life < NPC.lifeMax * 0.75)
                        {
                            num1328 = 7f;
                        }
                        if (NPC.life < NPC.lifeMax * 0.5)
                        {
                            num1328 = 8f;
                        }
                        if (NPC.life < NPC.lifeMax * 0.25)
                        {
                            num1328 = 9f;
                        }
                        num1327 = num1328 / num1327;
                        num1325 *= num1327;
                        num1326 *= num1327;
                        Projectile.NewProjectile(NPC.GetSource_FromAI(), vector159.X, vector159.Y, num1325, num1326, ModContent.ProjectileType<FallingDarkServant>(), 54, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
                else if (NPC.ai[3] < 0f)
				{
					NPC.ai[3] += 1f;
				}
				if (Main.netMode != 1)
				{
					NPC.ai[1] += Main.rand.Next(1, 4);
					if (NPC.ai[1] > 800f && num1320 < 600f)
					{
						NPC.ai[0] = -1f;
					}
				}
			}
			else if (NPC.ai[0] == 1f)
			{
				NPC.TargetClosest(true);
				float num1329 = 0.15f;
				float num1330 = 7f;
				if (NPC.life < NPC.lifeMax * 0.75)
				{
					num1329 = 0.17f;
					num1330 = 8f;
				}
				if (NPC.life < NPC.lifeMax * 0.5)
				{
					num1329 = 0.2f;
					num1330 = 9f;
				}
				if (NPC.life < NPC.lifeMax * 0.25)
				{
					num1329 = 0.25f;
					num1330 = 10f;
				}
				num1329 -= 0.05f;
				num1330 -= 1f;
				if (NPC.Center.X < Main.player[NPC.target].Center.X)
				{
					NPC.velocity.X = NPC.velocity.X + num1329;
					if (NPC.velocity.X < 0f)
					{
						NPC.velocity.X = NPC.velocity.X * 0.98f;
					}
				}
				if (NPC.Center.X > Main.player[NPC.target].Center.X)
				{
					NPC.velocity.X = NPC.velocity.X - num1329;
					if (NPC.velocity.X > 0f)
					{
						NPC.velocity.X = NPC.velocity.X * 0.98f;
					}
				}
				if (NPC.velocity.X > num1330 || NPC.velocity.X < -num1330)
				{
					NPC.velocity.X = NPC.velocity.X * 0.95f;
				}
				float num1331 = Main.player[NPC.target].position.Y - (NPC.position.Y + NPC.height);
				if (num1331 < 180f)
				{
					NPC.velocity.Y = NPC.velocity.Y - 0.1f;
				}
				if (num1331 > 200f)
				{
					NPC.velocity.Y = NPC.velocity.Y + 0.1f;
				}
				if (NPC.velocity.Y > 6f)
				{
					NPC.velocity.Y = 6f;
				}
				if (NPC.velocity.Y < -6f)
				{
					NPC.velocity.Y = -6f;
				}
				NPC.rotation = NPC.velocity.X * 0.01f;
				if (Main.netMode != 1)
				{
					NPC.ai[3] += 1f;
					int num1332 = 15;
					if (NPC.life < NPC.lifeMax * 0.75)
					{
						num1332 = 14;
					}
					if (NPC.life < NPC.lifeMax * 0.5)
					{
						num1332 = 12;
					}
					if (NPC.life < NPC.lifeMax * 0.25)
					{
						num1332 = 10;
					}
					if (NPC.life < NPC.lifeMax * 0.1)
					{
						num1332 = 8;
					}
					num1332 += 3;
                    if (NPC.ai[3] >= num1332)
                    {
                        NPC.ai[3] = 0f;
                        Vector2 vector160 = new Vector2(NPC.Center.X, NPC.position.Y + NPC.height - 14f);
                        int i2 = (int)(vector160.X / 16f);
                        int j2 = (int)(vector160.Y / 16f);
                        if (!WorldGen.SolidTile(i2, j2))
                        {
                            float num1333 = NPC.velocity.Y;
                            if (num1333 < 0f)
                            {
                                num1333 = 0f;
                            }
                            num1333 += 3f;
                            float speedX2 = NPC.velocity.X * 0.25f;
                            Projectile.NewProjectile(NPC.GetSource_FromAI(), vector160.X, vector160.Y, speedX2, num1333, ModContent.ProjectileType<FallingDarkSlime>(), 34, 0f, Main.myPlayer, Main.rand.Next(5), 0f);
                        }
                    }
                }
                if (Main.netMode != 1)
				{
					NPC.ai[1] += Main.rand.Next(1, 4);
					if (NPC.ai[1] > 600f)
					{
						NPC.ai[0] = -1f;
					}
				}
			}
            else if (NPC.ai[0] == 2f)
            {
                NPC.TargetClosest(true);
                Vector2 vector161 = new Vector2(NPC.Center.X, NPC.Center.Y - 20f);
                float num1334 = Main.rand.Next(-1000, 1001);
                float num1335 = Main.rand.Next(-1000, 1001);
                float num1336 = (float)Math.Sqrt(num1334 * num1334 + num1335 * num1335);
                float num1337 = 15f;
                NPC.velocity *= 0.95f;
                num1336 = num1337 / num1336;
                num1334 *= num1336;
                num1335 *= num1336;
                NPC.rotation += 0.2f;
                vector161.X += num1334 * 4f;
                vector161.Y += num1335 * 4f;
                NPC.ai[3] += 1f;
                int num1338 = 7;
                if (NPC.life < NPC.lifeMax * 0.75)
                {
                    num1338--;
                }
                if (NPC.life < NPC.lifeMax * 0.5)
                {
                    num1338 -= 2;
                }
                if (NPC.life < NPC.lifeMax * 0.25)
                {
                    num1338 -= 3;
                }
                if (NPC.life < NPC.lifeMax * 0.1)
                {
                    num1338 -= 4;
                }
                if (NPC.ai[3] > num1338)
                {
                    NPC.ai[3] = 0f;

                    // Corrected call to Projectile.NewProjectile
                    Projectile.NewProjectile(NPC.GetSource_FromAI(), vector161.X, vector161.Y, num1334, num1335, ModContent.ProjectileType<DarkBubblePro>(), 40, 0f, Main.myPlayer, 0f, 0f);
                }
                if (Main.netMode != 1)
                {
                    NPC.ai[1] += Main.rand.Next(1, 4);
                    if (NPC.ai[1] > 500f)
                    {
                        NPC.ai[0] = -1f;
                    }
                }
            }
            if (NPC.ai[0] == -1f)
			{
				int num1339 = Main.rand.Next(3);
				NPC.TargetClosest(true);
				if (Math.Abs(NPC.Center.X - Main.player[NPC.target].Center.X) > 1000f)
				{
					num1339 = 0;
				}
				NPC.ai[0] = num1339;
				NPC.ai[1] = 0f;
				NPC.ai[2] = 0f;
				NPC.ai[3] = 0f;
			}

		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {

            // Выпадение маски с шансом 1/4 (25%) вне экспертного режима
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<DarkEmperorMask>(), 4));

            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<DarkEmperorTrophy>(), 4));

            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<DrippingScythe>(), 10));

            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<DelightfulClump>(), 4));

            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<NastyJavelin>(), 1, 30, 50));

            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<DarkGel>(), 1, 50, 100));

            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<SoulofFight>(), 1, 20, 30));


            // Добавление предмета для экспертного режима с 100% шансом.
            //npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CyberKingBag>(), 1)); // 100% шанс выпадения

            // Альтернативное использование условия:
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<DarkEmperorBag>(), 1));
        }

        /*public override void OnKill()
		{
			if (Main.expertMode)
			{
				NPC.DropBossBags();
			}

			if (Main.netMode != 1)
			{
				int centerX = (int)(NPC.position.X + NPC.width / 2) / 16;
				int centerY = (int)(NPC.position.Y + NPC.height / 2) / 16;
				int halfLength = NPC.width / 2 / 16 + 1;

				if (!Main.expertMode && Main.rand.NextBool(7))
				{
					Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, Mod.Find<ModItem>("DarkEmperorMask").Type);
				}
				if (Main.rand.Next(10) == 0)
				{
					Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, Mod.Find<ModItem>("DarkEmperorTrophy").Type);
				}
				if (!Main.expertMode && Main.rand.NextBool(5))
				{
					Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, Mod.Find<ModItem>("DrippingScythe").Type);
				}
				if (!Main.expertMode && Main.rand.NextBool(5))
				{
					Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, Mod.Find<ModItem>("DelightfulClump").Type);
				}
				if (!Main.expertMode && Main.rand.NextBool())
				{
					Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, Mod.Find<ModItem>("NastyJavelin").Type, Main.rand.Next(30, 50));
				}
				if (!Main.expertMode && Main.rand.NextBool())
				{
					Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, Mod.Find<ModItem>("DarkGel").Type, Main.rand.Next(50, 100));
				}
				if (!Main.expertMode && Main.rand.NextBool())
				{
					Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, Mod.Find<ModItem>("SoulofFight").Type, Main.rand.Next(20, 30));
				}
				TremorWorld.Boss.DarkEmperor.Downed();
			}
		}*/
    }
}