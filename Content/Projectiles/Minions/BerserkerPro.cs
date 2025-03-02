using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles.Minions
{
    public class BerserkerPro : ModProjectile
    {
        public static class MyHelper
        {
            public static Vector2 PolarPos(Vector2 origin, float distance, float angle)
            {
                return origin + new Vector2((float)Math.Cos(angle) * distance, (float)Math.Sin(angle) * distance);
            }

            public static float RotateBetween2Points(Vector2 point1, Vector2 point2)
            {
                return (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            }
        }

        const float RotationSpeed = 1.0f; // Еще быстрее
        const float Distanse = 48;
        const int HitInterval = 10;

        float Rotation;
        int hitCooldown;

        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 34;
            Projectile.timeLeft = 6;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            hitCooldown = 0;
        }

        public override void AI()
        {
            Rotation += RotationSpeed;
            Projectile.Center = MyHelper.PolarPos(Main.player[(int)Projectile.ai[0]].Center, Distanse, MathHelper.ToRadians(Rotation));
            Projectile.rotation = MyHelper.RotateBetween2Points(Main.player[(int)Projectile.ai[0]].Center, Projectile.Center) - MathHelper.ToRadians(90);

            if (hitCooldown > 0)
                hitCooldown--;

            Player player = Main.player[(int)Projectile.ai[0]];
            if (!player.active || player.dead)
            {
                Projectile.Kill(); // Убиваем снаряд, если игрок мертв или неактивен
                return;
            }
        }

        public override bool? CanHitNPC(NPC target)
        {
            if (hitCooldown <= 0 && !target.friendly)
            {
                hitCooldown = HitInterval;
                return true;
            }
            return false;
        }

        /*public override void OnHitNPC(NPC target, NPC.HitInfo hit)
        {
            // Теперь damageModifier находится внутри структуры hit.
            // Используйте hit.Damage для получения урона до модификаций
            // и hit.Damage *= 1.5f; для изменения урона.

            // Пример изменения урона в зависимости от крита:
            if (hit.Crit)
            {
                hit.Damage = (int)(hit.Damage * 1.5f); // Умножаем урон на 1.5 при крите.
            }

            // Можно добавить и другие эффекты, используя hit:
            // hit.Knockback - сила отбрасывания
            // hit.HitDirection - направление удара
            // и другие.

            // Важно! Больше не нужно вызывать base.OnHitNPC(target, ref hit, ref damageModifier);
        }*/
    }
}