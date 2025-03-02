using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TremorMod.Utilities;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Vanity;
using TremorMod.Content.Items.Placeable;
using TremorMod.Content.Items.Weapons.Alchemical;
using TremorMod.Content.Items.Weapons.Melee;
using TremorMod.Content.Items.Accessories;
using TremorMod.Content.Items.Bag;
using TremorMod.Content.Items;
using TremorMod.Content.Items.Fungus;

namespace TremorMod.Content.NPCs.Bosses.FungusBeetle
{
	[AutoloadBossHead]
	public class FungusBeetle : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Fungus Beetle");
			Main.npcFrameCount[NPC.type] = 4;
		}

		Vector2 Hands = new Vector2(-1, -1);
		public override void SetDefaults()
		{
			NPC.lifeMax = 4200;
			NPC.width = 214;
			NPC.height = 114;
			AnimationType = 82;
			NPC.damage = 30;
			NPC.defense = 25;
			NPC.knockBackResist = 0f;
			NPC.aiStyle = 14;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit35;
			NPC.noGravity = true;
			NPC.DeathSound = SoundID.NPCDeath57;
			NPC.color = Color.White;
			NPC.boss = true;
			NPC.noTileCollide = true;
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FungusBeetleMask>(), 7));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FungusElement>(), 1, 10, 23));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FungusBeetleTrophy>(), 10));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<FungusBeetleBag>(), 1));
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("FungusBeetleGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("FungusBeetleGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("FungusBeetleGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("FungusBeetleGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("FungusBeetleGore4").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("FungusBeetleGore4").Type, 1f);
				for (int k = 0; k < 10; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 67, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
			}

			for (int k = 0; k < hit.Damage / NPC.lifeMax * 50.0; k++)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, 67, hitDirection, -1f, 0, default(Color), 0.7f);
			}
		}

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float bossLifeScale, float balance)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 0.625f * bossLifeScale);
            NPC.damage = (int)(NPC.damage * 0.6f);
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
			NPC.position -= NPC.velocity * 0.05f;

			if (NPC.AnyNPCs(Mod.Find<ModNPC>("GreatFungusBug").Type))
			{
				NPC.dontTakeDamage = true;
			}
			if (!NPC.AnyNPCs(Mod.Find<ModNPC>("GreatFungusBug").Type))
			{
				NPC.dontTakeDamage = false;
			}

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

			if (Main.rand.Next(120) == 0 && !Main.expertMode)
			{
				NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X - 70, (int)NPC.Center.Y, 261);
			}

			if (Main.rand.Next(110) == 0 && Main.expertMode)
			{
				NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X - 70, (int)NPC.Center.Y, 261);
			}

			if (Main.rand.Next(200) == 0)
			{
				NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X - 70, (int)NPC.Center.Y, ModContent.NPCType<LittleMushroomBug>());
			}

			if (Main.rand.Next(500) == 0)
			{
				NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X - 70, (int)NPC.Center.Y, ModContent.NPCType<GreatFungusBug>());
			}

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
				int num706 = Dust.NewDust(NPC.position, NPC.width, NPC.height, 67, 0f, 0f, 200, NPC.color, 0.5f);
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
			}
		}
	}
}