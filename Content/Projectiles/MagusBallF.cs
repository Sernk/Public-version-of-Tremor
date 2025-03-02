using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Utilities;

namespace TremorMod.Content.Projectiles
{
	public class MagusBallF : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 12;
			Projectile.height = 12;
			Projectile.friendly = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = -1;
			Projectile.extraUpdates = 1;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Rune Ball");

		}

		public override bool PreAI()
		{
			for (int i = 0; i < 10; i++)
			{
				float x = Projectile.Center.X - Projectile.velocity.X / 10f * i;
				float y = Projectile.Center.Y - Projectile.velocity.Y / 10f * i;
				int dust = Dust.NewDust(new Vector2(x, y), 1, 1, 68, 0f, 0f, 0, default(Color), 1f);
				Main.dust[dust].alpha = Projectile.alpha;
				Main.dust[dust].position.X = x;
				Main.dust[dust].position.Y = y;
				Main.dust[dust].velocity *= 0f;
				Main.dust[dust].noGravity = true;
			}
			if (Projectile.localAI[1] == 0f)
			{
				Projectile.localAI[1] = 1f;
			}
			if (Projectile.ai[0] == 0f || Projectile.ai[0] == 2f)
			{
				Projectile.scale += 0.01f;
				Projectile.alpha -= 50;
				if (Projectile.alpha <= 0)
				{
					Projectile.ai[0] = 1f;
					Projectile.alpha = 0;
				}
			}
			else if (Projectile.ai[0] == 1f)
			{
				Projectile.scale -= 0.01f;
				Projectile.alpha += 50;
				if (Projectile.alpha >= 255)
				{
					Projectile.ai[0] = 2f;
					Projectile.alpha = 255;
				}
			}
			return false;
		}

		public override void OnKill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
			Helper.Explode(Projectile.whoAmI, 120, 120, delegate
			{
				for (int i = 0; i < 40; i++)
				{
					int num = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 68, 0f, -2f, 0, default(Color), 2f);
					Main.dust[num].noGravity = true;
					Dust expr_62_cp_0 = Main.dust[num];
					expr_62_cp_0.position.X = expr_62_cp_0.position.X + (Main.rand.Next(-50, 51) / 20 - 1.5f);
					Dust expr_92_cp_0 = Main.dust[num];
					expr_92_cp_0.position.Y = expr_92_cp_0.position.Y + (Main.rand.Next(-50, 51) / 20 - 1.5f);
					if (Main.dust[num].position != Projectile.Center)
					{
						Main.dust[num].velocity = Projectile.DirectionTo(Main.dust[num].position) * 6f;
					}
				}
			});
		}

		public override bool PreDraw(ref Color lightColor)
		{
			Helper.DrawAroundOrigin(Projectile.whoAmI, lightColor);
			return false;
		}
	}
}
