using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class ToxicFlaskCloud : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.penetrate = 8;
            Projectile.aiStyle = 92;
            AIType = 511;
            Projectile.friendly = true;
            Projectile.timeLeft = 600;
        }
    }
}