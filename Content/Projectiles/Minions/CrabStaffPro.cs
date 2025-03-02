using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles.Minions
{
	public class CrabStaffPro : ModProjectile
    {
		public override void SetDefaults()
		{
			Projectile.width = 32;
			Projectile.height = 24;
			Projectile.netImportant = true;
			Projectile.friendly = true;
			Projectile.minionSlots = 1;
			Projectile.aiStyle = 26;
			Projectile.timeLeft = 18000;
			Main.projFrames[Projectile.type] = 1;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			Projectile.penetrate = -1;
			Projectile.timeLeft *= 5;
			Projectile.minion = true;
			AIType = 266;
			Projectile.tileCollide = false;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Crab Staff");
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
		{
			fallThrough = false;
			return true;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (Projectile.penetrate == 0)
			{
				Projectile.Kill();
			}
			return false;
		}

		private bool oldSlime;
		public override bool PreAI()
		{
			oldSlime = Main.player[Projectile.owner].slime;
			Main.player[Projectile.owner].slime = false;
			return base.PreAI();
		}

		public override void PostAI()
		{
			Main.player[Projectile.owner].slime = oldSlime;
		}
	}
}
