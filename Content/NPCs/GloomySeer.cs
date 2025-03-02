using System;
using Terraria;
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
	public class GloomySeer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Gloomy Seer");
			Main.npcFrameCount[NPC.type] = 5;
		}

		public override void SetDefaults()
		{
			NPC.lifeMax = 250;
			NPC.damage = 22;
			NPC.defense = 10;
			NPC.knockBackResist = 0.3f;
			NPC.width = 40;
			NPC.height = 40;
			AnimationType = 156;
			NPC.aiStyle = 22;
			NPC.npcSlots = 15f;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.noGravity = true;
			NPC.value = Item.buyPrice(0, 0, 2, 50);
			// banner = npc.type;
			// Todo: bannerItem = mod.ItemType("GloomySeerBanner");
		}

		public override void AI()
		{
			NPC.ai[0]++;

			if (Main.netMode != 1 && (NPC.ai[0] == 20f || NPC.ai[0] == 40f || NPC.ai[0] == 60f || NPC.ai[0] == 80f))
			{
				Player target = Main.player[NPC.target];
				if (Collision.CanHit(NPC.position, NPC.width, NPC.height, target.position, target.width, target.height))
				{
					float speed = 2.2f;
					Vector2 npcCenter = new Vector2(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
					float targetX = target.position.X + target.width * 0.5f - npcCenter.X + Main.rand.Next(-100, 101);
					float targetY = target.position.Y + target.height * 0.5f - npcCenter.Y + Main.rand.Next(-100, 101);
					float length = (float)Math.Sqrt(targetX * targetX + targetY * targetY);
					length = speed / length;

					targetX *= length;
					targetY *= length;
					
					Main.projectile[Projectile.NewProjectile(NPC.GetSource_FromThis(), npcCenter.X, npcCenter.Y, targetX, targetY, ProjectileID.Bone, 83, 0f, Main.myPlayer, 0f, 0f)].timeLeft = 3000;
				}
			}
			else if (NPC.ai[0] >= 150 + Main.rand.Next(150))
				NPC.ai[0] = 0f;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
				for (int k = 0; k < 20; k++)
					Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hitDirection, -2.5f, 0, default(Color), 1.2f);

                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("GSGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("GSGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("GSGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("GSGore3").Type, 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> Helper.NormalSpawn(spawnInfo) && Helper.NoZoneAllowWater(spawnInfo) && Main.bloodMoon && spawnInfo.SpawnTileY < Main.worldSurface ? 0.001f : 0f;
	}
}