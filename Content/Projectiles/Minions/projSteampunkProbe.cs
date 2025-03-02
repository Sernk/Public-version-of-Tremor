using System;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Projectiles.Minions
{
    public class projSteampunkProbe : ModProjectile
    {
        const int ShootType = ProjectileID.HeatRay;
        const float ShootRange = 600.0f;
        const float ShootKN = 1.0f;
        const int ShootRate = 30;
        const int ShootCount = 2;
        const float ShootSpeed = 20f;
        const int spread = 45;
        const float spreadMult = 0.045f;

        const int STATIC_DAMAGE = 30;

        int TimeToShoot = ShootRate;

        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.timeLeft = 6;
            Projectile.tileCollide = false;
            Projectile.aiStyle = 54;
        }

        /*public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steampunk Probe");
        }*/

        public override void AI()
        {
            Projectile.ai[0] = -1;
            Projectile.ai[1] = 0;
            if (--TimeToShoot <= 0)
            {
                TimeToShoot = ShootRate;
                int Target = GetTarget();
                if (Target != -1) Shoot(Target, GetDamage());
            }
        }

        int GetTarget()
        {
            int Target = -1;
            for (int k = 0; k < Main.npc.Length; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].Distance(Projectile.Center) <= ShootRange && Collision.CanHitLine(Projectile.Center, 4, 4, Main.npc[k].Center, 4, 4))
                {
                    Target = k;
                    break;
                }
            }
            return Target;
        }

        int GetDamage()
        {
            return STATIC_DAMAGE;
        }

        void Shoot(int Target, int Damage)
        {
            Vector2 velocity = Helper.VelocityToPoint(Projectile.Center, Main.npc[Target].Center, ShootSpeed);
            for (int l = 0; l < ShootCount; l++)
            {
                velocity.X = velocity.X + Main.rand.Next(-spread, spread + 1) * spreadMult;
                velocity.Y = velocity.Y + Main.rand.Next(-spread, spread + 1) * spreadMult;

                // Используем GetSource_FromThis() для источника снаряда
                IEntitySource source = Projectile.GetSource_FromThis();

                // Создаем снаряд с правильными аргументами
                int i = Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, velocity.X, velocity.Y, ShootType, Damage, ShootKN, Projectile.owner);
            }
        }
    }
}
