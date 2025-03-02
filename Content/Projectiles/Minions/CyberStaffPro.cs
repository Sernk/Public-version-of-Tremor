using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content;
using TremorMod;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Projectiles.Minions
{
    public class CyberStaffPro : ModProjectile
    {
        public override void SetDefaults()
        {
            // Используем параметры стандартного снаряда (например, 533 - это тип снаряда миньона)
            Projectile.CloneDefaults(533);
            Projectile.aiStyle = 533;
            Projectile.width = 50;
            Projectile.height = 50;
            Main.projFrames[Projectile.type] = 1;
            Projectile.friendly = true;
            Projectile.damage = 60; // Настраиваем урон
            Projectile.minion = true; // Указываем, что это миньон
            Projectile.minionSlots = 1; // Количество слотов для миньонов, которые может иметь игрок
            Projectile.penetrate = -1; // Миньон может пробивать до бесконечности (по сути это "неубиваемый" объект)
            Projectile.timeLeft = 18000; // Время жизни миньона
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false; // Миньон не сталкивается с плитками
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true; // Включаем возможность для миньона атаковать цели
        }

        public override void SetStaticDefaults()
        {
           // DisplayName.SetDefault("CyberStaffPro");
            //Main.projPet[Projectile.type] = true; // Пометка как питомца
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            // При столкновении с плитками, сохраняем прежнюю скорость
            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.velocity.X = oldVelocity.X;
            }
            if (Projectile.velocity.Y != oldVelocity.Y)
            {
                Projectile.velocity.Y = oldVelocity.Y;
            }
            return false; // Не уничтожаем миньона при столкновении с плитками
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            // Проверка, активен ли питомец
            if (!player.active || player.dead || !player.HasBuff(ModContent.BuffType<CyberSawBuff>()))
            {
                Projectile.Kill();
                return;
            }

            // Привязка к игроку
            Vector2 targetPosition = player.Center + new Vector2(0f, -48f);
            float speed = 10f;
            Vector2 direction = targetPosition - Projectile.Center;
            float distance = direction.Length();

            if (distance > 2000f) // Если питомец слишком далеко, телепортируем
            {
                Projectile.Center = player.Center;
            }
            else if (distance > 10f)
            {
                direction.Normalize();
                direction *= speed;
                Projectile.velocity = (Projectile.velocity * 20f + direction) / 21f;
            }
            else
            {
                Projectile.velocity *= 0.95f; // Замедление
            }

            Projectile.rotation += 0.1f; // Эффект вращения

            // Атака врагов
            NPC target = FindTarget();
            if (target != null)
            {
                Vector2 attackDirection = target.Center - Projectile.Center;
                attackDirection.Normalize();
                attackDirection *= speed;
                Projectile.velocity = (Projectile.velocity * 10f + attackDirection) / 11f;

                // Проверяем расстояние до цели
                if (Vector2.Distance(Projectile.Center, target.Center) < 50f)
                {
                    int damage = Projectile.damage; // Урон питомца
                    //float knockBack = 2f; // Отбрасывание
                    //bool crit = Main.rand.Next(100) < player.meleeCrit; // Критический удар
                    //target.StrikeNPC(damage, knockBack, Projectile.direction, crit); // Наносим урон
                }
            }
        }
        private NPC FindTarget()
        {
            NPC closestNPC = null;
            float closestDistance = 500f; // Радиус поиска врагов

            foreach (NPC npc in Main.npc)
            {
                if (npc.CanBeChasedBy(this) && Vector2.Distance(Projectile.Center, npc.Center) < closestDistance)
                {
                    closestNPC = npc;
                    closestDistance = Vector2.Distance(Projectile.Center, npc.Center);
                }
            }

            return closestNPC;
        }
    }
}