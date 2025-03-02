using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Dusts;
using TremorMod.Content.Items.BossLoot.TheDarkEmperor;

namespace TremorMod.Content.Projectiles
{
	public class NastyJavelinPro : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 9;
			Projectile.height = 33;
			Projectile.friendly = true;
			Projectile.aiStyle = 1;
			Projectile.timeLeft = 1200;
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Nasty Javelin Pro");

		}

		public override void AI()
		{
			int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<NightmareFlame>(), Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 1.9f);
			Main.dust[dust].noGravity = true;
		}

        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<NightmareFlame>(), Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 2f, 100, default(Color), 2f);
            }
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);

            if (Main.rand.NextBool(3))
            {
                IEntitySource source = Projectile.GetSource_DropAsItem();
                Item.NewItem(source, Projectile.position, Projectile.Size, ModContent.ItemType<NastyJavelin>());
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			Projectile.ai[0] += 0.1f;
			Projectile.velocity *= 0.75f;
		}
	}
}
