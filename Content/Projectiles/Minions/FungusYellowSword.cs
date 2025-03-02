using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles.Minions
{
    public class FungusYellowSword : ModProjectile
    {
        const float RotationSpeed = 0.08f;
        const float Distance = 100;

        private int hitCooldown = 10; // Кулдаун между ударами в кадрах
        private int hitTimer = 0; // Таймер для отслеживания кулдауна

        float Rotation;

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 44;
            Projectile.timeLeft = 6;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        }

        /*public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fungus Yellow Sword");
        }*/

        public override void AI()
        {
            Rotation += RotationSpeed;

            // Замена Helper.PolarPos
            Projectile.Center = CalculatePolarPosition(Main.LocalPlayer.Center, Distance, Rotation);

            // Замена Helper.rotateBetween2Points
            Projectile.rotation = CalculateRotation(Main.LocalPlayer.Center, Projectile.Center) - MathHelper.ToRadians(90);

            hitTimer++;
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (hitTimer < hitCooldown)
            {
                // Если кулдаун еще не прошел, урон не наносится
                modifiers.DisableCrit();
                modifiers.FinalDamage *= 0; // Отменяем урон
                return;
            }

            // Если кулдаун прошел, сбрасываем таймер
            hitTimer = 0;

            // Ваши эффекты удара
            if (Main.rand.Next(10) == 0)
            {
                target.AddBuff(BuffID.Midas, 180); // Эффект "Мидас"
            }
        }

        public override bool? CanHitNPC(NPC target)
        {
            return !target.friendly;
        }

        // Метод для замены PolarPos
        private Vector2 CalculatePolarPosition(Vector2 center, float radius, float angle)
        {
            return center + new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * radius;
        }

        // Метод для замены rotateBetween2Points
        private float CalculateRotation(Vector2 point1, Vector2 point2)
        {
            return (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
        }
    }
}
