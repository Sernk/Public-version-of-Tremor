using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	//ported from my tAPI mod because I don't want to make artwork
	public class DangerBladePro : ModProjectile
	{
		public override void SetDefaults()
		{

			Projectile.width = 14;
			Projectile.height = 42;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.penetrate = -2;
			Projectile.tileCollide = true;
			Projectile.light = 0.8f;
			Projectile.DamageType = DamageClass.Melee;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Danger Blade Pro");

		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item64, Projectile.position);

            // Создание эффекта пыли
            for (int num158 = 0; num158 < 20; num158++)
            {
                int num159 = Dust.NewDust(
                    new Vector2(Projectile.position.X, Projectile.position.Y),
                    Projectile.width,
                    Projectile.height,
                    60,
                    Projectile.velocity.X * 0.1f,
                    Projectile.velocity.Y * 0.1f,
                    0,
                    default(Color),
                    0.5f
                );

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

                    IEntitySource source = Projectile.GetSource_FromThis(); 
                    Vector2 spawnPosition = Projectile.oldPosition + new Vector2(Projectile.width / 2, Projectile.height / 2);

                    Projectile.NewProjectile(
                        source,
                        spawnPosition,
                        value12,
                        400,
                        (int)(Projectile.damage * 0.8f),
                        Projectile.knockBack * 0.8f,
                        Projectile.owner,
                        0f,
                        0f
                    );
                }
            }
        }
    }
}
