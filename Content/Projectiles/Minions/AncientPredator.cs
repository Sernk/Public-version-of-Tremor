using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles.Minions
{
	public class AncientPredator : ModProjectile
    {
		public override void SetDefaults()
		{
			Projectile.netImportant = true;
			Projectile.CloneDefaults(388);
			AIType = 388;

			Projectile.width = 36;
			Projectile.height = 34;
			Main.projFrames[Projectile.type] = 3;
			Projectile.friendly = true;
			Projectile.minion = true;
			Projectile.minionSlots = 1;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 18000;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
		}

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (Main.rand.Next(10) == 0)
            {
                target.AddBuff(BuffID.Poisoned, 80);
                target.AddBuff(BuffID.CursedInferno, 80); 
                target.AddBuff(BuffID.Venom, 80); 
            }
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
	}
}