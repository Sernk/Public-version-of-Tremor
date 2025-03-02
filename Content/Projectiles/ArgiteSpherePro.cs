using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class ArgiteSpherePro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 36;
			Projectile.height = 36;
			Projectile.aiStyle = 14;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 5;
			Projectile.timeLeft = 600;
			Projectile.light = 0.6f;
		}

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Argite Sphere");
		}*/

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.velocity.Y = -oldVelocity.Y;
			}
			else
			{
				Projectile.ai[0] += 0.1f;
				if (Projectile.velocity.X != oldVelocity.X)
				{
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y)
				{
					Projectile.velocity.Y = -oldVelocity.Y;
				}
				Projectile.velocity *= 0.75f;
			}
			return false;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 44, Projectile.velocity.X * 0.6f, Projectile.velocity.Y * 0.6f);
            }
        }
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item20, Projectile.position);
            for (int num158 = 0; num158 < 20; num158++)
            {
                int num159 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 44, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, default(Color), 0.5f);
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

                    Projectile.NewProjectile(
                        Projectile.GetSource_FromThis(), // Источник
                        Projectile.oldPosition.X + Projectile.width / 2,
                        Projectile.oldPosition.Y + Projectile.height / 2,
                        value12.X,
                        value12.Y,
                        400,
                        (int)(Projectile.damage * 0.8),
                        Projectile.knockBack * 0.8f,
                        Projectile.owner);
                }
            }
        }


    }
}
