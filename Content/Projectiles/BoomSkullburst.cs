using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using TremorMod.Content.Projectiles;

namespace TremorMod.Content.Projectiles
{
	public class BoomSkullburst : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.timeLeft = 420;
            Projectile.width = 52;
            Projectile.height = 52;
            Projectile.friendly = true;
            Main.projFrames[Projectile.type] = 12;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
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

            for (int i = 0; i < 3; i++)
            {
                float scaleFactor = 0.33f * (i + 1);
                Vector2 gorePosition = Projectile.Center - new Vector2(24f);
                int goreIndex = Gore.NewGore(Projectile.GetSource_FromThis(), gorePosition, Vector2.Zero, Main.rand.Next(61, 64), 1f);
                Main.gore[goreIndex].velocity *= scaleFactor;
                Main.gore[goreIndex].velocity += new Vector2(1f, 1f);
            }

            if (Projectile.owner == Main.myPlayer)
            {
                int numProjectiles = Main.rand.Next(2, 3);
                for (int i = 0; i < numProjectiles; i++)
                {
                    Vector2 velocity = Main.rand.NextVector2CircularEdge(1f, 1f) * Main.rand.NextFloat(0.1f, 2f);
                    Projectile.NewProjectile(
                        Projectile.GetSource_FromThis(),
                        Projectile.Center,
                        velocity,
                        ModContent.ProjectileType<BoomCloudPro>(),
                        Projectile.damage,
                        1f,
                        Projectile.owner
                    );
                }
            }
        }

        public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void AI()
		{
			Projectile.frameCounter++;
			if (Projectile.frameCounter > 2)
			{
				Projectile.frame++;
				Projectile.frameCounter = 0;
			}
			if (Projectile.frame >= 7)
			{ Projectile.velocity.X = 0f; Projectile.velocity.Y = 0f; }
			if (Projectile.frame >= 12)
			{ Projectile.Kill(); }
		}

	}
}