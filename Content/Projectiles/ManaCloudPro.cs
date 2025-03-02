using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class ManaCloudPro : ModProjectile
    {
		public override void SetDefaults()
		{
			Projectile.width = 40;
			Projectile.height = 40;
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
			int newLife = Main.rand.Next(hit.Damage / 2) + 3;
			Main.player[Projectile.owner].statMana += newLife;
			Main.player[Projectile.owner].ManaEffect(newLife);
		}
	}
}