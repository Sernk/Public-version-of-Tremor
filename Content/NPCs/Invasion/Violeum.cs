using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Dusts;
using TremorMod.Content.Event;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Weapons.Melee;

namespace TremorMod.Content.NPCs.Invasion
{
	public class Violeum : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Violeum");
			Main.npcFrameCount[NPC.type] = 4;
		}

		Vector2 Hands = new Vector2(-1, -1);
		public override void SetDefaults()
		{
			NPC.lifeMax = 18000;
			NPC.width = 78;
			NPC.height = 88;
			AnimationType = 82;
			NPC.damage = 250;
			NPC.defense = 70;
			NPC.knockBackResist = 0f;
			NPC.width = 70;
			NPC.height = 86;
			NPC.aiStyle = 14;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit35;
			NPC.noGravity = true;
			NPC.DeathSound = SoundID.NPCDeath57;
			NPC.color = Color.White;
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            if (Main.netMode != 1)
            {
                int centerX = (int)(NPC.position.X + NPC.width / 2) / 16;
                int centerY = (int)(NPC.position.Y + NPC.height / 2) / 16;
                int halfLength = NPC.width / 2 / 16 + 1;
                if (!Main.expertMode)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<VioleumMask>(), 7));
                }
                if (!Main.expertMode)
                {
                    npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<Crystyle>(), 5));
                }
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ItemID.HealingPotion, 1, 7, 20));
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<TimeTissue>(), 1, 5, 15));
                Main.NewText("Violeum has been defeated!", 39, 86, 134);
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>();
			int x = spawnInfo.SpawnTileX;
			int y = spawnInfo.SpawnTileY;
			int tile = Main.tile[x, y].TileType;
			return InvasionWorld.CyberWrath && y > Main.worldSurface ? 0.5f : 0f;
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
				if (InvasionWorld.CyberWrath && InvasionWorld.CyberWrathPoints1 < 85)
				{
					InvasionWorld.CyberWrathPoints1 += 15;
					//Main.NewText(("Wave 1: Complete " + TremorWorld.CyberWrathPoints + "%"), 39, 86, 134);
				}
			}

			for (int k = 0; k < hit.Damage / NPC.lifeMax * 50.0; k++)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<CyberDust>(), hitDirection, -1f, 0, default(Color), 0.7f);
			}
		}

		public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */
		{
			NPC.lifeMax = NPC.lifeMax * 1;
			NPC.damage = NPC.damage * 1;
		}

		const string Boss_Left_Hand_Type = "Violeum_LeftArm";
		const string Boss_Right_Hand_Type = "Violeum_RightArm";
		const string Boss_Up_Hand_Type = "Violeum_LeftArm";
		const string Boss_Down_Hand_Type = "Violeum_RightArm";

		void MakeHands()
		{
			Hands.X = NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X - 50, (int)NPC.Center.Y, Mod.Find<ModNPC>(Boss_Left_Hand_Type).Type, 0, 1, NPC.whoAmI);
			Hands.Y = NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X + 50, (int)NPC.Center.Y, Mod.Find<ModNPC>(Boss_Right_Hand_Type).Type, 0, -1, NPC.whoAmI);
			Hands.Y = NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y - 1000, Mod.Find<ModNPC>(Boss_Down_Hand_Type).Type, 0, -1, NPC.whoAmI);
			Hands.Y = NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y + 1000, Mod.Find<ModNPC>(Boss_Up_Hand_Type).Type, 0, -1, NPC.whoAmI);
		}

		void CheckHands()
		{
			if (Hands.X != -1)
				if (!((Main.npc[(int)Hands.X].type == Mod.Find<ModNPC>(Boss_Left_Hand_Type).Type && Main.npc[(int)Hands.X].ai[1] == NPC.whoAmI) && Main.npc[(int)Hands.X].active))
					Hands.X = -1;
			if (Hands.Y != -1)
				if (!((Main.npc[(int)Hands.Y].type == Mod.Find<ModNPC>(Boss_Right_Hand_Type).Type && Main.npc[(int)Hands.Y].ai[1] == NPC.whoAmI) && Main.npc[(int)Hands.Y].active))
					Hands.Y = -1;
			if (Hands.X != -1)
				if (!((Main.npc[(int)Hands.X].type == Mod.Find<ModNPC>(Boss_Up_Hand_Type).Type && Main.npc[(int)Hands.X].ai[1] == NPC.whoAmI) && Main.npc[(int)Hands.X].active))
					Hands.X = -1;
			if (Hands.Y != -1)
				if (!((Main.npc[(int)Hands.Y].type == Mod.Find<ModNPC>(Boss_Down_Hand_Type).Type && Main.npc[(int)Hands.Y].ai[1] == NPC.whoAmI) && Main.npc[(int)Hands.Y].active))
					Hands.Y = -1;
		}

        public override void ModifyHitByProjectile(Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            CheckHands();
            if (Hands.Y != -1)
                modifiers.FinalDamage /= 10;
        }

        public override void ModifyHitByItem(Player player, Item item, ref NPC.HitModifiers modifiers)
        {
            CheckHands();
            if (Hands.Y != -1)
                modifiers.FinalDamage /= 10;
        }

        public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
        {
            CheckHands();
            if (Hands.Y != -1)
                modifiers.FinalDamage /= 10;
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            CheckHands();
            if (Hands.Y != -1)
                modifiers.FinalDamage /= 10;
        }

		float customAi1;
		bool FirstState;
		//bool SecondState;
		public override void AI()
		{
			if (NPC.life > NPC.lifeMax / 2)
			{
				FirstState = true;
			}

			if (NPC.life < NPC.lifeMax / 2)
			{
				//SecondState = true;
			}

			if (Main.rand.NextBool(2))
			{
				int num706 = Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<CyberDust>(), 0f, 0f, 200, NPC.color, 0.5f);
				Main.dust[num706].velocity *= 0.6f;
			}
			if (FirstState)
			{
				NPC.TargetClosest();
				NPC.netUpdate = false;
				NPC.ai[1]++;

				NPC.TargetClosest(true);
				Vector2 PTC = Main.player[NPC.target].position + new Vector2(NPC.width / 2, NPC.height / 2);
				Vector2 NPos = NPC.position + new Vector2(NPC.width / 2, NPC.height / 2);
				NPC.netUpdate = true;

				customAi1 += (Main.rand.Next(2, 5) * 0.1f) * NPC.scale;
				if (customAi1 >= 4f)
					if (Main.rand.Next(300) == 1)
					{
						SoundEngine.PlaySound(SoundID.Pixie, NPC.position);
						float Angle = (float)Math.Atan2(NPos.Y - PTC.Y, NPos.X - PTC.X);
                        int SpitShot1 = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPos.X, NPos.Y, (float)((Math.Cos(Angle) * 22f) * -1), (float)((Math.Sin(Angle) * 22f) * -1), ModContent.ProjectileType<CyberLaserBat>(), 70, 0f, 0);
						Main.projectile[SpitShot1].timeLeft = 120;
						customAi1 = 1f;
					}
				NPC.netUpdate = true;

				NPC.ai[1] += (Main.rand.Next(2, 5) * 0.1f) * NPC.scale;
				if (NPC.ai[1] >= 10f)
				{
					NPC.TargetClosest(true);
					if (Main.rand.Next(60) == 0)
					{
						Vector2 vector8 = new Vector2(NPC.position.X + (NPC.width * 0.5f), NPC.position.Y + (NPC.height / 2));
						float rotation = (float)Math.Atan2(vector8.Y - (Main.player[NPC.target].position.Y + (Main.player[NPC.target].height * 0.5f)), vector8.X - (Main.player[NPC.target].position.X + (Main.player[NPC.target].width * 0.5f)));
						NPC.velocity.X = (float)(Math.Cos(rotation) * 14) * -1;
						NPC.velocity.Y = (float)(Math.Sin(rotation) * 14) * -1;
						NPC.ai[1] = 1f;
						NPC.netUpdate = true;
					}
				}

				//int num60;
				NPC.TargetClosest(true);

				if (Main.player[NPC.target].position.Y - 150 > NPC.position.Y)
				{
					NPC.directionY = 1;
				}
				else
				{
					NPC.directionY = -1;
				}

				if (NPC.direction == -1 && NPC.velocity.X > -2f)
				{
					NPC.velocity.X = NPC.velocity.X - 0.4f;
					if (NPC.velocity.X > 2f)
					{
						NPC.velocity.X = NPC.velocity.X - 0.4f;
					}
					else
					{
						if (NPC.velocity.X > 0f)
						{
							NPC.velocity.X = NPC.velocity.X + 0.08f;
						}
					}
					if (NPC.velocity.X < -2f)
					{
						NPC.velocity.X = -2f;
					}
				}
				else
				{
					if (NPC.direction == 1 && NPC.velocity.X < 4f)
					{
						NPC.velocity.X = NPC.velocity.X + 0.1f;
						if (NPC.velocity.X < -2f)
						{
							NPC.velocity.X = NPC.velocity.X + 0.1f;
						}
						else
						{
							if (NPC.velocity.X < 0f)
							{
								NPC.velocity.X = NPC.velocity.X - 0.08f;
							}
						}
						if (NPC.velocity.X > 2f)
						{
							NPC.velocity.X = 2f;
						}
					}
				}
				if (NPC.directionY == -1 && NPC.velocity.Y > -1.5)
				{
					NPC.velocity.Y = NPC.velocity.Y - 0.08f;

					if (NPC.velocity.Y < -1.5)
					{
						NPC.velocity.Y = -1.5f;
					}
				}
				else
				{
					if (NPC.directionY == 1 && NPC.velocity.Y < 1.5)
					{
						NPC.velocity.Y = NPC.velocity.Y + 0.08f;
						if (NPC.velocity.Y > 1.5)
						{
							NPC.velocity.Y = 1.5f;
						}
					}
				}

				if (Main.rand.NextBool(2))
				{

					float j = 0;
					float m = 0;
					float n = 0;
					FirstState = true;
					if ((int)Main.time % 140 > 50)
					{
						if ((int)Main.time % 40 < 1)
							for (int i = 0; i < 3; i++)
							{
								j += 2;
								m = (float)Math.Sin(j) * 25f;
								n = (float)Math.Cos(j) * 25f;
								SoundEngine.PlaySound(SoundID.Item8, NPC.position);
								int damage = 70,
								type = ModContent.ProjectileType<CyberLaserBat>();
								int num56 = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X + 20, NPC.position.Y + 50, m, n, type, damage, 0f, Main.myPlayer);
								Main.projectile[num56].timeLeft = 600;
							}
					}
				}
			}
		}
	}
}