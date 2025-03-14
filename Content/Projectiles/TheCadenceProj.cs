﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class TheCadenceProj : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 4;
			Projectile.height = 4;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.ignoreWater = true;
			Projectile.DamageType = DamageClass.Ranged;
            Projectile.alpha = 255;
			Projectile.penetrate = 1;
			Projectile.extraUpdates = 2;
			Projectile.timeLeft = 600;
		}

		public override void AI()
		{
			if (Projectile.ai[1] == 0f)
			{
				Projectile.ai[1] = 1f;
                SoundEngine.PlaySound(SoundID.Item12, Projectile.position);
            }
            if (Projectile.alpha > 0)
			{
				Projectile.alpha -= 15;
			}
			if (Projectile.alpha < 0)
			{
				Projectile.alpha = 0;
			}
			for (int num121 = 0; num121 < 5; num121++)
			{
				Dust dust4 = Main.dust[Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 172, Projectile.velocity.X, Projectile.velocity.Y, 100, default(Color), 1f)];
				dust4.velocity = Vector2.Zero;
				dust4.position -= Projectile.velocity / 5f * num121;
				dust4.noGravity = true;
				dust4.scale = 0.8f;
				dust4.noLight = true;
			}
		}
	}
}