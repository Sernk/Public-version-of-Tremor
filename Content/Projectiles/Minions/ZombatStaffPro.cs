using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content;
using TremorMod;
using TremorMod.Content.Buffs;

namespace TremorMod.Content.Projectiles.Minions
{
	public class ZombatStaffPro : ModProjectile
    {
		public override void SetDefaults()
		{
			Projectile.netImportant = true;
			Projectile.CloneDefaults(388);
			AIType = 388;

			Projectile.width = 36;
			Projectile.height = 28;
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

		public override void SetStaticDefaults()
		{
		  // DisplayName.SetDefault("Zombat Staff");
       
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if(Main.rand.NextBool(4))
			{
				target.AddBuff(20, 240, false);
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
