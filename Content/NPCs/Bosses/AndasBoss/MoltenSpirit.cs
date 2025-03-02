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
	public class MoltenSpirit : ModNPC
	{

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Molten Spirit");
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.width = 102;
			NPC.height = 88;
			NPC.damage = 80;
			NPC.defense = 95;
			NPC.knockBackResist = 0f;
			NPC.lifeMax = 4500;
			NPC.HitSound = SoundID.NPCHit54;
			NPC.DeathSound = SoundID.NPCDeath52;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.npcSlots = 0.75f;
			NPC.buffImmune[24] = true;
			NPC.buffImmune[67] = true;
			NPC.lavaImmune = true;
		}

		int AnimationRate = 6;
		int CurrentFrame;
		int TimeToAnimation = 6;

		Rectangle GetFrame(int Number)
		{
			return new Rectangle(0, NPC.frame.Height * (Number - 1), NPC.frame.Width, NPC.frame.Height);
		}

		public override bool PreAI()
		{
			NPC.spriteDirection = NPC.direction;
			if (--TimeToAnimation <= 0)
			{
				if (++CurrentFrame > 4)
					CurrentFrame = 1;
				TimeToAnimation = AnimationRate;
				NPC.frame = GetFrame(CurrentFrame);
			}
			float velMax = 1f;
			float acceleration = 0.011f;
			NPC.TargetClosest(true);
			Vector2 center = NPC.Center;
			float deltaX = Main.player[NPC.target].position.X + Main.player[NPC.target].width / 2 - center.X;
			float deltaY = Main.player[NPC.target].position.Y + Main.player[NPC.target].height / 2 - center.Y;
			float distance = (float)Math.Sqrt(deltaX * (double)deltaX + deltaY * (double)deltaY);
			NPC.ai[1] += 1f;
			if (NPC.ai[1] > 600.0)
			{
				acceleration *= 8f;
				velMax = 4f;
				if (NPC.ai[1] > 650.0)
				{
					NPC.ai[1] = 0f;
				}
			}
			else if (distance < 250.0)
			{
				NPC.ai[0] += 0.9f;
				if (NPC.ai[0] > 0f)
				{
					NPC.velocity.Y = NPC.velocity.Y + 0.019f;
				}
				else
				{
					NPC.velocity.Y = NPC.velocity.Y - 0.019f;
				}
				if (NPC.ai[0] < -100f || NPC.ai[0] > 100f)
				{
					NPC.velocity.X = NPC.velocity.X + 0.019f;
				}
				else
				{
					NPC.velocity.X = NPC.velocity.X - 0.019f;
				}
				if (NPC.ai[0] > 200f)
				{
					NPC.ai[0] = -200f;
				}
			}
			if (distance > 350.0)
			{
				velMax = 5f;
				acceleration = 0.3f;
			}
			else if (distance > 300.0)
			{
				velMax = 3f;
				acceleration = 0.2f;
			}
			else if (distance > 250.0)
			{
				velMax = 1.5f;
				acceleration = 0.1f;
			}
			float stepRatio = velMax / distance;
			float velLimitX = deltaX * stepRatio;
			float velLimitY = deltaY * stepRatio;
			if (Main.player[NPC.target].dead)
			{
				velLimitX = (float)(NPC.direction * velMax / 2.0);
				velLimitY = (float)(-(double)velMax / 2.0);
			}
			if (NPC.velocity.X < velLimitX)
			{
				NPC.velocity.X = NPC.velocity.X + acceleration;
			}
			else if (NPC.velocity.X > velLimitX)
			{
				NPC.velocity.X = NPC.velocity.X - acceleration;
			}
			if (NPC.velocity.Y < velLimitY)
			{
				NPC.velocity.Y = NPC.velocity.Y + acceleration;
			}
			else if (NPC.velocity.Y > velLimitY)
			{
				NPC.velocity.Y = NPC.velocity.Y - acceleration;
			}
			if (velLimitX > 0.0)
			{
				NPC.spriteDirection = -1;
				NPC.rotation = (float)Math.Atan2(velLimitY, velLimitX);
			}
			if (velLimitX < 0.0)
			{
				NPC.spriteDirection = 1;
				NPC.rotation = (float)Math.Atan2(velLimitY, velLimitX) + 3.14f;
			}
			Player target = Main.player[NPC.target];
			int distance2 = (int)Math.Sqrt((NPC.Center.X - target.Center.X) * (NPC.Center.X - target.Center.X) + (NPC.Center.Y - target.Center.Y) * (NPC.Center.Y - target.Center.Y));

			if (distance2 < 320)
			{
				float num867 = 6f; // Скорость
				int num869 = ModContent.ProjectileType<SpiritFire>(); // Тип проектиля

				// Источник для снаряда
				IEntitySource source = NPC.GetSource_FromAI();

				// Центр NPC
				Vector2 vector86 = NPC.Center;

				// Разница между позициями NPC и игрока
				float num864 = target.Center.X - vector86.X;
				float num865 = target.Center.Y - vector86.Y;

				// Нормализация скорости
				float num866 = (float)Math.Sqrt(num864 * num864 + num865 * num865);
				num866 = num867 / num866;
				num864 *= num866;
				num865 *= num866;

				// Добавление случайного разброса
				num865 += Main.rand.Next(-40, 41) * 0.01f;
				num864 += Main.rand.Next(-40, 41) * 0.01f;

				// Учет текущей скорости NPC
				num865 += NPC.velocity.Y * 0.5f;
				num864 += NPC.velocity.X * 0.5f;

				// Создание проектиля
				Projectile.NewProjectile(source, vector86, new Vector2(num864, num865), num869, NPC.damage, 0f, Main.myPlayer);
			}
			return false;


			/*public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
            {
                Texture2D drawTexture = Main.npcTexture[npc.type];
                Vector2 origin = new Vector2((drawTexture.Width / 2) * 0.5F, (drawTexture.Height / Main.npcFrameCount[npc.type]) * 0.5F);

                Vector2 drawPos = new Vector2(
                    npc.position.X - Main.screenPosition.X + (npc.width / 2) - (Main.npcTexture[npc.type].Width / 2) * npc.scale / 2f + origin.X * npc.scale,
                    npc.position.Y - Main.screenPosition.Y + npc.height - Main.npcTexture[npc.type].Height * npc.scale / Main.npcFrameCount[npc.type] + 4f + origin.Y * npc.scale + npc.gfxOffY);

                SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
                spriteBatch.Draw(drawTexture, drawPos, npc.frame, Color.White, npc.rotation, origin, npc.scale, effects, 0);

                return false;
            }*/
		}
	}
}