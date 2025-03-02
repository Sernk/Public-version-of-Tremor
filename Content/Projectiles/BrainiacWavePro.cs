using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TremorMod.Content.Projectiles
{
	public class BrainiacWavePro : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(348);

			Projectile.timeLeft = 120;
			AIType = 348;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("BrainiacWavePro");

		}

		public override void AI()
		{
			Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
			if (Main.rand.NextBool())
			{
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 60, Projectile.velocity.X * 0.9f, Projectile.velocity.Y * 0.9f);
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			for (int i = 0; i < 3; i++)
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 60, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f);
			return true;
		}

		public override bool CanHitPlayer(Player target)
		{
			return false;
		}

		public override bool? CanHitNPC(NPC target)
		{
			return (target.friendly) ? false : true;
		}

		public override void OnKill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item8, Projectile.position);
			for (int num158 = 0; num158 < 20; num158++)
			{
				int num159 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 60, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 0, default(Color), 0.5f);
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
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.oldPosition + new Vector2(Projectile.width / 2, Projectile.height / 2), value12, 400, (int)(Projectile.damage * 0.8), Projectile.knockBack * 0.8f, Projectile.owner);
                }
            }
        }
    }
}