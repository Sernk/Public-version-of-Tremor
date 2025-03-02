using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class ManaSupportCloudPro : ModProjectile
    {
		public override void SetDefaults()
		{
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.penetrate = 8;
			Projectile.aiStyle = 92;
			Projectile.hostile = true;
			Projectile.timeLeft = 600;
		}

		public override void AI()
		{
			Projectile.rotation = 0f;
		}

		public override void OnHitPlayer(Player target, Player.HurtInfo info)
		{
			int newLife = Main.rand.Next(5) + 5;
			target.statMana += newLife;
			target.ManaEffect(newLife);
		}

	}
}