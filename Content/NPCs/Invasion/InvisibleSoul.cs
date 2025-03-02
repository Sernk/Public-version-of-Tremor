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
using TremorMod.Content.NPCs.Invasion.ParadoxTitan;

namespace TremorMod.Content.NPCs.Invasion
{
	public class InvisibleSoul : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Paradox Soul Warrior");
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 12250;
			NPC.damage = 100;
			NPC.defense = 65;
			NPC.knockBackResist = 0f;
			NPC.width = 34;
			NPC.height = 40;
			AnimationType = 3;
			NPC.aiStyle = 3;
			AIType = 77;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit55;
			NPC.DeathSound = SoundID.NPCDeath51;
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

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (Main.rand.NextBool())
            {
                target.AddBuff(BuffID.VortexDebuff, 1000);
            }
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
				if (InvasionWorld.CyberWrath && Main.rand.NextBool(3))
				{
					InvasionWorld.CyberWrathPoints1 += 3;
					//Main.NewText(("Wave 1: Complete " + TremorWorld.CyberWrathPoints + "%"), 39, 86, 134);
				}
			}

			for (int k = 0; k < hit.Damage / NPC.lifeMax * 50.0; k++)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<CyberDust>(), hitDirection, -1f, 0, default(Color), 0.7f);
			}
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            if (Main.netMode != 1)
            {
                int centerX = (int)(NPC.position.X + NPC.width / 2) / 16;
                int centerY = (int)(NPC.position.Y + NPC.height / 2) / 16;
                int halfLength = NPC.width / 2 / 16 + 1;
                npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ParadoxElement>(), 3, 5, 7));
            }
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)/* tModPorter Note: bossLifeScale -> balance (bossAdjustment is different, see the docs for details) */
		{
			NPC.lifeMax = NPC.lifeMax * 1;
			NPC.damage = NPC.damage * 1;
		}

		//float customAi1;
		bool FirstState;
		bool SecondState;
		public Vector2 tilePos = default(Vector2);
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

			if (Main.rand.NextBool(2))
			{
				int num706 = Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<CyberDust>(), 0f, 0f, 200, NPC.color, 0.5f);
				Main.dust[num706].velocity *= 0.6f;
			}
			if (FirstState)
			{
				if (Main.player[NPC.target].position.X > NPC.position.X)
					NPC.spriteDirection = 1;
				else
					NPC.spriteDirection = -1;

				if (NPC.direction == -1 && NPC.velocity.X > -2f)
				{
					NPC.velocity.X = NPC.velocity.X - 0.1f;
					if (NPC.velocity.X > 2f)
					{
						NPC.velocity.X = NPC.velocity.X - 0.1f;
					}
					else
					{
						if (NPC.velocity.X > 0f)
						{
							NPC.velocity.X = NPC.velocity.X + 0.05f;
						}
					}
					if (NPC.velocity.X < -2f)
					{
						NPC.velocity.X = -2f;
					}
				}
				else
				{
					if (NPC.direction == 1 && NPC.velocity.X < 2f)
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
								NPC.velocity.X = NPC.velocity.X - 0.05f;
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
					NPC.velocity.Y = NPC.velocity.Y - 0.05f;

					if (NPC.velocity.Y < -1.5)
					{
						NPC.velocity.Y = -1.5f;
					}
				}
				else
				{
					if (NPC.directionY == 1 && NPC.velocity.Y < 1.5)
					{
						NPC.velocity.Y = NPC.velocity.Y + 0.05f;
						if (NPC.velocity.Y > 1.5)
						{
							NPC.velocity.Y = 1.5f;
						}
					}
				}

				if (Main.rand.Next(160) == 0)
				{
					NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X - 50, (int)NPC.position.Y, ModContent.NPCType<MiniSoul>());
				}
			}

			if (SecondState && !FirstState)
			{
				if (Main.player[NPC.target].position.X > NPC.position.X)
					NPC.spriteDirection = 1;
				else
					NPC.spriteDirection = -1;

				if (NPC.direction == -1 && NPC.velocity.X > -2f)
				{
					NPC.velocity.X = NPC.velocity.X - 0.1f;
					if (NPC.velocity.X > 2f)
					{
						NPC.velocity.X = NPC.velocity.X - 0.1f;
					}
					else
					{
						if (NPC.velocity.X > 0f)
						{
							NPC.velocity.X = NPC.velocity.X + 0.05f;
						}
					}
					if (NPC.velocity.X < -2f)
					{
						NPC.velocity.X = -2f;
					}
				}
				else
				{
					if (NPC.direction == 1 && NPC.velocity.X < 2f)
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
								NPC.velocity.X = NPC.velocity.X - 0.05f;
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
					NPC.velocity.Y = NPC.velocity.Y - 0.05f;

					if (NPC.velocity.Y < -1.5)
					{
						NPC.velocity.Y = -1.5f;
					}
				}
				else
				{
					if (NPC.directionY == 1 && NPC.velocity.Y < 1.5)
					{
						NPC.velocity.Y = NPC.velocity.Y + 0.05f;
						if (NPC.velocity.Y > 1.5)
						{
							NPC.velocity.Y = 1.5f;
						}
					}
				}

				if (Main.rand.Next(120) == 0)
				{
					NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X - 50, (int)NPC.position.Y, ModContent.NPCType<MiniSoul>());
				}

				/*if (Main.rand.Next(200) == 0)
				{
					NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X - 50, (int)NPC.position.Y, ModContent.NPCType<CyberSoul>());
				}*/
			}
		}
	}
}