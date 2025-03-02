using System;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using TremorMod.Utilities;

namespace TremorMod.Content.Projectiles.Minions
{
    public class NanoDronPro : ModProjectile
    {
        const int ShootRate = 45; // Частота выстрела (1 секунда = 60ед.)
        const float ShootDistance = 300f; // Дальность стрельбы
        const float ShootSpeed = 25f; // Скорость снаряда
        const int ShootDamage = 75; // Урон снаряда
        const float ShootKnockback = 5; // Отброс снаряда
        int ShootType = ProjectileID.Bullet; // Тип выстрела
        int TimeToShoot = ShootRate;

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.ZephyrFish);
            Projectile.width = 68;
            Main.projFrames[Projectile.type] = 1;
            Projectile.height = 96;
            Projectile.timeLeft = 5;
            Projectile.aiStyle = 62;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
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
                    if (!npc.active || npc.friendly || npc.lifeMax <= 5)
                        continue;
                    if (npc.Distance(Projectile.Center) < NearestNPCDist && Collision.CanHitLine(Projectile.Center, 1, 1, npc.Center, 1, 1))
                    {
                        NearestNPCDist = npc.Distance(Projectile.Center);
                        NearestNPC = npc.whoAmI;
                    }
                }
                if (NearestNPC == -1)
                    return;

                Vector2 Velocity = Helper.VelocityToPoint(Projectile.Center, Main.npc[NearestNPC].Center, ShootSpeed);

                // Используем правильный источник для Projectiles
                Projectile.NewProjectile(
                    Projectile.GetSource_FromThis(),
                    Projectile.Center,
                    Velocity,
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

            // Проигрывание звука
            if (Projectile.localAI[0] == 0f)
            {
                SoundEngine.PlaySound(SoundID.Item20, Projectile.position);
            }

            Projectile.localAI[0] += 1f;
            if (Projectile.localAI[0] > 3f)
            {
                if (Projectile.wet && !Projectile.lavaWet)
                {
                    Projectile.Kill();
                }
            }
        }
    }
}
