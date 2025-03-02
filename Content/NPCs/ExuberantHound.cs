using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.NPCs
{
	public class ExuberantHound : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Exuberant Hound");
			Main.npcFrameCount[NPC.type] = 12;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 3000;
			NPC.damage = 120;
			NPC.defense = 60;
			NPC.knockBackResist = 0.2f;
			NPC.width = 50;
			NPC.height = 44;
			AnimationType = 423;
			NPC.aiStyle = 26;
			NPC.npcSlots = 0.5f;
			NPC.HitSound = SoundID.NPCHit18;
			NPC.DeathSound = SoundID.NPCDeath21;
			NPC.value = Item.buyPrice(0, 0, 40, 0);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("ExuberantHoundBanner");
		}

		/*
		 * 
		 * 
		 * 
		 */

		public override void AI()
		{
			Vector2 npcCenter = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
			float targetX = Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f - npcCenter.X;
			float targetY = Main.player[NPC.target].position.Y - npcCenter.Y;
			float targetLength = (float)Math.Sqrt(targetX * targetX + targetY * targetY);

			if (NPC.ai[2] == 1f)
			{
				NPC.ai[1]++;
				NPC.velocity.X = NPC.velocity.X * 0.7f;
				if (NPC.ai[1] < 30f)
				{
					Vector2 newDustLocation = NPC.Center + Vector2.UnitX * NPC.spriteDirection * -20f;
					Dust newDust = Main.dust[Dust.NewDust(newDustLocation, 0, 0, 242, 0f, 0f, 0, default(Color), 1f)];
					Vector2 randomDirection = Vector2.UnitY.RotatedByRandom(Math.PI * 2);
					newDust.position = newDustLocation + randomDirection * 20f;
					newDust.velocity = -randomDirection * 2f;
					newDust.scale = 0.5f + randomDirection.X * -NPC.spriteDirection;
					newDust.fadeIn = 1f;
					newDust.noGravity = true;
				}
				else if (NPC.ai[1] == 30f)
				{
					for (int i = 0; i < 20; i++)
					{
						Vector2 newDustLocation = NPC.Center + Vector2.UnitX * NPC.spriteDirection * -20f;
						Dust newDust = Main.dust[Dust.NewDust(newDustLocation, 0, 0, 242, 0f, 0f, 0, default(Color), 1f)];
						Vector2 randomDirection = Vector2.UnitY.RotatedByRandom(Math.PI * 2);
						newDust.position = newDustLocation + randomDirection * 4f;
						newDust.velocity = randomDirection * 4f + Vector2.UnitX * Main.rand.NextFloat() * NPC.spriteDirection * -5f;
						newDust.scale = 0.5f + randomDirection.X * -NPC.spriteDirection;
						newDust.fadeIn = 1f;
						newDust.noGravity = true;
					}
				}
				
				if (NPC.velocity.X > -0.5f && NPC.velocity.X < 0.5f)
					NPC.velocity.X = 0f;

				if (NPC.ai[1] == 30f && Main.netMode != 1)
				{
					int projectileDamage = Main.expertMode ? 35 : 50;
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X + NPC.spriteDirection * -20, NPC.Center.Y, NPC.spriteDirection * -7, 0f, ProjectileID.MartianTurretBolt, projectileDamage, 0f, Main.myPlayer, NPC.target, 0f);
				}

				if (NPC.ai[1] >= 60f)
				{
					NPC.ai[1] = -Main.rand.Next(320, 601);
					NPC.ai[2] = 0f;
				}
			}
			else
			{
				NPC.ai[1]++;
				if (NPC.ai[1] >= 180f && targetLength < 500f && NPC.velocity.Y == 0f)
				{
					NPC.ai[1] = 0f;
					NPC.ai[2] = 1f;
					NPC.netUpdate = true;
				}
				else if (NPC.velocity.Y == 0f && targetLength < 100f && Math.Abs(NPC.velocity.X) > 3f && ((NPC.Center.X < Main.player[NPC.target].Center.X && NPC.velocity.X > 0f) || (NPC.Center.X > Main.player[NPC.target].Center.X && NPC.velocity.X < 0f)))
				{
					NPC.velocity.Y = NPC.velocity.Y - 4f;
				}
			}
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ConcentratedEther>(), 1, 2, 4));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<ToothofAbraxas>(), 5, 1, 3));
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 60; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 226, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 226, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 27, 2.5f * hitDirection, -2.5f, 0, default(Color), 0.7f);
				}
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ExuberantHoundGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ExuberantHoundGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ExuberantHoundGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ExuberantHoundGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ExuberantHoundGore3").Type, 1f);
			}
			else
			{
				for (int k = 0; k < hit.Damage / NPC.lifeMax * 50; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 226, hitDirection, -2f, 0, default(Color), 0.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 27, hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> (Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo)) && NPC.downedMoonlord && Main.hardMode && !Main.dayTime && spawnInfo.SpawnTileY < Main.worldSurface ? 0.001f : 0f;
	}
}