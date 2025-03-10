﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using System;

namespace TremorMod.Content.Projectiles
{
	public class AngelTearsPro : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.alpha = 255;
			Projectile.penetrate = 4;
			Projectile.timeLeft /= 2;
            Projectile.DamageType = DamageClass.Magic;
        }

		/*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angel Tears");
		}*/

		public override void AI()
		{
			Lighting.AddLight(Projectile.Center, ((255 - Projectile.alpha) * 0.45f) / 255f, ((255 - Projectile.alpha) * 0.2f) / 255f, ((255 - Projectile.alpha) * 0.1f) / 255f);
			for (int num92 = 0; num92 < 5; num92++)
			{
				float num93 = Projectile.velocity.X / 3f * num92;
				float num94 = Projectile.velocity.Y / 3f * num92;
				int num95 = 4;
				int num96 = Dust.NewDust(new Vector2(Projectile.position.X + num95, Projectile.position.Y + num95), Projectile.width - num95 * 2, Projectile.height - num95 * 2, 57, 0f, 0f, 100, default(Color), 1.2f);
				Main.dust[num96].noGravity = true;
				Main.dust[num96].velocity *= 0.1f;
				Main.dust[num96].velocity += Projectile.velocity * 0.1f;
				Dust expr_47FA_cp_0 = Main.dust[num96];
				expr_47FA_cp_0.position.X = expr_47FA_cp_0.position.X - num93;
				Dust expr_4815_cp_0 = Main.dust[num96];
				expr_4815_cp_0.position.Y = expr_4815_cp_0.position.Y - num94;
			}
			if (Main.rand.NextBool(5))
			{
				int num97 = 4;
				int num98 = Dust.NewDust(new Vector2(Projectile.position.X + num97, Projectile.position.Y + num97), Projectile.width - num97 * 2, Projectile.height - num97 * 2, 174, 0f, 0f, 100, default(Color), 0.6f);
				Main.dust[num98].velocity *= 0.25f;
				Main.dust[num98].velocity += Projectile.velocity * 0.5f;
			}
			if (Projectile.ai[1] >= 20f)
			{
				Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
			}
			else
			{
				Projectile.rotation += 0.3f * Projectile.direction;
			}
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}
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
				Projectile.ai[0] += 0.1f;
				if (Projectile.velocity.X != oldVelocity.X)
				{
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y)
				{
					Projectile.velocity.Y = -oldVelocity.Y;
				}
				SoundEngine.PlaySound(SoundID.Item10, Projectile.position); // Use SoundEngine.PlaySound here
			}
			return false;
		}
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position); // Use SoundEngine.PlaySound here
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 57, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
            }
        }
    }
}
