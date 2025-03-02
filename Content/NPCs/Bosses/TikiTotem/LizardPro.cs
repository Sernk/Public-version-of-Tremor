using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace TremorMod.Content.NPCs.Bosses.TikiTotem
{
	public class LizardPro : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 26;
			Projectile.height = 26;
			Projectile.aiStyle = 2;
			Projectile.timeLeft = 1200;
			Projectile.penetrate = 5;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("LizardPro");

		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
			}
			else
			{
				if (Projectile.velocity.X != oldVelocity.X)
				{
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y)
				{
					Projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			return false;
		}

		public override void OnKill(int timeLeft)
		{
            IEntitySource source = Projectile.GetSource_FromThis();
            NPC.NewNPC(source, (int)Projectile.Center.X, (int)Projectile.Center.Y, ModContent.NPCType<Lizard>());
        }
	}
}
