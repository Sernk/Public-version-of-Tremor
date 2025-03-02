using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Projectiles.Minions
{
    public class CorruptorStaffPro : ModProjectile
    {
        private int attackTimer;

        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 28;
            Projectile.friendly = true;
            Projectile.minion = true;
            Main.projFrames[Projectile.type] = 3;
            Projectile.minionSlots = 1;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 18000;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<CorruptorBuff>());
            }
            if (player.HasBuff(ModContent.BuffType<CorruptorBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            Vector2 targetPosition = player.Center + new Vector2(0f, -48f);
            float speed = 10f;
            Vector2 direction = targetPosition - Projectile.Center;
            float distance = direction.Length();

            NPC target = FindTarget();
            bool targetInRange = target != null && Vector2.Distance(Projectile.Center, target.Center) <= 100 * 16; // 100 блоков

            if (!targetInRange) // Если враг не в пределах 100 блоков
            {
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
            }

            // Логика атаки с интервалом в 1 секунду
            attackTimer++;
            if (attackTimer >= 60) // 60 кадров = 1 секунда
            {
                attackTimer = 0;
                if (target != null)
                {
                    Projectile.velocity = (target.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 5f; // Уменьшение скорости тарана
                }
            }
        }

        private NPC FindTarget()
        {
            NPC closestNPC = null;
            float closestDistance = 500f; // Максимальная дистанция поиска цели

            foreach (NPC npc in Main.npc)
            {
                if (npc.CanBeChasedBy(this))
                {
                    float distance = Vector2.Distance(Projectile.Center, npc.Center);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestNPC = npc;
                    }
                }
            }

            return closestNPC;
        }
    }
}