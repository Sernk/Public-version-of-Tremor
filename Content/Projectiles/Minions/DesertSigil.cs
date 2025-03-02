using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content;
using TremorMod;
using TremorMod.Content.Buffs;
using TremorMod.Utilities;

namespace TremorMod.Content.Projectiles.Minions
{
	public class DesertSigil : ModProjectile
	{
		const int ShootRate = 22; 
		const float ShootDistance = 300f; 
		const float ShootSpeed = 25f; 
		const int ShootDamage = 38; 
		const float ShootKnockback = 10; 
		int ShootType = 122; 
		int TimeToShoot = ShootRate;

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(226);

			Projectile.width = 34;
			Main.projFrames[Projectile.type] = 1;
			Projectile.height = 34;
			Projectile.timeLeft = 5;
			Projectile.aiStyle = 62;
			AIType = 226;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Desert Sigil");

		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}

		void Shoot()
		{
			if (--TimeToShoot <= 0)
			{
				TimeToShoot = ShootRate;

				float NearestNPCDist = ShootDistance;
				int NearestNPC = -1;
				foreach (NPC npc in Main.npc)
				{
					if (!npc.active)
						continue;
					if (npc.friendly || npc.lifeMax <= 5)
						continue;
					if (NearestNPCDist == -1 || npc.Distance(Projectile.Center) < NearestNPCDist && Collision.CanHitLine(Projectile.Center, 16, 16, npc.Center, 16, 16))
					{
						NearestNPCDist = npc.Distance(Projectile.Center);
						NearestNPC = npc.whoAmI;
					}
				}
				if (NearestNPC == -1)
					return;
				Vector2 Velocity = Helper.VelocityToPoint(Projectile.Center, Main.npc[NearestNPC].Center, ShootSpeed);
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, Velocity.X, Velocity.Y, ShootType, ShootDamage, ShootKnockback, Projectile.owner);
			}
		}

		public override void AI()
		{
			Shoot();
			Projectile.ai[1] = 1;
			base.AI();
			if (Projectile.localAI[0] == 0f)
			{
				SoundEngine.PlaySound(SoundID.Item20, Projectile.position);
			}
			Projectile.localAI[0] += 1f;
            if (Projectile.localAI[0] > 3f)
            {
                if (Projectile.localAI[0] > 5f)
                {
                    // Additional logic can be added here if needed
                }
                if (Projectile.wet && !Projectile.lavaWet)
                {
                    Projectile.Kill();
                }
            }
		}

	}
}
