using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;
using TremorMod;

namespace TremorMod.Content.Projectiles
{
	public class MoltenWatcher : ModProjectile
	{
		const int ShootRate = 35; // Частота выстрела (1 секунда = 60ед.)
		const float ShootDistance = 300f; // Дальность стрельбы
		const float ShootSpeed = 25f; // Скорость снаряда
		const int ShootDamage = 180; // Урон снаряда
		const float ShootKnockback = 5; // Отброс снаряда
		int ShootType = 668; // Тип выстрела (Если из ванильной терки)
		int TimeToShoot = ShootRate;

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ZephyrFish);

			Projectile.width = 26;
			Main.projFrames[Projectile.type] = 1;
			Projectile.height = 38;
			Projectile.timeLeft = 5;
			Projectile.aiStyle = 62;
			AIType = ProjectileID.ZephyrFish;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Molten Watcher");

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

                Vector2 velocity = Helper.VelocityToPointM(Projectile.Center, Main.npc[NearestNPC].Center, ShootSpeed);

                Projectile.NewProjectile(
                    Projectile.GetSource_FromThis(), 
                    Projectile.Center,              
                    velocity,                        
                    ShootType,                     
                    ShootDamage,                      
                    ShootKnockback,                   
                    Projectile.owner                
                );
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
				int num90 = 1;
				if (Projectile.localAI[0] > 5f)
				{
					num90 = 2;
				}
				for (int num91 = 0; num91 < num90; num91++)
				{
					int num92 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 2f), Projectile.width, Projectile.height, 6, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
					Main.dust[num92].noGravity = true;
					Dust expr_46AC_cp_0 = Main.dust[num92];
					expr_46AC_cp_0.velocity.X = expr_46AC_cp_0.velocity.X * 0.3f;
					Dust expr_46CA_cp_0 = Main.dust[num92];
					expr_46CA_cp_0.velocity.Y = expr_46CA_cp_0.velocity.Y * 0.3f;
					Main.dust[num92].noLight = true;
				}
				if (Projectile.wet && !Projectile.lavaWet)
				{
					Projectile.Kill();
				}
			}
		}

	}
}
