using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.NPCs.Bosses.Motherboard
{
	public class Clamper : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Clamper");
			Main.npcFrameCount[NPC.type] = 3;
		}

		private const float MaxTargetDistance = 1200f; // maximum distance to target

		public override void SetDefaults()
		{
			NPC.noTileCollide = true;
			NPC.noGravity = true;
			NPC.lifeMax = 5000;
			NPC.damage = 100;
			NPC.defense = 6;
			NPC.knockBackResist = 0f;
			NPC.width = 36;
			NPC.height = 33;
			//aiType = 6;
			NPC.aiStyle = -1; //5
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
			AnimationType = 2;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (Main.netMode != 1 && NPC.life <= 0)
				NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<Clamper2>());
		}

		public override bool CheckActive() => false;

		private NPC Motherboard => Main.npc[(int)NPC.ai[3]];

		public override void AI()
		{
			if (NPC.ai[2] == 1)
			{
				NPC.velocity *= 0.999f;
				return;
			}

			CheckDead();

			// sp/server only, update ais
			if (Main.netMode != 1)
			{
				--NPC.localAI[0];
				if (NPC.localAI[0] <= 0.0)
				{
					NPC.localAI[0] = Main.rand.Next(10, 26);
					NPC.ai[0] = Main.rand.Next(-5, 14);
					NPC.ai[1] = Main.rand.Next(-5, 14);
					NPC.netUpdate = true;
				}
			}

			NPC.TargetClosest();

			ControlVelocity();
			ControlRotation();

		}

		private new void CheckDead()
		{
			// turn to loose clamper when target is too far away?
			if (Main.player[Helper.GetNearestPlayer(NPC.Center)].Distance(NPC.position) > MaxTargetDistance)
			{
				int n = NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X, (int)NPC.position.Y, ModContent.NPCType<Clamper2>());
				Main.npc[n].rotation = NPC.rotation;
				Main.npc[n].velocity = NPC.velocity;
				NPC.active = false;
				NPC.netUpdate = true;
			}
			// Motherboard has dead, kill ourselves
			if (Motherboard.type != ModContent.NPCType<Motherboard>() || !Motherboard.active)
			{
				NPC.active = false;
				NPC.netUpdate = true;
			}
		}

		private void ControlVelocity()
		{
			// random garbage from here, todo: refactor
			float num1 = 0.2f;
			float num2 = 10f;
			if (Motherboard.life < Motherboard.lifeMax * 0.25)
				num2 += 5f;
			if (Motherboard.life < Motherboard.lifeMax * 0.1)
				num2 += 5f;
			float x = Motherboard.position.X + Motherboard.width / 2;
			float y = Motherboard.position.Y + Motherboard.height / 2;
			Vector2 vector2 = new Vector2(x, y);
			float num3 = x + NPC.ai[0];
			float num4 = y + NPC.ai[1];
			float num5 = num3 - vector2.X;
			float num6 = num4 - vector2.Y;
			float num7 = (float)Math.Sqrt(num5 * (double)num5 + num6 * (double)num6);
			float num8 = num2 / num7;
			float num9 = num5 * num8;
			float num10 = num6 * num8;
			if (NPC.position.X < x + (double)num9)
			{
				NPC.velocity.X += num1;
				if (NPC.velocity.X < 0.0 && num9 > 0.0)
					NPC.velocity.X *= 0.5f;
			}
			else if (NPC.position.X > x + (double)num9)
			{
				NPC.velocity.X -= num1;
				if (NPC.velocity.X > 0.0 && num9 < 0.0)
					NPC.velocity.X *= 0.5f;
			}
			if (NPC.position.Y < y + (double)num10)
			{
				NPC.velocity.Y += num1;
				if (NPC.velocity.Y < 0.0 && num10 > 0.0)
					NPC.velocity.Y *= 0.5f;
			}
			else if (NPC.position.Y > y + (double)num10)
			{
				NPC.velocity.Y -= num1;
				if (NPC.velocity.Y > 0.0 && num10 < 0.0)
					NPC.velocity.Y *= 0.5f;
			}
			Lighting.AddLight(NPC.Center, Color.White.ToVector3());
			// Limit velocity
			NPC.velocity.X = MathHelper.Clamp(NPC.velocity.X, -8.0f, 8.0f);
			NPC.velocity.Y = MathHelper.Clamp(NPC.velocity.Y, -8.0f, 8.0f);
		}

		private void ControlRotation()
		{
			NPC.rotation = NPC.AngleTo(NPC.target != -1 ? Main.player[NPC.target].Center : Motherboard.Center);
		}	
	}
}