using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Items.EvilCornItems;

namespace TremorMod.Content.Projectiles
{
    public class CornJavelinPro : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 4;
            Projectile.height = 4;
            Projectile.friendly = true;
            Projectile.aiStyle = 1;
            Projectile.timeLeft = 1200;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Corn Javelin Pro");
        }

        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 1, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 2f, 100, default(Color), 2f);
            }
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);

            if (Main.rand.NextBool(5))
            {
                Item.NewItem(Projectile.GetSource_Death(), Projectile.position, Projectile.Size, ModContent.ItemType<CornJavelin>());
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.ai[0] += 0.1f;
            Projectile.velocity *= 0.75f;
        }
    }
}