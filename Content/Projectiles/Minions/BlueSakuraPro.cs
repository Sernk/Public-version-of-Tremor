using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content;
using TremorMod;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Projectiles.Minions
{
	public class BlueSakuraPro : ModProjectile
    {
        private int attackCooldown = 0;

        public override void SetDefaults()
		{
			 Projectile.netImportant = true;
			 Projectile.CloneDefaults(388);
			 Projectile.width = 18;
			 Projectile.height = 18;
			 Main.projFrames[Projectile.type] = 4;
			 Projectile.friendly = true;
			 Projectile.minion = true;
			 Projectile.minionSlots = 1;
			 Projectile.penetrate = -1;
			 Projectile.timeLeft = 18000;
			 Projectile.ignoreWater = true;
             Projectile.tileCollide = false;
             ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
		}

		public override void SetStaticDefaults()
		{
			//DisplayName.SetDefault("Blue Sakura");			       
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.velocity.X = oldVelocity.X;
            }
            if (Projectile.velocity.Y != oldVelocity.Y)
            {
                Projectile.velocity.Y = oldVelocity.Y;
            }
            return false;
        }

        public override void AI()
        {
            this.Projectile.rotation = this.Projectile.velocity.ToRotation();

            if (Main.rand.NextBool(8))
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 41, Projectile.velocity.X * 0.9f, Projectile.velocity.Y * 0.9f);
            }

            Player player = Main.player[Projectile.owner];

            // Проверка, активен ли питомец
            if (!player.active || player.dead || !player.HasBuff(ModContent.BuffType<BlueSakuraBuff>()))
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

            NPC target = FindTarget();
            if (target != null)
            {
                Vector2 attackDirection = target.Center - Projectile.Center;
                attackDirection.Normalize();
                attackDirection *= speed * 2; // Увеличиваем скорость для рывка
                Projectile.velocity = attackDirection;

                // Проверяем расстояние до цели
                if (Vector2.Distance(Projectile.Center, target.Center) < 50f && attackCooldown <= 0)
                {
                    int damage = Projectile.damage; // Урон питомца
                    NPC.HitInfo hitInfo = new NPC.HitInfo
                    {
                        Damage = damage,
                        Knockback = 0f,
                        HitDirection = 0,
                        Crit = false
                    };
                    // Наносим урон и проходим сквозь врага
                    target.StrikeNPC(hitInfo);
                    attackCooldown = 30; // Устанавливаем таймер на 30 тиков (полсекунды)
                }
            }

            if (attackCooldown > 0)
            {
                attackCooldown--; // Уменьшаем таймер
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
