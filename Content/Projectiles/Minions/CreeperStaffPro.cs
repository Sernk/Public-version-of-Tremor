using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Projectiles.Minions
{
	public class CreeperStaffPro : ModProjectile
    {
        private int attackTimer;

        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 28;
            Projectile.friendly = true;
            Projectile.minion = true;
            Main.projFrames[Projectile.type] = 1;
            Projectile.minionSlots = 1;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 18000;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

        public override void AI() // Код тот же, что и в CorruptorStaffPro 
        {
            Player player = Main.player[Projectile.owner];
            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<CreeperBuff>());
            }
            if (player.HasBuff(ModContent.BuffType<CreeperBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            Vector2 targetPosition = player.Center + new Vector2(0f, -48f);
            float speed = 10f;
            Vector2 direction = targetPosition - Projectile.Center;
            float distance = direction.Length();

            NPC target = FindTarget();
            bool targetInRange = target != null && Vector2.Distance(Projectile.Center, target.Center) <= 100 * 16; 

            if (!targetInRange) 
            {
                if (distance > 2000f) 
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
                    Projectile.velocity *= 0.95f; 
                }
            }

            attackTimer++;
            if (attackTimer >= 60) 
            {
                attackTimer = 0;
                if (target != null)
                {
                    Projectile.velocity = (target.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * 5f; 
                }
            }
        }

        private NPC FindTarget()
        {
            NPC closestNPC = null;
            float closestDistance = 500f; 

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