using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using System.Linq;

namespace TremorMod.Content.Projectiles
{
    public class VulcanBladeRing : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.light = 0.5f;
            Projectile.timeLeft = 120;
            Projectile.alpha = 50;
        }

        public override void AI()
        {
            NPC target = Main.npc
                .Where(npc => npc.active && !npc.friendly && npc.life > 0)
                .OrderBy(npc => Vector2.Distance(npc.Center, Projectile.Center))
                .FirstOrDefault();

            if (target != null)
            {
                Vector2 direction = target.Center - Projectile.Center;
                direction.Normalize();
                Projectile.velocity = Vector2.Lerp(Projectile.velocity, direction * 8f, 0.1f);
            }
            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
            dust.velocity *= 0.5f;
            dust.scale = 1.2f;
        }

        public override void OnKill(int timeLeft)
        {
            // Create explosion effect with DustID.Torch
            for (int i = 0; i < 20; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
                dust.velocity *= 1.5f;
                dust.scale = 1.5f;
                dust.noGravity = true;
            }

            SoundEngine.PlaySound(SoundID.Item14, Projectile.position); 
        }
    }
}
