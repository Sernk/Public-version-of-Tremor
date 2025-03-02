using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class GoldenCloudPro : ModProjectile
    {
		public override void SetDefaults()
		{
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 8;
			Projectile.aiStyle = 92;
			Projectile.friendly = true;
			Projectile.timeLeft = 600;
			Projectile.light = 1.0f;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (Main.rand.NextBool())
			{
				target.AddBuff(72, 10000, false);
			}
		}
	}
}