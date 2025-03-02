using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
    public class FlamesofDespairPro : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(405);

            AIType = 405;
            Projectile.friendly = true;
            Projectile.timeLeft = 150;
            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.light = 0.9f;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("FlamesofDespairPro");

        }

        public override void AI()
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 6, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
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
                int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 2f);
                Main.dust[dustIndex].velocity *= 3f;
                if (Main.rand.NextBool(2))
                {
                    Main.dust[dustIndex].scale = 0.5f;
                    Main.dust[dustIndex].fadeIn = 1f + Main.rand.Next(10) * 0.1f;
                }
            }

            for (int i = 0; i < 70; i++)
            {
                int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default(Color), 3f);
                Main.dust[dustIndex].noGravity = true;
                Main.dust[dustIndex].velocity *= 5f;
                dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default(Color), 5f);
                Main.dust[dustIndex].velocity *= 2f;
            }

            IEntitySource source = Projectile.GetSource_Death();
            for (int i = 0; i < 3; i++)
            {
                float scaleFactor = i switch
                {
                    1 => 0.66f,
                    2 => 1f,
                    _ => 0.33f
                };

                Vector2 gorePos = Projectile.position + new Vector2(Projectile.width / 2 - 24f, Projectile.height / 2 - 24f);

                int goreIndex = Gore.NewGore(source, gorePos, Vector2.One, Main.rand.Next(61, 64), 1.5f);
                Main.gore[goreIndex].velocity *= scaleFactor;
                Main.gore[goreIndex].velocity += new Vector2(1f, 1f);

                goreIndex = Gore.NewGore(source, gorePos, Vector2.One, Main.rand.Next(61, 64), 0.5f);
                Main.gore[goreIndex].velocity *= scaleFactor;
                Main.gore[goreIndex].velocity += new Vector2(-1f, 1f);

                goreIndex = Gore.NewGore(source, gorePos, Vector2.One, Main.rand.Next(61, 64), 1.5f);
                Main.gore[goreIndex].velocity *= scaleFactor;
                Main.gore[goreIndex].velocity += new Vector2(1f, -1f);

                goreIndex = Gore.NewGore(source, gorePos, Vector2.One, Main.rand.Next(61, 64), 0.5f);
                Main.gore[goreIndex].velocity *= scaleFactor;
                Main.gore[goreIndex].velocity += new Vector2(-1f, -1f);
            }

            Projectile.position += new Vector2(Projectile.width / 2, Projectile.height / 2);
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.position -= new Vector2(Projectile.width / 2, Projectile.height / 2);
        }

    }
}