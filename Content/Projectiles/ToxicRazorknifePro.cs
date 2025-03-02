using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	//ported from my tAPI mod because I don't want to make artwork
	public class ToxicRazorknifePro : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 14;
			Projectile.height = 42;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = -2;
			Projectile.tileCollide = true;
			Projectile.DamageType = DamageClass.Melee;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Toxic Razorknife Pro");

		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (Main.rand.NextBool(6))
			{
				target.AddBuff(BuffID.Poisoned, 280, false);
			}
		}
	}
}
