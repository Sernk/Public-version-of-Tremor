using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Projectiles
{
	public class BoomSkull : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.width = 52;
			Projectile.height = 52;
			Projectile.friendly = true;
			Projectile.tileCollide = false;
			Projectile.ignoreWater = true;
			Projectile.penetrate = -1;
			Projectile.alpha = 255;
			Projectile.timeLeft = 420;
			Main.projFrames[Projectile.type] = 15;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

        
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
            Projectile.position.X = Projectile.position.X + Projectile.width / 2;
            Projectile.position.Y = Projectile.position.Y + Projectile.height / 2;
            Projectile.width = 80;
            Projectile.height = 80;
            Projectile.position.X = Projectile.position.X - Projectile.width / 2;
            Projectile.position.Y = Projectile.position.Y - Projectile.height / 2;

            for (int i = 0; i < 40; i++)
            {
                int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
                Main.dust[dustIndex].velocity *= 3f;
                if (Main.rand.NextBool(2))
                {
                    Main.dust[dustIndex].scale = 0.5f;
                    Main.dust[dustIndex].fadeIn = 1f + Main.rand.Next(10) * 0.1f;
                }
            }

            for (int i = 0; i < 70; i++)
            {
                int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 5f;
            }

            if (Projectile.owner == Main.myPlayer)
            {
                int numProjectiles = Main.rand.Next(2, 3);
                for (int i = 0; i < numProjectiles; i++)
                {
                    Vector2 velocity = Main.rand.NextVector2Circular(1f, 1f) * Main.rand.NextFloat(0.1f, 2f);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, velocity, ModContent.ProjectileType<BoomCloudPro>(), Projectile.damage, 1f, Projectile.owner);
                }
            }
        }

        public override void AI()
		{

			//int num613 = 10;
			//int num614 = 15;
			//float num615 = 1f;
			//int num616 = 150;
			//int num617 = 42;
			if (Projectile.velocity.X != 0f)
			{
				Projectile.direction = (Projectile.spriteDirection = -Math.Sign(Projectile.velocity.X));
			}
			Projectile.frameCounter++;
			if (Projectile.frameCounter > 2)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
			}
			if (Projectile.frame >= 10)
			{ Projectile.velocity.X = 0f; Projectile.velocity.Y = 0f; }
			if (Projectile.frame >= 15)
			{ Projectile.Kill(); }
			if (!Collision.SolidCollision(Projectile.position, Projectile.width, Projectile.height))
			{
				Projectile.alpha -= 30;
				if (Projectile.alpha < 60)
				{
					Projectile.alpha = 60;
				}
			}
			else
			{
				Projectile.alpha += 30;
				if (Projectile.alpha > 150)
				{
					Projectile.alpha = 150;
				}
			}

		}
	}
}