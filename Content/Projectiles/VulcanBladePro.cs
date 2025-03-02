using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
    public class VulcanBladePro : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 54;
            Projectile.height = 54;
            Projectile.aiStyle = 0; // Отключаем стандартный AI
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 5;
            Projectile.timeLeft = 180; // Живёт 3 секунды
            Projectile.light = 0.8f;
            Projectile.extraUpdates = 1;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void AI()
        {
            this.Projectile.rotation = this.Projectile.velocity.ToRotation();

            // Постепенно исчезает перед смертью
            if (Projectile.timeLeft < 60)
            {
                Projectile.alpha += 4;
            }

            // Каждые 3 кадра выпускает VulcanBladeRing
            if (Projectile.ai[0] % 3 == 0 && Main.myPlayer == Projectile.owner)
            {
                Vector2 velocity = new Vector2(Main.rand.Next(-3, 4), Main.rand.Next(-3, 4));
                Projectile.NewProjectile(
                    Projectile.GetSource_FromThis(),
                    Projectile.Center,
                    velocity,
                    ModContent.ProjectileType<VulcanBladeRing>(),
                    Projectile.damage / 2,
                    Projectile.knockBack,
                    Main.myPlayer
                );
            }

            Projectile.ai[0]++;
        }

        public override void OnKill(int timeLeft)
        {
            // Создаём взрыв
            Projectile.NewProjectile(
                Projectile.GetSource_FromThis(),
                Projectile.Center,
                Vector2.Zero,
                ModContent.ProjectileType<BoomCloudProV>(),
                Projectile.damage,
                Projectile.knockBack,
                Main.myPlayer
            );

            // Частицы огня при взрыве
            for (int i = 0; i < 20; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
                dust.velocity *= 2;
                dust.scale = 1.5f;
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
