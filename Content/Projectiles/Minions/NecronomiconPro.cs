using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles.Minions
{
	public class NecronomiconPro : ModProjectile
    {
		public override void SetDefaults()
		{
			Projectile.netImportant = true;
			Projectile.CloneDefaults(317);
			AIType = 317;

			Projectile.width = 20;
			Projectile.height = 30;
			Main.projFrames[Projectile.type] = 8;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.minionSlots = 1;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 18000;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (Projectile.velocity.X != oldVelocity.X)
			{
				Projectile.tileCollide = false;
			}
			if (Projectile.velocity.Y != oldVelocity.Y)
			{
				Projectile.tileCollide = false;
			}
			return false;
		}
	}
}