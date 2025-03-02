using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using TremorMod;

namespace TremorMod.Content.Projectiles
{
	public class Mini_Cyber : ModProjectile
    {
		const int ShootRate = 30;
		const float ShootDistance = 450f;
		const float ShootSpeed = 20f;
		const int ShootDamage = 40;
		const float ShootKnockback = 4;

		//int TimeToShoot = ShootRate;

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Mini-Cyber");
		}

		public override void SetDefaults()
		{
			Projectile.netImportant = true;
			Projectile.CloneDefaults(388);
			AIType = 388;
			Projectile.light = 2f;
			Projectile.width = 26;
			Projectile.height = 30;
			Main.projFrames[Projectile.type] = 3;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.minionSlots = 1;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 18000;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (Projectile.velocity.X != oldVelocity.X)
			{
				Projectile.velocity.X = oldVelocity.X;
			}
			if (Projectile.velocity.Y != oldVelocity.Y)
			{
				Projectile.velocity.Y = oldVelocity.Y;
			}
			return false;
		}

		void Shoot()
		{
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
			if (Main.mouseLeft)
				if ((int)(Main.time % 60) == 0)
				{
					Player player = Main.player[Main.myPlayer];
					Vector2 Velocity = Helper.VelocityToPoint(Projectile.Center, Main.npc[NearestNPC].Center, ShootSpeed);
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, Velocity.X, Velocity.Y, ModContent.ProjectileType<CyberLaser>(), ShootDamage, ShootKnockback, Projectile.owner);
				}
		}

		public override void AI()
		{
			Shoot();
			base.AI();
		}
	}
}