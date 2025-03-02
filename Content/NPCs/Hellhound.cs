using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.NPCs
{
	public class Hellhound : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Hellhound");
			Main.npcFrameCount[NPC.type] = 12;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 10000;
			NPC.damage = 160;
			NPC.defense = 70;
			NPC.knockBackResist = 0.2f;
			NPC.width = 50;
			NPC.height = 44;
			AnimationType = 423;
			NPC.aiStyle = 26;
			NPC.npcSlots = 0.5f;
			NPC.lavaImmune = true;
			NPC.buffImmune[24] = true;
			NPC.buffImmune[67] = true;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath21;
			NPC.value = Item.buyPrice(0, 0, 40, 0);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("HellhoundBanner");
		}

		public override void AI()
		{
			if (Main.rand.NextBool(4))
				Main.dust[Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 0f, 0f, 200, NPC.color)].velocity *= 0.3F;

			Vector2 vector72 = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
			float num738 = Main.player[NPC.target].position.X + Main.player[NPC.target].width * 0.5f - vector72.X;
			float num739 = Main.player[NPC.target].position.Y - vector72.Y;
			float num740 = (float)Math.Sqrt(num738 * num738 + num739 * num739);

			if (NPC.ai[2] == 1f)
			{
				NPC.ai[1] += 1f;
				NPC.velocity.X = NPC.velocity.X * 0.7f;
				if (NPC.ai[1] < 30f)
				{
					Vector2 vector73 = NPC.Center + Vector2.UnitX * NPC.spriteDirection * -20f;
					Dust newDust = Main.dust[Dust.NewDust(vector73, 0, 0, 6, 0f, 0f, 0, default(Color), 1f)];
					Vector2 vector74 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
					newDust.position = vector73 + vector74 * 20f;
					newDust.velocity = -vector74 * 2f;
					newDust.scale = 0.5f + vector74.X * -(float)NPC.spriteDirection;
					newDust.fadeIn = 1f;
					newDust.noGravity = true;
				}
				else if (NPC.ai[1] == 30f)
				{
					for (int num743 = 0; num743 < 20; num743++)
					{
						Vector2 vector75 = NPC.Center + Vector2.UnitX * NPC.spriteDirection * -20f;
						Dust newDust = Main.dust[Dust.NewDust(vector75, 0, 0, 6, 0f, 0f, 0, default(Color), 1f)];
						Vector2 vector76 = Vector2.UnitY.RotatedByRandom(6.2831854820251465);
						newDust.position = vector75 + vector76 * 4f;
						newDust.velocity = vector76 * 4f + Vector2.UnitX * Main.rand.NextFloat() * NPC.spriteDirection * -5f;
						newDust.scale = 0.5f + vector76.X * -(float)NPC.spriteDirection;
						newDust.fadeIn = 1f;
						newDust.noGravity = true;
					}
				}
				if (NPC.velocity.X > -0.5f && NPC.velocity.X < 0.5f)
					NPC.velocity.X = 0f;
				if (NPC.ai[1] == 30f && Main.netMode != 1)
				{
					int num744 = Main.expertMode ? 35 : 50;
					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X + NPC.spriteDirection * -20, NPC.Center.Y, NPC.spriteDirection * -7, 0f, 467, num744, 0f, Main.myPlayer, NPC.target, 0f);
				}
				if (NPC.ai[1] >= 60f)
				{
					NPC.ai[1] = -(float)Main.rand.Next(320, 601);
					NPC.ai[2] = 0f;
				}
			}
			else
			{
				NPC.ai[1] += 1f;
				if (NPC.ai[1] >= 180f && num740 < 500f && NPC.velocity.Y == 0f)
				{
					NPC.ai[1] = 0f;
					NPC.ai[2] = 1f;
					NPC.netUpdate = true;
				}
				else if (NPC.velocity.Y == 0f && num740 < 100f && Math.Abs(NPC.velocity.X) > 3f && ((NPC.Center.X < Main.player[NPC.target].Center.X && NPC.velocity.X > 0f) || (NPC.Center.X > Main.player[NPC.target].Center.X && NPC.velocity.X < 0f)))
				{
					NPC.velocity.Y = NPC.velocity.Y - 4f;
				}
			}
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<FireFragment>(), 1, 2, 4));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<FlamesofDespair>(), 25));
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 60; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 2.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.7f);
				}

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("HellhoundGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("HellhoundGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("HellhoundGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("HellhoundGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("HellhoundGore3").Type, 1f);
			}
			else
			{

				for (int k = 0; k < hit.Damage / NPC.lifeMax * 50.0; k++)
				{
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, hitDirection, -2f, 0, default(Color), 1.7f);
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 6, hitDirection, -1f, 0, default(Color), 0.7f);
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> (Helper.NoZoneAllowWater(spawnInfo)) && NPC.downedMoonlord && spawnInfo.SpawnTileY > Main.maxTilesY - 200 ? 0.002f : 0f;
	}
}