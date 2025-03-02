using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class DeadFlowerPro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 4;
			Projectile.height = 4;

			AIType = 295;
			Projectile.friendly = true;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Dead Flower");

		}

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
					int num92 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 2f), Projectile.width, Projectile.height, 27, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
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
            SoundEngine.PlaySound(SoundID.Item110, Projectile.position);

            for (int num158 = 0; num158 < 20; num158++)
            {
                int num159 = Dust.NewDust(
                    new Vector2(Projectile.position.X, Projectile.position.Y),
                    Projectile.width,
                    Projectile.height,
                    27,
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
