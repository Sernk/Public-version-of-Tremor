using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.NPCs.Bosses
{
	public class HeaterOfWorldsBody : HeaterofWorldsPart
	{
		const int MaxCooldown = 240;

		public float ShootCooldown
		{
			get { return NPC.ai[0]; }
			set { NPC.ai[0] = value; }
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			NPC.width = 26;
            NPC.height = 48;
		}

		public override void AI()
		{
			if (JustSpawned)
			{
				ShootCooldown = MaxCooldown;
				JustSpawned = false;
			}
			CheckSegments();
			TryShoot();
			DustFX();
		}

        private void TryShoot()
        {
            if (Main.rand.NextBool())
                ShootCooldown -= 1;

            NPC.TargetClosest(false);

            if (Main.netMode != NetmodeID.MultiplayerClient
                && NPC.HasValidTarget
                && ShootCooldown <= 0)
            {
                ShootCooldown = MaxCooldown;

                // Calculate the direction from NPC to the target (player)
                Vector2 direction = Main.player[NPC.target].Center - NPC.Center;
                direction.Normalize();  // Normalize the direction vector

                // Multiply the normalized vector by the speed
                Vector2 velocity = direction * 4; // Speed is 4

                // Use NewProjectile to shoot the projectile
                Projectile.NewProjectile(
                    NPC.GetSource_FromAI(),      // Source
                    NPC.Center,                  // Position (Vector2)
                    velocity,                    // Speed (Vector2)
                    326,                         // Projectile Type
                    10,                          // Damage
                    1f,                          // Knockback
                    Main.myPlayer                // Owner (player ID)
                );
            }
        }



        private void DustFX()
		{
			if (Main.rand.NextBool(3))
			{
				for (int i = 0; i < 2; i++)
				{
					Dust dust = Dust.NewDustPerfect(NPC.position, 6, Alpha: 200);
					dust.noGravity = true;
				}
			}
		}

		public override bool CheckActive()
		{
			return false;
		}

		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			return false;
		}
	}
}