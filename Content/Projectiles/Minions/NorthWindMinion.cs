using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using TremorMod;
using TremorMod.Utilities;

namespace TremorMod.Content.Projectiles.Minions
{
	public class NorthWindMinion : ModProjectile
    {

        const int ShootRate = 30; 
        const float ShootDistance = 300f; 
        const float ShootSpeed = 12f; 
        const int ShootDamage = 20; 
        const float ShootKnockback = 2; 
        int ShootType = 118; 
        int TimeToShoot = ShootRate;

		public override void SetDefaults()
		{
			Projectile.netImportant = true;
			Projectile.CloneDefaults(317);
            Projectile.aiStyle = 62;
			Projectile.width = 20;
			Projectile.height = 30;
			Main.projFrames[Projectile.type] = 8;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.minionSlots = 1;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 18000;
			Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
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
            base.AI();
        }

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (Projectile.velocity.X != oldVelocity.X)
			{
				Projectile.tileCollide = false;
			}
			if (Projectile.velocity.Y != oldVelocity.Y)
			{
				Projectile.tileCollide = false;
			}
        return false;
		}
	}
}
