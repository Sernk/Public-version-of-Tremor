using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Projectiles
{
	public class EndlessPainPro : ModProjectile
	{

		const int ShootRate = 20; 
		const float ShootDistance = 300f; 
		const float ShootSpeed = 12f; 
		const int ShootDamage = 210; 
		const float ShootKnockback = 2; 
		int ShootType = 496; 
		int TimeToShoot = ShootRate;
		//string ShootTypeMod;

		public override void SetDefaults()
		{

			Projectile.friendly = true;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 0;
			Main.projFrames[Projectile.type] = 4;
			Projectile.timeLeft = 1200;
			Projectile.penetrate = -1;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Endless Pain");

		}

		public override void OnKill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 27, Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f);
			}
			SoundEngine.PlaySound(SoundID.Item109, Projectile.position);
		}

		void Shoot()
		{
			if (--TimeToShoot <= 0)
			{
				TimeToShoot = ShootRate;
				//if (ShootType == -1)
				//	ShootType = Mod.Find<ModProjectile>(ShootTypeMod).Type;

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
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 27, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 136, default(Color), 0.9f);
			Main.dust[dust].noGravity = true;

			if (Projectile.frameCounter < 5)
				Projectile.frame = 0;
			else if (Projectile.frameCounter >= 5 && Projectile.frameCounter < 10)
				Projectile.frame = 1;
			else if (Projectile.frameCounter >= 10 && Projectile.frameCounter < 15)
				Projectile.frame = 2;
			else if (Projectile.frameCounter >= 15 && Projectile.frameCounter < 20)
				Projectile.frame = 3;
			else
				Projectile.frameCounter = 0;
			Projectile.frameCounter++;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

	}
}
