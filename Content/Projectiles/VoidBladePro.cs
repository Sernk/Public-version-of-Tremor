using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class VoidBladePro : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 54;
			Projectile.height = 54;
			Projectile.aiStyle = 27;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = 5;
			Projectile.timeLeft = 600;
			Projectile.light = 0.8f;
			Projectile.extraUpdates = 1;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
			AIType = ProjectileID.Bullet;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("VoidBladePro");

		}

		public override void OnKill(int timeLeft)
		{
			for (int num158 = 0; num158 < 20; num158++)
			{
				int num159 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 226, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, default(Color), 1.5f);
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
                IEntitySource source = Projectile.GetSource_FromThis(); 
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
                    Projectile.NewProjectile(source, position, value12, 400, (int)(Projectile.damage * 0.8), Projectile.knockBack * 2.8f, Projectile.owner, 0f, 0f);
                }
            }
        }

        public override void AI()
        {
            if (Projectile.scale > 1f)
                Projectile.scale = 1f;

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
                Terraria.DataStructures.IEntitySource source = Projectile.GetSource_FromThis();
                Vector2 vector64 = vector63 * -1f;
                vector64.Normalize();
                vector64 *= Main.rand.Next(5, 25) * 0.9f;
                Projectile.NewProjectile(
                    source,
                    Projectile.Center,
                    vector64,
                    ModContent.ProjectileType<VoidRingPro>(), 
                    Projectile.damage / 2,                 
                    Projectile.knockBack,                   
                    Projectile.owner,                        
                    -10f,                                    
                    0f                                       
                );
            }
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
	}
}
