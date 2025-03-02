using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class PoisonCloudPro : ModProjectile
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
		}

		public override void AI()
		{
			Projectile.rotation = 0f;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (Main.rand.NextBool(2))
			{
				target.AddBuff(20, 180, false);
			}
		}
	}
}