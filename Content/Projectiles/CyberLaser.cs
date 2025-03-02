using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using TremorMod.Content.Buffs;
using TremorMod.Content.Dusts;

namespace TremorMod.Content.Projectiles
{
	public class CyberLaser : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.scale = 1.5f;
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.aiStyle = 1;
			Projectile.light = 0.5f;
			Projectile.damage = 50;
			Projectile.friendly = true;
			Projectile.penetrate = 2;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			AIType = 598;
		}

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.player[Main.myPlayer];
            if (Main.rand.NextBool(2))
			{
				player.AddBuff(ModContent.BuffType<Light>(), 300);
			}
                
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
					int num92 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 2f), Projectile.width, Projectile.height, ModContent.DustType<CyberDust>(), Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.1f, 100, default(Color), 0.4f);
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

	}
}
