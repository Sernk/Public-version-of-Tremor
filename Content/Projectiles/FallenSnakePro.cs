using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class FallenSnakePro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ValkyrieYoyo);
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.timeLeft = 220;
			Projectile.friendly = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("");

		}

		public override bool PreAI()
		{
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 13, Projectile.velocity.X * 0.9f, Projectile.velocity.Y * 0.9f);
			}

			return true;
		}

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (Main.rand.Next(10) == 0)
            {
                target.AddBuff(BuffID.Midas, 280); 
            }
        }
	}
}
