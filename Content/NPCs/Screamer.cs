using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using TremorMod.Content.Items.Materials.OreAndBar;
using TremorMod.Content.Projectiles;
using TremorMod.Content.Items.Materials;
using TremorMod.Content.Items.Weapons.Magic;
using TremorMod.Content.Items.Placeable.Banners;
using TremorMod.Content.Items.Vanity;

namespace TremorMod.Content.NPCs
{
	public class Screamer : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Screamer");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.aiStyle = -1;
			NPC.lifeMax = 12000;
			NPC.damage = 160;
			NPC.defense = 135;
			AnimationType = 82;
			NPC.knockBackResist = 0f;
			NPC.width = 130;
			NPC.height = 140;
			NPC.value = Item.buyPrice(0, 20, 0, 0);
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath10;
			NPC.buffImmune[20] = true;
			NPC.buffImmune[24] = true;
			NPC.buffImmune[39] = true;
			NPC.npcSlots = 10f;
		}

		public override void AI()
		{
			float maxMoveSpeed = 5f;
			NPC.TargetClosest(true);
			Vector2 targetVelocity = Main.player[NPC.target].Center - NPC.Center;
			float velocityMagnitude = targetVelocity.Length();

			if (velocityMagnitude < 20f)
			{
				targetVelocity = NPC.velocity;
			}
			else if (velocityMagnitude < 40f)
			{
				targetVelocity.Normalize();
				targetVelocity *= maxMoveSpeed * 0.35f;
			}
			else if (velocityMagnitude < 80f)
			{
				targetVelocity.Normalize();
				targetVelocity *= maxMoveSpeed * 0.65f;
			}
			else
			{
				targetVelocity.Normalize();
				targetVelocity *= maxMoveSpeed;
			}

			NPC.SimpleFlyMovement(targetVelocity, 0.15F);
			NPC.rotation = NPC.velocity.X * 0.1f;

			if (NPC.ai[0]++ >= 70f)
			{
				NPC.ai[0] = 0f;
				if (Main.netMode != 1)
				{
					Vector2 randomProjectileVelocity = Vector2.Zero;
					while (Math.Abs(randomProjectileVelocity.X) < 1.5f)
						randomProjectileVelocity = Vector2.UnitY.RotatedByRandom(1.5707963705062866) * new Vector2(5f, 3f);

					Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X, NPC.Center.Y, randomProjectileVelocity.X, randomProjectileVelocity.Y, ProjectileID.AncientDoomProjectile, 60, 0f, Main.myPlayer, 0f, NPC.whoAmI);
				}
			}
		}

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.NotExpert(), ModContent.ItemType<Catalyst>(), 1, 6, 13));
        }

        public override void HitEffect(NPC.HitInfo hit)
		{
            int hitDirection = hit.HitDirection;

            if (NPC.life <= 0)
			{
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ScreamerGore1").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ScreamerGore2").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ScreamerGore3").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ScreamerGore3").Type, 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
			=> spawnInfo.SpawnTileY < Main.rockLayer && NPC.downedMoonlord && Main.eclipse ? 0.001f : 0f;
	}
}