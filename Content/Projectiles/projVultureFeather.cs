using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Projectiles
{
	public class projVultureFeather : ModProjectile
	{
		const int TileCollideDustType = DustID.Tin;
		const int TileCollideDustCount = 4;
		const float TileCollideDustSpeedMulti = 0.2f;

		public override void SetDefaults()
		{
			Projectile.width = 14;
			Projectile.height = 34;
			Projectile.timeLeft = 36000;
			Projectile.aiStyle = 0;
			Projectile.penetrate = -1;
			Projectile.hostile = true;
			Projectile.tileCollide = false;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Vulture Feather");
		}

		public override void AI()
		{
			Projectile.rotation = Helper.rotateBetween2Points(Projectile.position, Projectile.position + Projectile.velocity) + MathHelper.ToRadians(270);
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			for (int i = 0; i < TileCollideDustCount; i++)
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, TileCollideDustType, Projectile.velocity.X * TileCollideDustSpeedMulti, Projectile.velocity.Y * TileCollideDustSpeedMulti);
			return true;
		}
	}
}
