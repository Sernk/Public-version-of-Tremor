using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
    public class AdamantiteBolt : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 12;
            Projectile.height = 12;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 1200;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        /*public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Adamantite Bolt");
		}*/

        public override void AI()
        {
            if (Projectile.localAI[0] == 0f)
            {
                SoundEngine.PlaySound(SoundID.Item20, Projectile.position);
            }
            Projectile.localAI[0] += 1f;
            if (Projectile.localAI[0] > 3f)
            {
                int num90 = 1;
                if (Projectile.localAI[0] > 5f)
                {
                    num90 = 2;
                }
                for (int num91 = 0; num91 < num90; num91++)
                {
                    int num92 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 2f), Projectile.width, Projectile.height, 60, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
                    Main.dust[num92].noGravity = true;
                    Dust expr_46AC_cp_0 = Main.dust[num92];
                    expr_46AC_cp_0.velocity.X = expr_46AC_cp_0.velocity.X * 0.3f;
                    Dust expr_46CA_cp_0 = Main.dust[num92];
                    expr_46CA_cp_0.velocity.Y = expr_46CA_cp_0.velocity.Y * 0.3f;
                    Main.dust[num92].noLight = true;
                }
                if (Projectile.wet && !Projectile.lavaWet)
                {
                    Projectile.Kill();
                }
            }
        }

        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 60, Projectile.oldVelocity.X * 0.7f, Projectile.oldVelocity.Y * 0.7f);
            }
            SoundEngine.PlaySound(SoundID.Item109, Projectile.position);
            if (Projectile.owner == Main.myPlayer)
            {
                int num220 = Main.rand.Next(3, 6);
                for (int num221 = 0; num221 < num220; num221++)
                {
                    Vector2 value17 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                    value17.Normalize();
                    value17 *= Main.rand.Next(10, 201) * 0.01f;
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), // Используем правильный источник
                        Projectile.position.X,
                        Projectile.position.Y,
                        value17.X,
                        value17.Y,
                        ModContent.ProjectileType<AdamantiteCloud>(), // Используем тип снаряда как класс
                        Projectile.damage,
                        1f,
                        Projectile.owner,
                        0f,
                        Main.rand.Next(-45, 1));
                }
            }
        }

        /*public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.ai[0] += 0.1f;   //+
            projectile.velocity *= 0.75f;       //==
        }*/
    }
}
