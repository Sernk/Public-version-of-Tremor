using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace TremorMod.Content.Projectiles
{
	public class DarkBubblePro : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.aiStyle = 1;
			Projectile.hostile = true;
			Projectile.timeLeft = 150;
			Projectile.light = 0.8f;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Dark Bubble");

		}

		public override void AI()
		{
			if (Projectile.frameCounter < 5)
				Projectile.frame = 0;
			else if (Projectile.frameCounter >= 5 && Projectile.frameCounter < 10)
				Projectile.frame = 1;
			else if (Projectile.frameCounter >= 10 && Projectile.frameCounter < 15)
				Projectile.frame = 2;
			else if (Projectile.frameCounter >= 15 && Projectile.frameCounter < 20)
				Projectile.frame = 3;
			else
				Projectile.frameCounter = 0;
			Projectile.frameCounter++;
		}

		public override void OnKill(int timeLeft)
		{
			for (int num158 = 0; num158 < 20; num158++)
			{
				int num159 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 54, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, default(Color), 0.3f);
				if (Main.rand.NextBool(3))
				{
					Main.dust[num159].fadeIn = 1.1f + Main.rand.Next(-10, 11) * 0.01f;
					Main.dust[num159].scale = 0.35f + Main.rand.Next(-10, 11) * 0.01f;
					Main.dust[num159].type++;
				}
				else
				{
					Main.dust[num159].scale = 1.2f + Main.rand.Next(-10, 11) * 0.01f;
				}
				Main.dust[num159].noGravity = true;
				Main.dust[num159].velocity *= 2.5f;
				Main.dust[num159].velocity -= Projectile.oldVelocity / 10f;
			}
            if (Main.myPlayer == Projectile.owner)
            {
                int num160 = Main.rand.Next(0, 0); 
                for (int num161 = 0; num161 < num160; num161++)
                {
                    Vector2 value12 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                    while (value12.X == 0f && value12.Y == 0f)
                    {
                        value12 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                    }
                    value12.Normalize();
                    value12 *= Main.rand.Next(70, 101) * 0.1f;
                    IEntitySource source = Projectile.GetSource_FromThis();
                    Projectile.NewProjectile(source, Projectile.oldPosition.X + Projectile.width / 2, Projectile.oldPosition.Y + Projectile.height / 2, value12.X, value12.Y, 400, (int)(Projectile.damage * 0.8), Projectile.knockBack * 2.8f, Projectile.owner, 0f, 0f);
                }
            }

        }
    }
}
