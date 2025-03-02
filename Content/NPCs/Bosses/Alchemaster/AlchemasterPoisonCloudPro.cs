using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.NPCs.Bosses.Alchemaster
{
	public class AlchemasterPoisonCloudPro : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 8;
			Projectile.aiStyle = 92;
			Projectile.hostile = true;
			Projectile.timeLeft = 600;
			Projectile.light = 1.0f;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("PoisonCloudPro");

		}

		public override void OnHitPlayer(Player target, Player.HurtInfo info)
		{
			if (Main.rand.NextBool())
			{
				target.AddBuff(20, 180, false);
			}
		}

	}
}
