using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class VoidRingPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(405);

			AIType = 405;
			Projectile.friendly = true;
			Projectile.timeLeft = 150;
			Projectile.light = 0.8f;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("VoidRingPro");

		}

		public override bool PreDraw(ref Color lightColor)
		{
            SpriteBatch spriteBatch = Main.spriteBatch;
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
			for (int k = 0; k < Projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
				Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
				spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}

		public override void OnKill(int timeLeft)
		{
			for (int num158 = 0; num158 < 20; num158++)
			{
				int num159 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 226, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, default(Color), 0.3f);
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
                Terraria.DataStructures.IEntitySource source = Projectile.GetSource_FromThis();
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
                    Vector2 position = Projectile.oldPosition + new Vector2(Projectile.width / 2, Projectile.height / 2);
                    Projectile.NewProjectile(
                        source,
                        position,
                        value12, 
                        400, 
                        (int)(Projectile.damage * 0.8), 
                        Projectile.knockBack * 2.8f, 
                        Projectile.owner, 
                        0f, 
                        0f  
                    );
                }
            }

        }
    }
}
