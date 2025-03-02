using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace TremorMod.Content.Projectiles
{
	public class SuperBigCannonPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(261);

			AIType = 261;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("SuperBigCannonPro");

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
			for (int num628 = 0; num628 < 40; num628++)
			{
				int num629 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num629].velocity *= 3f;
				if (Main.rand.NextBool(2))
				{
					Main.dust[num629].scale = 0.5f;
					Main.dust[num629].fadeIn = 1f + Main.rand.Next(10) * 0.1f;
				}
			}
			for (int num630 = 0; num630 < 70; num630++)
			{
				int num631 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
				Main.dust[num631].noGravity = true;
				Main.dust[num631].velocity *= 5f;
				num631 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num631].velocity *= 2f;
			}
            for (int num632 = 0; num632 < 3; num632++)
            {
                float scaleFactor10 = 0.33f;
                if (num632 == 1) scaleFactor10 = 0.66f;
                if (num632 == 2) scaleFactor10 = 1f;

                IEntitySource source = Projectile.GetSource_FromThis(); 

                Vector2 gorePosition = new Vector2(Projectile.position.X + Projectile.width / 2 - 24f,
                                                   Projectile.position.Y + Projectile.height / 2 - 24f);

                int num633 = Gore.NewGore(source, gorePosition, Vector2.Zero, Main.rand.Next(61, 64), 1f);
                Main.gore[num633].velocity *= scaleFactor10;
                Main.gore[num633].velocity.X += 1f;
                Main.gore[num633].velocity.Y += 1f;

                num633 = Gore.NewGore(source, gorePosition, Vector2.Zero, Main.rand.Next(61, 64), 1f);
                Main.gore[num633].velocity *= scaleFactor10;
                Main.gore[num633].velocity.X -= 1f;
                Main.gore[num633].velocity.Y += 1f;

                num633 = Gore.NewGore(source, gorePosition, Vector2.Zero, Main.rand.Next(61, 64), 1f);
                Main.gore[num633].velocity *= scaleFactor10;
                Main.gore[num633].velocity.X += 1f;
                Main.gore[num633].velocity.Y -= 1f;

                num633 = Gore.NewGore(source, gorePosition, Vector2.Zero, Main.rand.Next(61, 64), 1f);
                Main.gore[num633].velocity *= scaleFactor10;
                Main.gore[num633].velocity.X -= 1f;
                Main.gore[num633].velocity.Y -= 1f;
            }

            Projectile.position.X = Projectile.position.X + Projectile.width / 2;
			Projectile.position.Y = Projectile.position.Y + Projectile.height / 2;
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.position.X = Projectile.position.X - Projectile.width / 2;
			Projectile.position.Y = Projectile.position.Y - Projectile.height / 2;
		}

	}
}
