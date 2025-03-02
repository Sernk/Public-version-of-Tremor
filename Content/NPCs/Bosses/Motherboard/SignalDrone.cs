using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.NPCs.Bosses.Motherboard
{
	public class SignalDrone : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Signal Drone");
		}

		public override void SetDefaults()
		{
			NPC.noTileCollide = true;
			NPC.noGravity = true;
			NPC.lifeMax = 1500;
			NPC.damage = 65;
			NPC.defense = 18;
			NPC.knockBackResist = 0.5f;
			NPC.width = 90;
			NPC.height = 90;
			NPC.aiStyle = 0;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath14;
		}

		private void UpdateDroneImmunities()
		{
			foreach (NPC drone in Main.npc.Where(x => x.type == NPC.type && NPC.active))
			{
				var signalDrone = drone.ModNPC as SignalDrone;
				if (signalDrone != null)
				{
					signalDrone._immuneTime = 240;
					signalDrone.NPC.netUpdate = true;
				}
			}
		}

		protected void UpdateMyImmunity()
		{
			_immuneTime = Math.Max(0, _immuneTime - 1);
		}

		public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
		{
			UpdateDroneImmunities();
		}

		public override bool CanHitPlayer(Player target, ref int cooldownSlot)
			=> _immuneTime <= 0;

		public override void AI()
		{
			CheckParent();
			SharknadoStyledAI();
			UpdateMyImmunity();
		}

		public override bool CheckActive() => false;

		private void CheckParent()
		{
			if (Motherboard.type != Mod.Find<ModNPC>("Motherboard").Type 
				|| !Motherboard.active)
			{
				NPC.active = false;
				NPC.netUpdate = true;
			}
		}

		private float _immuneTime
		{
			get { return NPC.ai[1]; }
			set { NPC.ai[1] = value; }
		}
		private NPC Motherboard => Main.npc[(int)NPC.ai[3]];

		private void SharknadoStyledAI()
		{
			// The amount of spacing
			// Default: 0.1f
			const float spacingValue = 0.25f;
			float spacingTreshold = (float)NPC.width * 2f;

			// Some movement control
			// This adds spacing between units
			// So that they dont all stack on the same position because they have the same AI
			for (int i = 0; i < Main.maxNPCs; i++)
			{
				NPC otherNPC = Main.npc[i];
				if (i != NPC.whoAmI // not us
				    && otherNPC.active // active
				    && otherNPC.type == NPC.type // same type
				    &&
				    // Basically this makes sure the padding movement code
				    // only kicks in if the units are within treshold range
				    Math.Abs(NPC.position.X - otherNPC.position.X)  // absolute x position difference
				    + Math.Abs(NPC.position.Y - otherNPC.position.Y)  // absolute y position difference
				    < spacingTreshold) // differences added up are lower than treshold
				{
					// Control X
					if (NPC.position.X < otherNPC.position.X)
					{
						NPC.velocity.X = NPC.velocity.X - spacingValue;
					}
					else
					{
						NPC.velocity.X = NPC.velocity.X + spacingValue;
					}

					// Control Y
					if (NPC.position.Y < otherNPC.position.Y)
					{
						NPC.velocity.Y = NPC.velocity.Y - spacingValue;
					}
					else
					{
						NPC.velocity.Y = NPC.velocity.Y + spacingValue;
					}
				}
			}

			NPC.TargetClosest();
			
			Entity target =
				NPC.target != -1
				&& !Main.player[NPC.target].dead
					? (Entity)Main.player[NPC.target]
					: (Entity)Motherboard;

			float velocityMultiplier = 
				(target as NPC) != null
				? 12f : 10f; // 16f is pretty much as fast as the player

			Vector2 distanceToTarget = target.Center - NPC.Center + new Vector2(0f, -20f);

			if (Math.Abs(distanceToTarget.X) > 40f
				|| Math.Abs(distanceToTarget.Y) > 10f)
			{
				distanceToTarget.Normalize();
				distanceToTarget *= velocityMultiplier;
				distanceToTarget *= new Vector2(1.25f, 0.65f);
				NPC.velocity = (NPC.velocity * 20f + distanceToTarget) / 21f;
			}
			else
			{
				if (NPC.velocity.X == 0f && NPC.velocity.Y == 0f)
				{
					NPC.velocity.X = -0.15f;
					NPC.velocity.Y = -0.05f;
				}
				NPC.velocity *= 1.01f;
			}

			// Rotation
			NPC.rotation = NPC.velocity.X * 0.05f;

			// Sprite direction
			if (NPC.velocity.X > 0f)
			{
				NPC.spriteDirection = (NPC.direction = -1);
			}
			else if (NPC.velocity.X < 0f)
			{
				NPC.spriteDirection = (NPC.direction = 1);
			}
		}
	}
}