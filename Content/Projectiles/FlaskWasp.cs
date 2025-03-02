using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
    public class FlaskWasp : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 3; // Устанавливаем количество кадров анимации
        }

        public override void SetDefaults()
        {
            Projectile.netImportant = true;
            Projectile.CloneDefaults(388); // Клонируем поведение снаряда ID 388 (Hornet)
            AIType = 388; // Используем ту же логику AI
            Projectile.width = 40;
            Projectile.height = 36;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 80); // Накладываем эффект "Poisoned" на 80 тиков
        }

        public override void AI()
        {
            Projectile.spriteDirection = Projectile.direction; // Направление спрайта соответствует движению
            Projectile.rotation = 0f; // Снаряд не вращается
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.velocity.X = oldVelocity.X; // Сохраняем старую скорость по X
            }
            if (Projectile.velocity.Y != oldVelocity.Y)
            {
                Projectile.velocity.Y = oldVelocity.Y; // Сохраняем старую скорость по Y
            }
            return false; // Снаряд не уничтожается при столкновении с плитой
        }
    }
}