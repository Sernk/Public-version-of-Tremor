using System.Linq;
using Terraria;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Projectiles
{
	public class HealingCloudPro : ModProjectile
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
			if (Main.LocalPlayer.HasBuff(ModContent.BuffType<ConcentratedTinctureBuff>()))
			{
				int newLife = 2;
				Main.player[Projectile.owner].statLife += newLife;
				Main.player[Projectile.owner].HealEffect(newLife);
			}
			else
			{
				int newLife = 1;
				Main.player[Projectile.owner].statLife += newLife;
				Main.player[Projectile.owner].HealEffect(newLife);
			}
		}

	}
}