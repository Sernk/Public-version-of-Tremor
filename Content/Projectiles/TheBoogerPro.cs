using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class TheBoogerPro : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 34;
			Projectile.height = 34;
			Projectile.friendly = true;
			Projectile.penetrate = -1; // Penetrates NPCs infinitely.
			Projectile.DamageType = DamageClass.Melee; // Deals melee dmg.

			Projectile.aiStyle = 15; // Set the aiStyle to that of a flail.
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("The Booger Pro");

		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

		public override void AI()
		{
			Vector2 vector63 = Main.player[Projectile.owner].Center - Projectile.Center;
			if (Main.player[Projectile.owner].dead)
			{
				Projectile.Kill();
				return;
			}
			if (Projectile.ai[0] == 0f && vector63.Length() > 400f)
			{
				Projectile.ai[0] = 1f;
			}
			if (Projectile.ai[0] == 1f || Projectile.ai[0] == 2f)
			{
				float num810 = vector63.Length();
				if (num810 > 1500f)
				{
					Projectile.Kill();
					return;
				}
				if (num810 > 600f)
				{
					Projectile.ai[0] = 2f;
				}
				float num811 = 20f;
				if (Projectile.ai[0] == 2f)
				{
					num811 = 40f;
				}
				if (vector63.Length() < num811)
				{
					Projectile.Kill();
					return;
				}
			}
			Projectile.ai[1] += 1f;
			if (Projectile.ai[1] > 5f)
			{
				Projectile.alpha = 0;
			}
			if ((int)Projectile.ai[1] % 3 == 0 && Projectile.owner == Main.myPlayer)
			{
				Vector2 vector64 = vector63 * -1f;
				vector64.Normalize();
				vector64 *= Main.rand.Next(5, 25) * 0.9f;

				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, vector64.X, vector64.Y, ModContent.ProjectileType<TheBoogerBallPro>(), Projectile.damage / 4, Projectile.knockBack, Projectile.owner, -10f, 0f);
			}
		}

		public override bool PreDraw(ref Color lightColor)
		{
            Texture2D texture = ModContent.Request<Texture2D>("TremorMod/Content/Projectiles/TheBooger_Chain").Value;

			Vector2 position = Projectile.Center;
			Vector2 mountedCenter = Main.player[Projectile.owner].MountedCenter;
			Rectangle? sourceRectangle = new Rectangle?();
			Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
			float num1 = texture.Height;
			Vector2 vector2_4 = mountedCenter - position;
			float rotation = (float)Math.Atan2(vector2_4.Y, vector2_4.X) - 1.57f;
			bool flag = true;
			if (float.IsNaN(position.X) && float.IsNaN(position.Y))
				flag = false;
			if (float.IsNaN(vector2_4.X) && float.IsNaN(vector2_4.Y))
				flag = false;
			while (flag)
			{
				if (vector2_4.Length() < num1 + 1.0)
				{
					flag = false;
				}
				else
				{
					Vector2 vector2_1 = vector2_4;
					vector2_1.Normalize();
					position += vector2_1 * num1;
					vector2_4 = mountedCenter - position;
					Color color2 = Lighting.GetColor((int)position.X / 16, (int)(position.Y / 16.0));
					color2 = Projectile.GetAlpha(color2);
					Main.spriteBatch.Draw(texture, position - Main.screenPosition, sourceRectangle, color2, rotation, origin, 1f, SpriteEffects.None, 0.0f);
				}
			}

			return true;
		}
	}
}
