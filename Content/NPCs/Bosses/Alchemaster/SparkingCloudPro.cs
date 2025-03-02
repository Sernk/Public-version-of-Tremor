using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.NPCs.Bosses.Alchemaster
{
	public class SparkingCloudPro : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 8;
			Projectile.aiStyle = 92;
			Projectile.hostile = true;
			Projectile.timeLeft = 600;
			Projectile.light = 1.0f;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("SparkingCloudPro");

		}

		public override void OnHitPlayer(Player target, Player.HurtInfo info)
		{
			if (Main.rand.NextBool(2))
			{
				target.AddBuff(24, 180, false);
			}
		}

	}
}
