using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
    public class ShockwavePro : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(348);
            Projectile.timeLeft = 120;
            Projectile.aiStyle = 348;
        }

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ShockwavePro");
		}*/

        public override void AI()
        {
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
            if (Main.rand.NextBool())
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 60, Projectile.velocity.X * 0.9f, Projectile.velocity.Y * 0.9f);
            }
        }

        public override bool CanHitPlayer(Player target)
        {
            return false;
        }

        public override bool? CanHitNPC(NPC target)
        {
            return (target.friendly) ? false : true;
        }

    }
}