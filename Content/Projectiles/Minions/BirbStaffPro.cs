using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles.Minions
{
	public class BirbStaffPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.netImportant = true;
			Projectile.CloneDefaults(388);

			Projectile.width = 28;
			Projectile.height = 18;
			Main.projFrames[Projectile.type] = 4;
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
				Projectile.velocity.X = oldVelocity.X;
			}
			if (Projectile.velocity.Y != oldVelocity.Y)
			{
				Projectile.velocity.Y = oldVelocity.Y;
			}
			return false;
		}

		public override void AI()
		{
            if (Projectile.velocity.X != 0)
            {
                Projectile.frameCounter++;
                if (Projectile.frameCounter >= 8) // Скорость смены кадров
                {
                    Projectile.frameCounter = 0;
                    Projectile.frame = (Projectile.frame + 1) % Main.projFrames[Projectile.type];
                }
            }
            else
            {
                Projectile.frame = 0; // Если стоит, показываем первый кадр
            }
        }
	}
}
