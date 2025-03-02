using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Utilities;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Filters = Terraria.Graphics.Effects.Filters;

namespace TremorMod.Content.NPCs.Bosses.AndasBoss
{
	public class InfernoSkull : ModProjectile
	{
		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Inferno Skull");
		}*/

		int target;
		const int ShootType = 258;
		const int ShootDamage = 55;
		const float ShootKnockback = 2f;
		const int ShootDirection = 7;

		public override void SetDefaults()
		{
			Projectile.width = 26;
			Projectile.height = 52;
			Projectile.hostile = true;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 175;
			Main.projFrames[Projectile.type] = 2;
		}
        public override void OnKill(int timeLeft)
        {
            // Замена устаревшего Main.PlaySound
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);

            // Создание новых снарядов
            IEntitySource source = Projectile.GetSource_Death();
            Projectile.NewProjectile(source, Projectile.position.X + 40, Projectile.position.Y + 40, -ShootDirection, 0, ShootType, ShootDamage, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(source, Projectile.position.X + 40, Projectile.position.Y + 40, ShootDirection, 0, ShootType, ShootDamage, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(source, Projectile.position.X + 40, Projectile.position.Y + 40, 0, ShootDirection, ShootType, ShootDamage, ShootKnockback, Main.myPlayer, 0f, 0f);
            Projectile.NewProjectile(source, Projectile.position.X + 40, Projectile.position.Y + 40, 0, -ShootDirection, ShootType, ShootDamage, ShootKnockback, Main.myPlayer, 0f, 0f);
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            Projectile.Kill();
        }

        public override bool PreAI()
		{
			Projectile.spriteDirection = Projectile.direction;
			Projectile.frameCounter++;
			if (Projectile.frameCounter >= 3)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
				if (Projectile.frame >= 2)
				{
					Projectile.frame = 0;
				}
			}

			Projectile.rotation = Projectile.velocity.ToRotation() + 1.57F;

			if (Projectile.ai[0] == 0 && Main.netMode != 1)
			{
				target = -1;
				float distance = 2000f;
				for (int k = 0; k < 255; k++)
				{
					if (Main.player[k].active && !Main.player[k].dead)
					{
						Vector2 center = Main.player[k].Center;
						float currentDistance = Vector2.Distance(center, Projectile.Center);
						if (currentDistance < distance || target == -1)
						{
							distance = currentDistance;
							target = k;
						}
					}
				}
				if (target != -1)
				{
					Projectile.ai[0] = 1;
					Projectile.netUpdate = true;
				}
			}
			Player targetPlayer = Main.player[target];
			Vector2 direction = targetPlayer.Center - Projectile.Center;
			direction.Normalize();
			Projectile.velocity *= 0.98f;
			int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6);
			Main.dust[dust2].noGravity = true;
			Main.dust[dust2].velocity *= 0f;
			Main.dust[dust2].velocity *= 0f;
			Main.dust[dust2].scale = 0.9f;
			if (Math.Sqrt((Projectile.velocity.X * Projectile.velocity.X) + (Projectile.velocity.Y * Projectile.velocity.Y)) < 14f)
			{
				if (Main.rand.Next(24) == 1)
				{
					direction.X = direction.X * Main.rand.Next(20, 24);
					direction.Y = direction.Y * Main.rand.Next(20, 24);
					Projectile.velocity.X = direction.X;
					Projectile.velocity.Y = direction.Y;
				}
			}
			return false;
		}

		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write(target);
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			target = reader.Read();
		}
	}
}
