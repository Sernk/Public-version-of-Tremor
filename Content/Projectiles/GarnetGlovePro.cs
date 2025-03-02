using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class GarnetGlovePro : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.CloneDefaults(303);
			Projectile.width = 28;
			Projectile.height = 38;
			AIType = 303;
			Projectile.timeLeft = 400;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("GarnetGlovePro");

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
