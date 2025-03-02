using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TremorMod.Utilities;

namespace TremorMod.Content.Projectiles.Minions
{
	public class OmnikronBeast : ModProjectile 
	{
		const int ShootRate = 15; // Частота выстрела (1 секунда = 60ед.)
		const float ShootDistance = 300f; // Дальность стрельбы
		const float ShootSpeed = 25f; // Скорость снаряда
		const int ShootDamage = 250; // Урон снаряда
		const float ShootKnockback = 5; // Отброс снаряда
		int ShootType = 503; // Тип выстрела (Если из ванильной терки)
		int TimeToShoot = ShootRate;

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ZephyrFish);

			Projectile.width = 68;
			Main.projFrames[Projectile.type] = 1;
			Projectile.height = 96;
			Projectile.timeLeft = 5;
			Projectile.aiStyle = 62;
			AIType = ProjectileID.ZephyrFish;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("OmnikronBeast");

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
                foreach (NPC enemy in Main.npc) 
                {
                    if (!enemy.active)
                        continue;
                    if (enemy.friendly || enemy.lifeMax <= 5)
                        continue;
                    if (NearestNPCDist == -1 || enemy.Distance(Projectile.Center) < NearestNPCDist && Collision.CanHitLine(Projectile.Center, 16, 16, enemy.Center, 16, 16))
                    {
                        NearestNPCDist = enemy.Distance(Projectile.Center);
                        NearestNPC = enemy.whoAmI;
                    }
                }
                if (NearestNPC == -1)
                    return;

                NPC targetNPC = Main.npc[NearestNPC];

                IEntitySource source = this.Projectile.GetSource_FromThis();

                Vector2 velocity = Helper.VelocityToPoint(Projectile.Center, targetNPC.Center, ShootSpeed);

                Projectile.NewProjectile(source, Projectile.Center, velocity, ShootType, ShootDamage, ShootKnockback, Projectile.owner);
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
					int num92 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 2f), Projectile.width, Projectile.height, 60, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
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
